using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engenharia
{
    public partial class BO : Form
    {

        public static string respostaFunc = "";
        public static string analiseFunc = "";
        //Criaremos variáveis do tipo string para adicionarmos elas no txtAnalise no fim das análises
        private string fase1;
        private string fase2;
        private string fase3;
        private string fase4;
        private string fase5;

        /*  Vamos usar essa variável pra detectar em qual fase da análise estamos. 
         *  Por enquanto ela não recebe valor, mas ao clicar no botão "Fazer Análise" ela irá 
         *  receber o valor 1. 
         *  
         *  Método que faz uso: fazerAnaliseButton_Click.
         */
        private int faseDaAnalise;

        /* statusAnalise será usada para o controle do Do While, já que o switch não permite um switch sem break;
         * Ficou meio confusa esta explicação então é só me perguntar o porquê dessa variável se tiver dúvidas */
        private bool statusAnalise;

        //Vamos criar uma variável para nos auxiliar no campo descrição. Vai ficar mais claro no método:
        //txtDescricao_TextChanged.        
        private string novaDescricao;

        public BO()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BO_Load(object sender, EventArgs e)
        {
            Dashboard f2 = new Dashboard();

            f2.FormClosed += (ev, args) =>
            {
                this.Show();
            };

            var numSoliti = Dashboard.solicitacaoNum;
            var result = dbAccess.callSql("SELECT * FROM backoffice where num_solicitacao=" + numSoliti);
            var resultKeys = result[0];

            var num_conta = Convert.ToString(resultKeys["num_conta"]);
            var num_solicitacao = Convert.ToString(resultKeys["num_solicitacao"]);
            var dt_abertura = Convert.ToDateTime(resultKeys["dt_abertura"]);
            var descricao = Convert.ToString(resultKeys["descricao"]);

            var resultConta = dbAccess.callSql("SELECT num_agencia, CPF FROM conta where num_conta=" + num_conta);
            var resultContaKeys = resultConta[0];

            var num_agencia = Convert.ToString(resultContaKeys["num_agencia"]);
            var CPF = Convert.ToString(resultContaKeys["CPF"]);

            var resultTelefone = dbAccess.callSql("SELECT * FROM telefone WHERE cpf = '" + CPF + "'");
            
            var resultTelefoneKeys1 = resultTelefone[0];

            if (resultTelefone.Count < 2)
            {
                checkTel2.Visible = false;
            }
            else
            {
                var resultTelefoneKeys2 = resultTelefone[1];
                var telefone2 = Convert.ToString(resultTelefoneKeys2["telefone"]);
                checkTel2.Text = telefone2;
            }

            var telefone1 = Convert.ToString(resultTelefoneKeys1["telefone"]);
            
            var resultNome = dbAccess.callSql("SELECT nome FROM cliente where cpf='" + CPF + "'");
            var resultNomeKeys = resultNome[0];

            var nome = Convert.ToString(resultNomeKeys["nome"]);

            lblNome.Text = nome;
            lblConta.Text = num_conta;
            lblBO.Text = num_solicitacao;
            lblData.Text = dt_abertura.ToShortDateString();
            lblHora.Text = dt_abertura.ToShortTimeString();
            lblAgencia.Text = num_agencia;
            lblCPF.Text = CPF;
            checkTel1.Text = telefone1;
            txtDescricao.Text = descricao;


        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            BO_Historico viewHistorico = new BO_Historico();
            viewHistorico.Show();
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (txtResposta.Text == "")
            {
                MessageBox.Show("Para concluir o atendimento é obrigatório o preenchimento do campo de resposta");
            }
            else if (txtAnalise.Text == "")
            {
                MessageBox.Show("Para concluir o atendimento é obrigatório a realização da análise");
            }
            else
            {
                respostaFunc = txtResposta.Text;
                analiseFunc = txtAnalise.Text;
                BO_Concluir viewConcluir = new BO_Concluir();
                viewConcluir.Show();
            }
            
        }

        private void btnAnalise_Click(object sender, EventArgs e)
        {
            /*  Aqui atribuímos o valor 1 à variável faseDaAnalise e iremos aumentá-lo de 1 em 1 conforme
                avançar-mos as fases.*/
            faseDaAnalise = 1;

            do
            {
                /*  Optei por usar 
                *  um switch ao invés de if porque daí não precisaremos passar por todas as fases caso
                *  a verificação falhe já na primeira. 
                */
                switch (faseDaAnalise)
                {
                    case 1:
                        /*  
                         *  Caso verificado: 1 - Verificar se entre a data e horário da solicitação a chave de segurança
                         *  já foi cadastrada. Caso tenha sido, o analista encerra a solicitação sem
                         *  contato.
                         *  
                         *  Primeiro criamos uma variável para receber a data de criação da chave de segurança.
                         *  Esta data está na tabela "historico_chaveseg" com o nome de "dt_hora_cadastro"
                         */

                        var resultChave = dbAccess.callSql("SELECT dt_hora_cadastro, cpf FROM historico_chaveseg where cpf='" + lblCPF.Text + "'");
                        var resultChaveKeys = resultChave[0];

                        DateTime dataCadastroChaveSeg = DateTime.Parse(resultChaveKeys["dt_hora_cadastro"].ToString());
                        DateTime dataCadastroUsuario = DateTime.Parse(lblData.Text);
                        //Agora verificamos se a chave de segurança foi cadastrada em uma data posterior ou igual à data de
                        //solicitação do chamado(lblData). Se sim, exibimos uma mensagem, se não, incrementamos a variável faseDaAnalise
                        //para que o próximo case rode.
                        if (dataCadastroChaveSeg >= dataCadastroUsuario)
                        {
                            fase1 = "Fase 1 - Chave já cadastrada, encerre o chamado.";

                            /*  Agora passamos o valor falso para statusAnalise para que ela saia do Do While e encerre o programa
                                Iremos fazer isto para todas as verificações.   */
                            statusAnalise = false;
                            break;
                        }
                        else
                        {
                            fase1 = "Fase 1 - Recusada";
                            faseDaAnalise++;
                            goto case 2;
                        }
                        
                    case 2:
                        /*
                         *  Caso verificado: 2 – Caso contrário, verificar os telefones no cadastro de clientes e se eles
                         *  foram cadastrados há mais de 30 dias. Bater as informações com os
                         *  números de contato deixados no BackOffice, se corresponderem aos
                         *  mesmos números, tentar contato. Se esses telefones não coincidirem,
                         *  continuar com a análise.  
                         *  
                         *  Primeiro criamos uma var que acessa a lista de telefones no cadastro de clientes. 
                         *  O campo que iremos acessar é o campo "telefone" da tabela "telefone"
                         */

                        var listaTelefonesClientes = dbAccess.callSql("SELECT * FROM telefone WHERE cpf = '" + lblCPF.Text + "'");

                        var resultTelefoneKeys1 = listaTelefonesClientes[0];
                        var resultTelefoneKeys2 = listaTelefonesClientes[1];

                        /*  
                         *  Aqui verificamos se o resultado é vazio, igual ao feito no login. Se for vazio
                         *  incrementamos a variável faseDaAnalise e passamos para o próximo case. 
                         *  Se não estiver vazio iremos verificar os resultados para ver se são iguais aos telefones
                         *  deixados no backoffice.
                        */
                        if (listaTelefonesClientes.Count == 0)
                        {
                            txtAnalise.Text = "Nenhum dos números informados passou nas verificações de segurança!";
                            break;
                        }
                        else
                        {
                            /*
                             * Se não for vazia iremos varrer a lista verificando se o número corresponde à algum
                             * dos números do backoffice. Se corresponder iremos verificar se foram cadastrados
                             * há mais de 30 dias
                             */
                            for (int x = 0; x < listaTelefonesClientes.Count; x++)
                            {
                                var telEspecifico = listaTelefonesClientes[x];
                                if (Convert.ToString(telEspecifico["telefone"]) == checkTel1.Text)
                                {
                                    //Se passar na verificação marcamos a checkbox como true.
                                    checkTel1.Checked = true;
                                    statusAnalise = false;
                                }
                                else if (Convert.ToString(telEspecifico["telefone"]) == checkTel2.Text)
                                {
                                    checkTel2.Checked = true;
                                    statusAnalise = false;
                                }

                            }

                            if (checkTel1.Checked || checkTel2.Checked)
                            {
                                statusAnalise = false;
                                fase2 = "Fase 2 - Um ou mais números que o cliente informou passaram na fase 2 da análise.";
                                break;
                            }
                            else
                            {
                                fase2 = "Fase 2 - Nenhum telefone corresponde ao CPF do cliente e foi cadastrado há mais de 30 dias.";
                                goto case 3;
                            }

                        }
                    case 3:
                        //
                        //    Caso verificado: 3 – Verificar na base de telefones de referência deixados pelo cliente em
                        //    sua agência detentora de conta. Bater as informações com os números
                        //    de contato deixados no BackOffice, se corresponderem aos mesmos
                        //    números, tentar contato. Se esses telefones não coincidirem, continuar
                        //    com a análise.
                        //     
                        //    Primeiro vamos pegar os cod_referencia vinculados ao cpf do cliente na tabela 
                        //    referencia_contato
                        var codReferenciaContato = dbAccess.callSql("SELECT cod_referencia FROM referencia_contato where cpf='" + lblCPF.Text + "'");

                        //Agora pegamos uma lista dos cod_referencia não vazios na tabela telefone
                        var codReferencia = dbAccess.callSql("SELECT cod_referencia FROM telefone where cpf='" + lblCPF.Text + "' and cod_referencia != null");

                        //E uma lista que recebe os telefones que estão com o cod_referencia não vazio
                        var telefoneCodReferencia = dbAccess.callSql("SELECT telefone FROM telefone where cod_referencia != null");


                        //Agora pesquisamos na tabela telefone os telefones que estão vinculados a estes
                        //códigos de referência verificamos se eles são iguais aos do backoffice
                        if (telefoneCodReferencia.Count == 0)
                        {
                            break;
                        }
                        else
                        {
                            for (int x = 0; x < codReferenciaContato.Count; x++)
                            {
                                var referenciaEspecificoContato = codReferenciaContato[x];

                                for (int y = 0; y < codReferencia.Count; y++)
                                {
                                    var referenciaEspecifico = codReferencia[y];
                                    var referenciaCodTel = telefoneCodReferencia[y];

                                        if (Convert.ToInt32(referenciaEspecifico["cod_referencia"]) == Convert.ToInt32(referenciaEspecificoContato["cod_referencia"]))
                                    {
                                        if (Convert.ToString(referenciaCodTel["telefone"]) == checkTel1.Text)
                                        {
                                            checkTel1.Checked = true;
                                        }
                                        else if (Convert.ToString(referenciaCodTel["telefone"]) == checkTel2.Text)
                                        {
                                            checkTel2.Checked = true;
                                        }
                                    }
                                }
                            }
                        }

                        //Se um dos dois números estiver OK encerramos e o atendente entra em contato. Do contrário
                        //vai para a próxima fase
                        if (checkTel1.Checked || checkTel2.Checked)
                        {
                            statusAnalise = false;
                            fase3 = "Fase 3 - Um ou mais números passaram na fase 3 da análise.";
                            break;
                        }
                        else
                        {
                            fase3 = "Fase 3 - Não existe nenhum telefone de referência de acordo com as regras.";
                            goto case 4;
                        }

                        

                    case 4:
                        //Caso verificado: 4 – Verificar base de recarga de celular vinculada a conta do cliente.
                        //Procurar telefones recarregados há mais de 30 dias.Bater as
                        //informações com os números de contato deixados no BackOffice, se
                        //corresponderem aos mesmos números, tentar contato.Se esses
                        //telefones não coincidirem, continuar com a análise.
                        //
                        //Vamos criar uma variável que irá receber os telefones da tabela "recarga_celular"
                        //que estão vinculados ao número da conta do cliente e que foram recarregados há
                        //pelo menos 30 dias

                        var telefonesRecarregados = dbAccess.callSql("SELECT telefone FROM recarga_celular where num_conta = " + lblConta.Text + "");

                        //Agora varremos esta lista e verificamos se algum deles bate com algum do backoffice
                        if (telefonesRecarregados.Count == 0)
                        {
                            break;
                        }
                        else
                        {
                            for (int x = 0; x < telefonesRecarregados.Count; x++)
                            {
                                var telRecarregadosRef = telefonesRecarregados[x];

                                if (Convert.ToString(telRecarregadosRef["telefone"]) == checkTel1.Text)
                                {
                                    checkTel1.Checked = true;
                                }
                                else if (Convert.ToString(telRecarregadosRef["telefone"]) == checkTel2.Text)
                                {
                                    checkTel2.Checked = true;
                                }
                            }
                        }

                        if (checkTel1.Checked || checkTel2.Checked)
                        {
                            statusAnalise = false;
                            fase4 = "Fase 4 - Um ou mais telefones foram recarregados há pelo menos 30 dias com essa conta";
                            break;
                        }
                        else
                        {
                            fase4 = "Fase 4 - Nenhum telefone foi recarregado há pelo menos 30 dias com essa conta";
                            goto case 5;
                        }

                        
                    case 5:
                        //Caso verificado: 5 – Verificar a base de identificador de chamadas(BINA) por números
                        //que entraram em contato com a central nos últimos cinco anos e há pelo
                        //menos 30 dias.Bater as informações com os números de contato
                        //deixados no BackOffice, se corresponderem aos mesmos números,
                        //tentar contato.Se esses telefones não coincidirem, continuar com a
                        //análise.
                        //
                        //Criamos uma variável que irá receber telefones da tabela "bina" que possuem uma data
                        //de contato dos últimos 5 anos e há pelo menos 30 dias

                        var telefonesBina = dbAccess.callSql("SELECT dt_hora, telefone FROM bina");

                        //Agora varremos esta lista e verificamos se algum número bate com os do backOffice
                        if (telefonesBina.Count == 0)
                        {
                            break;
                        }
                        else
                        {
                            for (int x = 0; x < telefonesBina.Count; x++)
                            {

                                var refRecarregadosTel = telefonesBina[x];
                                DateTime dateBina = DateTime.Parse(refRecarregadosTel["dt_hora"].ToString());

                                if ((Convert.ToString(refRecarregadosTel["telefone"]) == checkTel1.Text) && ((DateTime.Now.Month >= dateBina.Year + 5) || ((DateTime.Now.Month >= dateBina.Year + 5) && (dateBina.Month > DateTime.Now.Month))))
                                {
                                    checkTel1.Checked = true;
                                }
                                else if ((Convert.ToString(refRecarregadosTel["telefone"]) == checkTel2.Text) && ((DateTime.Now.Month >= dateBina.Year + 5) || ((DateTime.Now.Month >= dateBina.Year + 5) && (dateBina.Month > DateTime.Now.Month))))
                                {
                                    checkTel2.Checked = true;
                                }
                            }
                        }

                        if (checkTel1.Checked || checkTel2.Checked)
                        {
                            statusAnalise = false;
                            fase5 = "Fase 5 - Um ou mais telefones foram aprovados na fase 5 da análise.";
                        }
                        else
                        {
                            fase5 = "Nenhum telefone entrou em contato há no máximo 5 anos e há pelo menos 30 dias";
                        }
                        break;
                    default:
                        txtAnalise.Text = "Nenhum dos números informados passou nas verificações de segurança!";
                        statusAnalise = false;
                        break;
                }
            } while (statusAnalise);

            txtAnalise.Text = fase1 + "\r\n" + fase2 + "\r\n" + fase3 + "\r\n" + fase4 + "\r\n" + fase5;
        }
    }
}
