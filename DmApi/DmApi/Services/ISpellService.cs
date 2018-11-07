using System.Collections.Generic;
using System.Threading.Tasks;
using DmApi.Models;

namespace DmApi.Services
{
    public interface ISpellService
    {
        IEnumerable<Spell> GetAll();
        Task<Spell> GetAsync(int pID);
        Task<Spell> CreateAsync(Spell pSpell);
        Task<Spell> UpdateAsync(Spell pSpell);
        Task DeleteAsync(int pID);
    }
}
