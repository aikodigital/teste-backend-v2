using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste_backend_v2.Models;
using teste_backend_v2.ViewModels.EquipmentHourlyEarningsViewModel;
using teste_backend_v2.ViewModels.EquipmentModelViewModels;
using teste_backend_v2.ViewModels.EquipmentPositionViewModels;
using teste_backend_v2.ViewModels.EquipmentStateHistoryViewModels;
using teste_backend_v2.ViewModels.EquipmentStateViewModels;
using teste_backend_v2.ViewModels.EquipmentViewModels;

namespace teste_backend_v2.Controllers
{
    
    public class EquipmentsController : Controller
    {
        protected readonly AppDbContext db;
        private readonly ILogger logger;
        public EquipmentsController(ILogger<EquipmentsController> logger)
        {
            this.logger = logger;
            db = new AppDbContext();            
        }

        #region Equipment Model

        #region List Equipment Model

        [Route("/[controller]/Model/List")]
        public IActionResult ListEquipmentModel()
        {
            var equipmentModels = db.EquipmentModels;
            var listEquipmentModels = equipmentModels.Select(x => new ListEquipmentModelViewModel
            {
                Id = x.Id,
                Name = x.Name
            });

            return View("~/Views/EquipmentModel/ListEquipmentModel.cshtml", listEquipmentModels);
        }

        #endregion List Equipment Model

        #region Include Equipment Model

        [Route("/[controller]/Model/Include")]
        [HttpGet]
        public IActionResult IncludeEquipmentModel()
        {
            IncludeEquipmentModelViewModel model = new IncludeEquipmentModelViewModel();
            return View("~/Views/EquipmentModel/IncludeEquipmentModel.cshtml", model);
        }

        [Route("/[controller]/Model/Include")]
        [HttpPost]
        public IActionResult IncludeEquipmentModel(IncludeEquipmentModelViewModel model)
        {
            
            var error = model.ValidateData(this, db);
            if (error != null) return error;
            if (ModelState.IsValid)
            {
                var guid = Guid.NewGuid();

                using (var transation = db.Database.BeginTransaction())
                {
                    try
                    {
                        EquipmentModel equipmentModel = new EquipmentModel()
                        {
                            Id = guid,
                            Name = model.Name
                        };

                        db.EquipmentModels.Add(equipmentModel);
                        db.SaveChanges();
                        transation.Commit();

                        //return Json(new { success = true, message = "Equipment Model has been included!" });
                        return RedirectToAction(nameof(ListEquipmentModel));
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, e.Message);
                        return Json(new { success = false });
                    }
                }
            }

            return View("~/Views/EquipmentModel/IncludeEquipmentModel.cshtml", model);
        }

        #endregion Include Equipment Model

        #region Update Equipment Model 

        [Route("/[controller]/Model/Update")]
        [HttpGet]
        public IActionResult UpdateEquipmentModel(Guid id)
        {            
            if (id == null)
            {
                return NotFound();
            }

            UpdateEquipmentModelViewModel model = new UpdateEquipmentModelViewModel();
            model.Id = id;

            var error = model.LoadingData(this, db);
            if (error != null)
            {
                return error;
            }

            return View("~/Views/EquipmentModel/UpdateEquipmentModel.cshtml", model);
        }

        [Route("/[controller]/Model/Update")]
        [HttpPost]
        public IActionResult UpdateEquipmentModel(UpdateEquipmentModelViewModel model)
        {

            var error = model.ValidateData(this, db);
            if (error != null) return error;
            if (ModelState.IsValid)
            {

                using (var transation = db.Database.BeginTransaction())
                {
                    try
                    {
                        var equipmentModel = db.EquipmentModels.FirstOrDefault(x => x.Id == model.Id);
                        equipmentModel.Name = model.Name;

                        db.SaveChanges();
                        transation.Commit();
                        //return Json(new { success = true, message = "Equipment Model has been updated!" });
                        return RedirectToAction(nameof(ListEquipmentModel));
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, e.Message);
                        return Json(new { success = false });
                    }
                }
            }

