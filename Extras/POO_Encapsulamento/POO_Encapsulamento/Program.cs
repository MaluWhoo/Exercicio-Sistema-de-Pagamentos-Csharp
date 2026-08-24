/*
    
## EXERCÍCIO: Sistema de Contas Digitais

Uma fintech precisa de um sistema simples para cadastrar clientes e controlar suas contas digitais.

Cada cliente deve possuir:
    * Nome, 
    * CPF, 
    * Senha. 

Cada conta deve estar vinculada a um cliente e possuir:
    *   Um número, 
    *   saldo 
    *   situação.

O sistema deve permitir:
    * Cadastrar Clientes; 
    * Criar conta para clientes já cadastrados;
    * Realizar depósitos;
    * Realizar saques mediante validação da senha;

    * Bloquear contas;
    * Consultar os dados de uma conta;
    * Listar clientes e contas cadastradas;

    ### REGRAS DE NEGÓCIO

    * Não pode existir mais de um cliente com o mesmo CPF;
    * Não pode existir mais de uma conta com o mesmo número;
    * A conta deve iniciar ativa e com SALDO zero;

    ### CONDIÇÕES

    * Depósitos e saques só podem ser realizados em contas ativas;
    * O valor das operações deve ser maior que zero;
    * O saque exige senha correta e saldo suficiente;
    * Uma conta bloqueada não pode moviementar valores;
    * A senha nunca deve ser exibida;
    * Saldo senha e situação da conta não podem ser alterados diretamente;

O sistema deve funcionar por meio de um menu e armazenar os dados em lista de clientes e contas.

 */

using POO_Encapsulamento.Entity;

List<Cliente> clientes = new List<Cliente>();
List<Conta> contas = new List<Conta>();
int opcao;

Console.WriteLine("== CONTAS DIGITAIS ==");

do
{
    Console.WriteLine("\n============ MENU ============\n");

    Console.WriteLine("1 - Cadastrar Cliente");
    Console.WriteLine("2 - Criar Conta");
    Console.WriteLine("3 - Depósito");
    Console.WriteLine("4 - Saque");
    Console.WriteLine("5 - Consultar Conta");
    Console.WriteLine("6 - Clientes e Contas Cadastrados");
    Console.WriteLine("0 - Sair");

    Console.WriteLine("\n===============================\n");

    Console.Write("Navegação -> ");
    var menuDigitado = Console.ReadLine();

    if (!int.TryParse(menuDigitado, out opcao))
    {
        Console.WriteLine("Digite um número válido.");
        break;
    }

    switch (opcao)
    {
        case 1:
            CadastrarCliente(clientes);
            break;
        case 2:
            CriarConta(clientes, contas);
            break;
        case 3:
            Depositar(contas);
            break;
        case 4:
            Sacar(contas);
            break;
        case 5:
            Consultar(contas);
            break;
        case 6:
            ListarContas(contas);
            break;
        case 0:
            Console.WriteLine("\nEncerrando o sistema...");
            break;
        default:
            Console.WriteLine("\nOpção invalida. Tente novamente\n");
            break;
    }

} while (opcao != 0);


static void CadastrarCliente(List<Cliente> clientes)
{
    Console.WriteLine("\n=== CADASTRO DE CLIENTE ===\n");

    Console.Write("Nome do titular: ");
    string nome = Console.ReadLine();

    Console.Write("CPF: ");
    string cpf = Console.ReadLine();

    Console.Write("Digite uma senha (4 digitos): ");
    string senha = Console.ReadLine();

    if (clientes.Any(x => x.CPF == cpf))
    {
        Console.WriteLine("\nJá existe cadastro com esse CPF. Tente novamente.");
        return;
    }

    try
    {
        Cliente cliente = new(nome, cpf, senha);
        clientes.Add(cliente);
        Console.WriteLine("Cliente cadastrado com sucesso!");
    }
    catch (ArgumentException ex)
    {
        throw;
    }
}

