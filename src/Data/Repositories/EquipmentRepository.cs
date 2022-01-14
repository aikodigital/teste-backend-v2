using System;
using System.Linq;
using System.Threading.Tasks;

using Data.Context;
using Domain.Interfaces.Repositories;
using Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(ApplicationDbContext db) : base(db) { }
        
    }
}