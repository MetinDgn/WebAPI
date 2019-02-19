using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mobilion.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.DataAccess.Test
{
    [TestClass]
    public class EfUserDalTests
    {
        [TestMethod]
        public void Get_all_returns_users()
        {
            EfUserDal userDal = new EfUserDal();

            var result = userDal.GetList();
            Assert.AreEqual(4, result.Count);
        }
    }
}
