using Mobilion.Core.Abstract;
using Mobilion.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.DataAccess.Abstract
{
    public interface IUserDal :IEntityRepository<User>
    {
        Department GetDepartmentByDepartmentId(int departmentId);
    }
}
