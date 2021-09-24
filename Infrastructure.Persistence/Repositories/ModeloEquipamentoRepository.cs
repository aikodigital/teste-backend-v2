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
    public class ModeloEquipamentoRepository : GenericRepositoryAsync<Equipment_Model>
        , IModeloEquipamentoRepository
    {
        private readonly DbSet<Equipment_Model> equipment;

        public ModeloEquipamentoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            equipment = dbContext.Set<Equipment_Model>();
        }
    }
}
