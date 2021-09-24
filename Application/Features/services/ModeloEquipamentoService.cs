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
    public class ModeloEquipamentoService : IModeloEquipamentoService
    {
        private readonly IMapper _mapper;
        private readonly IModeloEquipamentoRepository _modeloEquipamentoRepository;
        private ILog logger;

        public ModeloEquipamentoService(IModeloEquipamentoRepository modeloEquipamentoRepository, 
            IMapper mapper, ILog logger)
        {
            _mapper = mapper;
            this._modeloEquipamentoRepository = modeloEquipamentoRepository;
            this.logger = logger;
        }

        public async Task<Response<List<ModelEquipamentoDTO>>> GetAllAsync()
        {
            try
            {
                return new Response<List<ModelEquipamentoDTO>>
               (_mapper.Map<List<ModelEquipamentoDTO>>(await this._modeloEquipamentoRepository.GetAllAsync()), $"Lista de modelos de equipamentos");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<ModelEquipamentoDTO>> GetByIdAsync(Guid id)
        {
            try
            {
                return new Response<ModelEquipamentoDTO>
               (_mapper.Map<ModelEquipamentoDTO>(await this._modeloEquipamentoRepository.GetByGUIDAsync(id)), $"Modelo de Equipamento por id");
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }

        }

        public async Task<Response<Guid>> RegisterAsync(ModelEquipamentoDTO request)
        {
            try
            {
                request.Created = DateTime.Now;
                request.id = Guid.NewGuid();

                var result = _mapper.Map<Equipment_Model>(request);
                await _modeloEquipamentoRepository.AddAsync(result);
                return new Response<Guid>(result.id, Constantes.Constantes.RegistoSalvo);
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex.Message);
                throw new ApiException(ex.Message);
            }
        }

        public async Task<Response<Guid>> UpdateAsync(ModelEquipamentoDTO request)
        {
            try
            {
                var result = await _modeloEquipamentoRepository.GetByGUIDAsync(request.id);

                if(result != null)
                {
                    result.name = request.name;
                    result.LastModified = DateTime.Now;
                    await _modeloEquipamentoRepository.UpdateAsync(result);
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
                await _modeloEquipamentoRepository.DeleteAsync(await this._modeloEquipamentoRepository.GetByGUIDAsync(id));
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
