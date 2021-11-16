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
    public class ClienteDAO
    {
        private MySqlConnection conexao;

        public ClienteDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        public void CadastrarCliente(Cliente cliente)
        {
            try
            {
                string sql = @"insert into tb_cliente
                           (nome,rg,cpf,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                           values (@nome, @rg, @cpf, @email, @telefone, @celular, @cep, @endereco, @numero, @comp, @bairro, @cidade, @estado)";

                MySqlCommand execsql = new MySqlCommand(sql, conexao);
                execsql.Parameters.AddWithValue("@nome", cliente.nome);
                execsql.Parameters.AddWithValue("@rg", cliente.rg);
                execsql.Parameters.AddWithValue("@cpf", cliente.cpf);
                execsql.Parameters.AddWithValue("@email", cliente.email);
                execsql.Parameters.AddWithValue("@telefone", cliente.telefone);
                execsql.Parameters.AddWithValue("@celular", cliente.celular);
                execsql.Parameters.AddWithValue("@cep", cliente.cep);
                execsql.Parameters.AddWithValue("@endereco", cliente.endereco);
                execsql.Parameters.AddWithValue("@numero", cliente.numero);
                execsql.Parameters.AddWithValue("@comp", cliente.complemento);
                execsql.Parameters.AddWithValue("@bairro", cliente.bairro);
                execsql.Parameters.AddWithValue("@cidade", cliente.cidade);
                execsql.Parameters.AddWithValue("@estado", cliente.uf);

                conexao.Open();
                execsql.ExecuteNonQuery();
                
                MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro durante a execução: " + erro);
            }
        }

        public void AlterarCliente(Cliente cliente)
        {
            try
            {
                string sql = @"update tb_cliente set nome = @nome, rg = @rg, cpf = @cpf,
                             email = @email, telefone = @telefone, celular = @celular,
                             cep = @cep, endereco = @endereco, numero = @numero, complemento = @comp,
                             bairro = @bairro, cidade = @cidade, estado = @estado where id = @id";

                MySqlCommand execsql = new MySqlCommand(sql, conexao);
                execsql.Parameters.AddWithValue("@nome", cliente.nome);
                execsql.Parameters.AddWithValue("@rg", cliente.rg);
                execsql.Parameters.AddWithValue("@cpf", cliente.cpf);
                execsql.Parameters.AddWithValue("@email", cliente.email);
                execsql.Parameters.AddWithValue("@telefone", cliente.telefone);
                execsql.Parameters.AddWithValue("@celular", cliente.celular);
                execsql.Parameters.AddWithValue("@cep", cliente.cep);
                execsql.Parameters.AddWithValue("@endereco", cliente.endereco);
                execsql.Parameters.AddWithValue("@numero", cliente.numero);
                execsql.Parameters.AddWithValue("@comp", cliente.complemento);
                execsql.Parameters.AddWithValue("@bairro", cliente.bairro);
                execsql.Parameters.AddWithValue("@cidade", cliente.cidade);
                execsql.Parameters.AddWithValue("@estado", cliente.uf);

                execsql.Parameters.AddWithValue("@id", cliente.id);

                conexao.Open();
                execsql.ExecuteNonQuery();
                conexao.Close();

                MessageBox.Show("Dados do cliente alterados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro durante a execução: " + erro);
            }
        }

        public DataTable ListarClientes()
        {
            try
            {
                DataTable tabelaCliente = new DataTable();
                string sql = @"select id as 'Código', nome as 'Nome', rg as 'RG',
                             cpf as 'CPF', email as 'E-mail', telefone as 'Telefone',
                             celular as 'Celular', cep as 'CEP', endereco as 'Endereço',
                             numero as 'Número', complemento as 'Complemento',
                             bairro as 'Bairro', cidade as 'Cidade', estado as 'Estado' from tb_cliente";

                MySqlCommand execsql = new MySqlCommand(sql, conexao);
                conexao.Open();
                execsql.ExecuteNonQuery();

                MySqlDataAdapter adapter = new MySqlDataAdapter(execsql);
                adapter.Fill(tabelaCliente);
                conexao.Close();

                return tabelaCliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro durante a execução: " + erro);
                return null;
            }
        }

        public void ExcluirCliente(int idCliente)
        {
            try
            {
                string sql = @"delete from tb_cliente where id = @id";

                MySqlCommand execsql = new MySqlCommand(sql, conexao);
                execsql.Parameters.AddWithValue("@id", idCliente);

                conexao.Open();
                execsql.ExecuteNonQuery();
                conexao.Close();

                MessageBox.Show("O cliente foi excluído com sucesso", "Sucesso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro durante a execução: " + erro);
            }
        }

        public DataTable ConsultarCliente(string dado, string tipo)
        {
            try
            {
                DataTable tabelaCliente = new DataTable();
                string sql;
                switch (tipo)
                {
                    case "nome":
                        sql = @"select id as 'Código', nome as 'Nome', rg as 'RG',
                             cpf as 'CPF', email as 'E-mail', telefone as 'Telefone',
                             celular as 'Celular', cep as 'CEP', endereco as 'Endereço',
                             numero as 'Número', complemento as 'Complemento',
                             bairro as 'Bairro', cidade as 'Cidade', estado as 'Estado' from tb_cliente where nome like @dado";
                        break;
                    default:
                        sql = @"select id as 'Código', nome as 'Nome', rg as 'RG',
                             cpf as 'CPF', email as 'E-mail', telefone as 'Telefone',
                             celular as 'Celular', cep as 'CEP', endereco as 'Endereço',
                             numero as 'Número', complemento as 'Complemento',
                             bairro as 'Bairro', cidade as 'Cidade', estado as 'Estado' from tb_cliente where cpf like @dado";
                        break;
                }
                MySqlCommand execsql = new MySqlCommand(sql, conexao);
                execsql.Parameters.AddWithValue("@dado", dado+"%");
                

                conexao.Open();
                execsql.ExecuteNonQuery();

                MySqlDataAdapter adapter = new MySqlDataAdapter(execsql);
                adapter.Fill(tabelaCliente);
                conexao.Close();

                return tabelaCliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte durante a execução: " + erro);
                return null;
            }
        }
    }
}
