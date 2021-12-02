using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using teste_backend_v2.Controllers;
using teste_backend_v2.Models;

namespace teste_backend_v2.ViewModels.EquipmentModelViewModels
{
    public class IncludeEquipmentModelViewModel
    {

        [Required(ErrorMessage = "Required field!")]    
        public string Name { get; set; }


        #region Methods

        public JsonResult ValidateData(EquipmentsController controller, AppDbContext db)
        {

            var equipamentos = db.EquipmentModels;

            if (equipamentos.Any(x => x.Name.ToLower() == Name.ToLower()))
            {
                controller.ModelState.AddModelError(nameof(Name), "This item already exists in database!");
            }

            return null;
        }

        #endregion

    }
}
