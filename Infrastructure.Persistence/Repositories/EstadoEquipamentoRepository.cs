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
    public class EstadoEquipamentoRepository : GenericRepositoryAsync<Equipment_State>,
        IEstadoEquipamentoRepository
    {
        private readonly DbSet<Equipment_State> equipment_state;

        public EstadoEquipamentoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            equipment_state = dbContext.Set<Equipment_State>();
        }
    }
}
