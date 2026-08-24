namespace POO_Polimorfismo.Entity
{
    internal class Carro : Veiculo
    {
        public int QuantidadePortas { get; }
        public bool PossuiArCondicionado { get; }

        public Carro(
            string placa,
            string modelo,
            decimal valorDiaria,
            int quantidadePortas,
            bool possuiArCondicionado) : base(placa, modelo, valorDiaria)
        {
            QuantidadePortas = quantidadePortas;
            PossuiArCondicionado = possuiArCondicionado;
        }

        public override decimal CalcularValorLocacao(int quantidadeDias)
        {
            decimal valorBase = base.CalcularValorLocacao(quantidadeDias);

            if (PossuiArCondicionado) 
            {
                return valorBase * 1.10m;
            }

            return valorBase;
        }

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();

            Console.WriteLine($"Quantidade de Portas: {QuantidadePortas}");
            Console.WriteLine($"Possui Ar Condicionado: {(PossuiArCondicionado ? "Sim" : "Não")}");
        }
    }
}
