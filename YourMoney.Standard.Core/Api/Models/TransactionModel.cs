﻿using System;
using Newtonsoft.Json;

namespace YourMoney.Standard.Core.Api.Models
{
    public class TransactionModel
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("category")]
        public string Category { get; set; }
        
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        public string FullDate => Date.ToString("dd, MMM yyyy hh:mm");
        
        [JsonProperty("value")]
        public decimal Value { get; set; }
        
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}