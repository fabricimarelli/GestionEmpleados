using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminEmpleados.BLL;
using AdminEmpleados.DAL;


namespace AdminEmpleados.PL
{
    public partial class frmDepartamentos : Form
    {
        DepartamentosDAL oDepartamentosDAL;
        public frmDepartamentos()
        {
            oDepartamentosDAL = new DepartamentosDAL();
            InitializeComponent();
            LLenarGrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Conectado...");
            oDepartamentosDAL.Agregar(RecuperarInformacion());

        }

        private DepartamentoBLL RecuperarInformacion()
        {
            DepartamentoBLL oDepartamentoBLL = new DepartamentoBLL();
            int ID = 0; int.TryParse(txtID.Text, out ID);
            oDepartamentoBLL.ID = ID;
            oDepartamentoBLL.Departamento = txtDepartamento.Text;

            return oDepartamentoBLL;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;//recupera el valor del indice(que fila esta seleccionada)
            txtID.Text = dgvDepartamentos.Rows[indice].Cells[0].Value.ToString();//trae el valor de la fila (indice) de la primer columna (que es la del ID)
            txtDepartamento.Text = dgvDepartamentos.Rows[indice].Cells[1].Value.ToString();//trae el valor de la fila (indice) de la segunda columna (que es el depto)
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oDepartamentosDAL.Eliminar(RecuperarInformacion());
            dgvDepartamentos.DataSource = oDepartamentosDAL.MostrarDepartamentos().Tables[0];

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oDepartamentosDAL.Modificar(RecuperarInformacion());
            LLenarGrid();
        }

        public void LLenarGrid()
        {
            dgvDepartamentos.DataSource = oDepartamentosDAL.MostrarDepartamentos().Tables[0];

        }
    }
}
