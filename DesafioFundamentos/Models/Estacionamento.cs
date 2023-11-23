namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        //MODIFICADO PARA EVITAR EXCEPTION E APLICAR MODULARISAÇÃO!!!
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            if (precoInicial < 0 || precoPorHora < 0)
            {
                throw new ArgumentException("Os preços não podem ser negativos.");
            }

            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            //IMPLEMENTADO!!!
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
                return;
            }

            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            //IMPLEMENTADO!!!
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().Trim().ToUpper();

            if (!veiculos.Contains(placa))
            {
                Console.WriteLine("Veículo não encontrado no estacionamento.");
                return;
            }

            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
            if (!int.TryParse(Console.ReadLine(), out int horas))
            {
                Console.WriteLine("Valor inválido para horas. Tente novamente.");
                return;
            }

            decimal valorTotal = CalcularPrecoTotal(horas);
            veiculos.Remove(placa);
            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
        }

        private decimal CalcularPrecoTotal(int horas)
        {
            //IMPLEMENTADO!!!
            return precoInicial + precoPorHora * horas;
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
