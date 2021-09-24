using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class EquipamentoController : BaseApiController
    {
        private readonly IEquipamentoService _equipamentoService;

        public EquipamentoController(IEquipamentoService equipamentoService)
        {
            _equipamentoService = equipamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _equipamentoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _equipamentoService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(EquipamentoDTO request)
        {
            return Ok(await _equipamentoService.RegisterAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EquipamentoDTO request)
        {
            return Ok(await _equipamentoService.UpdateAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _equipamentoService.RemoveAsync(id));
        }

        [HttpGet("estado_atual/{id}")]
        public async Task<IActionResult> GetEstadoAtualById(Guid id)
        {
            return Ok(await _equipamentoService.GetEstadoAtualById(id));
        }

        [HttpGet("posicao_atual/{id}")]
        public async Task<IActionResult> GetPosicaoAtualById(Guid id)
        {
            return Ok(await _equipamentoService.GetPosicaoAtualById(id));
        }

        [HttpGet("ganhoPorEquipamento/{id}")]
        public async Task<IActionResult> GetGanhoByEquipamentoById(Guid id)
        {
            return Ok(await _equipamentoService.GetGanhoByEquipamentoById(id));
        }

        [HttpGet("produtividadePorEquipamento/{id}")]
        public async Task<IActionResult> GetProdutividadeByEquipamentoById(Guid id)
        {
            return Ok(await _equipamentoService.GetProdutividadeByEquipamentoById(id));
        }
    }
}
