using ProyectoPV.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoPV.Presentacion
{
    public partial class frmHistorico : Form
    {
        public frmHistorico()
        {
            InitializeComponent();
        }

        private void frmHistorico_Load(object sender, EventArgs e)
        {
            LoadData();
        }




        #region LOADDATA
        private void LoadData()
        {
            using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
            {
                var lst = from d in db.Saldadores
                          select d;
                dgvSaldadores.DataSource = lst.ToList();
            }
        }
        #endregion

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
            {
                var lst = from d in db.Saldadores
                          select d;
                dgvSaldadores.DataSource = lst.Where(p => p.Nombres.Contains(txtBuscar.Text)).ToList();
            }
        }
    }
}
