namespace POO_Polimorfismo.Entity
{
    internal class Locacao
    {
        public int Id { get; }
        public Cliente Cliente { get; }
        public Veiculo Veiculo { get; }
        public DateTime DataRetirada { get; }
        public int QuantidadeDias { get; }
        public DateTime DataDevolucao { get; }
        public decimal ValorTotal { get; }
        public SituacaoLocacao Situacao { get; private set; }

        public Locacao(int id, Cliente cliente, Veiculo veiculo, DateTime dataRetirada, int quantidadeDias)
        {
            ValidarDados(id, cliente, veiculo, dataRetirada, quantidadeDias);

            Id = id;
            Cliente = cliente;
            Veiculo = veiculo;
            DataRetirada = dataRetirada;
            QuantidadeDias = quantidadeDias;
            DataDevolucao = dataRetirada.AddDays(quantidadeDias);
            Situacao = SituacaoLocacao.EmAndamento;
            ValorTotal = Veiculo.CalcularValorLocacao(quantidadeDias);

            veiculo.TornarIndisponivel();
        }

        private void ValidarDados(int id, Cliente cliente, Veiculo veiculo, DateTime dataRetirada, int quantidadeDias)
        {
            if (id <= 0)
            {
                throw new ArgumentException("\nO ID da locação deve ser maior que zero.");
            }

            if (cliente is null)
            {
                throw new ArgumentException("\nO cliente é obrigatório.");
            }

            if (veiculo is null)
            {
                throw new ArgumentException("\nO veículo é obrigatório.");
            }

            if (!veiculo.EstaDisponivel)
            {
                throw new ArgumentException("\nO veículo não está disponível.");
            }

            if (quantidadeDias <= 0)
            {
                throw new ArgumentException("\nA Quantidade de dias deve ser maior que zero.");
            }
        }

        public void Devolver()
        {
            if (Situacao == SituacaoLocacao.Finalizada)
            {
                Console.WriteLine("\nEssa locação já foi finalizada.");
                return;
            }

            Situacao = SituacaoLocacao.Finalizada;
            Veiculo.TornarDisponivel();
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine("");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nome:  {Cliente.Id} - {Cliente.Nome}");
            Console.WriteLine($"Veículo: {Veiculo.Modelo}");
            Console.WriteLine($"Placa: {Veiculo.Placa}");
            Console.WriteLine($"Data de Retirada: {DataRetirada:dd/MM/yyyy}");
            Console.WriteLine($"Devolução Esperada: {DataDevolucao:dd/MM/yyyy}");
            Console.WriteLine($"Quantidade de Dias: {QuantidadeDias}");
            Console.WriteLine($"Valor Total: {ValorTotal:C}");
            Console.WriteLine($"Situação: {(Situacao == SituacaoLocacao.EmAndamento ? "Em andamento" : "Finalizada")}");
        }
    }
}
