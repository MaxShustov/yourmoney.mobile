﻿using System;
using Newtonsoft.Json;

namespace YourMoney.Standard.Core.Entities
{
    public class Transaction: IBaseEnitity<string>
    {
        public string Id { get; set; }

        public string Description { get; set; }
        
        public string Category { get; set; }
        
        public DateTime Date { get; set; }

        public string FullDate => Date.ToString("dd, MMM yyyy hh:mm");
        
        public decimal Value { get; set; }
        
        public string UserId { get; set; }
    }
}