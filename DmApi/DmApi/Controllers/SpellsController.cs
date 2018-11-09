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
    [Authorize(Policy = "Admin")]
    public class SpellsController : Controller
    {
        private readonly ISpellService _spells;

        public SpellsController(ISpellService pService)
        {
            _spells = pService;
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
