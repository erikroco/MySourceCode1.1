using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ap_escuela
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Alumno AlumnoActual { get; set; }
        private void btnGuardar_Click(object sender, EventArgs e)
        {



            Alumno Alumno = new Alumno();
            Alumno.Nombre = txtNombre.Text;
            Alumno.Apellido = txtApellido.Text;
            Alumno.Direccion = txtDireccion.Text;
            Alumno.Fecha_Nac = txtFecha.Text;

            int resultado = AlumnoDAL.Agregar(Alumno);

            if (resultado > 0)
            {
                MessageBox.Show("datos guardados correctamente", "Datos Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }

            else
            {
                MessageBox.Show("No se pudieron Guardar los datos", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar pBuscar = new Buscar();
            pBuscar.ShowDialog();

            if (pBuscar.AlumnoSeleccionado != null)
            {
                AlumnoActual = pBuscar.AlumnoSeleccionado;
                txtNombre.Text = pBuscar.AlumnoSeleccionado.Nombre;
                txtApellido.Text = pBuscar.AlumnoSeleccionado.Apellido;
                txtDireccion.Text = pBuscar.AlumnoSeleccionado.Direccion;
                txtFecha.Text = pBuscar.AlumnoSeleccionado.Fecha_Nac;

                btnGuardar.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Alumno pAlumno = new Alumno();
            pAlumno.Nombre = txtNombre.Text;
            pAlumno.Apellido = txtApellido.Text;
            pAlumno.Apellido = txtDireccion.Text;
            pAlumno.Fecha_Nac = txtFecha.Text;
            pAlumno.Id = AlumnoActual.Id;

            int resultado = AlumnoDAL.Modificar(pAlumno);

            if (resultado > 0)
            {
                MessageBox.Show("Alumno Modificado con exito", "Alumno Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }

            else
            {
                MessageBox.Show("No se pudo Modificar el Alumno", "Ocurrio un Error !!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void Limpiar()
        {

            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtFecha.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Esta seguro que desea eliminar el alumno??", "Esta seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                int resultado = AlumnoDAL.Eliminar(AlumnoActual.Id);

                if (resultado > 0)
                {

                    MessageBox.Show("Alumnos Eliminado Correctamente", "ALumno Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }

                else
                {
                    MessageBox.Show("No se pudo Eliminar el alumno", "Ocurrio un error!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Cancelado");
        }

    }

}
