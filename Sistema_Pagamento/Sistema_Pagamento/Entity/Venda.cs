namespace Sistema_Pagamento.Entity
{
    internal class Venda
    {
        public int Numero { get; }
        Cliente Cliente { get; }
        public decimal Valor { get; private set; }
        public FormaPagamento FormaPagamento { get; private set; }
        public decimal ValorFinal { get; private set; }
        public bool Pago { get; private set; }
        public string Situacao => Pago ? "Pago" : "Pendente";

        public Venda(int numero, Cliente cliente, decimal valor)
        {
            ValidarInformacoes(numero, valor);

            Numero = numero;
            Cliente = cliente;
            Valor = valor;
            Pago = false;

            ProcessarCadastroVenda();
        }

        private void ValidarInformacoes(int numero, decimal valor)
        {
            if (numero <= 0) { throw new ArgumentException("\nO numero da venda deve ser maior que zero."); }

            if (valor <= 0) { throw new ArgumentException("\nO valor da compra deve ser maior que zero."); }
        }

        public void ProcessarCadastroVenda()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Venda Cadastrada com sucesso!");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Situação: {Situacao}");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ConsultarVendas()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Venda: {Numero}");
            Console.WriteLine($"Cliente: {Cliente.Nome}");
            Console.WriteLine($"Valor Original: {Valor:C}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Situação: {Situacao}");

            Console.ForegroundColor = ConsoleColor.White;
            //Se a conta já tiver sido paga...
            if (Pago == true)
            {
                Console.WriteLine();
                Console.WriteLine($"Forma de Pagamento: {FormaPagamento}");
                Console.WriteLine($"Valor Final: {ValorFinal:C}");
            }
        }

        public void RealizarPagamento(FormaPagamento formaPagamento)
        {
            if (Pago == true)
            {
                Console.WriteLine("\nA conta já esta paga.");
                return;
            }

            FormaPagamento = formaPagamento;
            ValorFinal = formaPagamento.CalcularValorFinal(Valor);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPagamento realizado com sucesso!");
            Pago = true;
        }
    }
}