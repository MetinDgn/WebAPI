using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mobilion.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.DataAccess.Test
{
    [TestClass]
    public class EfDepartmentDalTests
    {
        [TestMethod]
        public void Get_all_returns_users()
        {
            EfDepartmentDal departmentDal = new EfDepartmentDal();

            var result = departmentDal.GetList();
            Assert.AreEqual(2, result.Count);
        }
    }
}
