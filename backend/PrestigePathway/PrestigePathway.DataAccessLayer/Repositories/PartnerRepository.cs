using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;

namespace PrestigePathway.DataAccessLayer.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly SocialServicesDbContext _context;

        public PartnerRepository(SocialServicesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Partner>> GetAllPartnersAsync()
        {
            return await _context.Partners.ToListAsync();
        }

        public async Task<Partner> GetPartnerByIdAsync(int id)
        {
            return await _context.Partners.FindAsync(id);
        }

        public async Task AddPartnerAsync(Partner partner)
        {
            _context.Partners.Add(partner);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePartnerAsync(Partner partner)
        {
            _context.Entry(partner).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePartnerAsync(int id)
        {
            var partner = await _context.Partners.FindAsync(id);
            if (partner != null)
            {
                _context.Partners.Remove(partner);
                await _context.SaveChangesAsync();
            }
        }
    }
}