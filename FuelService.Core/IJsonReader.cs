using System;
using FuelService.Domain.Entities;
using FuelService.Domain.Objects;

namespace FuelService.Core
{
    public interface IJsonReader
    {
        void Process(string responce, Action<FuelEntity> dataAction);
    }
}