using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DmApi.Helpers;
using DmApi.Models;

namespace DmApi.Services
{
    public class SpellService : ISpellService
    {
        private readonly DataContext _context;

        public SpellService(DataContext pContext)
        {
            _context = pContext;
        }

        public async Task<Spell> CreateAsync(Spell pSpell)
        {
            try
            {
                await _context.Spells.AddAsync(pSpell);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }

            return pSpell;
        }

        public async Task DeleteAsync(int pID)
        {
            var spell = await _context.Spells.FindAsync(pID);
            if (spell == null)
                return;

            _context.Spells.Remove(spell);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Spell> GetAll()
        {
            return _context.Spells;
        }

        public async Task<Spell> GetAsync(int pID)
        {
            return await _context.Spells.FindAsync(pID);
        }

        public async Task<Spell> UpdateAsync(Spell pSpell)
        {
            var spell = await _context.Spells.FindAsync(pSpell.Id);
            if (spell == null)
                return null;

            _context.Spells.Remove(spell);
            await _context.AddAsync(pSpell);
            await _context.SaveChangesAsync();
            return spell;
        }
    }
}
