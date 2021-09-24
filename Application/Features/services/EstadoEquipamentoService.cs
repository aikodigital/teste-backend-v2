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
    public class EstadoEquipamentoService : IEstadoEquipamentoService
    {
        private readonly IMapper _mapper;
        private readonly IEstadoEquipamentoRepository _estadoEquipamentoRepository;
        private ILog logger;

        public EstadoEquipamentoService(
            IEstadoEquipamentoRepository estadoEquipamentoRepository,
            IMapper mapper, ILog logger)
        {
            _mapper = mapper;
            this._estadoEquipamentoRepository = estadoEquipamentoRepository;
            this.logger = logger;
        }

        public async Task<Response<List<EstadoEquipamentoDTO>>> GetAllAsync()
        {
            try
            {
                return new Response<List<EstadoEquipamentoDTO>>
               (_mapper.Map<List<EstadoEquipamentoDTO>>(
                   await this._estadoEquipamentoRepository.GetAllAsync()), 
                   $"Lista de estados de equipamentos");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<EstadoEquipamentoDTO>> GetByIdAsync(int id)
        {
            try
            {
                return new Response<EstadoEquipamentoDTO>
               (_mapper.Map<EstadoEquipamentoDTO>(
                   await this._estadoEquipamentoRepository.GetByIdAsync(id)), 
                   $"Estado de Equipamento por id");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<int>> RegisterAsync(EstadoEquipamentoDTO request)
        {
            try
            {
                var result = _mapper.Map<Equipment_State>(request);
                await _estadoEquipamentoRepository.AddAsync(result);
                return new Response<int>(result.id, Constantes.Constantes.RegistoSalvo);
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }
        }

        public async Task<Response<int>> UpdateAsync(EstadoEquipamentoDTO request)
        {
            try
            {
                var result = await _estadoEquipamentoRepository.GetByIdAsync(request.id);

                if (result != null)
                {
                    result.name = request.name;
                    await _estadoEquipamentoRepository.UpdateAsync(result);
                    return new Response<int>(result.id, 
                        Constantes.Constantes.RegistoActualizado);
                }
                return new Response<int>(0, Constantes.Constantes.ErrorMsg);

            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }
        }

        public async Task<Response<int>> RemoveAsync(int id)
        {
            try
            {
                await _estadoEquipamentoRepository.DeleteAsync(
                    await this._estadoEquipamentoRepository.GetByIdAsync(id));
                return new Response<int>(id, Constantes.Constantes.RegistoEliminado);
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }
        }
    }
}
