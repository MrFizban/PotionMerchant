using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PotionMerchant.Entity
{
    public record Recipe
    {
        public Guid id  { get; set; }
        public ICollection<Ingrediant> ingridients { get; set; }
        public Potion potion { get; set; }
        public string preparation { get; set; }
        
    }
}