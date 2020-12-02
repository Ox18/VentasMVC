using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appBd
{
    class Producto
    {
        private int id;
        private string descripcion;
        private string categoria;
        private double precio;

        public Producto() { }
        public Producto(int vId, string vDescripcion, string vCategoria, double vPrecio)
        {
            id = vId;
            descripcion = vDescripcion;
            categoria = vCategoria;
            precio = vPrecio;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
    }
}
