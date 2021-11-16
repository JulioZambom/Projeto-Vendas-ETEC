using Correios;
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
    public partial class F_Clientes : Form
    {
        public F_Clientes()
        {
            InitializeComponent();
            ClienteDAO dao = new ClienteDAO();
            dgvCliente.DataSource = dao.ListarClientes();
        }
        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            string cep = txtcep.Text;

            APICorreios correios = new APICorreios();
            correios.ConsultarCEP(cep);
            txtbairro.Text = correios.bairro;
            txtendereco.Text = correios.endereco;
            cbbuf.SelectedItem = correios.uf;
            cbbcidade.Text = correios.cidade;
            cbbuf.Text = correios.uf;
        }

        private void btnalterar_Click(object sender, EventArgs e)
        {

            Cliente cliente = new Cliente();
            try
            {
                if (Validar.ValidaCPF(txtcpf.Text))
                {
                    cliente.nome = txtnome.Text;
                    cliente.rg = Formatador.FormatarRG(txtrg.Text);
                    cliente.cpf = Formatador.FormatarCPF(txtcpf.Text);
                    cliente.email = txtemail.Text;
                    cliente.telefone = Formatador.FormatarTel_Cel(txttel.Text, "telefone");
                    cliente.celular = Formatador.FormatarTel_Cel(txtcel.Text, "celular");
                    cliente.cep = Formatador.FormataCEP(txtcep.Text);
                    cliente.endereco = txtendereco.Text;
                    cliente.numero = int.Parse(txtnum.Text);
                    cliente.complemento = txtcomp.Text;
                    cliente.bairro = txtbairro.Text;
                    cliente.cidade = cbbcidade.Text;
                    cliente.uf = cbbuf.Text;

                    cliente.id = int.Parse(txtid.Text);
                    if (cliente.rg == "" || cliente.telefone == "" || cliente.celular == "" || cliente.cep == "")
                    {

                    }
                    else
                    {
                        if(cliente.telefone == "none")
                        {
                            cliente.telefone = "";
                        }

                        if (cliente.celular == "none")
                        {
                            cliente.celular = "";
                        }
                        ClienteDAO dao = new ClienteDAO();
                        dao.AlterarCliente(cliente);
                        dgvCliente.DataSource = dao.ListarClientes();

                        DialogResult dr = MessageBox.Show("Deseja fazer mais alguma alteração?", "Atenção:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(dr == DialogResult.No)
                        {
                            LimparCampo();
                        }

                    }
                    
                }
                else
                {
                    MessageBox.Show("Verifique o CPF e tente novamente:", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

            }
        }

        private void cbbuf_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mun = Municipios.BuscarMunicipios(cbbuf.Text);
            cbbcidade.Items.Clear();

            foreach (Municipios m in mun)
            {
                cbbcidade.Items.Add(Formatador.UTF8_to_ISO(m.Nome));
            }

            cbbcidade.SelectedIndex = 0;
        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            try
            {
                if (Validar.ValidaCPF(txtcpf.Text))
                {
                    cliente.nome = txtnome.Text;
                    cliente.rg = Formatador.FormatarRG(txtrg.Text);
                    cliente.cpf = Formatador.FormatarCPF(txtcpf.Text);
                    cliente.email = txtemail.Text;
                    cliente.telefone = Formatador.FormatarTel_Cel(txttel.Text, "telefone");
                    cliente.celular = Formatador.FormatarTel_Cel(txtcel.Text, "celular");
                    cliente.cep = Formatador.FormataCEP(txtcep.Text);
                    cliente.endereco = txtendereco.Text;
                    cliente.numero = int.Parse(txtnum.Text);
                    cliente.complemento = txtcomp.Text;
                    cliente.bairro = txtbairro.Text;
                    cliente.cidade = cbbcidade.Text;
                    cliente.uf = cbbuf.Text;

                    if(cliente.rg == "" || cliente.telefone == "" || cliente.celular == "" || cliente.cep == "")
                    {

                    }
                    else
                    {
                        if (cliente.telefone == "none")
                        {
                            cliente.telefone = "";
                        }

                        if (cliente.celular == "none")
                        {
                            cliente.celular = "";
                        }

                        ClienteDAO dao = new ClienteDAO();
                        dao.CadastrarCliente(cliente);

                        dgvCliente.DataSource = dao.ListarClientes();
                        LimparCampo();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Verifique o CPF e tente novamente:", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

            } 
            
        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dgvCliente.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = dgvCliente.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = dgvCliente.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = dgvCliente.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = dgvCliente.CurrentRow.Cells[4].Value.ToString();
            txttel.Text = dgvCliente.CurrentRow.Cells[5].Value.ToString();
            txtcel.Text = dgvCliente.CurrentRow.Cells[6].Value.ToString();
            txtcep.Text = dgvCliente.CurrentRow.Cells[7].Value.ToString();
            txtendereco.Text = dgvCliente.CurrentRow.Cells[8].Value.ToString();
            txtnum.Text = dgvCliente.CurrentRow.Cells[9].Value.ToString();
            txtcomp.Text = dgvCliente.CurrentRow.Cells[10].Value.ToString();
            txtbairro.Text = dgvCliente.CurrentRow.Cells[11].Value.ToString();
            cbbuf.Text = dgvCliente.CurrentRow.Cells[13].Value.ToString();
            cbbcidade.Text = dgvCliente.CurrentRow.Cells[12].Value.ToString();
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtid.Text);
                DialogResult dr = MessageBox.Show("Deseja realmente excluir esse cliente?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {

                    ClienteDAO dao = new ClienteDAO();
                    dao.ExcluirCliente(id);

                    dgvCliente.DataSource = dao.ListarClientes();
                    LimparCampo();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro durante a exclusão. Verifique se selecionou um registro e tente novamente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string dados = txtconsulta.Text;
            int index = cbbfiltro.SelectedIndex;
            ClienteDAO dao = new ClienteDAO();

            if (index == 0)
            {
                dgvCliente.DataSource = dao.ConsultarCliente(dados, "nome");
            }

            else if (index == 1)
            {
                dgvCliente.DataSource = dao.ConsultarCliente(dados, "cpf");
            }
            else
            {
                MessageBox.Show("Selecione um item no filtro", "Atenção!", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            if(dgvCliente.RowCount == 0)
            {
                MessageBox.Show("Cliente não encontrado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LimparCampo()
        {
            txtnome.Clear();
            txtrg.Clear();
            txtcpf.Clear();
            txtemail.Clear();
            txttel.Clear();
            txtcel.Clear();
            txtcep.Clear();
            txtendereco.Clear();
            txtnum.Clear();
            txtcomp.Clear();
            txtbairro.Clear();
            cbbcidade.Text="";
            cbbuf.Text="";
            txtid.Clear();
        }
    }
}
