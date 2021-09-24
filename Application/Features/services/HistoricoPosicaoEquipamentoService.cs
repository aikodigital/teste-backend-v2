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
    public class HistoricoPosicaoEquipamentoService : IHistoricoPosicaoEquipamentoService
    {
        private readonly IMapper _mapper;
        private readonly IHistoricoPosicaoEquipamentoRepository _historicoPosicaoEquipamentoRepository;
        private ILog logger;

        public HistoricoPosicaoEquipamentoService(
            IHistoricoPosicaoEquipamentoRepository historicoPosicaoEquipamentoRepository, 
            IMapper mapper, ILog logger)
        {
            _mapper = mapper;
            this._historicoPosicaoEquipamentoRepository = historicoPosicaoEquipamentoRepository;
            this.logger = logger;
        }

        public async Task<Response<List<HistoricoPosicaoEquipamentoDTO>>> GetAllAsync()
        {
            try
            {
                return new Response<List<HistoricoPosicaoEquipamentoDTO>>
               (_mapper.Map<List<HistoricoPosicaoEquipamentoDTO>>(
                   await this._historicoPosicaoEquipamentoRepository.GetAllAsync()), $"Lista de equipamentos");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<HistoricoPosicaoEquipamentoDTO>> GetByIdAsync(Guid id)
        {
            try
            {
                return new Response<HistoricoPosicaoEquipamentoDTO>
               (_mapper.Map<HistoricoPosicaoEquipamentoDTO>(
                   await this._historicoPosicaoEquipamentoRepository.GetByGUIDAsync(id)), 
                   $"Equipamento por id");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<Guid>> RegisterAsync(HistoricoPosicaoEquipamentoDTO request)
        {
            try
            {
                request.Created = DateTime.Now;
                request.id = Guid.NewGuid();

                var result = _mapper.Map<Equipment_position_history>(request);
                await _historicoPosicaoEquipamentoRepository.AddAsync(result);
                return new Response<Guid>(result.id, Constantes.Constantes.RegistoSalvo);
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }
        }

        public async Task<Response<Guid>> UpdateAsync(HistoricoPosicaoEquipamentoDTO request)
        {
            try
            {
                var result = await _historicoPosicaoEquipamentoRepository.GetByGUIDAsync(request.id);

                if (result != null)
                {
                    result.LastModified = DateTime.Now;
                    await _historicoPosicaoEquipamentoRepository.UpdateAsync(result);
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
                await _historicoPosicaoEquipamentoRepository.DeleteAsync(await this._historicoPosicaoEquipamentoRepository.GetByGUIDAsync(id));
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
