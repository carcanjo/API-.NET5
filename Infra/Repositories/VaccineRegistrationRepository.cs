using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class VaccineRegistrationRepository : BaseRepository<VaccineRegistration>, IVaccineRegistrationRepository
    {
        private readonly DataContext _context;
        public VaccineRegistrationRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<VaccineRegistration> GetControlDose()
        {
            // receber o id vacina para saber quantas doses tenho em estoque
            throw new Exception();


        }
    }
}
