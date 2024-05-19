using System.Reflection;
using GuardOS.Models;
using GuardOS.Models.UserInterface; // Aqui estão armazenadas as Funcionalidades do Programa!
using GuardOS.Models.Interfaces; // As Interfaces de Usuário (UI) estão armazenadas nesta classe!

namespace GuardOS.Program;

public class Program 
{
    public static void Main (string [] args)
    {
        int MenuConsole;
        bool estaLigado = true;
        while (estaLigado == true)
        {
        //vvv Exibição de UI vvv
        Console.Clear();
        VisualInterfaces.Logo();
        VisualInterfaces.HomePage();
        //^^^^^^^^^^^^^^^^^^^^^^

        //Sensor de Inicialização do Sistema
        MenuConsole = Convert.ToInt32(Console.ReadLine());

            // Seletor e redirecionador de Funções
        switch (MenuConsole)
            {
                case 1:
                //Redireciona para o Autoatendimento
                VisualInterfaces.Redirecionamento("Login de Autoatendimento");
                ProgramaPrincipal.Iniciar();
                break;

                case 2:
                VisualInterfaces.Redirecionamento("About Me Page");
                VisualInterfaces.AboutMePage();
                break;

                case 0:
                //Encerra o Programa.
                Console.WriteLine("\nXXXX Encerrando Guard OS XXXX\n");
                Console.WriteLine("Pressione a tecla Enter para prosseguir>>>");
                Console.ReadLine();
                Console.WriteLine("\n XX - Programa Encerrado - XX \n");
                
                estaLigado = false;
                break;

                default:
                //Redirect Incorrect Sintax
                break;
            }
        }
    }
}