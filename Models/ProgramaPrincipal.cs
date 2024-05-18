using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GuardOS.Models; // Aqui estão armazenadas as Funções Gerais do Programa!
using GuardOS.Program; // Aqui estão armazenados os dados do arquivo inicial do programa!
using GuardOS.Models.Interfaces; // Aqui estão armazenadas as Interfaces Gráficas de Usuário!
using GuardOS.Models.Services;
using System.Data.SqlTypes; // Aqui estão armazenados os serviços do GuardOS

namespace GuardOS.Models.UserInterface
{
    //Submenu Após o Login (Programa em Si)
    public class ProgramaPrincipal
    {
        //Método de Inicialização de Serviço de Automação
        public static void Iniciar()
        {   
            string LoginVerificacaoOficial = "admin";
            string SenhaVerificacaoOficial = "adminuserlogin";
            string NomeVerificacaoOficial = "Cliente";
            decimal MenuInicPrecoHora;
            string Login, Password;

            Console.Clear();
            VisualInterfaces.LoginLogo();

            // vvv Exibição de UI vvv
            VisualInterfaces.LoginAssets();
            // ^^^^^^^^^^^^^^^^^^^^^^

            //Inserção de Login do Usuário
            Login = Console.ReadLine();

            if (Login == "0") 
            {
                Console.WriteLine("XX - Redirecionando para Menu - XX");
            } 
            else
            {
                // vvv Exibição de UI vvv
                Console.WriteLine("\n\n*--------------------------------*\n");
                VisualInterfaces.PasswordAssets();
                // ^^^^^^^^^^^^^^^^^^^^^^

                //Inserção de Senha
                Password = Console.ReadLine();
                            
                if (Login == LoginVerificacaoOficial && Password == SenhaVerificacaoOficial)
                {
                    //Insere o Valor do Estacionamento naquele dia.
                    // vvv Exibição de UI vvv
                    
                    VisualInterfaces.PricePerHourAssets();
                    // ^^^^^^^^^^^^^^^^^^^^^^

                    MenuInicPrecoHora = Convert.ToDecimal(Console.ReadLine());

                    //Inicia o Programa de Automação
                    VisualInterfaces.Redirecionamento("Autoatendimento");
                    ProgramaPrincipal.UIProgramAutomation(Login, NomeVerificacaoOficial, Password, MenuInicPrecoHora);
                }   
                else 
                {
                    VisualInterfaces.ErrorLogin();

                }  
            }
        }

