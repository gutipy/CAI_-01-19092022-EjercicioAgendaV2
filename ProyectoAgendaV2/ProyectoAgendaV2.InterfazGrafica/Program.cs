using ProyectoAgendaV2.Dominio.Entidades;
using ProyectoAgendaV2.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace ProyectoAgendaV2.InterfazGrafica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaración de variables
            string _opcionMenu = "";
            string _codigoContacto;
            int _codigoContactoValidado = 0;
            bool flag;

            Contacto C1 = new ContactoPersona(1, "Calle 123", "Agustín", "Gutiérrez", DateTime.Now.AddYears(-26));

            Contacto C2 = new ContactoEmpresa(2, "Calle 123", "Los Gutierritos S.A.", DateTime.Now.AddYears(-5));

            //Contacto C3 = new Contacto(3, "Mariano", "Gutiérrez", "1234-5678", "Calle 123", DateTime.Now.AddYears(-65));

            //Contacto C4 = new Contacto(4, "Graciela", "Andreacchio", "1234-5678", "Calle 123", DateTime.Now.AddYears(-61));


            Agenda agendaElectronica = new Agenda("Mi agenda", "Electrónica");

            agendaElectronica.AgregarContacto(C1);
            agendaElectronica.AgregarContacto(C2);
            //agendaElectronica.AgregarContacto(C3);
            //agendaElectronica.AgregarContacto(C4);

            C1.Llamar();
            C1.Llamar();
            C1.Llamar();
            C2.Llamar();

            bool consolaActiva = true;


            try
            {
                while (consolaActiva)
                {
                    //Despliego en pantalla las opciones para que el usuario decida
                    OpcionesMenu();

                    //Se valida que la opcion ingresada no sea vacío y/o distinta de las opciones permitidas
                    FuncionValidacionOpcion(ref _opcionMenu);

                    //Estructura condicional para controlar el flujo del programa
                    switch (_opcionMenu)
                    {
                        case "1":
                            //Listar contactos de la agenda
                            Listar(agendaElectronica, C2);

                            break;

                        case "2":
                            //Agrego un contacto a la agenda
                            Agregar(agendaElectronica);

                            break;

                        case "3":
                            //Elimino un contacto de la agenda
                            do
                            {
                                Console.WriteLine("Ingrese el código del contacto que desea eliminar");
                                _codigoContacto = Console.ReadLine();
                                flag = FuncionValidarNumero(_codigoContacto, ref _codigoContactoValidado);

                            }while (flag == false);

                            Eliminar(agendaElectronica, _codigoContactoValidado);

                            break;

                        case "4":
                            //Traer contacto más frecuente
                            TraerContactoFrec(agendaElectronica);

                            break;

                        case "5":
                            //Salir del programa
                            Salir();

                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static void OpcionesMenu()
        {
            Console.WriteLine(
                "Bienvenido a la agenda! Seleccione una opción:" + Environment.NewLine +
                "1 - Listar contactos de la agenda" + Environment.NewLine +
                "2 - Agregar contacto" + Environment.NewLine +
                "3 - Eliminar contacto" + Environment.NewLine +
                "4 - Traer contacto más frecuente" + Environment.NewLine +
                "5 - Salir"
                )
                ;
        }

        //Método para listar todos los contactos que posee la agenda y mostrarlos en pantalla
        public static void Listar(Agenda agenda, Contacto contacto)
        {
            //Si la agenda está vacía le aviso y le pido que ingrese otra opción
            if (agenda.Contactos.Count == 0)
            {
                Console.WriteLine("La agenda se encuentra vacía, presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();
            }
            //Si el contacto ingresado es de tipo "Persona", se muestra en pantalla los datos correspondientes
            else if (contacto is ContactoPersona)
            {
                ContactoPersona contactoPersona = (ContactoPersona)contacto;

                Console.WriteLine(contactoPersona.Nombre + " " + contactoPersona.Apellido + " " + contactoPersona.FechaNacimiento);

                Console.WriteLine("Presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();
            }
            else if (contacto is ContactoEmpresa)
            {
                ContactoEmpresa contactoEmpresa = (ContactoEmpresa)contacto;

                Console.WriteLine(contactoEmpresa.RazonSocial + " " + contactoEmpresa.FechaConstitucion);

                Console.WriteLine("Presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();
            }

        }

        //Método para agregar un nuevo contacto a la agenda
        public static void Agregar(Agenda agenda)
        {
            //Declaración de variables
            int _codigoContacto;
            string _opcion;
            Contacto contacto = null;
            string _nombre;
            string _apellido;
            string _direccion;
            string _fecha;
            DateTime _fechaValidada = DateTime.Now;
            bool flag;

            //Asignación del código de contacto de manera incremental
            _codigoContacto = agenda.Contactos.Count + 1;

            //Pregunto al usuario de que tipo va a ser el contacto que quiere agregar a la agenda
            Console.WriteLine("¿Que tipo de contacto desea ingresar? Presione 1 si quiere ingresar un contacto persona, presione 2 si quiere ingresar un contacto empresa");
            _opcion = Console.ReadLine();

            if (_opcion == "1")
            {
                //ContactoPersona contactoPersona = (ContactoPersona)contacto;

                //Pido al usuario que ingrese los datos de contacto y a la vez valido cada input ingresado
                do
                {
                    Console.WriteLine("Ingrese el nombre del contacto");
                    _nombre = Console.ReadLine();
                    flag = FuncionValidarCadena(ref _nombre);
                } while (flag == false);

                do
                {
                    Console.WriteLine("Ingrese el apellido del contacto");
                    _apellido = Console.ReadLine();
                    flag = FuncionValidarCadena(ref _apellido);
                } while (flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de nacimiento del contacto");
                    _fecha = Console.ReadLine();
                    flag = FuncionValidarFecha(_fecha, ref _fechaValidada, "Fecha de nacimiento");
                } while (flag == false);

                do
                {
                    Console.WriteLine("Ingrese la dirección del contacto");
                    _direccion = Console.ReadLine();
                    flag = FuncionValidarCadena(ref _direccion);
                } while (flag == false);

                //Instancio la clase ContactoPersona y lo agrego a la agenda
                contacto = new ContactoPersona(
                    _codigoContacto,
                    _direccion,
                    _nombre,
                    _apellido,
                    _fechaValidada
                    );

                agenda.AgregarContacto(contacto);

                Console.WriteLine("El contacto fue agregado exitosamente a la agenda, presione Enter para elegir otra opción.");
                Console.ReadKey();
                Console.Clear();
            }
            else if (_opcion == "2")
            {
                //Pido al usuario que ingrese los datos de contacto y a la vez valido cada input ingresado
                do
                {
                    Console.WriteLine("Ingrese la razón social del contacto");
                    _nombre = Console.ReadLine();
                    flag = FuncionValidarCadena(ref _nombre);
                } while (flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de constitución del contacto");
                    _fecha = Console.ReadLine();
                    flag = FuncionValidarFecha(_fecha, ref _fechaValidada, "Fecha de constitución");
                } while (flag == false);

                do
                {
                    Console.WriteLine("Ingrese la dirección del contacto");
                    _direccion = Console.ReadLine();
                    flag = FuncionValidarCadena(ref _direccion);
                } while (flag == false);

                //Instancio la clase ContactoEmpresa y lo agrego a la agenda
                contacto = new ContactoEmpresa(
                    _codigoContacto,
                    _direccion,
                    _nombre,
                    _fechaValidada
                    );

                agenda.AgregarContacto(contacto);

                Console.WriteLine("El contacto fue agregado exitosamente a la agenda, presione Enter para elegir otra opción.");
                Console.ReadKey();
                Console.Clear();

            }
        }

        //Método para eliminar un contacto de la agenda
        public static void Eliminar(Agenda agenda, int codigoContacto)
        {
            //Le paso el código de contacto validado a la clase Agenda para que busque en la lista de contactos y si existe dicho contacto que lo elimine
            agenda.EliminarContacto(codigoContacto);
        }

        public static void TraerContactoFrec(Agenda agenda)
        {
            Contacto c = agenda.TraerContactoFrecuente();

            if (c is ContactoPersona)
            {
                ContactoPersona contactoPersona = (ContactoPersona)c;
                Console.WriteLine("El contacto más frecuente es de tipo Persona y sus datos son: " + Environment.NewLine +
                    "Nombre: " + contactoPersona.Nombre + Environment.NewLine +
                    "Apellido: " + contactoPersona.Apellido + Environment.NewLine +
                    "Número de llamadas: " + contactoPersona.Llamadas
                    )
                    ;

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
            else if (c is ContactoEmpresa)
            {
                ContactoEmpresa contactoEmpresa = (ContactoEmpresa)c;
                Console.WriteLine("El contacto más frecuente es de tipo Empresa y sus datos son: " + Environment.NewLine +
                    contactoEmpresa.RazonSocial + Environment.NewLine +
                    contactoEmpresa.Llamadas
                    )
                    ;

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void Salir()
        {
            Console.WriteLine("Usted ha salido de la agenda, presione Enter");
            Console.ReadKey();

            Environment.Exit(0);
        }

        //Funciones que validan los inputs requeridos al usuario
        public static string FuncionValidacionOpcion(ref string opcion)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                opcion = Console.ReadLine();

                if (string.IsNullOrEmpty(opcion))
                {
                    Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
                }
                else if (opcion == "1" || opcion == "2" || opcion == "3" || opcion == "4")
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("ERROR! La opción " + opcion + " no es una opción válida, intente nuevamente.");
                }
            } while (flag == false);

            return opcion;
        }

        public static bool FuncionValidarCadena(ref string cadena)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(cadena))
            {
                Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        public static bool FuncionValidarFecha(string fecha, ref DateTime fechaValidada, string campo)
        {
            bool flag = false;

            if (!DateTime.TryParse(fecha, out fechaValidada))
            {
                Console.WriteLine("El campo " + campo + " debe tener un formato válido del tipo dd/mm/aaaa, intente nuevamente.");
            }
            else if (fechaValidada > DateTime.Now)
            {
                Console.WriteLine("La fecha ingresada no puede ser superior al día de hoy, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        public static bool FuncionValidarNumero(string numero, ref int numeroValidado)
        {
            bool flag = false;

            if (!int.TryParse(numero, out numeroValidado))
            {
                Console.WriteLine("El código ingresado debe ser de tipo numérico, intente nuevamente");
            }
            else if (numeroValidado <= 0)
            {
                Console.WriteLine("El código ingresado debe ser mayor a cero, intente nuevamente");
            }
            else
            {
                flag = true;
            }

            return flag;
        }
    }
}

