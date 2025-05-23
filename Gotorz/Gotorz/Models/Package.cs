﻿using System.Text.Json.Serialization;

namespace Gotorz.Models
{
    public class Package
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("pictures")]
        public List<Picture?> Pictures { get; set; }

        [JsonPropertyName("selectedFlight")]
        public Flight SelectedFlight { get; set; }

        [JsonPropertyName("selectedHotel")]
        public Hotel SelectedHotel { get; set; }
        [JsonPropertyName("flights")]
        public List<Flight> Flights { get; set; }

        [JsonPropertyName("employee")]
        public Employee Employee { set; get; }
    }
}
