using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgendaV2.Dominio.Entidades
{
    public class ContactoEmpresa : Contacto
    {
        //Atributos
        protected string _razonSocial;
        protected DateTime _fechaConstitucion;

        //Constructor
        public ContactoEmpresa(int codigo, string direccion, string razonSocial, DateTime fechaConstitucion) : base(codigo, direccion)
        {
            _razonSocial = razonSocial;
            _fechaConstitucion = fechaConstitucion;
        }

        //Propiedades
        public string RazonSocial { get => _razonSocial; }
        public DateTime FechaConstitucion { get => _fechaConstitucion; }

        //Método para calcular la antiguedad de la empresa
        public int Antiguedad()
        {
            //Declaración de variables
            int _antiguedad;

            //Calculo la edad
            _antiguedad = (DateTime.Now - _fechaConstitucion).Days / 365;

            return _antiguedad;
        }
    }
}
