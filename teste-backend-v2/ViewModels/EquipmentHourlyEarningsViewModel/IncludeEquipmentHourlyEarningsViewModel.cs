using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using teste_backend_v2.Controllers;
using teste_backend_v2.Models;

namespace teste_backend_v2.ViewModels.EquipmentHourlyEarningsViewModel
{
    public class IncludeEquipmentHourlyEarningsViewModel
    {
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public float Value { get; set; }

        public float LastValue { get; set; }

        [Display(Name = "Value (R$)")]
        [Required(ErrorMessage = "Required field!")]
        public string ValueMask { get; set; }

        [Display(Name = "Equipment model")]
        [Required(ErrorMessage = "Required field!")]
        public Guid EquipmentModelId { get; set; }

        [Display(Name = "Equipment state")]
        [Required(ErrorMessage = "Required field!")]
        public Guid EquipmentStateId { get; set; }

        public IEnumerable<SelectListItem> EquipmentModels { get; set; }

        public IEnumerable<SelectListItem> EquipmentStates { get; set; }

        #region Methods

        public void SetValuesDropdown(AppDbContext db)
        {
            EquipmentModels = db.EquipmentModels.OrderBy(e => e.Name).Select(model => new SelectListItem(model.Name, model.Id.ToString()));
            EquipmentStates = db.EquipmentStates.OrderBy(e => e.Name).Select(model => new SelectListItem(model.Name, model.Id.ToString()));

        }

        public JsonResult ValidateData(EquipmentsController controller, AppDbContext db)
        {

            // Como essa tabela não possui um Id próprio, não será possível fazer essa validação de item duplicado, pois poderá quebrar a funcionaldade

            //var earnings = db.EquipmentModelStateHourlyEarnings;
            //if (earnings.Any(x => x.EquipmentModelId == EquipmentModelId && x.EquipmentStateId == EquipmentStateId))
            //{
            //    controller.ModelState.AddModelError(nameof(EquipmentModelId), "This item already exists in database!");
            //    controller.ModelState.AddModelError(nameof(EquipmentStateId), "This item already exists in database!");
            //}

            var earning = ValueMask.Replace(".",string.Empty).Replace(",",string.Empty);
            Value = float.Parse(earning);
            return null;
        }

        #endregion Methods
    }
}
