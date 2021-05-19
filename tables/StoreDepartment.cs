using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingProject.tables
{
    public class StoreDepartment
    {
        public int StoreId { get; set; }
        public int DepartmentId { get; set; }
        public SchemeType Scheme { get; set; }

        public List<Stand> Stands { get; set; }
    }
}
