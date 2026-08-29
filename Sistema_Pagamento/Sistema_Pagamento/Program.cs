using Sistema_Pagamento.Entity;

List<Cliente> clientes = new List<Cliente>();
List<Venda> vendas = new List<Venda>();

string opcao;

do
{
    Console.Clear();
    Menu();

    switch (opcao)
    {
        case "1":
            CadastrarVenda(clientes, vendas);
            break;
        case "2":
            ListarVendas(vendas);
            break;
        case "3":
            RealizarPagamento(vendas);
            break;
        case "0":
            Console.WriteLine("\nFinalizando ...");
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nDigite um valor válido ou zero para sair.");
            break;
    }

    if (opcao != "0")
    {
        Console.WriteLine("\nPressione ENTER para continuar...");
        Console.ReadLine();
    }

} while (opcao != "0");

void Menu()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("==== SISTEMA DE VENDAS ====");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine();
    Console.WriteLine("1 - Cadastrar Venda");
    Console.WriteLine("2 - Listar Vendas");
    Console.WriteLine("3 - Realizar Pagamento");
    Console.WriteLine("0 - Sair");

    Console.Write("\nNavegação --> ");
    opcao = Console.ReadLine();
}

static void CadastrarVenda(List<Cliente> clientes, List<Venda> vendas)
{
    Console.WriteLine("\n---- Cadastrar Venda ----");

    Console.Write("Número da Venda: ");
    var numeroDigitado = Console.ReadLine();

    if (!int.TryParse(numeroDigitado, out int numero))
    {
        Console.WriteLine("\nDigite um número válido.");
        return;
    }

    if (vendas.Any(x => x.Numero == numero))
    {
        Console.WriteLine($"\nO número de venda {numero} já está cadastrado.");
        return;
    }

    Console.Write("Nome do Cliente: ");
    string nome = Console.ReadLine();

    Console.Write("CPF: ");
    string cpf = Console.ReadLine();

    Console.Write("Valor da Compra: R$ ");
    var valorDigitado = Console.ReadLine();

    if (!decimal.TryParse(valorDigitado, out decimal valor))
    {
        Console.WriteLine("\nInsira um valor de compra válido!");
        return;
    }

    try
    {
        Cliente cliente = new Cliente(nome, cpf);
        Venda venda = new Venda(numero, cliente, valor);

        clientes.Add(cliente);
        vendas.Add(venda);
    }
    catch (ArgumentException ex) { Console.WriteLine($"{ex.Message}"); }
}

static void ListarVendas(List<Venda> vendas)
{
    Console.WriteLine("\n---- Consultar Vendas ----\n");

    if (vendas.Count == 0) { Console.WriteLine("\nNenhuma venda cadastrada."); return; }

    foreach (Venda venda in vendas)
    {
        venda.ConsultarVendas();
    }
}

static void RealizarPagamento(List<Venda> vendas)
{
    Console.WriteLine("\n---- Realizar Pagamento ----\n");

    if (vendas.Count == 0) { Console.WriteLine("\nNenhuma venda cadastrada."); return; }

    Console.Write("Informa o número da venda --> ");
    var numeroDigitado = Console.ReadLine();

    if (!int.TryParse(numeroDigitado, out int numero))
    {
        Console.WriteLine("\nInsirá um valor válido.");
        return;
    }

    // Passar para a classe depois
    if (!vendas.Any(x => x.Numero == numero))
    {
        Console.WriteLine($"Nenhuma venda {numero} cadastrada.");
        return;
    }

    // Pegando o valor da compra pelo numero desta
    var venda = vendas.FirstOrDefault(x => x.Numero == numero);
    var valor = venda.Valor;

    string opcao;

    Console.WriteLine();
    Console.WriteLine("1 - PIX");
    Console.WriteLine("2 - Cartão de Crédito");
    Console.WriteLine("3 - Dinheiro");
    Console.WriteLine("0 - Voltar");

    Console.Write("\nEscolha a forma de pagamento --> ");
    opcao = Console.ReadLine();

    FormaPagamento formaPagamento;

    switch (opcao)
    {
        case "1":
            formaPagamento = new PagamentoPix();
            break;
        case "2":
            formaPagamento = new CartaoCredito();
            break;
        case "3":
            formaPagamento = new Dinheiro();
            break;
        case "0":
            return;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nValor inválido.");
            return;
    }

    venda.RealizarPagamento(formaPagamento);
}