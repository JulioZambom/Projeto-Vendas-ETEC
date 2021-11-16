using MySql.Data.MySqlClient;
using Projeto_Venda_ETEC.br.com.projetos.connection;
using Projeto_Venda_ETEC.br.com.projetos.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Venda_ETEC.br.com.projetos.dao
{
    public class FornecedorDAO
    {
        private MySqlConnection conexao;
        public FornecedorDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        public void CadastrarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                string sql = @"insert into tb_fornecedor (nome, cnpj, email, telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado)
                             values
                             (@nome, @cnpj, @email, @telefone, @celular, @cep, @endereco, @numero, @comp, @bairro, @cidade, @estado)";

                MySqlCommand execsql = new MySqlCommand(sql, conexao);
                execsql.Parameters.AddWithValue("@nome", fornecedor.nome);
                execsql.Parameters.AddWithValue("@cnpj", fornecedor.cnpj);
                execsql.Parameters.AddWithValue("@email", fornecedor.email);
                execsql.Parameters.AddWithValue("@telefone", fornecedor.telefone);
                execsql.Parameters.AddWithValue("@celular", fornecedor.celular);
                execsql.Parameters.AddWithValue("@cep", fornecedor.cep);
                execsql.Parameters.AddWithValue("@endereco", fornecedor.endereco);
                execsql.Parameters.AddWithValue("@numero", fornecedor.numero);
                execsql.Parameters.AddWithValue("@comp", fornecedor.complemento);
                execsql.Parameters.AddWithValue("@bairro", fornecedor.bairro);
                execsql.Parameters.AddWithValue("@cidade", fornecedor.cidade);
                execsql.Parameters.AddWithValue("@estado", fornecedor.uf);

                conexao.Open();
                execsql.ExecuteNonQuery();
                conexao.Close();

                MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro durante a execução: " + erro);
            }
        }

        public DataTable ListarFornecedor()
        {
            DataTable tabelaFornecedor = new DataTable();
            try
            {
                string sql = @"select id as 'Código', nome as 'Nome', cnpj as 'CNPJ', email as 'E-mail', telefone as 'Telefone', celular as 'Celular', cep as 'CEP',
                             endereco as 'Endereço', numero as 'Número', complemento as 'Complemento', bairro as 'Bairro', cidade as 'Cidade', estado as 'Estado'
                             from tb_fornecedor";
                MySqlCommand execsql = new MySqlCommand(sql, conexao);

                conexao.Open();
                execsql.ExecuteNonQuery();

                MySqlDataAdapter adapter = new MySqlDataAdapter(execsql);
                adapter.Fill(tabelaFornecedor);
                conexao.Close();

                return tabelaFornecedor;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro durante a execução: " + erro);
                return null;
            }
        }

        public void ExcluirFornecedor(int idFornecedor)
        {
            try
            {
                string sql = "delete from tb_fornecedor where id = @id";

                MySqlCommand execsql = new MySqlCommand(sql, conexao);
                execsql.Parameters.AddWithValue("@id", idFornecedor);

                conexao.Open();
                execsql.ExecuteNonQuery();
                conexao.Close();

                MessageBox.Show("O fornecedor foi excluído com sucesso", "Sucesso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro durante a execução: " + erro);
            }
        }

        public void AlterarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                string sql = @"update tb_fornecedor set nome=@nome, cnpj=@cnpj, email=@email, telefone=@telefone, celular=@celular, cep=@cep,
                             endereco=@endereco, numero=@numero, complemento=@comp, bairro=@bairro, cidade=@cidade, estado=@estado where id = @id";

                MySqlCommand execsql = new MySqlCommand(sql, conexao);
                execsql.Parameters.AddWithValue("@nome", fornecedor.nome);
                execsql.Parameters.AddWithValue("@cnpj", fornecedor.cnpj);
                execsql.Parameters.AddWithValue("@email", fornecedor.email);
                execsql.Parameters.AddWithValue("@telefone", fornecedor.telefone);
                execsql.Parameters.AddWithValue("@celular", fornecedor.celular);
                execsql.Parameters.AddWithValue("@cep", fornecedor.cep);
                execsql.Parameters.AddWithValue("@endereco", fornecedor.endereco);
                execsql.Parameters.AddWithValue("@numero", fornecedor.numero);
                execsql.Parameters.AddWithValue("@comp", fornecedor.complemento);
                execsql.Parameters.AddWithValue("@bairro", fornecedor.bairro);
                execsql.Parameters.AddWithValue("@cidade", fornecedor.cidade);
                execsql.Parameters.AddWithValue("@estado", fornecedor.uf);

                execsql.Parameters.AddWithValue("@id", fornecedor.id);

                conexao.Open();
                execsql.ExecuteNonQuery();
                conexao.Close();

                MessageBox.Show("Dados do fornecedor alterados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro durante a execução: " + erro);
            }
        }

        public DataTable ConsultarFornecedor(string dado, string tipo)
        {
            try
            {
                DataTable tabelaFornecedor = new DataTable();
                string sql;
                switch (tipo)
                {
                    case "nome":
                        sql = @"select id as 'Código', nome as 'Nome', cnpj as 'CNPJ', email as 'E-mail', telefone as 'Telefone', celular as 'Celular', cep as 'CEP',
                             endereco as 'Endereço', numero as 'Número', complemento as 'Complemento', bairro as 'Bairro', cidade as 'Cidade', estado as 'Estado'
                             from tb_fornecedor where nome like @dado";
                        break;
                    default:
                        sql = @"select id as 'Código', nome as 'Nome', cnpj as 'CNPJ', email as 'E-mail', telefone as 'Telefone', celular as 'Celular', cep as 'CEP',
                             endereco as 'Endereço', numero as 'Número', complemento as 'Complemento', bairro as 'Bairro', cidade as 'Cidade', estado as 'Estado'
                             from tb_fornecedor where cnpj like @dado";
                        break;
                }

                MySqlCommand execsql = new MySqlCommand(sql, conexao);
                execsql.Parameters.AddWithValue("@dado", dado + "%");

                conexao.Open();
                execsql.ExecuteNonQuery();

                MySqlDataAdapter adapter = new MySqlDataAdapter(execsql);
                adapter.Fill(tabelaFornecedor);
                conexao.Close();

                return tabelaFornecedor;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro durante a execução: " + erro);
                return null;
            }

        }
    }
}
