using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_18
{
    class Jarra
    {
        // En litros
        private int _capacidad; 
        private int _contenido;

        public Jarra(int capacidad)
        {
            _capacidad = capacidad;
            _contenido = capacidad;
        }

        public int Capacidad
        {
            get { return _capacidad; }
        }

        public int Cantidad
        {
            get { return _contenido; }
            set 
            {
                if (value >= Capacidad)
                {
                    _contenido = Capacidad;
                }
                else
                {
                    _contenido = value; 
                }
            }
        }

        public void Llenar()
        {
            Cantidad = Capacidad;
        }

        public void Vaciar()
        {
            Cantidad = 0;
        }

        public void LLenarDesde(Jarra unaJarra)
        {
            if (this.Cantidad < this.Capacidad) // No esta llena
            {
                int tmp = this.Cantidad;
                this.Cantidad += unaJarra.Cantidad; // suma todo
                unaJarra.Cantidad -= this.Cantidad - tmp;
            }
        }
        public override string ToString()
        {
            return "Jarra de " + Capacidad + " litro(s) de capacidad llena con " + Cantidad + " litro(s)";
        }
    }
}
