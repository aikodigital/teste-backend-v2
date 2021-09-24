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
    public class GanhosHoraEstadoService : IGanhosHoraEstadoService
    {
        private readonly IMapper _mapper;
        private readonly IGanhosHoraEstadoRepository _ganhosHoraEstadoRepository;
        private readonly IModeloEquipamentoRepository _modeloEquipamentoRepository;
        private ILog logger;

        public GanhosHoraEstadoService(
            IGanhosHoraEstadoRepository ganhosHoraEstadoRepository,
            IModeloEquipamentoRepository modeloEquipamentoRepository,
            IMapper mapper, ILog logger)
        {
            _mapper = mapper;
            this._ganhosHoraEstadoRepository = ganhosHoraEstadoRepository;
            this.logger = logger;
            _modeloEquipamentoRepository = modeloEquipamentoRepository;
        }

        public async Task<Response<List<GanhoHoraEstadoDTO>>> GetAllAsync()
        {
            try
            {
                return new Response<List<GanhoHoraEstadoDTO>>
               (_mapper.Map<List<GanhoHoraEstadoDTO>>(
                   await this._ganhosHoraEstadoRepository.GetAllAsync()),
                   $"Lista de Ganhos por hora e estado");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<GanhoHoraEstadoDTO>> GetByIdAsync(Guid id)
        {
            try
            {
                return new Response<GanhoHoraEstadoDTO>
               (_mapper.Map<GanhoHoraEstadoDTO>(
                   await this._ganhosHoraEstadoRepository.GetByGUIDAsync(id)),
                   $"Ganhos por hora e estado por id");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<Guid>> RegisterAsync(GanhoHoraEstadoDTO request)
        {
            try
            {
                request.id = Guid.NewGuid();

                var result = _mapper.Map<Equipment_model_state_hourly_earnings>(request);
                
                await _ganhosHoraEstadoRepository.AddAsync(result);
                return new Response<Guid>(result.id, Constantes.Constantes.RegistoSalvo);
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }
        }

        public async Task<Response<Guid>> UpdateAsync(GanhoHoraEstadoDTO request)
        {
            try
            {
                var result = await _ganhosHoraEstadoRepository.GetByGUIDAsync(request.id);

                if (result != null)
                {
                    result.value = request.value;
                    result.equipment_model_id = request.equipment_model_id;
                    request.equipment_state_id = request.equipment_state_id;
                    await _ganhosHoraEstadoRepository.UpdateAsync(result);
                    return new Response<Guid>(result.id,
                        Constantes.Constantes.RegistoActualizado);
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
                await _ganhosHoraEstadoRepository.DeleteAsync(
                    await this._ganhosHoraEstadoRepository.GetByGUIDAsync(id));
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
