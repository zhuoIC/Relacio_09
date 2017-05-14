using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_15
{
    class Punto
    {
        int x;
        int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Punto(int ejeX, int ejeY)
        {
            x = ejeX;
            y = ejeY;
        }
    }

    class Bola
    {
        Punto top;
        Punto left;
        Punto right;
        Punto bottom;

        internal Punto Top
        {
            get { return top; }
            set { top = value; }
        }
        internal Punto Left
        {
            get { return left; }
            set { left = value; }
        }
        

        internal Punto Right
        {
            get { return right; }
            set { right = value; }
        }
        

        internal Punto Bottom
        {
            get { return bottom; }
            set { bottom = value; }
        }

        public Bola(int ancho, int alto)
        {
            top = new Punto(ancho / 2, 0);
            left = new Punto(0, alto / 2);
            right = new Punto(ancho, alto / 2);
            bottom = new Punto(ancho / 2, alto);
        }
    }

    class Barra
    {
        Punto extremoIzq;
        Punto extremoDer;

        internal Punto ExtremoIzq
        {
            get { return extremoIzq; }
            set { extremoIzq = value; }
        }

        internal Punto ExtremoDer
        {
            get { return extremoDer; }
            set { extremoDer = value; }
        }

        public Barra(int ancho, int posicionCanvas)
        {
            extremoIzq = new Punto(0, posicionCanvas);
            extremoDer = new Punto(ancho, posicionCanvas);
        }
    }
}
