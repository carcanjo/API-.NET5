using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        private readonly DataContext _context;

        public PatientRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Patient> GetByCpf(string cpf)
        {
            var user = await _context.patients
                .Where(x  => x.Cpf.ToLower() == cpf.ToLower())
                .AsNoTracking()
                .ToListAsync();

            return user.FirstOrDefault();
        }

        public async Task<Patient> GetByEmail(string email)
        {
              var user = await _context.patients
                .Where(x => x.Email.ToLower() == email.ToLower())
                .AsNoTracking()
                .ToListAsync();
            return user.FirstOrDefault();
        }
    }
}
