using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Venda_ETEC
{
    public class Municipios
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static List<Municipios> BuscarMunicipios(string UF)
        {
            string estado;

            switch (UF)
            {
                case "AC":
                    estado = "12";
                    break;
                case "AL":
                    estado = "27";
                    break;
                case "AM":
                    estado = "13";
                    break;
                case "AP":
                    estado = "16";
                    break;
                case "BA":
                    estado = "29";
                    break;
                case "CE":
                    estado = "23";
                    break;
                case "DF":
                    estado = "53";
                    break;
                case "ES":
                    estado = "32";
                    break;
                case "GO":
                    estado = "52";
                    break;
                case "MA":
                    estado = "21";
                    break;
                case "MG":
                    estado = "31";
                    break;
                case "MS":
                    estado = "50";
                    break;
                case "MT":
                    estado = "51";
                    break;
                case "PA":
                    estado = "15";
                    break;
                case "PB":
                    estado = "25";
                    break;
                case "PE":
                    estado = "26";
                    break;
                case "PI":
                    estado = "22";
                    break;
                case "PR":
                    estado = "41";
                    break;
                case "RJ":
                    estado = "33";
                    break;
                case "RN":
                    estado = "24";
                    break;
                case "RO":
                    estado = "11";
                    break;
                case "RR":
                    estado = "14";
                    break;
                case "RS":
                    estado = "43";
                    break;
                case "SC":
                    estado = "42";
                    break;
                case "SE":
                    estado = "28";
                    break;
                case "SP":
                    estado = "35";
                    break;
                default:
                    estado = "17";
                    break;
            }
            string url = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/"+estado+"/municipios";
            
            string json = (new System.Net.WebClient()).DownloadString(url);

            var mun = JsonConvert.DeserializeObject<List<Municipios>>(json);

            return mun;
        }


    }
}
