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
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.services
{
    public class HistoricoEstadoEquipamentoService : IHistoricoEstadoEquipamentoService
    {
        private readonly IMapper _mapper;
        private readonly IHistoricoEstadoEquipamentoRepository _historicoEstadoEquipamentoRepository;
        private ILog logger;

        public HistoricoEstadoEquipamentoService(
            IHistoricoEstadoEquipamentoRepository historicoEstadoEquipamentoRepository, 
            IMapper mapper, ILog logger)
        {
            _mapper = mapper;
            this._historicoEstadoEquipamentoRepository = historicoEstadoEquipamentoRepository;
            this.logger = logger;
        }

        public async Task<Response<List<HistoricoEstadoEquipamentoDTO>>> GetAllAsync()
        {
            try
            {
                return new Response<List<HistoricoEstadoEquipamentoDTO>>
               (_mapper.Map<List<HistoricoEstadoEquipamentoDTO>>(
                   await this._historicoEstadoEquipamentoRepository.GetAllAsync()), $"Lista de equipamentos");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<HistoricoEstadoEquipamentoDTO>> GetByIdAsync(Guid id)
        {
            try
            {
                return new Response<HistoricoEstadoEquipamentoDTO>
               (_mapper.Map<HistoricoEstadoEquipamentoDTO>(
                   await this._historicoEstadoEquipamentoRepository.GetByGUIDAsync(id)), $"Equipamento por id");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<Guid>> RegisterAsync(HistoricoEstadoEquipamentoDTO request)
        {
            try
            {
                request.Created = DateTime.Now;
                request.id = Guid.NewGuid();

                var result = _mapper.Map<Equipment_state_history>(request);
                await _historicoEstadoEquipamentoRepository.AddAsync(result);
                return new Response<Guid>(result.id, Constantes.Constantes.RegistoSalvo);
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }
        }

        public async Task<Response<Guid>> UpdateAsync(HistoricoEstadoEquipamentoDTO request)
        {
            try
            {
                var result = await _historicoEstadoEquipamentoRepository.GetByGUIDAsync(request.id);

                if (result != null)
                {
                    result.LastModified = DateTime.Now;
                    await _historicoEstadoEquipamentoRepository.UpdateAsync(result);
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
                await _historicoEstadoEquipamentoRepository.DeleteAsync(
                    await this._historicoEstadoEquipamentoRepository.GetByGUIDAsync(id));
                return new Response<Guid>(id, Constantes.Constantes.RegistoEliminado);
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }
        }
    }
}
