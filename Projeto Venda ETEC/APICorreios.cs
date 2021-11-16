using Correios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Venda_ETEC
{
    class APICorreios
    {
        public string cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string endereco { get; set; }
        public string uf { get; set; }

        public void ConsultarCEP(string cep)
        {
            if (cep.Length < 8)
            {
                MessageBox.Show("Preencha o campo CEP corretamente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    CorreiosApi correiosapi = new CorreiosApi();
                    bairro = correiosapi.consultaCEP(cep).bairro;
                    cidade= correiosapi.consultaCEP(cep).cidade;
                    endereco = correiosapi.consultaCEP(cep).end;
                    uf = correiosapi.consultaCEP(cep).uf;


                }
                catch (Exception)
                {
                    MessageBox.Show("Algo deu errado durante a execução, verifique o CEP e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
