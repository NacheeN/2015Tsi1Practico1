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

        
                int opcion;
                string nombre;
                char tipoEmpleado;
                int numeradorId = 0;
                double precioHora;
                int salario;

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
                                Console.WriteLine("Precio por hora:");
                                precioHora = double.Parse(Console.ReadLine());
                                PartTimeEmployee empleado = new PartTimeEmployee();
                                empleado.HourlyRate = precioHora;
                                empleado.Name = nombre;
                                empleado.Id = numeradorId;
                                empleado.StartDate = DateTime.Now;
                                handler.AddEmployee(empleado);
                            }
                            else
                            {
                                Console.WriteLine("Precio mensual:");
                                salario = int.Parse(Console.ReadLine());
                                FullTimeEmployee empleado = new FullTimeEmployee();
                                empleado.Salary = salario;
                                empleado.Name = nombre;
                                empleado.Id = numeradorId;
                                empleado.StartDate = DateTime.Now;
                                handler.AddEmployee(empleado);
                            }

                            Console.WriteLine("Empleado registrado correctamente!");
                            break;
                        case 2:
                            List<Employee> empleados= handler.GetAllEmployees();
                            Console.WriteLine("ID       NOMBRE          FECHA DE INGRESO          TIPO");
                            string tipo;

                            foreach (Employee empleado in empleados)
                            {
                                if (empleado is FullTimeEmployee){
                                    tipo = "FullTime";
                                }
                                else
                                {
                                    tipo = "PartTime";
                                }
                                Console.WriteLine("{0}     {1}        {2}     {3} ", empleado.Id, empleado.Name, empleado.StartDate, tipo);
                            }
                            break;
                        case 3:
                            int idCalcular, horas;
                            Console.WriteLine("Ingrese el id del empleado a calcular:");
                            idCalcular = int.Parse(Console.ReadLine());
                            Console.WriteLine("Ingrese la cantidad de horas trabajadas:");
                            horas = int.Parse(Console.ReadLine());
                            Double salarioCalculado = handler.CalcPartTimeEmployeeSalary(idCalcular, horas);
                            Console.WriteLine("El salario correspondiente es: $ {0}", salarioCalculado);
                            //falta agarrar el throw
                            break;
                        case 4:
                            Console.WriteLine("Ingrese el id del empleado a dar de baja:");
                            int id = int.Parse(Console.ReadLine());
                            handler.DeleteEmployee(id);
                            Console.WriteLine("Empleado dado de baja correctamente");
                            break;
                    }
                } while (opcion != 5);
                }
                }

}