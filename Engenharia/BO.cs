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
        //Criaremos vari�veis do tipo string para adicionarmos elas no txtAnalise no fim das an�lises
        private string fase1;
        private string fase2;
        private string fase3;
        private string fase4;
        private string fase5;

        /*  Vamos usar essa vari�vel pra detectar em qual fase da an�lise estamos. 
         *  Por enquanto ela n�o recebe valor, mas ao clicar no bot�o "Fazer An�lise" ela ir� 
         *  receber o valor 1. 
         *  
         *  M�todo que faz uso: fazerAnaliseButton_Click.
         */
        private int faseDaAnalise;

        /* statusAnalise ser� usada para o controle do Do While, j� que o switch n�o permite um switch sem break;
         * Ficou meio confusa esta explica��o ent�o � s� me perguntar o porqu� dessa vari�vel se tiver d�vidas */
        private bool statusAnalise;

        //Vamos criar uma vari�vel para nos auxiliar no campo descri��o. Vai ficar mais claro no m�todo:
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
                MessageBox.Show("Para concluir o atendimento � obrigat�rio o preenchimento do campo de resposta");
            }
            else if (txtAnalise.Text == "")
            {
                MessageBox.Show("Para concluir o atendimento � obrigat�rio a realiza��o da an�lise");
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
            /*  Aqui atribu�mos o valor 1 � vari�vel faseDaAnalise e iremos aument�-lo de 1 em 1 conforme
                avan�ar-mos as fases.*/
            faseDaAnalise = 1;

            do
            {
                /*  Optei por usar 
                *  um switch ao inv�s de if porque da� n�o precisaremos passar por todas as fases caso
                *  a verifica��o falhe j� na primeira. 
                */
                switch (faseDaAnalise)
                {
                    case 1:
                        /*  
                         *  Caso verificado: 1 - Verificar se entre a data e hor�rio da solicita��o a chave de seguran�a
                         *  j� foi cadastrada. Caso tenha sido, o analista encerra a solicita��o sem
                         *  contato.
                         *  
                         *  Primeiro criamos uma vari�vel para receber a data de cria��o da chave de seguran�a.
                         *  Esta data est� na tabela "historico_chaveseg" com o nome de "dt_hora_cadastro"
                         */

                        var resultChave = dbAccess.callSql("SELECT dt_hora_cadastro, cpf FROM historico_chaveseg where cpf='" + lblCPF.Text + "'");
                        var resultChaveKeys = resultChave[0];

                        DateTime dataCadastroChaveSeg = DateTime.Parse(resultChaveKeys["dt_hora_cadastro"].ToString());
                        DateTime dataCadastroUsuario = DateTime.Parse(lblData.Text);
                        //Agora verificamos se a chave de seguran�a foi cadastrada em uma data posterior ou igual � data de
                        //solicita��o do chamado(lblData). Se sim, exibimos uma mensagem, se n�o, incrementamos a vari�vel faseDaAnalise
                        //para que o pr�ximo case rode.
                        if (dataCadastroChaveSeg >= dataCadastroUsuario)
                        {
                            fase1 = "Fase 1 - Chave j� cadastrada, encerre o chamado.";

                            /*  Agora passamos o valor falso para statusAnalise para que ela saia do Do While e encerre o programa
                                Iremos fazer isto para todas as verifica��es.   */
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
                         *  Caso verificado: 2 � Caso contr�rio, verificar os telefones no cadastro de clientes e se eles
                         *  foram cadastrados h� mais de 30 dias. Bater as informa��es com os
                         *  n�meros de contato deixados no BackOffice, se corresponderem aos
                         *  mesmos n�meros, tentar contato. Se esses telefones n�o coincidirem,
                         *  continuar com a an�lise.  
                         *  
                         *  Primeiro criamos uma var que acessa a lista de telefones no cadastro de clientes. 
                         *  O campo que iremos acessar � o campo "telefone" da tabela "telefone"
                         */

                        var listaTelefonesClientes = dbAccess.callSql("SELECT * FROM telefone WHERE cpf = '" + lblCPF.Text + "'");

                        var resultTelefoneKeys1 = listaTelefonesClientes[0];
                        var resultTelefoneKeys2 = listaTelefonesClientes[1];

                        /*  
                         *  Aqui verificamos se o resultado � vazio, igual ao feito no login. Se for vazio
                         *  incrementamos a vari�vel faseDaAnalise e passamos para o pr�ximo case. 
                         *  Se n�o estiver vazio iremos verificar os resultados para ver se s�o iguais aos telefones
                         *  deixados no backoffice.
                        */
                        if (listaTelefonesClientes.Count == 0)
                        {
                            txtAnalise.Text = "Nenhum dos n�meros informados passou nas verifica��es de seguran�a!";
                            break;
                        }
                        else
                        {
                            /*
                             * Se n�o for vazia iremos varrer a lista verificando se o n�mero corresponde � algum
                             * dos n�meros do backoffice. Se corresponder iremos verificar se foram cadastrados
                             * h� mais de 30 dias
                             */
                            for (int x = 0; x < listaTelefonesClientes.Count; x++)
                            {
                                var telEspecifico = listaTelefonesClientes[x];
                                if (Convert.ToString(telEspecifico["telefone"]) == checkTel1.Text)
                                {
                                    //Se passar na verifica��o marcamos a checkbox como true.
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
                                fase2 = "Fase 2 - Um ou mais n�meros que o cliente informou passaram na fase 2 da an�lise.";
                                break;
                            }
                            else
                            {
                                fase2 = "Fase 2 - Nenhum telefone corresponde ao CPF do cliente e foi cadastrado h� mais de 30 dias.";
                                goto case 3;
                            }

                        }
                    case 3:
                        //
                        //    Caso verificado: 3 � Verificar na base de telefones de refer�ncia deixados pelo cliente em
                        //    sua ag�ncia detentora de conta. Bater as informa��es com os n�meros
                        //    de contato deixados no BackOffice, se corresponderem aos mesmos
                        //    n�meros, tentar contato. Se esses telefones n�o coincidirem, continuar
                        //    com a an�lise.
                        //     
                        //    Primeiro vamos pegar os cod_referencia vinculados ao cpf do cliente na tabela 
                        //    referencia_contato
                        var codReferenciaContato = dbAccess.callSql("SELECT cod_referencia FROM referencia_contato where cpf='" + lblCPF.Text + "'");

                        //Agora pegamos uma lista dos cod_referencia n�o vazios na tabela telefone
                        var codReferencia = dbAccess.callSql("SELECT cod_referencia FROM telefone where cpf='" + lblCPF.Text + "' and cod_referencia != null");

                        //E uma lista que recebe os telefones que est�o com o cod_referencia n�o vazio
                        var telefoneCodReferencia = dbAccess.callSql("SELECT telefone FROM telefone where cod_referencia != null");


                        //Agora pesquisamos na tabela telefone os telefones que est�o vinculados a estes
                        //c�digos de refer�ncia verificamos se eles s�o iguais aos do backoffice
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

                        //Se um dos dois n�meros estiver OK encerramos e o atendente entra em contato. Do contr�rio
                        //vai para a pr�xima fase
                        if (checkTel1.Checked || checkTel2.Checked)
                        {
                            statusAnalise = false;
                            fase3 = "Fase 3 - Um ou mais n�meros passaram na fase 3 da an�lise.";
                            break;
                        }
                        else
                        {
                            fase3 = "Fase 3 - N�o existe nenhum telefone de refer�ncia de acordo com as regras.";
                            goto case 4;
                        }

                        

                    case 4:
                        //Caso verificado: 4 � Verificar base de recarga de celular vinculada a conta do cliente.
                        //Procurar telefones recarregados h� mais de 30 dias.Bater as
                        //informa��es com os n�meros de contato deixados no BackOffice, se
                        //corresponderem aos mesmos n�meros, tentar contato.Se esses
                        //telefones n�o coincidirem, continuar com a an�lise.
                        //
                        //Vamos criar uma vari�vel que ir� receber os telefones da tabela "recarga_celular"
                        //que est�o vinculados ao n�mero da conta do cliente e que foram recarregados h�
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
                            fase4 = "Fase 4 - Um ou mais telefones foram recarregados h� pelo menos 30 dias com essa conta";
                            break;
                        }
                        else
                        {
                            fase4 = "Fase 4 - Nenhum telefone foi recarregado h� pelo menos 30 dias com essa conta";
                            goto case 5;
                        }

                        
                    case 5:
                        //Caso verificado: 5 � Verificar a base de identificador de chamadas(BINA) por n�meros
                        //que entraram em contato com a central nos �ltimos cinco anos e h� pelo
                        //menos 30 dias.Bater as informa��es com os n�meros de contato
                        //deixados no BackOffice, se corresponderem aos mesmos n�meros,
                        //tentar contato.Se esses telefones n�o coincidirem, continuar com a
                        //an�lise.
                        //
                        //Criamos uma vari�vel que ir� receber telefones da tabela "bina" que possuem uma data
                        //de contato dos �ltimos 5 anos e h� pelo menos 30 dias

                        var telefonesBina = dbAccess.callSql("SELECT dt_hora, telefone FROM bina");

                        //Agora varremos esta lista e verificamos se algum n�mero bate com os do backOffice
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
                            fase5 = "Fase 5 - Um ou mais telefones foram aprovados na fase 5 da an�lise.";
                        }
                        else
                        {
                            fase5 = "Nenhum telefone entrou em contato h� no m�ximo 5 anos e h� pelo menos 30 dias";
                        }
                        break;
                    default:
                        txtAnalise.Text = "Nenhum dos n�meros informados passou nas verifica��es de seguran�a!";
                        statusAnalise = false;
                        break;
                }
            } while (statusAnalise);

            txtAnalise.Text = fase1 + "\r\n" + fase2 + "\r\n" + fase3 + "\r\n" + fase4 + "\r\n" + fase5;
        }
    }
}
