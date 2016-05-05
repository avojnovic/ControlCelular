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

        private decimal _costo;

        public decimal Costo
        {
            get { return _costo; }
            set { _costo = value; }
        }

        private bool _borrado;

        public bool Borrado
        {
            get { return _borrado; }
            set { _borrado = value; }
        }


        public string ProveedorNombre
        {
            get { return Proveedor.Nombre; }
        }

        public string ModeloDescripcion
        {
            get { return Modelo.Modelo1+" - "+Modelo.Nombre; }
        }

    }
}
