using DesafioFundamentos.Models;

namespace DesafioFundamentos
{
    class Program
    {
        static void Main()
        {
            //MODIFICADO PARA EVITAR EXCEPTION E APLICAR MODULARISAÇÃO!!!
            // Configura o encoding para UTF8 para exibir acentuação correta
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            decimal precoInicial = ObterDecimalDoUsuario("Digite o preço inicial:");
            decimal precoPorHora = ObterDecimalDoUsuario("Agora digite o preço por hora:");

            // Instancia a classe Estacionamento com os valores obtidos
            Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

            bool continuar = true;

            while (continuar)
            {
                MostrarMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        estacionamento.AdicionarVeiculo();
                        break;

                    case "2":
                        estacionamento.RemoverVeiculo();
                        break;

                    case "3":
                        estacionamento.ListarVeiculos();
                        break;

                    case "4":
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadLine();
                Console.Clear();
            }

            Console.WriteLine("O programa se encerrou");
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("Digite a sua opção:");
            Console.WriteLine("1 - Cadastrar veículo");
            Console.WriteLine("2 - Remover veículo");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("4 - Encerrar");
        }

        static decimal ObterDecimalDoUsuario(string mensagem)
        {
            decimal valor;

            while (true)
            {
                Console.WriteLine(mensagem);
                if (decimal.TryParse(Console.ReadLine(), out valor) && valor >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Digite um número decimal válido.");
                }
            }

            return valor;
        }
    }
}