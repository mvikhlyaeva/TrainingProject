using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingProject.tables
{
    public class Stands
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Size { get; set; }
        public int Position { get; set; }
        public int Side { get; set; }
        public int StoreId { get; set; }
        public int DepartmentId { get; set; }
    }
}
