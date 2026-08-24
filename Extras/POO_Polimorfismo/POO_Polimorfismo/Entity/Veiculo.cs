namespace POO_Polimorfismo.Entity
{
    internal class Veiculo
    {
        public string Placa { get; }
        public string Modelo { get; }
        public decimal ValorDiaria { get; private set; }
        public bool EstaDisponivel { get; private set; }
        public string Situacao => EstaDisponivel ? "Disponível" : "Alugado";

        public Veiculo(string placa, string modelo, decimal valorDiaria)
        {
            Placa = placa;
            Modelo = modelo;
            ValorDiaria = valorDiaria;
            EstaDisponivel = true;
        }

        public bool AlterarValorDiaria(decimal valorDiaria)
        {
            if (ValorDiaria < 0)
            {
                return false;
            }

            ValorDiaria = valorDiaria;
            return true;
        }

        public void TornarIndisponivel()
        {
            EstaDisponivel = false;
        }

        public void TornarDisponivel()
        {
            EstaDisponivel = true;
        }

        public virtual decimal CalcularValorLocacao(int quantidadeDias)
        {
            if (quantidadeDias <= 0)
            {
                throw new ArgumentException("A quantidade de dias deve ser maior que zero.");
            }

            return ValorDiaria * quantidadeDias;
        }

        public virtual void ExibirInformacoes()
        {
            Console.WriteLine("");
            Console.WriteLine($"Categoria: {GetType().Name}");
            Console.WriteLine($"Placa: {Placa}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Valor Diária: {ValorDiaria:C}");
            Console.WriteLine($"Situação: {Situacao}");
        }
    }
}