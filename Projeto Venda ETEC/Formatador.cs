using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Venda_ETEC
{
    public class Formatador
    {
        public static string UTF8_to_ISO(string value)
        {
            Encoding isoEncoding = Encoding.GetEncoding("ISO-8859-1");
            Encoding utfEncoding = Encoding.UTF8;

            byte[] bytesIso = utfEncoding.GetBytes(value);
            byte[] bytesUtf = Encoding.Convert(utfEncoding, isoEncoding, bytesIso);

            string textoISO = utfEncoding.GetString(bytesUtf);

            return textoISO;
        }
        public static string FormatarCPF(string cpf)
        {

            string cpfform = cpf.Trim();
            if (cpfform.Length == 11)
            {
                cpfform = cpfform.Insert(9, "-");
                cpfform = cpfform.Insert(6, ".");
                cpfform = cpfform.Insert(3, ".");
            }

            return cpfform;
        }

        public static string FormatarCNPJ(string cnpj)
        {
            string cnpjform = cnpj.Trim();
            if(cnpjform.Length == 14)
            {
                cnpjform = cnpjform.Insert(12, "-");
                cnpjform = cnpjform.Insert(8, "/");
                cnpjform = cnpjform.Insert(5, ".");
                cnpjform = cnpjform.Insert(2, ".");
            }

            return cnpjform;
        }

        public static string FormatarRG(string rg)
        {
            string rgform = rg;

            rgform = rgform.Replace(".", "");
            rgform = rgform.Replace("-", "");
            rgform = rgform.Trim();
            if (rgform.Length == 9)
            {
                rgform = rgform.Insert(8, "-");
                rgform = rgform.Insert(5, ".");
                rgform = rgform.Insert(2, ".");
                return rgform;
            }
            else
            {
                MessageBox.Show("Insira o RG corretamente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }
            
            
        }

        public static string FormatarTel_Cel(string tel_cel, string tipo)
        {
            string tel_celform = tel_cel;
            tel_celform = tel_celform.Replace("(", "");
            tel_celform = tel_celform.Replace(")", "");
            tel_celform = tel_celform.Replace("-", "");
            tel_celform = tel_celform.Trim();

            if (tel_celform.Length == 11)
            {
                tel_celform = tel_celform.Insert(7, "-");
                tel_celform = tel_celform.Insert(2, ")");
                tel_celform = tel_celform.Insert(0, "(");
                return tel_celform;
            }
            else if(tel_celform.Length == 10)
            {
                tel_celform = tel_celform.Insert(6, "-");
                tel_celform = tel_celform.Insert(2, ")");
                tel_celform = tel_celform.Insert(0, "(");
                return tel_celform;
            }
            else
            {
                if(tel_celform.Length == 0)
                {
                    return "none";
                }
                else
                {
                    MessageBox.Show("Insira o número do " + tipo + " corretamente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return "";
                }

            }
        }

        public static string FormataCEP(string cep)
        {
            string cepform = cep;
            cepform = cepform.Replace("-", "");
            cepform = cepform.Trim();
            if (cepform.Length == 8)
            {
                cepform = cepform.Insert(5, "-");
                return cepform;
            }
            else
            {
                MessageBox.Show("Insira o número do cep corretamente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }

            
        }
    }
}
