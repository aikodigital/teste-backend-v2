using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App.ViewModels;

using AutoMapper;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages
{
    public class EquipmentsModel : PageModel
    {
        public List<EquipmentViewModel> Equipments { get; set; }
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EquipmentsModel(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task OnGetAsync()
        {
            var equipments = await _unitOfWork.EquipmentRepository.GetAll();
            Equipments = _mapper.Map<List<EquipmentViewModel>>(equipments);
        }
    }
}