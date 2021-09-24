using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class HistoricoPosicaoEquipamentoController : BaseApiController
    {
        private readonly IHistoricoPosicaoEquipamentoService _historicoPosicaoEquipamentoService;

        public HistoricoPosicaoEquipamentoController(
            IHistoricoPosicaoEquipamentoService historicoPosicaoEquipamentoService)
        {
            _historicoPosicaoEquipamentoService = historicoPosicaoEquipamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _historicoPosicaoEquipamentoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _historicoPosicaoEquipamentoService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(HistoricoPosicaoEquipamentoDTO request)
        {
            return Ok(await _historicoPosicaoEquipamentoService.RegisterAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(HistoricoPosicaoEquipamentoDTO request)
        {
            return Ok(await _historicoPosicaoEquipamentoService.UpdateAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _historicoPosicaoEquipamentoService.RemoveAsync(id));
        }
    }
}
