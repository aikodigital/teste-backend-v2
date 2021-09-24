using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class EquipamentoRepository : GenericRepositoryAsync<Equipment>, IEquipamentoRepository
    {
        private readonly DbSet<Equipment> equipment;

        public EquipamentoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            equipment = dbContext.Set<Equipment>();
        }
    }
}
