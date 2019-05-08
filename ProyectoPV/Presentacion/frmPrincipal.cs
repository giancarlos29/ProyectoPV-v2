using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ProyectoPV.Models;
using System.Data.Entity;
using ProyectoPV.Presentacion;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace ProyectoPV
{
    public partial class frmPrincipal : Form
    {
        Deudores deudor = new Deudores();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sistemaPrestamosPVDataSet.Deudores' table. You can move, or remove it, as needed.
            this.deudoresTableAdapter.Fill(this.sistemaPrestamosPVDataSet.Deudores);
            LoadData();
        }

        #region LOADDATA
        private void LoadData()
        {
            using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
            {
                var lst = from d in db.Deudores
                          where d.CuotasVencidas > 0
                          select d;
                dgvPool.DataSource = lst.ToList();
            }
        }
        #endregion

        #region GETID
        private int? GetId()
        {
            try
            {
                return int.Parse(dgvPool.Rows[dgvPool.CurrentRow.Index].Cells[0].Value.ToString());

            }
            catch (Exception)
            {

                return null;
            }
        }
        #endregion


        private void btnPagarUltimaCuota_Click(object sender, EventArgs e)
        {
            try
            {
                var id = GetId();
                DateTime fecha = DateTime.Now;
                using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
                {
                    Deudores deu = db.Deudores.Find(id);
                    if (id != null)
                    {
                        if (deu.CuotasVencidas < 2)
                        {
                            deu.CuotasPagadasATiempo++;
                        }
                            deu.CuotasVencidas--;
                            deu.UltimoPago = fecha;
                            deu.CuotasPagadas++;
                            deu.ReditoAcumulado -= deu.ReditoMensual;
                            deu.Score = deu.CuotasGeneradas / deu.CuotasPagadas * 100;//Se lleva a porcentaje para saber el credito del deudor
                            db.Entry(deu).State = EntityState.Modified;
                            var pregunta = MessageBox.Show("Desea guardar factura?", "Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                 if (pregunta == DialogResult.Yes) //Imprime factura para una cuota
                                 {
                                      #region Factura

                                      try
                                      {
                                                   string nombreMasFecha = deu.Nombres + " " + fecha.ToString("MM - dd - yy");
                                                   string pdfFilename = $@"C:\Sistema Repuestos Pavel\Facturas de Cuotas\{nombreMasFecha}.pdf";
                                                   FileStream fs = new FileStream(pdfFilename, FileMode.Create, FileAccess.Write, FileShare.None);
                                                   Document doc = new Document();
                                                   PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                                                   doc.Open();

                                                      Paragraph espacioEntreParrrafos = new Paragraph("  ");
                                                      Paragraph fechaFactura = new Paragraph(fecha.ToString());
                                                      fechaFactura.Alignment = Element.ALIGN_RIGHT;
                                                      Paragraph linea = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                                                      Chunk titulo = new Chunk("GRUPO INVERSIONES VERAS");
                                                      Chunk subtitulo = new Chunk("República Dominicana ");
                                                      Chunk descripcion = new Chunk("DESCRIPCION - PAGO DE CUOTA");

                                                      descripcion.Font.Size = 15;
                                                      descripcion.Font.SetStyle("Bold");
                                                      titulo.Font.SetStyle("Bold");
                                                      titulo.Font.Size = 40;
                                                      subtitulo.Font.SetStyle("Bold");
                                                      subtitulo.Font.Size = 20;
                                                      Paragraph Titulo = new Paragraph(titulo);
                                                      Paragraph Subtitulo = new Paragraph(subtitulo);
                                                      Paragraph Descripcion = new Paragraph(descripcion);

                                                      Descripcion.Alignment = Element.ALIGN_CENTER;
                                                      Titulo.Alignment = Element.ALIGN_CENTER;
                                                      Subtitulo.Alignment = Element.ALIGN_CENTER;
                                                      doc.Add(linea);
                                                      doc.Add(Titulo);
                                                      doc.Add(Subtitulo);
                                                      doc.Add(Descripcion);
                                                      doc.Add(linea);


                                                       Chunk deudorNombre = new Chunk("A nombre del deudor: " + deu.Nombres + " " + deu.Apellidos);
                                                       deudorNombre.Font.Size = 20;
                                                       deudorNombre.Font.SetStyle("Bold");
                                                       Paragraph DeudorNombre = new Paragraph(deudorNombre);
                                                       doc.Add(DeudorNombre);
                                                       doc.Add(espacioEntreParrrafos);
                                                       doc.Add(espacioEntreParrrafos);


                                                       Chunk cuota = new Chunk("Monto pagado:RD$" + deu.ReditoMensual.ToString());
                                                       cuota.Font.Size = 20;
                                                       cuota.Font.SetStyle("Bold");
                                                       Paragraph Cuota = new Paragraph(cuota);
                                                       doc.Add(Cuota);
                                                       doc.Add(espacioEntreParrrafos);
                                                       doc.Add(espacioEntreParrrafos);


                                                       Chunk reditoPendiente = new Chunk("Reditos Pendientes:RD$" + deu.ReditoAcumulado.ToString());
                                                       reditoPendiente.Font.Size = 20;
                                                       reditoPendiente.Font.SetStyle("Bold");
                                                       Paragraph ReditoPendiente = new Paragraph(reditoPendiente);
                                                       doc.Add(ReditoPendiente);
                                                       doc.Add(espacioEntreParrrafos);
                                                       doc.Add(espacioEntreParrrafos);

                                                       Chunk capitalPendiente = new Chunk("Capital Pendientes:RD$" + deu.Capital.ToString());
                                                       capitalPendiente.Font.Size = 20;
                                                       capitalPendiente.Font.SetStyle("Bold");
                                                       Paragraph CapitalPendiente = new Paragraph(capitalPendiente);
                                                       doc.Add(CapitalPendiente);

                                                       for (int i = 0; i < 8; i++)
                                                       {
                                                           doc.Add(espacioEntreParrrafos);
                                                       }
                                                       doc.Add(linea);
                                                       doc.Add(fechaFactura);

                                                      doc.Close();
                                                      string pdfPath = Path.Combine(Application.StartupPath, pdfFilename);

                                                      Process.Start(pdfPath);
                                      }

                                      catch (Exception m)
                                      {
                                        MessageBox.Show(m.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                      }

                                     #endregion

                                 }

                        else //De lo contrario solo se muestra MessageBox. 
                        {
                                     MessageBox.Show(deu.Nombres + " " + deu.Apellidos + " Ha pagado" +
                                      " una cuota, le quedan " + deu.CuotasVencidas.ToString() + " Cuotas vencidas");
                                 }
                        
                    }
                    db.SaveChanges();
                    LoadData();
                }
            }
            catch (Exception Men)
            {
                MessageBox.Show(Men.Message);
                MessageBox.Show("Por haga click en algun registro!","Error:No cliente seleccionado");
            }

        }
    

        private void dgvPool_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
            {
                var id = GetId();
                Deudores deu = db.Deudores.Find(id);
                frmAbonarSaldar form = new frmAbonarSaldar(deu);
                form.ShowDialog();
                LoadData();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

 

        private void dgvPool_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnPagarUltimaCuota.Enabled = true;
            btnPagos.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Esta seguro de que desea salir del programa?", "Aviso!", MessageBoxButtons.YesNo,
            MessageBoxIcon.Information);

            if (DialogResult == DialogResult.Yes)//Se crea el backup de DB cada 25 dias
            {
                using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
                { 
                    DateTime fechaActual = DateTime.Now;
                    TimeSpan? diasDesdeUltimoBackUp;


                    var MyDate = db.BackUps.Select(x => x.UltimoBackUp).Max();

                    diasDesdeUltimoBackUp = fechaActual - MyDate;

                    if (diasDesdeUltimoBackUp.Value.Days > 25)
                    {
                        //SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SistemaPrestamosPV;Integrated Security=True");
                        //SqlCommand cmd = new SqlCommand();
                        //cmd.Connection = conn;
                        //cmd.CommandText = "backupdb";
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //conn.Open();
                        //cmd.ExecuteNonQuery();
                        //conn.Close();

                        db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "backupdb");
                        //var bu = db.backupdb();

                        var backu = new BackUp();
                        backu.UltimoBackUp = fechaActual;
                        db.BackUps.Add(backu);
                        db.SaveChanges();

                    }
                }
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frmCliente = new frmClientes();
            frmCliente.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAdministrarUsuarios admUsu = new frmAdministrarUsuarios();
            admUsu.ShowDialog();
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            var frmHistoric = new frmHistorico();
            frmHistoric.ShowDialog();
        }

        private void frmPrincipal_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void frmPrincipal_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var report = new frmReporte();
            report.ShowDialog();
        }
    }
    
}


