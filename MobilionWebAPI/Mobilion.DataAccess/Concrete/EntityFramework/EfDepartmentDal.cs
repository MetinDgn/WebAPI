using Mobilion.Core.DataAccess.EntityFramework;
using Mobilion.DataAccess.Abstract;
using Mobilion.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobilion.DataAccess.Concrete.EntityFramework
{
    public class EfDepartmentDal:EfEntityRepositoryBase<Department,MobilionContext>,IDepartmentDal
    {
        public List<User> GetUsersByDepartmentId(int departmentId)
        {
            using (MobilionContext context = new MobilionContext())
            {
                return context.Users.Where(x => x.DepartmentId == departmentId).ToList();
            }

        }
        public User GetUserByUserId(int userId)
        {
            using (MobilionContext context = new MobilionContext())
            {
                return context.Users.Where(x => x.UserId == userId).SingleOrDefault();
            }

        }
    }
}
