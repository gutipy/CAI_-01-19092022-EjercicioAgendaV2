using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgendaV2.Dominio.Entidades
{
    public abstract class Contacto
    {
        //Atributos
        private int _codigo;
        private string _direccion;
        private int _llamadas;

        //Constructor
        public Contacto(int codigo, string direccion)
        {
            _codigo = codigo;
            _direccion = direccion;
            _llamadas = 0;
        }

        //Propiedades
        public int Codigo { get => _codigo; }
        public string Direccion { get => _direccion; }
        public int Llamadas { get => _llamadas; }

        //Método para agregar una llamada al contador de llamadas
        public void Llamar()
        {
            _llamadas++;
        }
    }


}
