using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class GanhosHoraEstadoController : BaseApiController
    {
        private readonly IGanhosHoraEstadoService _ganhosHoraEstadoService;

        public GanhosHoraEstadoController(IGanhosHoraEstadoService ganhosHoraEstadoService)
        {
            _ganhosHoraEstadoService = ganhosHoraEstadoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ganhosHoraEstadoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _ganhosHoraEstadoService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(GanhoHoraEstadoDTO request)
        {
            return Ok(await _ganhosHoraEstadoService.RegisterAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(GanhoHoraEstadoDTO request)
        {
            return Ok(await _ganhosHoraEstadoService.UpdateAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _ganhosHoraEstadoService.RemoveAsync(id));
        }
    }
}
