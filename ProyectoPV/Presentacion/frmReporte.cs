using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ProyectoPV.Models;


namespace ProyectoPV.Presentacion
{
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            using (var db = new SistemaPrestamosPVEntities())
            {
                label13.Text = db.spSumCuotasVencidas().Sum().ToString();

                var totalACobrar =
                 (from deu in db.Deudores
                  select deu.ReditoAcumulado)
                 .Sum();
                label7.Text = totalACobrar.ToString();


                var totalCapital =
                 (from deu in db.Deudores
                  select deu.Capital)
                 .Sum();
                label8.Text = totalCapital.ToString();


                var totalClientes =
                 (from deu in db.Deudores
                  select deu.ReditoAcumulado)
                 .Count();
                label9.Text = totalClientes.ToString();


                var totalClientesEnAtraso =
                 (from deu in db.Deudores
                  where deu.CuotasVencidas>2
                  select deu)
                 .Count();
                label10.Text = totalClientesEnAtraso.ToString();

                var mayorDeudor = db.Deudores.OrderByDescending(x => x.Capital).FirstOrDefault();

                label11.Text = mayorDeudor.Nombres + " " + mayorDeudor.Apellidos;

                label15.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }
    }
}
