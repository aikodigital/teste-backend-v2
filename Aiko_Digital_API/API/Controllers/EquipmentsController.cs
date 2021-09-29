using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Equipments.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EquipmentsController : BaseController
    {
        [HttpGet]
        public async Task<IReadOnlyList<Equipment>> ListEquipments()
        {
            return await Mediator.Send(new ListAllEquipmentsQuery());
        }
    }
}