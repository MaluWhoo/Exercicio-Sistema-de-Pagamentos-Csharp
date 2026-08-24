namespace POO_Polimorfismo.Entity
{
    internal class Caminhao : Veiculo
    {
        public int CapacidadeTonelada { get; }

        public Caminhao(string placa, string modelo, decimal valorDiaria, int capacidadeTonelada) : base(placa, modelo, valorDiaria)
        {
            CapacidadeTonelada = capacidadeTonelada;
        }

        public override decimal CalcularValorLocacao(int quantidadeDias)
        {
            decimal valorBase = base.CalcularValorLocacao(quantidadeDias);

            //R$ 50,00 por tonelada de capacidade da carga para cada dia da locação.
            decimal taxaCarga = 50 * CapacidadeTonelada * quantidadeDias;

            return valorBase + taxaCarga;
        }

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();

            Console.WriteLine($"Capacidade de Carga/Tonelada: {CapacidadeTonelada}");
        }
    }
}