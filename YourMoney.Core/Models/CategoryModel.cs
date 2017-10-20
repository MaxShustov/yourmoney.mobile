﻿namespace YourMoney.Core.Models
{
    public class CategoryModel
    {
        public string Name { get; set; }

        public bool IsIncome { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}