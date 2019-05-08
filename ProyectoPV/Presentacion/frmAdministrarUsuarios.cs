using ProyectoPV.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoPV.Presentacion
{
    public partial class frmAdministrarUsuarios : Form
    {
        public frmAdministrarUsuarios()
        {
            InitializeComponent();
        }

        #region LOADDATA
        private void LoadData()
        {
            using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
            {
                var lst = from d in db.Usuarios
                          select d;
                dgvUsuarios.DataSource = lst.ToList();
            }
        }
        #endregion

        #region GETID
        private int? GetId()
        {
            try
            {
                return int.Parse(dgvUsuarios.Rows[dgvUsuarios.CurrentRow.Index].Cells[0].Value.ToString());

            }
            catch (Exception)
            {

                return null;
            }
        }
        #endregion

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
                {
                    Usuario us = db.Usuarios.Find(id);
                    db.Usuarios.Remove(us);
                    db.SaveChanges();
                    MessageBox.Show("Se eliminó el usuario: "+ us.Usuario1, "Regristro Borrado!");
                }
                LoadData();
            }
        }

        private void AdministrarUsuarios_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
            {
                var lst = from d in db.Usuarios
                          select d;
                dgvUsuarios.DataSource = lst.Where(p => p.Usuario1.Contains(txtBuscar.Text)).ToList();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtNombre.Text))
            { 
                if(txtPassword.Text == txtConfirmarPassword.Text)
                {
                    using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
                    {
                    Usuario usuario = new Usuario();
                    usuario.Usuario1 = txtNombre.Text;
                    usuario.Password = txtPassword.Text;
                    db.Usuarios.Add(usuario);
                    MessageBox.Show("Usuario agregado!");
                    db.SaveChanges();
                    LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Los campos de contraseñas deben de ser identicos!", "ERROR!");
                }
            }
            else
            {
                MessageBox.Show("El campo de Usuario no puede estar vacío", "ERROR!");
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = GetId();
            using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
            {
                Usuario us = db.Usuarios.Find(id);
                txtNombre.Text = us.Usuario1;
                txtPassword.Text = us.Password;
                btnEditarCliente.Enabled = true;
                btnEliminar.Enabled = true;

            }
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                var id = GetId();
                using (SistemaPrestamosPVEntities db = new SistemaPrestamosPVEntities())
                {
                    Usuario us = db.Usuarios.Find(id);
                    if (id != null)
                    {
                        us.Usuario1 = txtNombre.Text;
                        us.Password = txtPassword.Text;
                        db.Entry(us).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Se actualizó el usuario: " + us.Usuario1, "Información Actualizada");
                        btnEditarCliente.Enabled = false;
                    }
                    LoadData();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Por favor haga click en un usuario.");
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtConfirmarPassword.Clear();
            txtNombre.Clear();
            txtPassword.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
