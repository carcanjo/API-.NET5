using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class VaccineRepository : BaseRepository<Vaccine>, IVaccineRepository
    {
        private readonly DataContext _context;

        public VaccineRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Vaccine> GetByIntervalOfDoses(int id)
        {
            var vaccine = await _context.vaccines
                 .Where(x => x.id == id)
                 .AsNoTracking()
                 .ToListAsync();

            return vaccine.FirstOrDefault();
        }

        public async Task<Vaccine> GetByManufacture(int id)
        {
            var vaccine = await _context.vaccines
                .Where(x => x.id == id)
                .AsNoTracking()
                .ToListAsync();

            return vaccine.FirstOrDefault();
        }

        public async Task<Vaccine> GetByManufactureAplied(int id)
        {
            throw new NotImplementedException();
        }

    }
}
