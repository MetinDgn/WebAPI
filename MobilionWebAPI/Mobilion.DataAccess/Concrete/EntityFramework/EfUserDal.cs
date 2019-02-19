using Mobilion.Core.DataAccess.EntityFramework;
using Mobilion.DataAccess.Abstract;
using Mobilion.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Mobilion.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, MobilionContext>, IUserDal
    {
        public Department GetDepartmentByDepartmentId(int departmentId)
        {
            using (MobilionContext context = new MobilionContext())
            {
                return context.Departments.Where(x => x.DepartmentId == departmentId).SingleOrDefault();
            }
        }
    }
}
