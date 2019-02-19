using Mobilion.Business.Dto;
using Mobilion.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.Business.Helpers
{
    public class DepartmentMapper
    {
        public static Department DepartmentDtoToDepartment(DepartmentDto department)
        {
            return new Department()
            {
                DepartmentId = department.DepartmentId,
                Name = department.DepartmentName
            };
        }
    }
}
