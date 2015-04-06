using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;


namespace PresentationLayerConsole
{
    class Program
    {
        static void Main(string[] args)
        {           
            IBLEmployees blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());

            //your code goes here!
            //use the blHandler reference to the business logic layer
            //...
            //...
        }
    }
}

