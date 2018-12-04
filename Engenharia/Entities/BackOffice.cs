using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia.Entities
{
    class BackOffice
    {
        [System.ComponentModel.DisplayName("Número da Solicitação")]
        public int num_solicitacao { get; set; }
        [System.ComponentModel.DisplayName("Data da Abertura")]
        public DateTime dtAbertura { get; set; }
        [System.ComponentModel.DisplayName("Status")]
        public string status { get; set; }
    }

    public enum enStatusBackoffice
    {
        [Description("Início")]
        Inicio = 1,
        [Description("Concluído")]
        Concluido = 2,
        [Description("Agendado")]
        Agendado = 3,
        [Description("Sem Sucesso")]
        SemSucesso = 4
    }
}
