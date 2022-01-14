using Data.Context;

using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        
        /* Repositories */

        private IEquipmentRepository _equipmentRepository;
        public IEquipmentRepository EquipmentRepository
        {
            get => _equipmentRepository ??= new EquipmentRepository(_context);
        }

        private IModelRepository _modelRepository;
        public IModelRepository ModelRepository
        {
            get => _modelRepository ??= new ModelRepository(_context);
        }

        private IStateRepository _stateRepository;
        public IStateRepository StateRepository
        {
            get => _stateRepository ??= new StateRepository(_context);
        }

        private IPositionHistoryRepository _positionHistoryRepository;

        public IPositionHistoryRepository PositionHistoryRepository
        {
            get => _positionHistoryRepository ??= new PositionHistoryRepository(_context);
        }

        private IStateHistoryRepository _stateHistoryRepository;

        public IStateHistoryRepository StateHistoryRepository
        {
            get => _stateHistoryRepository ??= new StateHistoryRepository(_context);
        }

        private IModelStateHourlyEarningsRepository _modelStateHourlyEarningsRepository;

        public IModelStateHourlyEarningsRepository ModelStateHourlyEarningsRepository
        {
            get => _modelStateHourlyEarningsRepository ??= new ModelStateHourlyEarningsRepository(_context);
        }

        public bool Commit()
        {
            var successfulChanges = _context.SaveChanges();
            return successfulChanges > 0;
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}