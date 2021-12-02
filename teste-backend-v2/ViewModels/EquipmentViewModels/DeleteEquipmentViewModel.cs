using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using teste_backend_v2.Controllers;
using teste_backend_v2.Models;

namespace teste_backend_v2.ViewModels.EquipmentViewModels
{
    public class DeleteEquipmentViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Display(Name = "Equipment model")]
        public string EquipmentModelId { get; set; }

        public string Name { get; set; }

        #region Methods

        public JsonResult LoadingData(EquipmentsController controller, AppDbContext db)
        {
            var equipment = db.Equipment.FirstOrDefault(x => x.Id == Id);
            if (equipment == null)
            {
                controller.ModelState.AddModelError(nameof(Name), "Item not found!");
            }

            var equipmentModel = db.EquipmentModels.FirstOrDefault(em => em.Id == equipment.EquipmentModelId);
            if (equipmentModel == null)
            {
                controller.ModelState.AddModelError(nameof(Name), "Item not found!");
            }

            Name = equipment.Name;
            EquipmentModelId = equipmentModel.Name;
            return null;
        }

        #endregion Methods

    }
}
