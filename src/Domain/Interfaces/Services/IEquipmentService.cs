using System;

using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IEquipmentService
    {
        bool Create(Equipment equipment);
        bool Update(Equipment equipment);
        bool Remove(Equipment equipment);
    }
}