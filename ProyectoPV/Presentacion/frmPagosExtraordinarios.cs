using ProyectoPV.Models;
using System;
using System.Windows.Forms;

namespace ProyectoPV.Presentacion
{
    public partial class frmAbonarSaldar : Form
    {
        Deudores abonador = new Deudores();

        public frmAbonarSaldar()
        {
            InitializeComponent();
        }

        public frmAbonarSaldar(Deudores saldador)
        {
            InitializeComponent();
            abonador = saldador;
            label3.Text = saldador.Nombres + " " + saldador.Apellidos;
            label4.Text = saldador.Capital.ToString();
            label6.Text = saldador.ReditoAcumulado.ToString();

        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
            {
                try
                {
                    float abono = Convert.ToSingle(txtMontoAbonar.Text);
                    DateTime fechaHoy = DateTime.Now;

                    if (abonador.ReditoAcumulado > 0)
                    {
                        abonador.ReditoAcumulado = abonador.ReditoAcumulado - abono;
                        if (abonador.ReditoAcumulado < 0)
                        {
                            float abonocapital = Convert.ToSingle(abonador.ReditoAcumulado) * (-1);
                            abonador.ReditoAcumulado = 0;
                            abonador.Capital = abonador.Capital - abonocapital;
                            MessageBox.Show("El deudor " + abonador.Nombres + " tiene su balance de reditos en:$RD"
                                + abonador.ReditoAcumulado);
                            MessageBox.Show("El deudor " + abonador.Nombres + " tiene su balance de capital en:$RD"
                                + abonador.Capital);
                        }
                        db.Entry(abonador).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        Close();
                    }
                    else if (abonador.Capital > 0)
                    {
                        abonador.Capital = abonador.Capital - abono;
                        abonador.ReditoMensual = abonador.Capital * (abonador.Interes / 100);
                        db.Entry(abonador).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("El deudor " + abonador.Nombres + " ha disminuido su capital a " + abonador.Capital);
                    }
                    if (abonador.Capital <= 0) // Cuando el deudor salda el capital, 
                    {                               // se borra de la tabla Deudores y se envia como historico a la tabla Saldadores
                        Saldadore saldador = new Saldadore();
                        saldador.Nombres = abonador.Nombres;
                        saldador.Apellidos = abonador.Apellidos;
                        saldador.CapitalSaldado = abonador.Capital;
                        saldador.FechaInicializacionPrestamo = abonador.FechaInicializacionPrestamo;
                        saldador.FechaFinalizacionPrestamo = fechaHoy;
                        saldador.CuotasGeneradas = abonador.CuotasGeneradas;
                        saldador.CuotasPagadasATiempo = abonador.CuotasPagadasATiempo;
                        saldador.Score = abonador.Score;
                        saldador.Telefono = abonador.Telefono;
                        saldador.Direccion = abonador.Direccion;
                        saldador.Cedula = abonador.Cedula;
                        db.Saldadores.Add(saldador);

                        db.Deudores.Remove(abonador);
                        db.SaveChanges();

                        MessageBox.Show("El deudor " + abonador.Nombres + " ha saldado su deuda a RD$0.00.");
                    }
                    Close();

                }
                catch (Exception)
                {
                    
                    MessageBox.Show("Verifique el campo de abono, no puede estar vacio o con un caracter que no sea numeros","Error!");
                }
                     


            }

        }


        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
