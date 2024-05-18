using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using System.Threading.Tasks;
using GuardOS.Models.Interfaces;

namespace GuardOS.Models.Services
{
    public class Estacionamento
    {
        //Esta parte será para a manipulação de dados durante o atendimento do cliente!
        List<string> VeiculosEstacionados = new List<string>();
        List<string> NomeTitularVeiculo = new List<string>();
        List<string> CPFTitularVeiculo = new List<string>();
        List<decimal> HorasEstacionado = new List<decimal>();
        List<DateTime> HorasEntrada = new List<DateTime>();
        List<DateTime> HorasSaida = new List<DateTime>();
        List<TimeSpan> DiferencaHorasEntrada_Saida = new List<TimeSpan>();
        List<string> ContatoTitular = new List<string>();
        
        public decimal horasEstacionados(string Placa)
        {
            int indice = VeiculosEstacionados.IndexOf(Placa);
            decimal horas = HorasEstacionado[indice];
            return horas;
        }
        public void EntradaVeiculo(string Placa, string NomeTitular, string CPF, string Contato, int Horas)
        {
            VeiculosEstacionados.Add(Placa);
            NomeTitularVeiculo.Add(NomeTitular);
            CPFTitularVeiculo.Add(CPF);
            ContatoTitular.Add(Contato);
            HorasEstacionado.Add(Horas);
            HorasEntrada.Add(DateTime.Now);
        }
        public DateTime SaidaVeiculoRegister(string Placa)
        {
            int indice = VeiculosEstacionados.IndexOf(Placa);
            HorasSaida[indice] = DateTime.Now;
            return HorasSaida[indice];
        }
        public void SaidaVeiculo(string Placa, string NomeTitular, string CPF)
        {
            int indice = VeiculosEstacionados.IndexOf(Placa);
            VeiculosEstacionados.Remove(Placa);
            NomeTitularVeiculo.Remove(NomeTitular);
            CPFTitularVeiculo.Remove(CPF);
            ContatoTitular.Remove(ContatoTitular[indice]);
            HorasEstacionado.Remove(HorasEstacionado[indice]);
        }
        public void ListagemVeiculosEstacionados(List<string> Placas, List<string> Nome, List<string> CPF, List<string> Contato)
        {   
            int i;
            Console.Clear();
            if (Placas.Count > 0)
            {
                VisualInterfaces.Logo();
                VisualInterfaces.QuantosCarrosEstaoEstacionados(Placas.Count);

                Console.WriteLine("N°   - Placa    : CPF             - Contato         - Nome do Titular do Veículo");
                Console.WriteLine("----------------------------------------------------------------------------------");

                for (i = 0; i < Placas.Count; i++)
                {
                    string formattedContato = String.Format("{0:(##)#####-####}", Contato[i]);
                    string formattedCPF = String.Format("{0:###.###.###-##}", CPF[i]);
                    string formattedPlaca = String.Format("{0:###-####}", Placas[i]).ToUpper();
                    Console.WriteLine("{0,-4} - {1,-8} : {2,-15} - {3,-15} - {4}",
                        i + 1, formattedPlaca, formattedCPF, formattedContato, Nome[i].ToUpper());
                }
                VisualInterfaces.PareCodigoPorUmMomento();
            }
            else
            {
                Console.Clear();
                VisualInterfaces.Logo();
                Console.WriteLine("");
                Console.WriteLine("N°   - Placa    : CPF            - Contato        - Nome do Titular do Veículo");
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine($"\nXX - {Placas.Count} Veículos Estacionados - XX");
                VisualInterfaces.PareCodigoPorUmMomento();

            }
        }
        public static List<string> ListaPlacas(Estacionamento NomeClasse)
        {
            List<string> placas = NomeClasse.VeiculosEstacionados;
            return placas;
        }
        public static List<string> ListaNomes(Estacionamento NomeClasse)
        {
            List<string> nomes = NomeClasse.NomeTitularVeiculo;
            return nomes;
        }
        public static List<string> ListaCPF(Estacionamento NomeClasse)
        {
            List<string> cpfs = NomeClasse.CPFTitularVeiculo;
            return cpfs;
        }
        public static List<string> ListaContatos(Estacionamento NomeClasse)
        {
            List<string> contatos = NomeClasse.ContatoTitular;
            return contatos;
        }
        public bool IsNotCPForPhoneNumber(string number11digits)
        {
            bool is11Digits = number11digits.Length == 11;
            if (is11Digits)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool ValidacaoCPF(string Placa, string CPF)
        {
            int indice = VeiculosEstacionados.IndexOf(Placa);
            
            if (CPF == CPFTitularVeiculo[indice])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidacaoNome(string Placa, string Contato)
        {
            int indice = VeiculosEstacionados.IndexOf(Placa);
            
            if (Contato == NomeTitularVeiculo[indice])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VeiculosEstacionadosAgora(string Placa)
        {
            int auxCount = new int();

            for (int n = 0; n < VeiculosEstacionados.Count; n++)
            {
                if (Placa != VeiculosEstacionados[n])
                {
                    auxCount += 0;
                }
                else
                {
                    auxCount += 1;
                }
            }
            
            if (auxCount == 0)
            {
                return false;
            }
            else
            {
                auxCount = 0;
                return true;
            }
        }
        public static decimal ValorSaida(decimal Horas, decimal ValorHora)
        {
            decimal res = (Horas * ValorHora) + 5.19M;
            return res;
        }
    }   
}