static void CriarConta(List<Cliente> clientes, List<Conta> contas)
{
    if (clientes.Count == 0)
    {
        Console.WriteLine("\nNenhum cliente cadastrado ainda. Cadastre um cliente para criar sua conta.");
        return;
    }

    Console.WriteLine("\n=== CRIAR CONTA ===\n");

    Console.Write("Digite o CPF do títular da conta: ");
    string cpf = Console.ReadLine();

    var cliente = clientes.Find(x => x.CPF == cpf);

    if (cliente == null)
    {
        Console.WriteLine("Cliente não encontrado!");
        return;
    }

    Console.Write("Informe o número da conta: ");
    var conta = Console.ReadLine();

    if (contas.Any(x => x.NumeroConta == conta))
    {
        Console.WriteLine("\nJá existe uma conta com o número cadastrado. Tente novamente.");
        return;
    }

    try
    {
        Conta contaDigital = new Conta(cliente, conta);
        contas.Add(contaDigital);
        Console.WriteLine("Conta cadastrada com sucesso!");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void Depositar(List<Conta> contas)
{
    var conta = BuscarConta(contas);

    if (contas.Count == 0)
    {
        Console.WriteLine("\nNenhuma conta foi cadastrada no momento.\n");
        return;
    }

    if (conta == null)
    {
        Console.WriteLine("\nConta não encontrada.\n");
        return;
    }

    Console.WriteLine("\n=== DEPÓSITAR ===\n");

    Console.Write("Infome um valor para o depósito: R$ ");
    var valorDigitado = Console.ReadLine();

    if (!decimal.TryParse(valorDigitado, out decimal valor))
    {
        Console.WriteLine("Informe um valor válido");
        return;
    }

    if (valor <= 0)
    {
        Console.WriteLine("\nDepósito inválido!");
        return;
    }

    Console.Write("Senha: ");
    var senhaDigitada = Console.ReadLine();

    conta.Depositar(valor, senhaDigitada, conta);

    try
    {
        //Console.WriteLine("Depósito realizado com sucesso!");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void Sacar(List<Conta> contas)
{
    var conta = BuscarConta(contas);

    if (contas.Count == 0)
    {
        Console.WriteLine("\nNenhuma conta foi cadastrada no momento. Faça um cadastro.\n");
        return;
    }

    if (conta == null)
    {
        return;
    }

    Console.WriteLine("\n=== SAQUE ===\n");

    Console.Write("Infome um valor para o saque: R$ ");
    var valorDigitado = Console.ReadLine();

    if (!decimal.TryParse(valorDigitado, out decimal valor))
    {
        Console.WriteLine("Informe um valor válido");
        return;
    }

    Console.Write("Senha: ");
    var senha = Console.ReadLine();

    conta.Sacar(valor, senha, conta);

    try
    {
        //Console.WriteLine("Saque realizado com sucesso!");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void Consultar(List<Conta> contas)
{
    Console.WriteLine("\n=== CONSULTAR CONTA ===\n");

    if (contas.Count == 0)
    {
        Console.WriteLine("\nNenhuma conta foi cadastrada no momento. Faça um cadastro.\n");

        return;
    }

    var conta = BuscarConta(contas);

    if (conta == null)
    {
        Console.WriteLine("\nConta ainda não cadastrada.");
        return;
    }

    Console.Write("Senha: ");
    var senha = Console.ReadLine();

    conta.Consultar(senha, conta);

    try
    {
        //Console.WriteLine("Conta consultada!");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex);
    }
}

static void ListarContas(List<Conta> contas)
{
    if (contas.Count == 0)
    {
        Console.WriteLine("Nenhuma conta cadastrada.");
        return;
    }

    foreach (Conta conta in contas)
    {
        Console.WriteLine();
        Console.WriteLine($"Titular: {conta.Cliente.Nome}");
        Console.WriteLine($"CPF: {conta.Cliente.CPF}");
        Console.WriteLine($"Conta: {conta.NumeroConta}");
        Console.WriteLine($"Situação Conta: {conta.Situacao}");
        Console.WriteLine("---------------------------------");
    }
}

static Conta BuscarConta(List<Conta> conta)
{
    Console.Write("Número da conta: ");
    string contaInformada = Console.ReadLine();

    var contaEncontrada = conta.Find(x => x.NumeroConta == contaInformada);

    if (conta == null)
    {
        Console.WriteLine($"Conta {contaInformada} não encontrada.");
    }

    return contaEncontrada;
}