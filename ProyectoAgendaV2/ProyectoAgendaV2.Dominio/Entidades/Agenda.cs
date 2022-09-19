using ProyectoAgendaV2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgendaV2.Dominio
{
    public class Agenda
    {
        //Atributos de la clase Agenda
        private string _nombre;
        private string _tipo;
        private List<Contacto> _contactos = new List<Contacto>();
        private int _cantidadMaximaContactos;

        //Constructor de la clase Agenda
        public Agenda(string nombre, string tipo)
        {
            _nombre = nombre;
            _tipo = tipo;
            _contactos = new List<Contacto>();
            //Defino la cantidad máxima de contactos de la agenda arbitrariamente
            _cantidadMaximaContactos = 100;
        }

        //Propiedades de la clase Agenda
        public string Nombre
        {
            get
            {
                return _nombre;
            }
        }

        public string Tipo
        {
            get
            {
                return _tipo;
            }
        }

        public int CantidadMaximaContactos
        {
            get
            {
                return _cantidadMaximaContactos;
            }
        }

        public List<Contacto> Contactos
        {
            get
            {
                return _contactos;
            }
        }

        //Procedimiento que permite agregar un contacto a la agenda
        public void AgregarContacto(Contacto c)
        {
            if (_contactos.Count < _cantidadMaximaContactos)
            {
                //Agrego los datos que ingresó el usuario a la lista dinámica que almacena los contactos
                _contactos.Add(c);
            }
            else
            {
                //throw new AgendaLlenaException(CantidadMaximaContactos);
            }

        }

        //Procedimiento que permite eliminar un contacto de la agenda
        public void EliminarContacto(int codigoContacto)
        {
            //Si el código ingresado no es válido le tira un cartel de error
            if (_contactos.Find(C => C.Codigo == codigoContacto) == null)
            {
                //throw new CodigoContactoNoExisteException(codigoContacto);
            }

            //Le indico que remueva a todos los contactos que tengan el mismo codigo ingresado por el usuario
            else
            {
                _contactos.RemoveAll(C => C.Codigo == codigoContacto);
            }
        }

        //Función para traer el contacto frecuente (el que mas veces ha sido llamado)
        public void TraerContactoFrecuente()
        {
            //Declaración de variables
            int _maximasLlamadas = 0;
            int _idContacto = 0;

            foreach (Contacto c in _contactos)
            {
                if (c.Llamadas > _maximasLlamadas)
                {
                    _maximasLlamadas = c.Llamadas;
                    _idContacto = c.Codigo;
                }
            }

            Console.WriteLine("El contacto con ID: " + _idContacto + " tiene un total de " + _maximasLlamadas + " llamadas");
        }
    }
}
