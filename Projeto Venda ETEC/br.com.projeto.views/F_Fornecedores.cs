using Projeto_Venda_ETEC.br.com.projetos.dao;
using Projeto_Venda_ETEC.br.com.projetos.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Venda_ETEC.br.com.projeto.views
{
    public partial class F_Fornecedores : Form
    {
        public F_Fornecedores()
        {
            InitializeComponent();
            FornecedorDAO dao = new FornecedorDAO();
            dgvFornecedor.DataSource = dao.ListarFornecedor();
        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            try
            {
                if (Validar.ValidaCnpj(txtcnpj.Text))
                {
                    fornecedor.nome = txtnome.Text;
                    fornecedor.cnpj = Formatador.FormatarCNPJ(txtcnpj.Text);
                    fornecedor.email = txtemail.Text;
                    fornecedor.telefone = Formatador.FormatarTel_Cel(txttel.Text, "telefone");
                    fornecedor.celular = Formatador.FormatarTel_Cel(txtcel.Text, "celular");
                    fornecedor.cep = Formatador.FormataCEP(txtcep.Text);
                    fornecedor.endereco = txtendereco.Text;
                    fornecedor.numero = int.Parse(txtnum.Text);
                    fornecedor.complemento = txtcomp.Text;
                    fornecedor.bairro = txtbairro.Text;
                    fornecedor.cidade = cbbcidade.Text;
                    fornecedor.uf = cbbuf.Text;

                    if(fornecedor.telefone == "" || fornecedor.celular == "" || fornecedor.cep == "")
                    {

                    }
                    else
                    {
                        if(fornecedor.telefone == "none")
                        {
                            fornecedor.telefone = "";
                        }
                        if(fornecedor.celular == "none")
                        {
                            fornecedor.celular = "";
                        }

                        FornecedorDAO dao = new FornecedorDAO();
                        dao.CadastrarFornecedor(fornecedor);
                        dgvFornecedor.DataSource = dao.ListarFornecedor();
                        LimparCampo();
                    }
                }
                else
                {
                    MessageBox.Show("Verifique o CNPJ e tente novamente:", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            APICorreios correios = new APICorreios();
            correios.ConsultarCEP(txtcep.Text);
            txtbairro.Text = correios.bairro;
            txtendereco.Text = correios.endereco;
            cbbuf.SelectedItem = correios.uf;
            cbbcidade.Text = correios.cidade;
            cbbuf.Text = correios.uf;
        }

        private void cbbuf_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mun = Municipios.BuscarMunicipios(cbbuf.Text);
            cbbcidade.Items.Clear();

            foreach (var m in mun)
            {
                cbbcidade.Items.Add(Formatador.UTF8_to_ISO(m.Nome));
            }

            cbbcidade.SelectedIndex = 0;
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtid.Text);
                DialogResult dr = MessageBox.Show("Deseja realmente excluir esse fornecedor?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    FornecedorDAO dao = new FornecedorDAO();
                    dao.ExcluirFornecedor(id);
                    dgvFornecedor.DataSource = dao.ListarFornecedor();
                    LimparCampo();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro durante a exclusão. Verifique se selecionou um registro e tente novamente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LimparCampo()
        {
            txtid.Clear();
            txtnome.Clear();
            txtcnpj.Clear();
            txtemail.Clear();
            txttel.Clear();
            txtcel.Clear();
            txtcep.Clear();
            txtendereco.Clear();
            txtnum.Clear();
            txtcomp.Clear();
            txtbairro.Clear();
            cbbcidade.Text = "";
            cbbuf.Text = "";
        }

        private void btnalterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar.ValidaCnpj(txtcnpj.Text))
                {
                    Fornecedor fornecedor = new Fornecedor();

                    fornecedor.nome = txtnome.Text;
                    fornecedor.cnpj = Formatador.FormatarCNPJ(txtcnpj.Text);
                    fornecedor.email = txtemail.Text;
                    fornecedor.telefone = Formatador.FormatarTel_Cel(txttel.Text, "telefone");
                    fornecedor.celular = Formatador.FormatarTel_Cel(txtcel.Text, "celular");
                    fornecedor.cep = Formatador.FormataCEP(txtcep.Text);
                    fornecedor.endereco = txtendereco.Text;
                    fornecedor.numero = int.Parse(txtnum.Text);
                    fornecedor.complemento = txtcomp.Text;
                    fornecedor.bairro = txtbairro.Text;
                    fornecedor.cidade = cbbcidade.Text;
                    fornecedor.uf = cbbuf.Text;

                    fornecedor.id = int.Parse(txtid.Text);

                    if (fornecedor.telefone == "" || fornecedor.celular == "" || fornecedor.cep == "")
                    {

                    }
                    else
                    {
                        if (fornecedor.telefone == "none")
                        {
                            fornecedor.telefone = "";
                        }
                        if (fornecedor.celular == "none")
                        {
                            fornecedor.celular = "";
                        }

                        FornecedorDAO dao = new FornecedorDAO();
                        dao.AlterarFornecedor(fornecedor);
                        dgvFornecedor.DataSource = dao.ListarFornecedor();
                        LimparCampo();
                    }
                }
                else
                {
                    MessageBox.Show("Verifique o CNPJ e tente novamente:", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

            }
        }

        private void dgvFornecedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dgvFornecedor.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = dgvFornecedor.CurrentRow.Cells[1].Value.ToString();
            txtcnpj.Text = dgvFornecedor.CurrentRow.Cells[2].Value.ToString();
            txtemail.Text = dgvFornecedor.CurrentRow.Cells[3].Value.ToString();
            txttel.Text = dgvFornecedor.CurrentRow.Cells[4].Value.ToString();
            txtcel.Text = dgvFornecedor.CurrentRow.Cells[5].Value.ToString();
            txtcep.Text = dgvFornecedor.CurrentRow.Cells[6].Value.ToString();
            txtendereco.Text = dgvFornecedor.CurrentRow.Cells[7].Value.ToString();
            txtnum.Text = dgvFornecedor.CurrentRow.Cells[8].Value.ToString();
            txtcomp.Text = dgvFornecedor.CurrentRow.Cells[9].Value.ToString();
            txtbairro.Text = dgvFornecedor.CurrentRow.Cells[10].Value.ToString();
            cbbcidade.Text = dgvFornecedor.CurrentRow.Cells[11].Value.ToString();
            cbbuf.Text = dgvFornecedor.CurrentRow.Cells[12].Value.ToString();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string dados = txtconsulta.Text;
            int index = cbbfiltro.SelectedIndex;
            FornecedorDAO dao = new FornecedorDAO();
            
            if(index == 0)
            {
                dgvFornecedor.DataSource = dao.ConsultarFornecedor(dados, "nome");
            }
            else if (index == 1)
            {
                dgvFornecedor.DataSource = dao.ConsultarFornecedor(dados, "cnpj");
            }
            else
            {
                MessageBox.Show("Selecione um item no filtro", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if(dgvFornecedor.RowCount == 0)
            {
                MessageBox.Show("Fornecedor não encontrado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
