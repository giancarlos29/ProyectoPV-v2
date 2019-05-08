using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ProyectoPV.Models;

namespace ProyectoPV
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
            {
               string query = (from c in db.Usuarios
                               where c.Usuario1 == txtUsuario.Text && c.Password == txtPassword.Text
                               select c.Usuario1).FirstOrDefault();
                if (query != null)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DateTime fechaActual = DateTime.Now;
                    DialogResult result = MessageBox.Show("Está seguro de que la fecha correcta es:" +
                    fechaActual.ToString("dd/MM/yyyy"), "Confirme fecha correcta", buttons);
                    if (result == DialogResult.Yes)
                    {
                        TimeSpan cuotasGen;

                        var lst = from d in db.Deudores
                                  select d;

                        foreach (var item in lst)
                        {
                            cuotasGen = fechaActual - item.FechaInicializacionPrestamo;
                            item.CuotasGeneradas = cuotasGen.Days / 30;
                            item.CuotasVencidas = item.CuotasGeneradas - item.CuotasPagadas;
                            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        }
                        db.SaveChanges();
                        frmPrincipal frmPrincipal = new frmPrincipal();
                        frmPrincipal.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Por favor configure la fecha correctamente en su sistema" +
                            " y vuelva a iniciar sección",
                        "Actualiza la fecha en su sistema");
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña incorrecto", "ERROR!");
                }
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Esta seguro de que desea salir del programa?", "Aviso!", MessageBoxButtons.YesNo,
           MessageBoxIcon.Information);

            if (DialogResult == DialogResult.Yes)
            {
                Application.Exit();

            }
        }
    }
}
