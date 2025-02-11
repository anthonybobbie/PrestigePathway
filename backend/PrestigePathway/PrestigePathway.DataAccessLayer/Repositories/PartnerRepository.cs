using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PrestigePathway.DataAccessLayer.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly SocialServicesDbContext _context;

        public async Task AddAsync(Partner partner)
        {
            _context.Partners.Add(partner);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var partner = await _context.Partners.FindAsync(id);
            if (partner == null)
            {
                _context.Partners.Remove(partner);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Partner>> GetAllAsync()
        {
            return await _context.Partners.ToListAsync();
        }

        public async Task<Partner> GetByIdAsync(int id)
        {
            return await _context.Partners.FindAsync(id);
        }

        //public async Task<IEnumerable<Partner>> GetPartnersByLocationAsync(string location)
        //{
        //    return await _context.Partners
        //        .Where(p => p.Location ==  location)
        //        .ToListAsync();
        //}

        public async Task UpdateAsync(Partner partner)
        {
            _context.Entry(partner).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}