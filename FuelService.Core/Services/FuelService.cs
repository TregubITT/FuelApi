﻿using FuelService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using FuelService.Domain.Entities;
using FuelService.Domain.Objects;

namespace FuelService.Core.Services
{
    public class FuelService : IFuelService
    {
        private readonly IFuelRepository _repository;
        private readonly IJsonReader _jsonReader;
        private readonly int _getLastDays;
        private readonly int _chunkSize;
        private readonly string _serviceApi;

        public FuelService(IFuelRepository repository, IJsonReader jsonReader, int getLastDays, int chunkSize, string serviceApi)
        {
            _repository = repository;
            _jsonReader = jsonReader;
            _getLastDays = getLastDays;
            _chunkSize = chunkSize;
            _serviceApi = serviceApi;
        }

        public void Process()
        {
            var fuelEntities = new List<FuelEntity>();

            _jsonReader.Process(GetResponceFromApi(_serviceApi), fuel =>
            {
                if (fuel.Date >= DateTime.Today.AddDays(-_getLastDays))
                {
                    fuelEntities.Add(fuel);
                    if (fuelEntities.Count >= _chunkSize)
                        HandleWriteAndFlushFuel(fuelEntities);
                }
            });

            HandleWriteAndFlushFuel(fuelEntities);
        }

        private void HandleWriteAndFlushFuel(List<FuelEntity> entities)
        {
            var existList = _repository.RetriveAllIntersections(entities.Select(s => s.Date));
            var updateList = entities.Where(a => !existList.Any(s => s.Date == a.Date)).ToList();

            if (updateList.Count > 0)
                _repository.BulkCreate(updateList);

            entities.Clear();
        }

        public string GetResponceFromApi(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
