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
using GuardOS.Models.UserCredentials;
using System.Data.SqlTypes;
using System.Reflection.PortableExecutable; // Aqui estão armazenados os serviços do GuardOS

namespace GuardOS.Models.UserInterface
{
    //Submenu Após o Login (Programa em Si)
    public class ProgramaPrincipal
    {
        //Método de Inicialização de Serviço de Automação
        public static void Iniciar()
        {   
            Credentials Admin = new() // Gênero / Gender : Sem Atriuição / No Atribution
            {
                Nome = "Administrador",
                Login = "admin",
                Password = "adminuserlogin",
                Gender = "s/n"
            };
            Credentials User1 = new() // Gênero / Gender : Homem / Male
            {
                Nome = "User1",
                Login = "user1example",
                Password = "user1pass",
                Gender = "o"
            };
            Credentials User2 = new() // Gênero / Gender : Mulher / Female
            {
                Nome ="User2",
                Login = "user2example",
                Password = "user2pass",
                Gender = "a",
            };

            Credentials SecStep1 = new Credentials();

            Console.Clear();
            VisualInterfaces.LoginLogo();

            // vvv Exibição de UI vvv
            VisualInterfaces.LoginAssets();
            // ^^^^^^^^^^^^^^^^^^^^^^

            //Inserção de Login do Usuário
            SecStep1.Login = Console.ReadLine();

            if (SecStep1.Login == "0") 
            {
                Console.WriteLine("XX - Redirecionando para Menu - XX");
            } 
            else
            {
                // vvv Exibição de UI vvv
                Console.Clear();
                VisualInterfaces.LoginLogo();
                VisualInterfaces.PasswordAssets();
                // ^^^^^^^^^^^^^^^^^^^^^^

                //Inserção de Senha
                SecStep1.Password = Console.ReadLine();
                decimal PrecoHora;
                decimal PrecoTaxa;

                
                if (SecStep1.VerifyCredentialsRef(SecStep1, Admin))
                {
                    //Insere o Valor do Estacionamento naquele dia.
                    // vvv Exibição de UI vvv
                    VisualInterfaces.PricePerHourAssets();
                    // ^^^^^^^^^^^^^^^^^^^^^^

                    PrecoHora = Convert.ToDecimal(Console.ReadLine());

                    VisualInterfaces.PriceTaxAssets();

                    PrecoTaxa = Convert.ToDecimal(Console.ReadLine());
                    SecStep1.Nome = Admin.Nome;

                    //Inicia o Programa de Automação
                    VisualInterfaces.Redirecionamento("Autoatendimento");
                    ProgramaPrincipal.UIProgramAutomation(SecStep1.Login, SecStep1.Nome, SecStep1.Password, SecStep1.Gender, PrecoHora, PrecoTaxa);
                }
                else if (SecStep1.VerifyCredentialsRef(SecStep1, User1))
                {
                    //Insere o Valor do Estacionamento naquele dia.
                    // vvv Exibição de UI vvv
                    VisualInterfaces.PricePerHourAssets();
                    // ^^^^^^^^^^^^^^^^^^^^^^

                    PrecoHora = Convert.ToDecimal(Console.ReadLine());

                    VisualInterfaces.PriceTaxAssets();

                    PrecoTaxa = Convert.ToDecimal(Console.ReadLine());
                    SecStep1.Nome = User1.Nome;

                    //Inicia o Programa de Automação
                    VisualInterfaces.Redirecionamento("Autoatendimento");
                    ProgramaPrincipal.UIProgramAutomation(SecStep1.Login, SecStep1.Nome, SecStep1.Password, SecStep1.Gender, PrecoHora, PrecoTaxa);
                }
                else if (SecStep1.VerifyCredentialsRef(SecStep1, User2))
                {
                    //Insere o Valor do Estacionamento naquele dia.
                    // vvv Exibição de UI vvv
                    VisualInterfaces.PricePerHourAssets();
                    // ^^^^^^^^^^^^^^^^^^^^^^

                    PrecoHora = Convert.ToDecimal(Console.ReadLine());

                    VisualInterfaces.PriceTaxAssets();

                    PrecoTaxa = Convert.ToDecimal(Console.ReadLine());
                    SecStep1.Nome = User1.Nome;

                    //Inicia o Programa de Automação
                    VisualInterfaces.Redirecionamento("Autoatendimento");
                    ProgramaPrincipal.UIProgramAutomation(SecStep1.Login, SecStep1.Nome, SecStep1.Password, SecStep1.Gender, PrecoHora, PrecoTaxa);
                }
                else 
                {
                    VisualInterfaces.ErrorLogin();

                }  
            }
        }

