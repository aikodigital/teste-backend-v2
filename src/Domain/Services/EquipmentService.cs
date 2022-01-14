using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EquipmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public bool Create(Equipment equipment)
        {
            _unitOfWork.EquipmentRepository.Add(equipment);
            return _unitOfWork.Commit();
        }

        public bool Update(Equipment equipment)
        {
            _unitOfWork.EquipmentRepository.Update(equipment);
            return _unitOfWork.Commit();
        }

        public bool Remove(Equipment equipment)
        {
            _unitOfWork.EquipmentRepository.Remove(equipment);
            return _unitOfWork.Commit();
        }
    }
}