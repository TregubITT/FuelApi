using FuelService.Domain.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FuelService.Core
{
    public class JsonReader : IJsonReader
    {
        public void Process(string responce, Action<FuelEntity> dataAction)
        {
            JObject serviceRresponce = JObject.Parse(responce);

            foreach (JToken result in serviceRresponce.SelectTokens("$.series[*].data[*]"))
            {
                DateTime.TryParseExact(result.First.ToObject<string>(), "yyyyMMdd",
                    CultureInfo.CurrentUICulture, DateTimeStyles.None, out DateTime date);
                var price = result.Last.ToObject<decimal>();

                dataAction(new FuelEntity() { Date = date.Date, Price = price });
            }
        }
    }
}
