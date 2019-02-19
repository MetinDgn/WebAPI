using Mobilion.Core.Abstract;
using Mobilion.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.DataAccess.Abstract
{
    public interface IDepartmentDal : IEntityRepository<Department>
    {
        List<User> GetUsersByDepartmentId(int departmentId);
        User GetUserByUserId(int userId);
    }
}
