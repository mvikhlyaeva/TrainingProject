using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingProject.Domain;

namespace TrainingProject.Application.Queries.StoreDepartments.GetStpreDepartment
{
    public class GetStoreDepartmentQuery: IRequest<StoreDepartmentDomainModel>
    {
        public int StoreId { get; set; }
        public int DepartmentId { get; set; }

        public GetStoreDepartmentQuery(int storeId, int departmentId)
        {
            StoreId = storeId;
            DepartmentId = departmentId;
        }
    }
}
