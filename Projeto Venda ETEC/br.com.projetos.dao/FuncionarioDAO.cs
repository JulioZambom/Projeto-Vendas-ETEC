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
    public class FuncionarioDAO
    {
        private MySqlConnection conexao;

        public FuncionarioDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        public void CadastrarFunc(Funcionario func)
        {
            try
            {
                string sql = @"insert into tb_funcionario 
                         (nome, rg, cpf, email, senha, cargo, nivel_acesso, telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado)
                         values
                         (@nome, @rg, @cpf, @email, @senha, @cargo, @nivel_acesso, @telefone, @celular, @cep, @endereco, @numero, @comp, @bairro, @cidade, @estado)";

                MySqlCommand execsql = new MySqlCommand(sql, conexao);
                execsql.Parameters.AddWithValue("@nome", func.nome);
                execsql.Parameters.AddWithValue("@rg", func.rg);
                execsql.Parameters.AddWithValue("@cpf", func.cpf);
                execsql.Parameters.AddWithValue("@email", func.email);
                execsql.Parameters.AddWithValue("@senha", func.senha);
                execsql.Parameters.AddWithValue("@cargo", func.cargo);
                execsql.Parameters.AddWithValue("@nivel_acesso", func.nivel_acesso);
                execsql.Parameters.AddWithValue("@telefone", func.telefone);
                execsql.Parameters.AddWithValue("@celular", func.celular);
                execsql.Parameters.AddWithValue("@cep", func.cep);
                execsql.Parameters.AddWithValue("@endereco", func.endereco);
                execsql.Parameters.AddWithValue("@numero", func.numero);
                execsql.Parameters.AddWithValue("@comp", func.complemento);
                execsql.Parameters.AddWithValue("@bairro", func.bairro);
                execsql.Parameters.AddWithValue("@cidade", func.cidade);
                execsql.Parameters.AddWithValue("@estado", func.uf);

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

        public void ExcluirFunc(int idFuncionario)
        {
            try
            {
                string sql = @"delete from tb_funcionario where id = @id";

                MySqlCommand execsql = new MySqlCommand(sql, conexao);
                execsql.Parameters.AddWithValue("@id", idFuncionario);

                conexao.Open();
                execsql.ExecuteNonQuery();
                conexao.Close();

                MessageBox.Show("O funcionário foi excluído com sucesso", "Sucesso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro durante a execução: " + erro);
            }
           
        }

        public DataTable ListarFunc()
        {
            try
            {
                DataTable tabelaFunc = new DataTable();
                string sql = @"select id as 'Código', nome as 'Nome', rg as 'RG', cpf as 'CPF', email as 'E-mail',
                         senha as 'Senha', cargo as 'Cargo', nivel_acesso as 'Nível', telefone as 'Telefone',
                         celular as 'Celular', cep as 'CEP', endereco as 'Endereço', numero as 'Número', complemento as 'Complemento',
                         bairro as 'Bairro', cidade as 'Cidade', estado as 'Estado' from tb_funcionario";

                MySqlCommand execsql = new MySqlCommand(sql, conexao);

                conexao.Open();
                execsql.ExecuteNonQuery();

                MySqlDataAdapter adapter = new MySqlDataAdapter(execsql);
                adapter.Fill(tabelaFunc);
                conexao.Close();

                return tabelaFunc;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro durante a execução: " + erro);
                return null;
            }            
        }

        public void AlterarFunc(Funcionario func)
        {
            try
            {
                string sql = @"update tb_funcionario set nome = @nome, rg = @rg, cpf = @cpf, email = @email, senha = @senha,
                             cargo = @cargo, nivel_acesso = @nivel_acesso, telefone = @telefone, celular = @celular, cep = @cep,
                             endereco = @endereco, numero = @numero, complemento = @comp, bairro = @bairro, cidade = @cidade, estado = @estado
                             where id = @id";
                MySqlCommand execsql = new MySqlCommand(sql, conexao);
                execsql.Parameters.AddWithValue("@nome", func.nome);
                execsql.Parameters.AddWithValue("@rg", func.rg);
                execsql.Parameters.AddWithValue("@cpf", func.cpf);
                execsql.Parameters.AddWithValue("@email", func.email);
                execsql.Parameters.AddWithValue("@senha", func.senha);
                execsql.Parameters.AddWithValue("@cargo", func.cargo);
                execsql.Parameters.AddWithValue("@nivel_acesso", func.nivel_acesso);
                execsql.Parameters.AddWithValue("@telefone", func.telefone);
                execsql.Parameters.AddWithValue("@celular", func.celular);
                execsql.Parameters.AddWithValue("@cep", func.cep);
                execsql.Parameters.AddWithValue("@endereco", func.endereco);
                execsql.Parameters.AddWithValue("@numero", func.numero);
                execsql.Parameters.AddWithValue("@comp", func.complemento);
                execsql.Parameters.AddWithValue("@bairro", func.bairro);
                execsql.Parameters.AddWithValue("@cidade", func.cidade);
                execsql.Parameters.AddWithValue("@estado", func.uf);

                execsql.Parameters.AddWithValue("@id", func.id);

                conexao.Open();
                execsql.ExecuteNonQuery();
                conexao.Close();

                MessageBox.Show("Dados do funcionário alterados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro durante a execução: " + erro);
            }
        }

        public DataTable ConsultarFunc(string dado, string tipo)
        {
            try
            {
                DataTable tabelaFunc = new DataTable();
                string sql;
                switch (tipo)
                {
                    case "nome":
                        sql = @"select id as 'Código', nome as 'Nome', rg as 'RG', cpf as 'CPF', email as 'E-mail',
                         senha as 'Senha', cargo as 'Cargo', nivel_acesso as 'Nível', telefone as 'Telefone',
                         celular as 'Celular', cep as 'CEP', endereco as 'Endereço', numero as 'Número', complemento as 'Complemento',
                         bairro as 'Bairro', cidade as 'Cidade', estado as 'Estado' from tb_funcionario where nome like @dado";
                        break;
                    default:
                        sql = @"select id as 'Código', nome as 'Nome', rg as 'RG', cpf as 'CPF', email as 'E-mail',
                         senha as 'Senha', cargo as 'Cargo', nivel_acesso as 'Nível', telefone as 'Telefone',
                         celular as 'Celular', cep as 'CEP', endereco as 'Endereço', numero as 'Número', complemento as 'Complemento',
                         bairro as 'Bairro', cidade as 'Cidade', estado as 'Estado' from tb_funcionario where cpf like @dado;";
                        break;
                }

                MySqlCommand execsql = new MySqlCommand(sql, conexao);
                execsql.Parameters.AddWithValue("@dado", dado + "%");

                conexao.Open();
                execsql.ExecuteNonQuery();

                MySqlDataAdapter adapter = new MySqlDataAdapter(execsql);
                adapter.Fill(tabelaFunc);
                conexao.Close();

                return tabelaFunc;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro durante a execução: " + erro);
                return null;
            }
        }

    }
}
