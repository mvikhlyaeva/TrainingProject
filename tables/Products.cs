using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingProject.tables
{
    public class Products
    {
        public Guid Id { get; set; }
        public Guid Cellid { get; set; }
        public string ProductCode { get; set; }
        public decimal Quantity { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
