using System;
using FuelService.Domain.Entities;

namespace FuelService.Core
{
    public interface IJsonReader
    {
        void Process(string responce, Action<FuelEntity> dataAction);
    }
}