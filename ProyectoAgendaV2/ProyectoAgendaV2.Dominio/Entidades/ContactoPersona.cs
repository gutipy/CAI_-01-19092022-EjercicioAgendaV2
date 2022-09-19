using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgendaV2.Dominio.Entidades
{
    public class ContactoPersona : Contacto
    {
        //Atributos
        protected string _nombre;
        protected string _apellido;
        protected DateTime _fechaNacimiento;

        //Constructor
        public ContactoPersona(int codigo, string direccion, string nombre, string apellido, DateTime fechaNacimiento) : base(codigo, direccion)
        {
            _nombre = nombre;
            _apellido = apellido;
            _fechaNacimiento = fechaNacimiento;
        }

        //Propiedades
        public string Nombre { get => _nombre; }
        public string Apellido { get => _apellido; }
        public DateTime FechaNacimiento { get => _fechaNacimiento; }

        //Método para calcular la edad de una persona
        public int Edad()
        {
            //Declaración de variables
            int _edad;

            //Calculo la edad
            _edad = (DateTime.Now - _fechaNacimiento).Days / 365;

            return _edad;
        }
    }
}
