using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;


namespace PresentationLayerConsole
{
    class Program
    {

        static void Main(string[] args)
        {
                var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                IUnityContainer container = new UnityContainer().LoadConfiguration(section);
                //section.Configure(container);
                //Helper.RegisterTypes(container);
             
                
                IBLEmployees handler = container.Resolve<IBLEmployees>();

                //Program ej = new Program();
                //ej.Bucle();
                
                   int opcion;
                   string nombre;
                   double HourlyRate;
                   char tipoEmpleado;
                   int numeradorId = 0;

                   do
                   {
                       Console.WriteLine("---------PRACTICO 01--------");
                       Console.WriteLine("-----------------------------");
                       Console.WriteLine("-----------------------------");
                       Console.WriteLine("-OPCIONES-");
                       Console.WriteLine("1-Registrar Empleado-");
                       Console.WriteLine("2-Listar Empleados-");
                       Console.WriteLine("3-Calcular Salario-");
                       Console.WriteLine("4-Eliminar Empleado-");
                       Console.WriteLine("5-Salir-");

                       Console.WriteLine("INGRESE SU OPCION: ");
                       opcion = int.Parse(Console.ReadLine());

                       while (opcion < 1 || opcion > 5)//control de la variable opcion
                       {
                           Console.WriteLine("Error, opcion no valida");
                           Console.WriteLine("INGRESE SU OPCION: ");
                           opcion = int.Parse(Console.ReadLine());
                       }

                       Console.Clear();

                       switch (opcion)
                       {
                           case 1:

                               //Employee empleado;
                               numeradorId++;

                               Console.WriteLine("Nombre:");
                               nombre = Console.ReadLine();

                               Console.WriteLine("Es PartTime(P) o FullTime(F):");
                               tipoEmpleado = char.Parse(Console.ReadLine());

                               while (tipoEmpleado != 'P' && tipoEmpleado != 'F')//control de la variable opcion
                               {
                                   Console.WriteLine("Error, el tipo de empleado no es valido. Ingrese nuevamente (P)o(F)");
                                   tipoEmpleado = char.Parse(Console.ReadLine());
                               }

                               if (tipoEmpleado == 'P')
                               {
                                   PartTimeEmployee empleado = new PartTimeEmployee();
                                   Console.WriteLine("HourlyRate:");
                                   HourlyRate = double.Parse(Console.ReadLine());
                                   empleado.HourlyRate = HourlyRate;
                                   empleado.Name = nombre;
                                   empleado.Id = numeradorId;
                                   empleado.StartDate = DateTime.Now;
                                   handler.AddEmployee(empleado);
                               }
                               else
                               {
                                   FullTimeEmployee empleado = new FullTimeEmployee();
                                   
                               }

                               

                               

                               Console.WriteLine("Empleado registrado correctamente!");
                               break;
                           case 2:
                               //listar();
                               break;
                           case 3:
                               //calcularSalario();
                               break;
                           case 4:
                               //eliminarEmpleado();
                               break;
                       }
                   } while (opcion != 5);
            
        }
    }
}

