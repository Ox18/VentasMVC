using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace appBd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           // testear();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Instanciar la clase conexion
            Conexion conexion = new Conexion();
            // Ejecutar el metodo: conectarToDB()
            // y recojer la conexion generada
            SqlConnection cnx = conexion.conectarToDB();
            // Abrir la conexion
            cnx.Open();
            // Crear un comando vinculado a la conexion
            SqlCommand cmd = cnx.CreateCommand();
            // Establecer el tipo de comando: SQL(Text) //  StoreProcedure
            cmd.CommandType = CommandType.Text;
            // Asignar la instruccion SQL al comando
            cmd.CommandText = "SELECT * FROM producto where descripcion like '%' + @valor + '%'";
            // Leer el valor buscado
            string valorBuscado = txtValorBuscado.Text;
            // Pasar el valor al parametro 
            cmd.Parameters.AddWithValue("@valor", valorBuscado);

            ////FORMA I: DataAdapter => DataTable
            ////Instanciar un DataAdapter
            //SqlDataAdapter daProducto = new SqlDataAdapter();
            ////Asignar el comando al DataAdapter
            //daProducto.SelectCommand = cmd;
            ////Instanciar DataTable
            //DataTable dataTable = new DataTable();
            ////Llenar DT con los registros
            //daProducto.Fill(dataTable);
            ////Asignar al GRID
            //dgvProductos.DataSource = dataTable;

            // FORMAR II: DataReader
            // Crear un DataReader y asignar los registros
            SqlDataReader dataReader = cmd.ExecuteReader();

            List<Producto> productos = new List<Producto>();
            while (dataReader.Read())
            {
                // Leer los valores de los campos de registro
                int id = Convert.ToInt32(dataReader["id"]);
                string descripcion = Convert.ToString(dataReader["descripcion"]);
                string categoria = Convert.ToString(dataReader["categoria"]);
                double precio = Convert.ToDouble(dataReader["precio"]);
                //instanicar producto con sus valores
                Producto producto = new Producto(id, descripcion, categoria, precio);
                //agregar el producto a la lista
                productos.Add(producto);
            }
            // asignar la lista al grid
            dgvProductos.DataSource = productos;
            //cerrar conexion
            cnx.Close();
            // Llamar el formateo
            formatearGrid();

        }
        private void formatearGrid()
        {
            // Dar formato a las celdas
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            // Retirar la nueva fila
            dgvProductos.AllowUserToAddRows = false;
            // Restringir solo lectura las celdas
            dgvProductos.ReadOnly = false;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void testear()
        {
            Conexion conexion = new Conexion();
            SqlConnection cnx = conexion.conectarToDB();
            cnx.Open();
            MessageBox.Show("abierto");
            cnx.Close();
            MessageBox.Show("Cerrado");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                // recoger la fija seleccionada
                DataGridViewRow filaSelecionada = dgvProductos.SelectedRows[0];

                //recoger los valores
                int id = Convert.ToInt32(filaSelecionada.Cells["id"].Value);
                string descripcion = Convert.ToString(filaSelecionada.Cells["descripcion"].Value);
                string categoria = Convert.ToString(filaSelecionada.Cells["categoria"].Value);
                double precio = Convert.ToDouble(filaSelecionada.Cells["precio"].Value);


            }
        }
    }
}