            return View("~/Views/EquipmentModel/UpdateEquipmentModel.cshtml", model);
        }

        #endregion Update Equipment Model 

        #region Delete Equipment Model

        [Route("[controller]/Model/Delete")]
        [HttpGet]
        public async Task<IActionResult> DeleteEquipmentModel(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
        
            var equipmentModel = await db.EquipmentModels.FirstOrDefaultAsync(m => m.Id == id);
            if (equipmentModel == null)
            {
                return NotFound();
            }
            return View("~/Views/EquipmentModel/DeleteEquipmentModel.cshtml", equipmentModel);           
        }

        [Route("[controller]/Model/Delete")]
        [HttpPost]
        public IActionResult DeleteEquipmentModel(Guid id)
        {

            using (var transation = db.Database.BeginTransaction())
            {
                try
                {
                    var equipmentModel = db.EquipmentModels.FirstOrDefault(x => x.Id == id);
                    db.EquipmentModels.Remove(equipmentModel);
                    db.SaveChanges();
                    transation.Commit();
                    //return Json(new { success = true, message = "Equipment Model has been deleted!" });
                    return RedirectToAction(nameof(ListEquipmentModel));
                }
                catch (Exception e)
                {
                    logger.LogError(e, e.Message);
                    return Json(new { success = false });
                }
            }
        }

        #endregion Delete Equipment Model

        #endregion Equipment Model

        #region Equipments States

        #region List Equipments States

        [Route("/[controller]/State/List")]
        public IActionResult ListEquipmentState()
        {
            var equipmentStates = db.EquipmentStates;
            var listEquipmentStates = equipmentStates.Select(x => new ListEquipmentStateViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Color = x.Color
            });

            return View("~/Views/EquipmentState/ListEquipmentState.cshtml", listEquipmentStates);
        }

        #endregion List Equipments States

        #region Include Equipment State

        [Route("/[controller]/State/Include")]
        [HttpGet]
        public IActionResult IncludeEquipmentState()
        {
            IncludeEquipmentStateViewModel model = new IncludeEquipmentStateViewModel();
            return View("~/Views/EquipmentState/IncludeEquipmentState.cshtml", model);
        }

        [Route("/[controller]/State/Include")]
        [HttpPost]
        public IActionResult IncludeEquipmentState(IncludeEquipmentStateViewModel model)
        {

            var error = model.ValidateData(this, db);
            if (error != null) return error;
            if (ModelState.IsValid)
            {
                var guid = Guid.NewGuid();

                using (var transation = db.Database.BeginTransaction())
                {
                    try
                    {
                        EquipmentState equipmentsState = new EquipmentState()
                        {
                            Id = guid,
                            Name = model.Name,
                            Color = model.Color
                        };

                        db.EquipmentStates.Add(equipmentsState);
                        db.SaveChanges();
                        transation.Commit();

                        //return Json(new { success = true, message = "Equipment State has been included!" });
                        return RedirectToAction(nameof(ListEquipmentState));
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, e.Message);
                        return Json(new { success = false });
                    }
                }
            }

            return View("~/Views/EquipmentState/IncludeEquipmentState.cshtml", model);
        }

        #endregion Include Equipment State

        #region Update Equipment State

        [Route("/[controller]/State/Update")]
        [HttpGet]
        public IActionResult UpdateEquipmentState(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UpdateEquipmentStateViewModel model = new UpdateEquipmentStateViewModel();
            model.Id = id;

            var error = model.LoadingData(this, db);
            if (error != null)
            {
                return error;
            }

            return View("~/Views/EquipmentState/UpdateEquipmentState.cshtml", model);
        }

        [Route("/[controller]/State/Update")]
        [HttpPost]
        public IActionResult UpdateEquipmentState(UpdateEquipmentStateViewModel model)
        {

            var error = model.ValidateData(this, db);
            if (error != null) return error;
            if (ModelState.IsValid)
            {

                using (var transation = db.Database.BeginTransaction())
                {
                    try
                    {
                        var equipmentState = db.EquipmentStates.FirstOrDefault(x => x.Id == model.Id);
                        equipmentState.Name = model.Name;
                        equipmentState.Color = model.Color;

                        db.SaveChanges();
                        transation.Commit();
                        //return Json(new { success = true, message = "Equipment State has been updated!" });
                        return RedirectToAction(nameof(ListEquipmentState));
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, e.Message);
                        return Json(new { success = false });
                    }
                }
            }

            return View("~/Views/EquipmentState/UpdateEquipmentState.cshtml", model);
        }

        #endregion Update Equipment State

        #region Delete Equipment State

        [Route("[controller]/State/Delete")]
        [HttpGet]
        public async Task<IActionResult> DeleteEquipmentState(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipmentState = await db.EquipmentStates.FirstOrDefaultAsync(m => m.Id == id);
            if (equipmentState == null)
            {
                return NotFound();
            }
            return View("~/Views/EquipmentState/DeleteEquipmentState.cshtml", equipmentState);
        }

        [Route("[controller]/State/Delete")]
        [HttpPost]
        public IActionResult DeleteEquipmentState(Guid id)
        {

            using (var transation = db.Database.BeginTransaction())
            {
                try
                {
                    var equipmentState = db.EquipmentStates.FirstOrDefault(x => x.Id == id);
                    db.EquipmentStates.Remove(equipmentState);
                    db.SaveChanges();
                    transation.Commit();
                    //return Json(new { success = true, message = "Equipment State has been deleted!" });
                    return RedirectToAction(nameof(ListEquipmentState));
                }
                catch (Exception e)
                {
                    logger.LogError(e, e.Message);
                    return Json(new { success = false });
                }
            }
        }

        #endregion Delete Equipment State

        #endregion Equipments States

        #region Equipments

        #region List Equipments


        [Route("/[controller]/List")]
        public IActionResult ListEquipment()
        {
            var equipments = db.Equipment;
            var listEquipments = equipments.Select(x => new ListEquipmentViewModel
            {
                Id = x.Id,
                EquipmentModelId = x.EquipmentModel.Name,
                Name = x.Name                
            });

            return View("~/Views/Equipment/ListEquipment.cshtml", listEquipments);
        }

        #endregion List Equipments

        #region Include Equipment 

        [Route("/[controller]/Include")]
        [HttpGet]
        public IActionResult IncludeEquipment()
        {
            IncludeEquipmentViewModel model = new IncludeEquipmentViewModel();
            model.SetValuesDropdown(db);
            return View("~/Views/Equipment/IncludeEquipment.cshtml", model);
        }

        [Route("/[controller]/Include")]
        [HttpPost]
        public IActionResult IncludeEquipment(IncludeEquipmentViewModel model)
        {

            var error = model.ValidateData(this, db);
            if (error != null) return error;
            if (ModelState.IsValid)
            {
                var guid = Guid.NewGuid();

                using (var transation = db.Database.BeginTransaction())
                {
                    try
                    {
                        Equipment equipment = new Equipment()
                        {
                            Id = guid,
                            Name = model.Name,
                            EquipmentModelId = model.EquipmentModelId
                        };

                        db.Equipment.Add(equipment);
                        db.SaveChanges();
                        transation.Commit();

                        //return Json(new { success = true, message = "Equipment has been included!" });
                        return RedirectToAction(nameof(ListEquipment));
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, e.Message);
                        return Json(new { success = false });
                    }
                }
            }
            model.SetValuesDropdown(db);
            return View("~/Views/Equipment/IncludeEquipment.cshtml", model);
        }

        #endregion Include Equipment

        #region Update Equipment

        [Route("/[controller]/Update")]
        [HttpGet]
        public IActionResult UpdateEquipment(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UpdateEquipmentViewModel model = new UpdateEquipmentViewModel();
            model.Id = id;

            model.SetValuesDropdown(db);
            var error = model.LoadingData(this, db);
            if (error != null)
            {
                return error;
            }

            return View("~/Views/Equipment/UpdateEquipment.cshtml", model);
        }

        [Route("/[controller]/Update")]
        [HttpPost]
        public IActionResult UpdateEquipment(UpdateEquipmentViewModel model)
        {

            var error = model.ValidateData(this, db);
            if (error != null) return error;
            if (ModelState.IsValid)
            {

                using (var transation = db.Database.BeginTransaction())
                {
                    try
                    {
                        var equipment = db.Equipment.FirstOrDefault(x => x.Id == model.Id);
                        equipment.Name = model.Name;
                        equipment.EquipmentModelId = model.EquipmentModelId;

                        db.SaveChanges();
                        transation.Commit();
                        //return Json(new { success = true, message = "Equipment has been updated!" });
                        return RedirectToAction(nameof(ListEquipment));
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, e.Message);
                        return Json(new { success = false });
                    }
                }
            }
            model.SetValuesDropdown(db);
            return View("~/Views/Equipment/UpdateEquipment.cshtml", model);
        }

        #endregion Update Equipment

        #region Delete Equipment

        [Route("[controller]/Delete")]
        [HttpGet]
        public async Task<IActionResult> DeleteEquipment(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeleteEquipmentViewModel model = new DeleteEquipmentViewModel();
            model.Id = id;

            var error = model.LoadingData(this, db);
            if (error != null)
            {
                return error;
            }

            return View("~/Views/Equipment/DeleteEquipment.cshtml", model);
        }

        [Route("[controller]/Delete")]
        [HttpPost]
        public IActionResult DeleteEquipment(Guid id)
        {

            using (var transation = db.Database.BeginTransaction())
            {
                try
                {
                    var equipment = db.Equipment.FirstOrDefault(x => x.Id == id);
                    db.Equipment.Remove(equipment);
                    db.SaveChanges();
                    transation.Commit();
                    //return Json(new { success = true, message = "Equipment has been deleted!" });
                    return RedirectToAction(nameof(ListEquipment));
                }
                catch (Exception e)
                {
                    logger.LogError(e, e.Message);
                    return Json(new { success = false });
                }
            }
        }

        #endregion Delete Equipment

        #endregion Equipments

        #region Equipment State History

        #region List last states per equipment

        [Route("/[controller]/State/History")]
        public IActionResult ListLastEquipmentStateHistory()
        {
            var equipmentsLastHistories = db.EquipmentStateHistories;

            var listaAux = new List<EquipmentStateHistory>();

            IQueryable<ListLastEquipmentStateViewModel> list = Enumerable.Empty<ListLastEquipmentStateViewModel>().AsQueryable();
            
            foreach (var equipment in equipmentsLastHistories.OrderByDescending(e => e.Date))
            {           
                if(!listaAux.Any(x => x.EquipmentId == equipment.EquipmentId))
                {
                    listaAux.Add(equipment);
                }
            }

            var listEquipments = listaAux.OrderByDescending(e => e.Date).Select(x => new ListLastEquipmentStateViewModel
            {
                EquipmentId = x.EquipmentId,
                Equipment = db.Equipment.FirstOrDefault(z => z.Id == x.EquipmentId).Name,
                EquipmentState = db.EquipmentStates.FirstOrDefault(z => z.Id == x.EquipmentStateId).Name,
                Date = x.Date.ToString()
            });                      

            return View("~/Views/EquipmentStateHistory/ListLastEquipmentStateHistory.cshtml", listEquipments);
        }

        #endregion List last states per equipment

        #region List states per equipment history

        public IActionResult ListEquipmentStateHistory(Guid equipmentId)
        {
            if (equipmentId == null)
            {
                return NotFound();
            }

            var equipmentsStateHistories = db.EquipmentStateHistories;

            var listEquipmentsHistory = equipmentsStateHistories.Where(a => a.EquipmentId == equipmentId).OrderByDescending(e => e.Date).Select(x => new ListEquipmentStateHistoryViewModel
            {     
                Equipment = x.Equipment.Name,
                EquipmentState = x.EquipmentState.Name,
                Date = x.Date.ToString()
            });

            return View("~/Views/EquipmentStateHistory/ListEquipmentStateHistory.cshtml", listEquipmentsHistory);
        }

        #endregion List states per equipment history

        #endregion Equipment State History

        #region Equipment Position History

        [Route("/[controller]/Position")]
        public IActionResult ListLastEquipmentPosition()
        {
            var equipmentsLastPositions = db.EquipmentPositionHistories;

            var listaAux = new List<EquipmentPositionHistory>();

            IQueryable<ListLastEquipmentPositionViewModel> list = Enumerable.Empty<ListLastEquipmentPositionViewModel>().AsQueryable();

            foreach (var equipment in equipmentsLastPositions.OrderByDescending(e => e.Date))
            {
                if (!listaAux.Any(x => x.EquipmentId == equipment.EquipmentId))
                {
                    listaAux.Add(equipment);
                }
            }

            var listEquipmentsPosition = listaAux.OrderByDescending(e => e.Date).Select(x => new ListLastEquipmentPositionViewModel
            {
                EquipmentId = x.EquipmentId,
                Equipment = db.Equipment.FirstOrDefault(z => z.Id == x.EquipmentId).Name,   
                Latitude = x.Lat.ToString(),
                Longitude = x.Lon.ToString(),
                Date = x.Date.ToString()
            });

            var latitudes = listEquipmentsPosition.Select(x => x.Latitude.Replace(",","."));
            var longitudes = listEquipmentsPosition.Select(x => x.Longitude.Replace(",", "."));
            var equipments = listEquipmentsPosition.Select(x => x.Equipment);

            ViewBag.Latitudes = latitudes;
            ViewBag.Longitudes = longitudes;
            ViewBag.Equipments = equipments;

            return View("~/Views/EquipmentPosition/ListLastEquipmentPosition.cshtml", listEquipmentsPosition);
        }

        #endregion Equipment Position History

        // O crud para a funcionalidade "Equipment Model State Hourly Earnings" não pôde ser feito, pois está faltando uma chave primária na tabela 'equipment_model_state_hourly_earnings'

    }
}
