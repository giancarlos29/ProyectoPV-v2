using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ProyectoPV.Models;

namespace ProyectoPV
{
    public partial class frmClientes : Form
    {

        public void ActualizaData()
        {
            
        }


        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #region LOADDATA
        private void LoadData()
        {
            using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
            {
                var lst = from d in db.Deudores
                          select d;
                dgvDeudores.DataSource = lst.ToList();
            }
        }
        #endregion

      

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Presentacion.frmTabla oFrmTabla = new Presentacion.frmTabla();
            oFrmTabla.ShowDialog();
            LoadData();
        }

        #region GETID
        private int? GetId()
        {
            try
            {
                return int.Parse(dgvDeudores.Rows[dgvDeudores.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion


        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                Presentacion.frmTabla oFrmTabla = new Presentacion.frmTabla(id);
                oFrmTabla.ShowDialog();
                LoadData();
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
                {
                    Deudores oTabla = db.Deudores.Find(id);
                    db.Deudores.Remove(oTabla);
                    db.SaveChanges();
                    MessageBox.Show("Regristro Borrado!");
                }
                LoadData();
            }   

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
            {
                var lst = from d in db.Deudores
                          select d;
                dgvDeudores.DataSource = lst.Where(p => p.Nombres.Contains(txtBuscar.Text)).ToList();
            }
        }
    }
}
