using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity.Configuration;
using BusinessLogicLayer;
using Shared.Entities;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace Test
{
    [TestClass]
    public class CalcPartTimeEmployeeSalaryTest
    {
        private UnityContainer container = new UnityContainer();

        [TestMethod]
        public void InitTest()
        {
            Helper.RegisterTypes(container);
        }
        [TestMethod]
        public void CalcPartTimeEmployeeSalaryTestMethod()
        {
            //arrange
            int hours = 10;

            InitTest();
            
            IBLEmployees blHandler = container.Resolve<IBLEmployees>();
            List<Employee> partTimeEmployees = blHandler.
                                               GetAllEmployees().Where(emp => emp is PartTimeEmployee).ToList();
            //act
            var sum = partTimeEmployees.Sum(emp => blHandler.CalcPartTimeEmployeeSalary(emp.Id, hours));

            //assert
            Assert.AreEqual(sum, 0);
        }

    }
}
