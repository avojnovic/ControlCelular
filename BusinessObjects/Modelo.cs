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

        private SistemaOperativo _sistemaOperativo;

        public SistemaOperativo SistemaOperativo
        {
            get { return _sistemaOperativo; }
            set { _sistemaOperativo = value; }
        }

        private string _procesador;

        public string Procesador
        {
            get { return _procesador; }
            set { _procesador = value; }
        }

        private Marca _marca;

        public Marca Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private bool _borrado;

        public bool Borrado
        {
            get { return _borrado; }
            set { _borrado = value; }
        }
    }
}
