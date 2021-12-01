using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using teste_backend_v2.Controllers;
using teste_backend_v2.Models;

namespace teste_backend_v2.ViewModels.EquipmentStateViewModels
{
    public class IncludeEquipmentStateViewModel
    {
        [Required(ErrorMessage = "Required field!")]
        public string Name { get; set; }

        public string Color { get; set; }

        #region Methods

        public JsonResult ValidateData(EquipmentsController controller, AppDbContext db)
        {

            var equipamentsState = db.EquipmentStates;

            if (equipamentsState.Any(x => x.Name.ToLower() == Name.ToLower()))
            {
                controller.ModelState.AddModelError(nameof(Name), "This item already exists in database!");
            }

            return null;
        }

        #endregion Methods
    }
}
