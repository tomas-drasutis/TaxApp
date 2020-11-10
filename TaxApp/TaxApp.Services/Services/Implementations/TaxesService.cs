﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxApp.Contracts.Incoming;
using TaxApp.Models.Domain;
using TaxApp.Models.Entities;
using TaxApp.Services.Repositories;

namespace TaxApp.Services.Services.Implementations
{
    public class TaxesService : ITaxesService
    {
        private readonly ITaxesRepository _taxesRepository;
        private readonly IMapper _mapper;

        public TaxesService(ITaxesRepository taxesRepository, IMapper mapper)
        {
            _taxesRepository = taxesRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(TaxRequest model)
        {
            return await _taxesRepository.Add(_mapper.Map<TaxEntity>(model));
        }

        public async Task Delete(Guid id)
        {
            await _taxesRepository.Delete(id);
        }

        public async Task<IEnumerable<Tax>> GetAll()
        {
            return _mapper.Map<IEnumerable<Tax>>(await _taxesRepository.GetAll());
        }

        public async Task<Tax> GetById(Guid id)
        {
            return _mapper.Map<Tax>(await _taxesRepository.GetById(id));
        }

        public async Task<Tax> Update(Guid id, TaxRequest model)
        {
            return _mapper.Map<Tax>(await _taxesRepository.Update(id, _mapper.Map<TaxEntity>(model)));
        }
    }
}
