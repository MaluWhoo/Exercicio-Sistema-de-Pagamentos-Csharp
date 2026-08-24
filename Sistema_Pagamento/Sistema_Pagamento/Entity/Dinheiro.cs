namespace Sistema_Pagamento.Entity
{
    internal class Dinheiro : FormaPagamento
    {
        public override string ToString()
        {
            return "Dinheiro";
        }
        public override decimal CalcularValorFinal(decimal valor)
        {
            decimal valorFinal = valor;

            Console.WriteLine($"\nValor Original: {valor:C}");
            Console.WriteLine("Forma de Pagamento: Dinheiro");
            Console.WriteLine($"Valor Final: {valorFinal:C}");

            return valorFinal;
        }
    }
}
