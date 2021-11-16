using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Projeto_Venda_ETEC.br.com.projetos.connection
{
    public class ConnectionFactory
    {
        public MySqlConnection getconnection()
        {
            string conexao = ConfigurationManager.ConnectionStrings["bd_vendas"].ConnectionString;
            return new MySqlConnection(conexao);
        }
        
    }
}
