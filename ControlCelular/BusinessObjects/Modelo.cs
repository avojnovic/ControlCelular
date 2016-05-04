using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class Modelo
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _modelo;

        public string Modelo1
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        private Marca _marca;

        public Marca Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }
    }
}