        public static void UIProgramAutomation(string commLogin, string commName, string commPass, decimal commPrecoHora)
        {
            Estacionamento EstacionamentoAgora = new Estacionamento();

            bool Automacao;

            if (commName != "")
            {
                Automacao = true;
            } 
            else 
            {
                Automacao = false;
            }

            while (Automacao == true)
            {
                // vvv Exibição de UI vvv
                Console.Clear();
                VisualInterfaces.LogoAutomacao();
                VisualInterfaces.HomePageAutomacao();
                // ^^^^^^^^^^^^^^^^^^^^^^

                //Seletor de Menu
                string AutoMenu = Console.ReadLine();

                //Redirecionamento de Menu Selecionado.
                switch (AutoMenu)
                {
                    case "1": //Entrada de Veículos Estacionados.
                        //Inicia a Interface de Verificação de Dados
                        /*XX - Nota - XX
                        Se os dados digitados pelo usuário não corresponderem corretamente suas respectivas
                        formatações, não será feita a listagem dos dados na lista principal!
                        Do contrário, se TODOS os dados forem digitados corretamente, o código enviará os
                        dados para a lista principal! 
                        */

                    bool EntradaAtivado = true;
                    string EntradaValorPlaca;
                    string EntradaValorNome;
                    string EntradaValorCPF;
                    string EntradaValorContato;
                    string EntradaValorHora;

                    while (EntradaAtivado)
                    {
                        Console.Clear();
                        VisualInterfaces.InterfaceEntradaLogo();
                        VisualInterfaces.EntradaPlaca();
                        EntradaValorPlaca = Console.ReadLine().ToUpper();
                        Console.Clear();
                        VisualInterfaces.InterfaceEntradaLogo();
                        VisualInterfaces.EntradaNome();
                        EntradaValorNome = Console.ReadLine().ToUpper();
                        Console.Clear();
                        VisualInterfaces.InterfaceEntradaLogo();
                        VisualInterfaces.EntradaCPF();
                        EntradaValorCPF = Console.ReadLine();
                        Console.Clear();
                        VisualInterfaces.InterfaceEntradaLogo();
                        VisualInterfaces.EntradaContato();
                        EntradaValorContato = Console.ReadLine();
                        Console.Clear();
                        VisualInterfaces.InterfaceEntradaLogo();
                        VisualInterfaces.EntradaHora();
                        EntradaValorHora = Console.ReadLine(); 


                        if (EntradaValorPlaca == "")
                        {
                            VisualInterfaces.ErroDigitacao("Placa", "a");
                            VisualInterfaces.PareCodigoPorUmMomento();
                        } 
                        else if (EntradaValorNome == "")
                        {
                            VisualInterfaces.ErroDigitacao("Nome", "o");
                            VisualInterfaces.PareCodigoPorUmMomento();
                        }
                        else if (EstacionamentoAgora.IsNotCPForPhoneNumber(EntradaValorCPF))
                        {
                            VisualInterfaces.ErroDigitacao("Número de CPF", "o");
                            VisualInterfaces.PareCodigoPorUmMomento();
                        }
                        else if (EstacionamentoAgora.IsNotCPForPhoneNumber(EntradaValorContato))
                        {
                            VisualInterfaces.ErroDigitacao("Número de Telefone", "o");
                            VisualInterfaces.PareCodigoPorUmMomento();
                        }
                        else if (EntradaValorHora == "")
                        {
                            VisualInterfaces.ErroDigitacao("Hora", "a");
                            VisualInterfaces.PareCodigoPorUmMomento();
                        }
                        else
                        {
                            VisualInterfaces.Sucesso("Operação");
                            EstacionamentoAgora.EntradaVeiculo(EntradaValorPlaca, EntradaValorNome, EntradaValorCPF, EntradaValorContato, Convert.ToInt32(EntradaValorHora));
                            EntradaAtivado = false;
                        }
                    }


                    break;

                    case "2": //Saída de Veículos Estacionados.

                    bool SaidaAtivado = true;
                    string SaidaValorPlaca;
                    string SaidaValorNome;
                    string SaidaValorCPF;

                    while (SaidaAtivado)
                    {
                        Console.Clear();
                        VisualInterfaces.InterfaceSaidaLogo();
                        VisualInterfaces.EntradaPlaca();
                        SaidaValorPlaca = Console.ReadLine().ToUpper();
                        Console.Clear();
                        VisualInterfaces.InterfaceSaidaLogo();
                        VisualInterfaces.EntradaNome();
                        SaidaValorNome = Console.ReadLine().ToUpper();
                        Console.Clear();
                        VisualInterfaces.InterfaceSaidaLogo();
                        VisualInterfaces.EntradaCPF();
                        SaidaValorCPF = Console.ReadLine();

                        if (!EstacionamentoAgora.VeiculosEstacionadosAgora(SaidaValorPlaca))
                        {
                            VisualInterfaces.ErroDigitacao("Placa", "a");
                            VisualInterfaces.PareCodigoPorUmMomento();
                        } 
                        else if (!EstacionamentoAgora.ValidacaoNome(SaidaValorPlaca, SaidaValorNome))
                        {
                            VisualInterfaces.ErroDigitacao("Nome", "o");
                            VisualInterfaces.PareCodigoPorUmMomento();
                        }
                        else if (!EstacionamentoAgora.ValidacaoCPF(SaidaValorPlaca, SaidaValorCPF))
                        {
                            VisualInterfaces.ErroDigitacao("Número de CPF", "o");
                            VisualInterfaces.PareCodigoPorUmMomento();
                        }
                        else
                        {
                            VisualInterfaces.SureExit();
                            string option = Console.ReadLine();

                            switch (option)
                            {
                                case "y":
                                    decimal x = Estacionamento.ValorSaida(EstacionamentoAgora.horasEstacionados(SaidaValorPlaca), commPrecoHora);
                                    VisualInterfaces.ValorEstacionamento(x, commPrecoHora, 5.19M);
                                    VisualInterfaces.SimulacaoPago();
                                    VisualInterfaces.Sucesso("Operação");
                                    EstacionamentoAgora.SaidaVeiculo(SaidaValorPlaca, SaidaValorNome, SaidaValorCPF);
                                    VisualInterfaces.Agradecimento();
                                    VisualInterfaces.PareCodigoPorUmMomento();
                                    SaidaAtivado = false;
                                break;

                                case "n":
                                break;

                                default:
                                break;
                            }
                            
                        }
                    }
                    break;

                    case "3": //Listagem de Veículos Estacionados.
                        VisualInterfaces.Redirecionamento("Listagem de Veículos Estacionados");
                        List<string> Nomes = Estacionamento.ListaNomes(EstacionamentoAgora);
                        List<string> Placas = Estacionamento.ListaPlacas(EstacionamentoAgora);
                        List<string> CPFS = Estacionamento.ListaCPF(EstacionamentoAgora);
                        List<string> Contatos = Estacionamento.ListaContatos(EstacionamentoAgora);

                        EstacionamentoAgora.ListagemVeiculosEstacionados(Placas, Nomes, CPFS, Contatos);
                                                                      //TODO: Consertar isto!!
                    break;

                    case "0": // Falta Fazer o sistema de login para saída!
                    VisualInterfaces.Encerramento("Automação");
                    Automacao = false; //Interrompe o Loop do Menu
                    break;

                    default:
                    VisualInterfaces.ErroDigitacao("Valor", "o");
                    VisualInterfaces.PareCodigoPorUmMomento();
                    break;
                }
            }
        }
    }
}