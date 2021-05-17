using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingProject.tables
{
    public class StoreDepartments
    {
        public int StoreID { get; set; }
        public int DepartmentId { get; set; }
        public SchemeType Scheme { get; set; }
    }
}
