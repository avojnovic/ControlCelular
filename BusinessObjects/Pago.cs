using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class Pago
    {

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }


        private Decimal _montoPago;

        public Decimal MontoPago
        {
            get { return _montoPago; }
            set { _montoPago = value; }
        }


        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public string ClienteNombre
        {
            get { return _cliente.NombreCompleto; }
        }


    }
}
