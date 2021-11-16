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
    public partial class F_Funcionarios : Form
    {
        public F_Funcionarios()
        {
            InitializeComponent();
            FuncionarioDAO dao = new FuncionarioDAO();
            dgvFuncionario.DataSource = dao.ListarFunc();
        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar.ValidaCPF(txtcpf.Text))
                {
                    Funcionario func = new Funcionario();

                    func.nome = txtnome.Text;
                    func.rg = Formatador.FormatarRG(txtrg.Text);
                    func.cpf = Formatador.FormatarCPF(txtcpf.Text);
                    func.email = txtemail.Text;
                    func.senha = txtsenha.Text;
                    func.cargo = txtcargo.Text;
                    func.nivel_acesso = cbbnivel_acesso.Text;
                    func.telefone = Formatador.FormatarTel_Cel(txttel.Text, "telefone");
                    func.celular = Formatador.FormatarTel_Cel(txtcel.Text, "celular");
                    func.cep = Formatador.FormataCEP(txtcep.Text);
                    func.endereco = txtendereco.Text;
                    func.numero = int.Parse(txtnum.Text);
                    func.complemento = txtcomp.Text;
                    func.bairro = txtbairro.Text;
                    func.cidade = cbbcidade.Text;
                    func.uf = cbbuf.Text;

                    if(func.telefone == "" || func.celular == "" || func.rg == "" || func.cep == "")
                    {

                    }
                    else
                    {
                        if(func.telefone == "none")
                        {
                            func.telefone = "";
                        }
                        if(func.celular == "none")
                        {
                            func.celular = "";
                        }
                        FuncionarioDAO dao = new FuncionarioDAO();
                        dao.CadastrarFunc(func);
                        dgvFuncionario.DataSource = dao.ListarFunc();
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

        private void cbbuf_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mun = Municipios.BuscarMunicipios(cbbuf.Text);
            cbbcidade.Items.Clear();

            foreach(Municipios m in mun)
            {
                cbbcidade.Items.Add(Formatador.UTF8_to_ISO(m.Nome));
            }

            cbbcidade.SelectedIndex = 0;
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
            cbbcidade.Text = "";
            cbbuf.Text = "";
            txtid.Clear();
            cbbnivel_acesso.Text = "";
            txtsenha.Clear();
            txtcargo.Clear();
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtid.Text);
                DialogResult dr = MessageBox.Show("Deseja realmente excluir esse funcionário?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    FuncionarioDAO dao = new FuncionarioDAO();
                    dao.ExcluirFunc(id);
                    dgvFuncionario.DataSource = dao.ListarFunc();
                    LimparCampo();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro durante a exclusão. Verifique se selecionou um registro e tente novamente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void dgvFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dgvFuncionario.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = dgvFuncionario.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = dgvFuncionario.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = dgvFuncionario.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = dgvFuncionario.CurrentRow.Cells[4].Value.ToString();
            txtsenha.Text = dgvFuncionario.CurrentRow.Cells[5].Value.ToString();
            txtcargo.Text = dgvFuncionario.CurrentRow.Cells[6].Value.ToString();
            cbbnivel_acesso.Text = dgvFuncionario.CurrentRow.Cells[7].Value.ToString();
            txttel.Text = dgvFuncionario.CurrentRow.Cells[8].Value.ToString();
            txtcel.Text = dgvFuncionario.CurrentRow.Cells[9].Value.ToString();
            txtcep.Text = dgvFuncionario.CurrentRow.Cells[10].Value.ToString();
            txtendereco.Text = dgvFuncionario.CurrentRow.Cells[11].Value.ToString();
            txtnum.Text = dgvFuncionario.CurrentRow.Cells[12].Value.ToString();
            txtcomp.Text = dgvFuncionario.CurrentRow.Cells[13].Value.ToString();
            txtbairro.Text = dgvFuncionario.CurrentRow.Cells[14].Value.ToString();
            cbbcidade.Text = dgvFuncionario.CurrentRow.Cells[15].Value.ToString();
            cbbuf.Text = dgvFuncionario.CurrentRow.Cells[16].Value.ToString();
        }

        private void btnalterar_Click(object sender, EventArgs e)
        {
            try
            {
                Funcionario func = new Funcionario();

                if (Validar.ValidaCPF(txtcpf.Text))
                {
                    

                    func.nome = txtnome.Text;
                    func.rg = Formatador.FormatarRG(txtrg.Text);
                    func.cpf = Formatador.FormatarCPF(txtcpf.Text);
                    func.email = txtemail.Text;
                    func.senha = txtsenha.Text;
                    func.cargo = txtcargo.Text;
                    func.nivel_acesso = cbbnivel_acesso.Text;
                    func.telefone = Formatador.FormatarTel_Cel(txttel.Text, "telefone");
                    func.celular = Formatador.FormatarTel_Cel(txtcel.Text, "celular");
                    func.cep = Formatador.FormataCEP(txtcep.Text);
                    func.endereco = txtendereco.Text;
                    func.numero = int.Parse(txtnum.Text);
                    func.complemento = txtcomp.Text;
                    func.bairro = txtbairro.Text;
                    func.cidade = cbbcidade.Text;
                    func.uf = cbbuf.Text;

                    func.id = int.Parse(txtid.Text);

                    if(func.rg == "" || func.telefone == "" || func.celular == "" || func.cep == "")
                    {

                    }
                    else
                    {
                        if(func.telefone == "none")
                        {
                            func.telefone = "";
                        }
                        if(func.celular == "none")
                        {
                            func.celular = "";
                        }

                        FuncionarioDAO dao = new FuncionarioDAO();
                        dao.AlterarFunc(func);
                        dgvFuncionario.DataSource = dao.ListarFunc();

                        DialogResult dr = MessageBox.Show("Deseja fazer mais alguma alteração?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string dado = txtconsulta.Text;
            int index = cbbfiltro.SelectedIndex;
            string tipo;

            FuncionarioDAO dao = new FuncionarioDAO();
            if(index == 0)
            {
                tipo = "nome";
                dgvFuncionario.DataSource = dao.ConsultarFunc(dado, tipo);
            }
            else if(index == 1)
            {
                tipo = "cpf";
                dgvFuncionario.DataSource = dao.ConsultarFunc(dado, tipo);
            }
            else
            {
                MessageBox.Show("Selecione um item no filtro", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if(dgvFuncionario.RowCount == 0)
            {
                MessageBox.Show("Funcionário não encontrado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
