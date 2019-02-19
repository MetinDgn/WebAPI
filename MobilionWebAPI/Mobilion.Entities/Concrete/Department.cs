using Mobilion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.Entities.Concrete
{
    public class Department :IEntity
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
    }
}
