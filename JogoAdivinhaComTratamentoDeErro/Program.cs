using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace JogoAdivinhaComTratamentoDeErro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaração de variáveis
            int njogador = 0;
            char continuarJogando;
            Random gerador = new Random();
            var tentativas = 0;

            //Boas-vindas
            Console.WriteLine("Bem-vindo ao adivinhador de números! Você quer jogar? Digite S para sim e N para não.");

            //Loop enquanto há jogo
            do
            {

                //Receber a resposta se quer continuar jogando
                continuarJogando = Convert.ToChar(Console.ReadLine());

                //Verificar se o usuário quer jogar/continuar jogando
                do
                {
                    //Caso aceite jogar
                    if (continuarJogando == 'S' || continuarJogando == 's')
                    {
                        break;
                    }

                    //Caso recuse jogar
                    if (continuarJogando == 'N' || continuarJogando == 'n')
                    {
                        Console.Clear();
                        Console.WriteLine("Aperte qualquer tecla para sair.");
                        Console.ReadKey();
                        Environment.Exit(0);

                    }

                    //Caso ele não digite uma das opções
                    else
                    {
                        Console.WriteLine("Você deve digitar uma das opções. S ou N.");
                        continuarJogando = Convert.ToChar(Console.ReadLine());
                    }
                }
                while (continuarJogando != 'N' || continuarJogando != 'n');

                //Limpando console para um novo jogo
                Console.Clear();

                //Gerando número randômico
                int numero = gerador.Next(1, 101);

                //Loop até o jogador adivinhar o número
                do
                {
                    try
                    {
                        do
                        {
                            Console.WriteLine("Digite o seu palpite: ");
                            njogador = Convert.ToInt32(Console.ReadLine());

                            if (numero > njogador)
                            {
                                Console.WriteLine("O número correto é maior do que o informado!");
                            }
                            if (numero < njogador)
                            {
                                Console.WriteLine("O número correto é menor do que o informado!");
                            }

                            tentativas++;
                        }
                        while (numero != njogador);

                    }

                    //Tratativa de erro (caso ele escreva uma letra ao invés de um número)
                    catch (FormatException ex)
                    {
                        Console.Clear();
                        Console.WriteLine("Erro encontrado. Você deve digitar um número entre 1 e 100.");
                        Console.WriteLine("Aguarde 5 segundos para digitar novamente.");
                        Thread.Sleep(5000);
                        Console.Clear();
                    }
                }
                while (numero != njogador);

                
                //Declaração que a pessoa acertou o número
                Console.WriteLine($"Parabéns! Você acertou em {tentativas} tentativas! O número era {numero}.\n");

                //Tempo para reiniciar o programa
                Thread.Sleep(2500);

                //Pergunta se quer continuar jogando ou não
                Console.WriteLine("Você deseja descobrir uma nova charada?\n\nDigite: S se sim ou N se não");
            }
            while (continuarJogando == 'S' || continuarJogando == 's');

            Console.ReadKey();
        }
    }
}
