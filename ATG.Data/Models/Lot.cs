using System;
using System.Collections.Generic;

#nullable disable

namespace ATG.Data.Models
{
    public partial class Lot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsArchived { get; set; }
    }
}
