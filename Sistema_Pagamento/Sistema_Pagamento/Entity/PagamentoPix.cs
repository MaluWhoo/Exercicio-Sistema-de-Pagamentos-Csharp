namespace Sistema_Pagamento.Entity
{
    internal class PagamentoPix : FormaPagamento
    {
        public override string ToString()
        {
            return "PIX";
        }

        public override decimal CalcularValorFinal(decimal valor)
        {
            decimal valorFinal = valor * 0.95m;

            Console.WriteLine($"\nValor Original: {valor:C}");
            Console.WriteLine("Forma de Pagamento: PIX");
            Console.WriteLine($"Valor Final: {valorFinal:C}");

            return valorFinal;
        }
    }
}
