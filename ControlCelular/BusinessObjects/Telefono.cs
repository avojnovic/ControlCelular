using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class Telefono
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _imei;

        public string Imei
        {
            get { return _imei; }
            set { _imei = value; }
        }

        private string _color;

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        private Modelo _modelo;

        public Modelo Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        private Proveedor _proveedor;

        public Proveedor Proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
        }

        
    }
}
