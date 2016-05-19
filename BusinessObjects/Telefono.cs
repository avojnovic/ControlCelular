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

        private ColorTelefono _color;

        public ColorTelefono Color
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


        private DateTime _fechaCompra;

        public DateTime FechaCompra
        {
            get { return _fechaCompra; }
            set { _fechaCompra = value; }
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

        public string ColorNombre
        {
            get { return Color.Nombre; }
        }

        public string ProveedorNombre
        {
            get { return Proveedor.Nombre; }
        }

        public string ModeloDescripcion
        {
            get { return Modelo.MarcaNombre + " - "+ Modelo.Nombre+" - "+Modelo.Modelo1; }
        }

        private int _venta;

        public int Venta
        {
            get { return _venta; }
            set { _venta = value; }
        }

        public string Vendido
        {
            get {
                if (_venta == 0)
                    return "No";
                else
                    return "Si";
                }
        }

        public bool VendidoBool
        {
            get
            {
                if (_venta == 0)
                    return false;
                else
                    return true;
            }
        }


       
    }
}