        public static void UIProgramAutomation(string commLogin, string commName, string commPass, string commGender, decimal commPrecoHora, decimal commPrecoTaxa)
        {
            Estacionamento EstacionamentoAgora = new Estacionamento();

            bool RunProgram;
            if (commLogin != "" && commName != "" ){RunProgram = true;} else {RunProgram = false;} //Define se o Loop do Programa inicia ou não.
            List<DateTime> InicioHora = new List<DateTime>();
            DateTime FinalHora = new DateTime();
            List<ModuloHora> HoraAgora = new List<ModuloHora>();

            while (RunProgram)
            {
                // vvv Exibição de UI vvv
                Console.Clear();
                VisualInterfaces.LogoAutomacao();
                VisualInterfaces.HomePageAutomacao(commName, commGender, commPrecoHora, commPrecoTaxa);
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
                    int EntradaValorHora;

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
                        EntradaValorHora = Convert.ToInt32(Console.ReadLine()); 


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
                        else if (EntradaValorHora == 0)
                        {
                            VisualInterfaces.ErroDigitacao("Hora", "a");
                            VisualInterfaces.PareCodigoPorUmMomento();
                        }
                        else
                        {
                            VisualInterfaces.Sucesso("Operação");
                            EstacionamentoAgora.EntradaVeiculo(EntradaValorPlaca, EntradaValorNome, EntradaValorCPF, EntradaValorContato, EntradaValorHora);
                            VisualInterfaces.PareCodigoPorUmMomento();
                            InicioHora.Add(DateTime.Now);
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
                                    Console.Clear();
                                    int indice = EstacionamentoAgora.ReturnIndex(SaidaValorPlaca);
                                    FinalHora = DateTime.Now;
                                    decimal HoraUsuario = EstacionamentoAgora.GetHoursbyIndex(EstacionamentoAgora, indice);
                                    decimal DescontoExcedente = ModuloHora.CalculoDescontoExcedente(InicioHora, FinalHora, HoraUsuario, indice); 
                                    decimal x = Estacionamento.ValorSaida(EstacionamentoAgora.horasEstacionados(SaidaValorPlaca), commPrecoHora, commPrecoTaxa, DescontoExcedente);
                                    VisualInterfaces.ValorEstacionamento(x, commPrecoHora, commPrecoTaxa, DescontoExcedente);
                                    VisualInterfaces.SimulacaoPago();
                                    VisualInterfaces.Sucesso("Operação");
                                    EstacionamentoAgora.SaidaVeiculo(SaidaValorPlaca, SaidaValorNome, SaidaValorCPF);
                                    VisualInterfaces.Agradecimento();
                                    VisualInterfaces.PareCodigoPorUmMomento();
                                    SaidaAtivado = false;
                                break;

                                case "n":
                                SaidaAtivado = false;
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
                        List<decimal> Horas = EstacionamentoAgora.TodasHorasEstacionado(EstacionamentoAgora);

                        EstacionamentoAgora.ListagemVeiculosEstacionados(Placas, Nomes, CPFS, Contatos, InicioHora, Horas);
                    break;

                    case "0": // Sistema Logoff
                    bool Exit = ProgramaPrincipal.Sair(commLogin, commPass); //Método de validação de saída

                    if (Exit)
                    {
                        VisualInterfaces.Encerramento("Automação");
                        RunProgram = false;  //Interrompe o Loop do Menu
                    }
                    break;

                    case "4":
                        VisualInterfaces.TabelaDePrecos(commPrecoHora, commPrecoTaxa);
                        VisualInterfaces.PareCodigoPorUmMomento();
                    break;

                    default: // Validação falsa
                    VisualInterfaces.ErroDigitacao("Valor", "o");
                    VisualInterfaces.PareCodigoPorUmMomento();
                    break;
                }
            }
        }

        public static bool Sair(string commLogin, string commPass)
        {
            Console.Clear();
            VisualInterfaces.SairSecaoLogo();
            VisualInterfaces.SairSecao_Login();
            string Login = Console.ReadLine();

            if (Login == "0") {return false;}

            Console.Clear();
            VisualInterfaces.SairSecaoLogo();
            VisualInterfaces.SairSecao_Senha();
            string Senha = Console.ReadLine();

            if (Login == commLogin && Senha == commPass)
            {
                VisualInterfaces.SureExit();
                string selector = Console.ReadLine();

                switch (selector)
                {
                    case "y":
                    return true;
                    
                    case "n":
                    return false;

                    default:
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}