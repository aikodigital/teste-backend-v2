using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using teste_backend_v2.Controllers;
using teste_backend_v2.Models;

namespace teste_backend_v2.ViewModels.EquipmentModelViewModels
{
    public class UpdateEquipmentModelViewModel
    {
        [Required(ErrorMessage = "Required field!")]
        public string Name { get; set; }

        public Guid Id { get; set; }

        #region Methods

        public JsonResult LoadingData(EquipmentsController controller, AppDbContext db)
        {           
            var equipmentModel = db.EquipmentModels.FirstOrDefault(x => x.Id == Id);
            if (equipmentModel == null)
            {
                controller.ModelState.AddModelError(nameof(Name), "Item not found!");
            }

            Name = equipmentModel.Name;
            return null;
        }

        public JsonResult ValidateData(EquipmentsController controller, AppDbContext db)
       {            
        
            var equipamentos = db.EquipmentModels;
        
            if (equipamentos.Any(x => x.Name.ToLower() == Name.ToLower() && x.Id != Id))
            {
                controller.ModelState.AddModelError(nameof(Name), "This item already exists in database!");
            }
        
            return null;
        }

        #endregion Methods

    }
}
