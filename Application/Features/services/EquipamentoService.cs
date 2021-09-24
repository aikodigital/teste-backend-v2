using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces.NLog;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.services
{
    public class EquipamentoService : IEquipamentoService
    {
        private readonly IMapper _mapper;
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IHistoricoPosicaoEquipamentoRepository _historicoPosicaoEquipamentoRepository;
        private readonly IHistoricoEstadoEquipamentoRepository _historicoEstadoEquipamentoRepository;
        private readonly IGanhosHoraEstadoRepository _ganhosHoraEstadoRepository;
        private ILog logger;

        public EquipamentoService(
            IEquipamentoRepository equipamentoRepository,
            IHistoricoPosicaoEquipamentoRepository historicoPosicaoEquipamentoRepository,
            IHistoricoEstadoEquipamentoRepository historicoEstadoEquipamentoRepository,
            IGanhosHoraEstadoRepository ganhosHoraEstadoRepository,
            IMapper mapper, 
            ILog logger)
        {
            _mapper = mapper;
            this._equipamentoRepository = equipamentoRepository;
            this.logger = logger;
            _historicoPosicaoEquipamentoRepository = historicoPosicaoEquipamentoRepository;
            _historicoEstadoEquipamentoRepository = historicoEstadoEquipamentoRepository;
            _ganhosHoraEstadoRepository = ganhosHoraEstadoRepository;
        }

        public async Task<Response<List<EquipamentoDTO>>> GetAllAsync()
        {
            try
            {
                return new Response<List<EquipamentoDTO>>
               (_mapper.Map<List<EquipamentoDTO>>(await this._equipamentoRepository.GetAllAsync()), $"Lista de equipamentos");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<EquipamentoDTO>> GetByIdAsync(Guid id)
        {
            try
            {
                return new Response<EquipamentoDTO>
               (_mapper.Map<EquipamentoDTO>(await this._equipamentoRepository.GetByGUIDAsync(id)), $"Equipamento por id");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<EquipamentoDTO>> GetPercProdutByIdAsync(Guid id)
        {
            try
            {
                return new Response<EquipamentoDTO>
               (_mapper.Map<EquipamentoDTO>(await this._equipamentoRepository.GetByGUIDAsync(id)), $"Equipamento por id");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<Guid>> RegisterAsync(EquipamentoDTO request)
        {
            try
            {
                request.Created = DateTime.Now;
                request.id = Guid.NewGuid();

                var result = _mapper.Map<Equipment>(request);
                await _equipamentoRepository.AddAsync(result);
                return new Response<Guid>(result.id, Constantes.Constantes.RegistoSalvo);
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }
        }

        public async Task<Response<Guid>> UpdateAsync(EquipamentoDTO request)
        {
            try
            {
                var result = await _equipamentoRepository.GetByGUIDAsync(request.id);

                if (result != null)
                {
                    result.name = request.name;
                    result.equipment_model_id = request.equipment_model_id;
                    result.LastModified = DateTime.Now;
                    await _equipamentoRepository.UpdateAsync(result);
                    return new Response<Guid>(result.id, Constantes.Constantes.RegistoActualizado);
                }
                return new Response<Guid>(Guid.NewGuid(), Constantes.Constantes.ErrorMsg);
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }
        }

        public async Task<Response<Guid>> RemoveAsync(Guid id)
        {
            try
            {
                await _equipamentoRepository.DeleteAsync(await this._equipamentoRepository.GetByGUIDAsync(id));
                return new Response<Guid>(id, Constantes.Constantes.RegistoEliminado);
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }
        }

        public async Task<Response<HistoricoPosicaoEquipamentoDTO>> GetPosicaoAtualById(Guid id)
        {
            try
            {
                return new Response<HistoricoPosicaoEquipamentoDTO>
               (_mapper.Map<HistoricoPosicaoEquipamentoDTO>(
                   await _historicoPosicaoEquipamentoRepository.GetPosicaoAtualById(id)),
                   $"Posição atual Equipamento por id");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<HistoricoEstadoEquipamentoDTO>> GetEstadoAtualById(Guid id)
        {
            try
            {
                return new Response<HistoricoEstadoEquipamentoDTO>
               (_mapper.Map<HistoricoEstadoEquipamentoDTO>(
                   await this._historicoEstadoEquipamentoRepository.GetEstadoAtualById(id)), 
                   $"Estado atual do Equipamento por id");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<int>> GetGanhoByEquipamentoById(Guid id)
        {
            try
            {
                var equipamento = await _equipamentoRepository.GetByGUIDAsync(id);

                var horasModeloOperando = await _ganhosHoraEstadoRepository
                    .GetQuantHorasOperando(equipamento.equipment_model_id);

                var horasModeloManutencao = await _ganhosHoraEstadoRepository
                    .GetQuantHorasManutencao(equipamento.equipment_model_id);

                var horasEquipamentoOperando = await _historicoEstadoEquipamentoRepository
                    .GetQuantHorasOperando(equipamento.id);

                var horasEquipamentoManutencao = await _historicoEstadoEquipamentoRepository
                    .GetQuantHorasManutencao(equipamento.id);

                var resultado = horasModeloOperando * horasEquipamentoOperando
                    + horasModeloManutencao * horasEquipamentoManutencao;

                return new Response<int>(resultado, $"Ganho do Equipamento por id");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<string>> GetProdutividadeByEquipamentoById(Guid id)
        {
            try
            {
                var operandoHoje = await _historicoEstadoEquipamentoRepository
                    .GetQuantHorasOperandoHoje(id);

                var geralHoje = await _historicoEstadoEquipamentoRepository
                    .GetQuantHorasHoje(id);

                var resultado = operandoHoje / geralHoje * 100;

                return new Response<string>(resultado+"%", 
                    $"Percentual da Produtividade do Equipamento");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }
    }
}
