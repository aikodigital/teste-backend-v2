using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using teste_backend_v2.Controllers;
using teste_backend_v2.Models;

namespace teste_backend_v2.ViewModels.EquipmentStateViewModels
{
    public class UpdateEquipmentStateViewModel
    {
        [Required(ErrorMessage = "Required field!")]
        public string Name { get; set; }

        public string Color { get; set; }

        public Guid Id { get; set; }

        #region Methods

        public JsonResult LoadingData(EquipmentsController controller, AppDbContext db)
        {
            var equipmentState = db.EquipmentStates.FirstOrDefault(x => x.Id == Id);
            if (equipmentState == null)
            {
                controller.ModelState.AddModelError(nameof(Name), "Item not found!");
            }

            Name = equipmentState.Name;
            Color = equipmentState.Color;
            return null;
        }

        public JsonResult ValidateData(EquipmentsController controller, AppDbContext db)
        {

            var equipamentsState = db.EquipmentStates;

            if (equipamentsState.Any(x => x.Name.ToLower() == Name.ToLower() && x.Id != Id))
            {
                controller.ModelState.AddModelError(nameof(Name), "This item already exists in database!");
            }

            return null;
        }

        #endregion Methods
    }
}
