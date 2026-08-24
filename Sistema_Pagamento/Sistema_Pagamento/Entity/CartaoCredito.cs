namespace Sistema_Pagamento.Entity
{
    internal class CartaoCredito : FormaPagamento
    {
        public override string ToString()
        {
            return "Cartão de Crédito";
        }
        public override decimal CalcularValorFinal(decimal valor)
        {
            decimal valorFinal = valor * 1.03m;

            Console.WriteLine($"\nValor Original: {valor:C}");
            Console.WriteLine("Forma de Pagamento: Cartão de Crédito");
            Console.WriteLine($"Valor Final: {valorFinal:C}");

            return valorFinal;
        }
    }
}
