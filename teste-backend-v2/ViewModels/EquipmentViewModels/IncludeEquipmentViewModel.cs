using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using teste_backend_v2.Controllers;
using teste_backend_v2.Models;
//using System.Linq;
//using teste_backend_v2.Controllers;

namespace teste_backend_v2.ViewModels.EquipmentViewModels
{
    public class IncludeEquipmentViewModel
    {
        [Required(ErrorMessage = "Required field!")]
        public string Name { get; set; }

        [Display(Name = "Equipment model")]
        [Required(ErrorMessage = "Required field!")]
        public Guid EquipmentModelId { get; set; }

        public IEnumerable<SelectListItem> EquipmentModels { get; set; }

        #region Methods

        public void SetValuesDropdown(AppDbContext db)
        {
            EquipmentModels = db.EquipmentModels.OrderBy(e => e.Name).Select(model => new SelectListItem(model.Name, model.Id.ToString()));
        }

        public JsonResult ValidateData(EquipmentsController controller, AppDbContext db)
        {

            var equipaments = db.Equipment;

            if (equipaments.Any(x => x.Name.ToLower() == Name.ToLower() && x.EquipmentModelId == EquipmentModelId))
            {
                controller.ModelState.AddModelError(nameof(Name), "This item already exists in database!");
            }

            return null;
        }

        #endregion Methods
    }
}
