using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class Venta
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private Telefono _telefono;

        public Telefono Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        private Decimal _monto;

        public Decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        private Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        private bool _cobrado;

        public bool Cobrado
        {
            get { return _cobrado; }
            set { _cobrado = value; }
        }

        private DateTime _fechaCobro;

        public DateTime FechaCobro
        {
            get { return _fechaCobro; }
            set { _fechaCobro = value; }
        }

        private bool _borrado;

        public bool Borrado
        {
            get { return _borrado; }
            set { _borrado = value; }
        }
    }
}
