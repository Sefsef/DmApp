using System;
using System.Collections.Generic;
using System.Linq;
using DnDApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace DnDApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpellsController : Controller
    {
        private readonly SpellContext _spells;

        public SpellsController(SpellContext pContext)
        {
            _spells = pContext;

            if (!_spells.Spells.Any())
            {
                var spell = new Spell
                {
                    ID = 192,
                    Name = "Fireball",
                    Level = 3,
                    School = "evocation",
                    Description = "A bright streak flashes from your pointing finger to a point you choose within range and then blossoms with a low roar into an explosion of flame. " +
                "Each creature in a 20-foot-radius sphere centered on that point must make a Dexterity saving throw. " +
                "A target takes 8d6 fire damage on a failed save, or half as much damage on a successful one." + Environment.NewLine + Environment.NewLine +
                "The fire spreads around corners. It ignites flammable objects in the area that aren't being worn or carried." + Environment.NewLine + Environment.NewLine +
                "At Higher Levels. When you cast this spell using a spell slot of 4th level or higher, the damage increases by 1d6 for each slot level above 3rd."
                };

                _spells.Spells.Add(spell);
                _spells.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Spell>> GetAll()
        {
            return _spells.Spells.ToList();
        }

        [HttpGet("byID/{id}", Name = "GetSpell")]
        public ActionResult<Spell> GetByID(int id)
        {
            Spell item = _spells.Spells.SingleOrDefault(spell => spell.ID == id);
            return item ?? (ActionResult<Spell>)NotFound();
        }

        [HttpGet("byName/{name}", Name = "GetSpellByName")]
        public ActionResult<List<Spell>> GetByName(string name)
        {
            var item = _spells.Spells.Where(pSpell => pSpell.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            return item ?? (ActionResult<List<Spell>>)NotFound();
        }

        [HttpPost]
        public IActionResult Create(Spell item)
        {
            _spells.Spells.Add(item);
            _spells.SaveChanges();

            return CreatedAtRoute("GetSpell", new { id = item.Name }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Spell item)
        {
            Spell spell = _spells.Spells.Find(id);
            if (spell == null)
                return NotFound();

            spell.Name = item.Name;
            spell.Description = item.Description;
            spell.School = item.School;
            spell.Level = item.Level;

            _spells.Spells.Update(spell);
            _spells.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Spell spell = _spells.Spells.Find(id);
            if (spell == null)
                return NotFound();

            _spells.Spells.Remove(spell);
            _spells.SaveChanges();
            return NoContent();
        }
    }
}
