﻿using BlazorApp.Constants;
using BlazorApp.Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class TelemetricsService : ITelemetricsService
    {
        private readonly IGenericRepository _genericRepository;
        public TelemetricsService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<Telemetrics>> GetTelemetricsAsync()
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = $"{ApiConstants.TelemetricsEndpoint}"
            };
            string url = builder.Path;

           return await _genericRepository.GetAsync<IEnumerable<Telemetrics>>(builder.ToString());
        }

        //public async Task<Telemetrics> GetTelemetricsAsync(string id)
        //{
        //    UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        //    {
        //        Path = $"{ApiConstants.TelemetricsEndpoint}/{id}"
        //    };
        //    return await _genericRepository.GetAsync<Telemetrics>(builder.ToString());
        //}

        //public async Task<bool> AddTelemetricsAsync(Telemetrics Telemetrics)
        //{
        //    UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        //    {
        //        Path = ApiConstants.TelemetricsEndpoint
        //    };
        //    await _genericRepository.PostAsync(builder.ToString(), Telemetrics);
        //    return true;
        //}

        //public async Task<bool> UpdateTelemetricsAsync(Telemetrics Telemetrics)
        //{
        //    UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        //    {
        //        Path = $"{ApiConstants.TelemetricsEndpoint}/{Telemetrics.Id}"
        //    };
        //    await _genericRepository.PutAsync(builder.ToString(), Telemetrics);
        //    return true;
        //}

        //public async Task<bool> DeleteTelemetricsAsync(string id)
        //{
        //    UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        //    {
        //        Path = $"{ApiConstants.TelemetricsEndpoint}/{id}"
        //    };
        //    await _genericRepository.DeleteAsync(builder.ToString());
        //    return true;
        //}
    }
}