using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingProject.DomainModels
{
    public class StoreDepartmentDomainModel
    {
        public int StoreId { get; set; }
        public int DepartmentId { get; set; }
        public SchemeType Scheme { get; set; }
    }
}
