using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardOS.Models.Interfaces
{
    public class VisualInterfaces
    {
        public static void Logo()
        {
            Console.WriteLine(@"

         ░▒▓██████▓▒░░▒▓█▓▒░░▒▓█▓▒░░▒▓██████▓▒░░▒▓███████▓▒░░▒▓███████▓▒░        ░▒▓██████▓▒░ ░▒▓███████▓▒░ 
        ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░        
        ░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░        
        ░▒▓█▓▒▒▓███▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓████████▓▒░▒▓███████▓▒░░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░░▒▓██████▓▒░  
        ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░ 
        ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░ 
         ░▒▓██████▓▒░ ░▒▓██████▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓███████▓▒░        ░▒▓██████▓▒░░▒▓███████▓▒░  
        ");
        }

        public static void LogoAutomacao()
        {
            Console.WriteLine(@"
         █████╗ ████████╗███████╗███╗   ██╗██████╗ ██╗███╗   ███╗███████╗███╗   ██╗████████╗ ██████╗ 
        ██╔══██╗╚══██╔══╝██╔════╝████╗  ██║██╔══██╗██║████╗ ████║██╔════╝████╗  ██║╚══██╔══╝██╔═══██╗
        ███████║   ██║   █████╗  ██╔██╗ ██║██║  ██║██║██╔████╔██║█████╗  ██╔██╗ ██║   ██║   ██║   ██║
        ██╔══██║   ██║   ██╔══╝  ██║╚██╗██║██║  ██║██║██║╚██╔╝██║██╔══╝  ██║╚██╗██║   ██║   ██║   ██║
        ██║  ██║   ██║   ███████╗██║ ╚████║██████╔╝██║██║ ╚═╝ ██║███████╗██║ ╚████║   ██║   ╚██████╔╝
        ╚═╝  ╚═╝   ╚═╝   ╚══════╝╚═╝  ╚═══╝╚═════╝ ╚═╝╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝   ╚═╝    ╚═════╝ 
                                                                                                                     
            ");
        }

        public static void HomePage()
        {
        Console.WriteLine("_______________________________________________________________________________________________________________________");
        Console.WriteLine("\n                    Bem Vindo ao GuardOS, seu Sistema de Estacionamento Inteligente");
        Console.WriteLine("\n \n Selecione a Operação: ");
        Console.WriteLine("\n_______________________________________________________________________________________________________________________");
        Console.WriteLine("\n   1 - Entrada de Programa Principal \n \n   0 - Encerrar Guard OS");
        Console.WriteLine("\n_______________________________________________________________________________________________________________________\n\n>>>");
        }

        public static void HomePageAutomacao(string Nome, string GeneroTerminoVogal)
        {
            switch (GeneroTerminoVogal)
            {
                case "o":
                    Console.WriteLine("\n______________________________________________________________________________________________________________________");
                    Console.WriteLine($"\n               Bem Vindo {Nome} ao Guard OS, seu Sistema de Estacionamento Inteligente");
                    Console.WriteLine("\n \n Selecione a Operação: ");
                    Console.WriteLine("\n_______________________________________________________________________________________________________________________");
                    Console.WriteLine("\n   1 - Entrada de Veículo \n   2 - Saída de Veículo \n   3 - Listagem de Veículos Estacionados \n \n   0 - Voltar");
                    Console.WriteLine("\n_______________________________________________________________________________________________________________________ \n");
                break;

                case "a":
                    Console.WriteLine("\n______________________________________________________________________________________________________________________");
                    Console.WriteLine($"\n               Bem Vinda {Nome} ao Guard OS, seu Sistema de Estacionamento Inteligente");
                    Console.WriteLine("\n \n Selecione a Operação: ");
                    Console.WriteLine("\n_______________________________________________________________________________________________________________________");
                    Console.WriteLine("\n   1 - Entrada de Veículo \n   2 - Saída de Veículo \n   3 - Listagem de Veículos Estacionados \n \n   0 - Voltar");
                    Console.WriteLine("\n_______________________________________________________________________________________________________________________ \n");
                break;

                default:
                    Console.WriteLine("\n______________________________________________________________________________________________________________________");
                    Console.WriteLine($"\n               Bem Vindo {Nome} ao Guard OS, seu Sistema de Estacionamento Inteligente");
                    Console.WriteLine("\n \n Selecione a Operação: ");
                    Console.WriteLine("\n_______________________________________________________________________________________________________________________");
                    Console.WriteLine("\n   1 - Entrada de Veículo \n   2 - Saída de Veículo \n   3 - Listagem de Veículos Estacionados \n \n   0 - Voltar");
                    Console.WriteLine("\n_______________________________________________________________________________________________________________________ \n");
                break;
            }
               
        }

        public static void LoginLogo()
        {
            Console.WriteLine(@"                                                          
    __                  _      
   / /   ____   ____ _ (_)____ 
  / /   / __ \ / __ `// // __ \
 / /___/ /_/ // /_/ // // / / /
/_____/\____/ \__, //_//_/ /_/ 
             /____/            ");
        }

        public static void LoginAssets()
        {
            Console.WriteLine(@"
************************************
*                                  *
*         Digite seu Login         *
*                                  *
************************************
            (Digite 0 para Retornar)
>>>");
        }

        public static void PasswordAssets()
        {
            Console.WriteLine(@"
************************************
*                                  *
*         Digite sua Senha         *
*                                  *
************************************
            
>>>");
        }

        public static void PricePerHourAssets()
        {
            Console.Clear();
            Console.WriteLine(@"
____________________________________________________________________
|                                                                  |
|   Digite o valor da Hora no Estacionamento (Em Reais: '0.00'):   |
|__________________________________________________________________|
    
>>>");
        }

        public static void Redirecionamento(string Situacao)
        {
            Console.WriteLine($"\nXXXX Redirecionando para o Programa de {Situacao} XXXX\n");
            Console.WriteLine("Pressione a tecla Enter para prosseguir>>>");
            Console.ReadLine();
        }

        public static void Encerramento(string Situacao)
        {
            Console.WriteLine($"\nXX - Encerrando para o Programa de {Situacao} - XX\n");
            Console.WriteLine("Digite qualquer tecla para prosseguir>>>");
            Console.ReadLine();
        }

        public static void ErrorLogin()
        {
            Console.WriteLine(@"
<<< Login Incorreto! >>>
            ");
        }
        
        public static void ErroDigitacao(string Situacao, string TerminoVogal)
        {
            //Variável "string TerminoVogal" auxiliar de digitação.
            //Variável "string Situacao" principal de Erro.
            if (TerminoVogal == "o")
            {
            Console.WriteLine($"\n<<< {Situacao} Inválido! >>>\n");
            }
            else if (TerminoVogal == "a")
            {
                Console.WriteLine($"\n<<< {Situacao} Inválida! >>>\n");
            }
        }
        
        public static void Sucesso(string Situacao)
        {
            //Variável "string Situacao" principal de Erro.
            Console.WriteLine($"\n<<< {Situacao} Concluida com sucesso! >>>\n");
        }

        public static void PareCodigoPorUmMomento()
        {
            Console.WriteLine("\nPressione Enter para Prosseguir>>>");
            Console.ReadLine();
        }

        public static void QuantosCarrosEstaoEstacionados(int Quantidade)
        {
            if (Quantidade >= 2)
            {
            Console.WriteLine(@$"
Estão estacionados {Quantidade} Carros no Estacionamento!
");
            }
            else
            {
                Console.WriteLine(@$"
Está estacionado {Quantidade} Carro no Estacionamento!");
            }
        }

        public static void InterfaceEntradaLogo()
        {
            Console.WriteLine(@"
    ______            __                          __            __
   / ____/  ____     / /_   _____   ____ _   ____/ /  ____ _   / /
  / __/    / __ \   / __/  / ___/  / __ `/  / __  /  / __ `/  / / 
 / /___   / / / /  / /_   / /     / /_/ /  / /_/ /  / /_/ /  /_/  
/_____/  /_/ /_/   \__/  /_/      \__,_/   \__,_/   \__,_/  (_)   
");
        }
        
        public static void InterfaceSaidaLogo()
        {
            Console.WriteLine(@"
   _____             __       __            __
  / ___/   ____ _   /_/  ____/ /  ____ _   / /
  \__ \   / __ `/  / /  / __  /  / __ `/  / / 
 ___/ /  / /_/ /  / /  / /_/ /  / /_/ /  /_/  
/____/   \__,_/  /_/   \__,_/   \__,_/  (_)   
");
        }

        public static void Agradecimento()
            {
                Console.WriteLine(@"
   ____   _            _                    _                       _        
  / __ \ | |          (_)                  | |                     | |       
 | |  | || |__   _ __  _   __ _   __ _   __| |  ___    _ __    ___ | |  __ _ 
 | |  | || '_ \ | '__|| | / _` | / _` | / _` | / _ \  | '_ \  / _ \| | / _` |
 | |__| || |_) || |   | || (_| || (_| || (_| || (_) | | |_) ||  __/| || (_| |
  \____/ |_.__/ |_|   |_| \__, | \__,_| \__,_| \___/  | .__/  \___||_| \__,_|
                           __/ |                      | |                    
  _____              __   |___/     //\               |_|       _            
 |  __ \            / _|           |/ \|             (_)       | |           
 | |__) |_ __  ___ | |_  ___  _ __  ___  _ __    ___  _   __ _ | |           
 |  ___/| '__|/ _ \|  _|/ _ \| '__|/ _ \| '_ \  / __|| | / _` || |           
 | |    | |  |  __/| | |  __/| |  |  __/| | | || (__ | || (_| ||_|           
 |_|    |_|   \___||_|  \___||_|   \___||_| |_| \___||_| \__,_|(_)           
                                                                             
");
            }

        public static void EntradaPlaca()
        {
            Console.WriteLine(@"
____________________________________________________________________
|                                                                  |
|                  Digite o Número de sua Placa!                   |
|__________________________________________________________________|
        <<<SOMENTE LETRAS E NÚMEROS, ausentes de símbolos>>>

>>>");
        }

        public static void EntradaNome()
        {
            Console.WriteLine(@"
____________________________________________________________________
|                                                                  |
|                   Digite seu Nome Completo!                      |
|__________________________________________________________________|

>>>");
        }
            
        public static void EntradaCPF()
        {
            Console.WriteLine(@"
____________________________________________________________________
|                                                                  |
|                   Digite o Número do seu CPF!                    |
|__________________________________________________________________|
                      <<<SOMENTE NÚMEROS>>>

>>>");
        }
            
        public static void EntradaContato()
        {
            Console.WriteLine(@"
____________________________________________________________________
|                                                                  |
|                Digite o seu Número de Telefone!                  |
|__________________________________________________________________|
              <<<SOMENTE NÚMEROS, incluindo o DDD>>>

>>>");
        }
        
        public static void EntradaHora()
        {
            Console.WriteLine(@"
____________________________________________________________________
|                                                                  |
|              Quantas Horas Você deseja Estacionar?               |
|__________________________________________________________________|
                 <<<SOMENTE NÚMEROS INTEIROS!>>>

>>>");
        }


       public static void SureExit()
       {
         Console.WriteLine(@"
____________________________________________________________________
|                                                                  |
|                Você tem certeza que deseja sair?                 |
|__________________________________________________________________|
                    <<< y - Sim || n - Não >>>

>>>");
       }

       public static void ValorEstacionamento(decimal Total, decimal ValorHora, decimal valorTarifa)
       {
        Console.WriteLine(@$"
____________________________________________________________________
                                                                  
     Valor P/Hora   -   Valor Tarifa    -   Valor Total de Horas

        {ValorHora:C2}               {valorTarifa:C2}               {Total:C2}             
____________________________________________________________________

Pressione Enter para Pagar>>>");
        Console.ReadLine();
       }
       public static void SimulacaoPago()
       {
        Console.WriteLine(@"
########     ###     ######    #######  
##     ##   ## ##   ##    ##  ##     ## 
##     ##  ##   ##  ##        ##     ## 
########  ##     ## ##   #### ##     ## 
##        ######### ##    ##  ##     ## 
##        ##     ## ##    ##  ##     ## 
##        ##     ##  ######    #######  

Pressione Enter para Continuar>>>");
Console.ReadLine();
       }

    }
}