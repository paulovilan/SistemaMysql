using SistemaMysql.Entidades;
using SistemaMysql.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaMysql
{
    public partial class Login : Form
    {
        UsuarioModel model = new UsuarioModel();
        public Login()
        {
            InitializeComponent();
        }

        public void Logar(Usuarios dado)
        {
            try
            {
                if(txtLogin.Text == "")
                {
                    MessageBox.Show("Preencha o Usuário!");
                    txtLogin.Focus();
                    return;
                }
                if (txtSenha.Text == "")
                {
                    MessageBox.Show("Preencha a Senha!");
                    txtSenha.Focus();
                    return;
                }
                dado.Usuario = txtLogin.Text;
                dado.Senha = txtSenha.Text;
                dado = model.Login(dado);
                if(dado.Usuario == null)
                {
                    lblMensagem.Text = "Usuário ou senha incorretos!!";
                    lblMensagem.ForeColor = Color.Red;
                    return;
                }

                TelaPrincipal form = new TelaPrincipal();
                this.Hide();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de Login " + ex.Message);
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            Logar(usuario);
        }
    }
}
