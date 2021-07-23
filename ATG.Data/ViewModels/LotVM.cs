using System;
using System.Collections.Generic;
using System.Text;

namespace ATG.Data.ViewModels
{
    public class LotVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsArchived { get; set; }
    }
}
