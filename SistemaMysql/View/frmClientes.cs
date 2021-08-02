using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaMysql.Entidades;
using SistemaMysql.Model;

namespace SistemaMysql.View
{
    public partial class frmClientes : Form
    {
        ClienteModel model = new ClienteModel();

        public void HabilitarCampos()
        {
            txtNome.Enabled = true;
            cbSexo.Enabled = true;
            dtNascimento.Enabled = true;
        }

        public void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            cbSexo.Enabled = false;
            dtNascimento.Enabled = false;
        }

        public void LimparCampos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            cbSexo.Text = "";
        }

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            try
            {
                grid.DataSource = model.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Listar os Dados" + ex.Message);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            LimparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Clientes dado = new Clientes();
            Salvar(dado);
            Listar();
            LimparCampos();
            DesabilitarCampos();
        }

        public void Salvar(Clientes dado)
        {
            try
            {
                dado.Nome = txtNome.Text;
                dado.Sexo = cbSexo.Text;
                dado.Nascimento = Convert.ToDateTime(dtNascimento.Text);
                model.Salvar(dado);
                MessageBox.Show("Cliente Salvo com Sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Salvar " + ex.Message);
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            cbSexo.Text = grid.CurrentRow.Cells[2].Value.ToString();
            dtNascimento.Text = grid.CurrentRow.Cells[3].Value.ToString();
            HabilitarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Selecione na Tabela um registro para Edição!");
                return;
            }
            Clientes dado = new Clientes();
            Editar(dado);
            Listar();
            LimparCampos();
            DesabilitarCampos();
        }

        public void Editar(Clientes dado)
        {
            try
            {
                dado.Id = Convert.ToInt32(txtCodigo.Text);
                dado.Nome = txtNome.Text;
                dado.Sexo = cbSexo.Text;
                dado.Nascimento = Convert.ToDateTime(dtNascimento.Text);
                model.Editar(dado);
                MessageBox.Show("Cliente Editado com Sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Editar " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Selecione na Tabela um registro para Excluir!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Deseja Excluir o Cliente?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            Clientes dado = new Clientes();
            Excluir(dado);
            Listar();
            LimparCampos();
            DesabilitarCampos();
        }

        public void Excluir(Clientes dado)
        {
            try
            {
                dado.Id = Convert.ToInt32(txtCodigo.Text);
                model.Excluir(dado);
                MessageBox.Show("Cliente Excluído com Sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Excluir " + ex.Message);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Clientes dado = new Clientes();
            Buscar(dado);

            if (txtBuscar.Text == "")
            {
                Listar();
                return;
            }
        }

        public void Buscar(Clientes dado)
        {
            try
            {
                dado.Nome = txtBuscar.Text;
                grid.DataSource = model.Buscar(dado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Buscar os Dados" + ex.Message);
            }
        }
    }
}
