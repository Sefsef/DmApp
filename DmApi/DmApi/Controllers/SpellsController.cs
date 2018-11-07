using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DmApi.Models;
using DmApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DmApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SpellsController : Controller
    {
        private readonly ISpellService _spells;

        public SpellsController(ISpellService pService)
        {
            _spells = pService;

            //if (!_spells.Spells.Any())
            //{
            //    var spell = new Spell
            //    {
            //        ID = 192,
            //        Name = "Fireball",
            //        Level = 3,
            //        School = "evocation",
            //        Description = "A bright streak flashes from your pointing finger to a point you choose within range and then blossoms with a low roar into an explosion of flame. " +
            //    "Each creature in a 20-foot-radius sphere centered on that point must make a Dexterity saving throw. " +
            //    "A target takes 8d6 fire damage on a failed save, or half as much damage on a successful one." + Environment.NewLine + Environment.NewLine +
            //    "The fire spreads around corners. It ignites flammable objects in the area that aren't being worn or carried." + Environment.NewLine + Environment.NewLine +
            //    "At Higher Levels. When you cast this spell using a spell slot of 4th level or higher, the damage increases by 1d6 for each slot level above 3rd."
            //    };

            //    _spells.Spells.Add(spell);
            //    _spells.SaveChanges();
            //}
        }

        [HttpGet]
        public ActionResult<IEnumerable<Spell>> GetAll()
        {
            return Ok(_spells.GetAll());
        }

        [HttpGet("{id}", Name = "GetSpell")]
        public async Task<ActionResult<Spell>> GetByID(int pID)
        {
            var spell = await _spells.GetAsync(pID);
            if (spell == null)
                return NotFound();

            return Ok(spell);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Spell pSpell)
        {
            var spell = await _spells.CreateAsync(pSpell);
            if (spell == null)
                return BadRequest();

            return CreatedAtRoute("GetSpell", new { id = spell.Id }, spell);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int pId, Spell pSpell)
        {
            var spell = await _spells.UpdateAsync(pSpell);

            if (spell == null)
                return NotFound();

            else return Ok(spell);

            //Spell spell = _spells.Spells.Find(pId);
            //if (spell == null)
            //    return NotFound();

            //spell.Name = pSpell.Name;
            //spell.Description = pSpell.Description;
            //spell.School = pSpell.School;
            //spell.Level = pSpell.Level;

            //_spells.Spells.Update(spell);
            //_spells.SaveChanges();
            //return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int pId)
        {
            try
            {
                await _spells.DeleteAsync(pId);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }

            //Spell spell = _spells.Spells.Find(pId);
            //if (spell == null)
            //    return NotFound();

            //_spells.Spells.Remove(spell);
            //_spells.SaveChanges();
            //return NoContent();
        }
    }
}
