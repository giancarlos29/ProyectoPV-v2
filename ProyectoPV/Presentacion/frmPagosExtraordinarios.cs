using ProyectoPV.Models;
using System;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;



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
                            MessageBox.Show("El deudor " + abonador.Nombres + " tiene su balance de capital en:$RD"
                                + abonador.Capital,"Info!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("El deudor " + abonador.Nombres + " ha disminuido su capital a " + abonador.Capital, "Info!",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

                        //Carta de Saldo automaticamente se crea el PDF

                        #region CartaDeSaldo

                        try
                        {
                            string nombreMasFecha = abonador.Nombres + " " + fechaHoy.ToString("MM - dd - yy");
                            string pdfFilename = $@"C:\Sistema Repuestos Pavel\Cartas de Saldo\{nombreMasFecha}.pdf";
                            FileStream fs = new FileStream(pdfFilename, FileMode.Create, FileAccess.Write, FileShare.None);
                            Document doc = new Document();
                            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                            doc.Open();

                            Paragraph espacioEntreParrrafos = new Paragraph("  ");
                            Paragraph fechaFactura = new Paragraph(fechaHoy.ToString());
                            fechaFactura.Alignment = Element.ALIGN_RIGHT;
                            Paragraph linea = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                            Chunk titulo = new Chunk("GRUPO INVERSIONES VERAS");
                            Chunk subtitulo = new Chunk("República Dominicana ");
                            Chunk descripcion = new Chunk("DESCRIPCION - CARTA DE SALDO");

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


                            Chunk deudorNombre = new Chunk("A nombre de: " + abonador.Nombres + " " + abonador.Apellidos);
                            deudorNombre.Font.Size = 20;
                            deudorNombre.Font.SetStyle("Bold");
                            Paragraph DeudorNombre = new Paragraph(deudorNombre);
                            doc.Add(DeudorNombre);
                            doc.Add(espacioEntreParrrafos);
                            doc.Add(espacioEntreParrrafos);


                            Chunk cuota = new Chunk("Monto pagado:RD$" + abonador.ReditoMensual.ToString());
                            cuota.Font.Size = 20;
                            cuota.Font.SetStyle("Bold");
                            Paragraph Cuota = new Paragraph(cuota);
                            doc.Add(Cuota);
                            doc.Add(espacioEntreParrrafos);
                            doc.Add(espacioEntreParrrafos);


                            Chunk reditoPendiente = new Chunk("Reditos Pendientes:RD$" + abonador.ReditoAcumulado.ToString());
                            reditoPendiente.Font.Size = 20;
                            reditoPendiente.Font.SetStyle("Bold");
                            Paragraph ReditoPendiente = new Paragraph(reditoPendiente);
                            doc.Add(ReditoPendiente);
                            doc.Add(espacioEntreParrrafos);
                            doc.Add(espacioEntreParrrafos);

                            Chunk capitalPendiente = new Chunk("Capital Pendientes:RD$" + abonador.Capital.ToString());
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

                        db.Deudores.Remove(abonador);
                        db.SaveChanges();

                        MessageBox.Show("El deudor " + abonador.Nombres + " ha saldado su deuda a RD$0.00.",
                            "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Close();

                }
                catch (Exception)
                {
                        MessageBox.Show("Verifique el campo de abono, no puede estar vacio o con un caracter que no sea numeros",
                            "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                     

            }

        }


        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
