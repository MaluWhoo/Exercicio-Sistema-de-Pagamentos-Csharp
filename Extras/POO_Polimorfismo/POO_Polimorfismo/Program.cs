/*

 # Atividade: Gestão de locação de uma frota

Uma empresa de locação de veículos precisa informatizar o controle de sua frota.
O sistema deverá permitir consultar veiculos, calulcar operações, registar locações e devoluções.

A empresa trabalha com **CARROS, MOTOS e CAMINHÕES**, e cada categoria possui uma regra diferente 
para calcular o valor da locação.

Sua tarefa será desenvolver uma aplicação Console em CSharp utilizando
** CLASSES, HERANÇAS, ENCAPSULAMENTO E POLIMORFISMO **

## CLIENTES DISPONÍVEIS 

Para não aumentar o escopo do exercício, os clientes deverão ser cadastrados diretamente no código.

Cada cliente deve possuir:
    * ID
    * Nome

Exemplo de clientes disponíveis:

ID: 1 - Ana Souza
ID: 2 - Carlos Oliveira
ID: 3 - Marina Santos

O sistema não precisa permitir o cadastro, a edição ou a exclusão de clientes.
 
Ao registrar uma locação, o usuário deverá permitir informar apenas o ID do cliente. 
O sistema deverá localizar o cliente correspondente na lista já existente.

## Cadastro dos veículos

Todos os veículos da frota devem possuir:
    * Placa
    * Modelo
    * Valor da Diária
    * Situação atual: disponível ou alugado

A placa e o modelo devem ser definidos na criação do veículo e não poderão ser alterados posteriormente.

O valor da diário não poderá ser modificado diretamente. Sua alteração deverá ocorrer 
por meio de uma operação espefica e somente poderá receber valores maiores que zero.

Todo veículo deverá ser cadastrado inicialmente como disponível.

## Categorias e regras comerciais

### Carros
Além dos dados comuns, um carro deve  possuir:
    * Quantidade de portas.
    * Informações sobre ar-condicionado.

O valor base da locação será:
    VALOR DA DIÁRIA X QUANTIDADE DE DIAS

Quando o carro possuir ar-condicionado, deverá ser acrescentada uma taxa de 10% sobre o valor total.

### Motos
Além dos dados comuns, uma moto deve  possuir:
    * Cilindradas.

O valor base da locação será:
    VALOR DA DIÁRIA X QUANTIDADE DE DIAS

Moto com mais de 500 cilindradas terão um acréscimo de 15% sobre o valor total.

### Caminhões
Além dos dados comuns, uma moto deve  possuir:
    * Capacidade de carga em toneladas.
  
O valor base da locação será:
    VALOR DA DIÁRIA X QUANTIDADE DE DIAS  

Também deverá ser cobrada uma tava de R$ 50,00 por tonelada de capacidade da carga para cada dia da locação.

# Dados da locação

Ao registrar uma locação o sistema deverá armazenar: ,
    * Número ou ID da locãção
    * Cliente responsável
    * Veículo locado
    * Data de retirada
    * Quantidade de dias contratados
    * Data esperada para devolução
    * Valor totl da locação
    * Situação da locação

A situação inicial da locação poderá ser:

Em andamento

Quando o veículo for devolvido, a situação deverá ser alterada para:

Finalizada

## Registro de uma locação

Para registrar uma nova locação, o sistema deverá solicitar:

1. A placa do veículo
2. O ID do cliente
3. A data de retirada
4. A quantidade de dias da locação

Antes de concluir, o sistema deverá validar:

    * Se o Cliente existe
    * Se o Veículo existe.
    * Se o Veículo está disponível
    * Se a data informada é válida
    * Se a quantidade de dias é maior que zero

Depois da validação, o sistema deverá:

1. Calcular o valor total
2. Calcular a data esperada para devolução
3. Criar a locação
4. Alterar o veículo para alugada
5. Exibir um resumo da operação

Exemplo saída:
    
Locação registrada com sucesso!

Cliente: NOME CLIENTE
Veíulo: Honda Civic
Placa: ABC-1234
Data de Retirada: 10/08/2026
Devolução Esperada: 13/08/2026
Período contratado: 3 dias
Valor total: R$ 825,00
Situação: Em andamento

## REGISTRO DE DEVOLUÇÃO

O sistema deverá permitir localizar uma locação em andamento pelo seu ID.

Ao registrar a devolução:

    * A locação deverá ser marcada como finalizada.
    * O veículo deverá voltar a ficar disponível.
    * O sistema deverá informar que a devolução foi registrada.

Não será necessário calcular atraso, multa ou diferença de valores neste exercício.

## MENU INTERATIVO

==================================
    SISTEMA DE LOCAÇÃO DE FROTA
==================================
1 - Consultar frota
2 - Consultar clientes
3 - Calcular cotação
4 - Registrar cotação
5 - Registrar devolução
6 - Consultar locações
7 - Alterar valor diária
0 - Sair
==================================

## PROCESSAMENTO DE FROTA

No Program.cs, cadastre diretamente no código pelo menos:

    * Dois carros
    * Duas motos
    * Uma caminhão
    * Três clientes

Todos os deverão ser armazenados em uma unica coleção: 
    Ceículos: List<Veiculo>
    Clientes: List<Cliente>
    Locações: List<Locacao>

## REGRAS DE ENCAPSULAMENTO

- O sistema não deverá permitir alterações diretas nas seguintes informações:

    * Disponibilidade do veiculo.
    * Valor da diaria
    * Situação da locação
    * Data esperada para devolução
    * Valor total da locação

Essas alterações deverão ocorrer somente por meio de métodos que representem operações do negocio, como:

    Alugar
    Devolver
    AlterarValorDiaria
    FinalizarLocacao

## HENRANÇA E POLIMORFISMO

Crie uma classe base abstrada chamada 'Veiculo'.

As classes que herdarão dela serão;

    - Carro
    - Moto
     -Caminhão

Cada categoria deverá implemnetar sua própria regra de cálculo do valor da locação.

Mesmo que todos os veículos estejam armazenados como 'Veiculo', o sistema deverá 
executar automaticamente a regra correspondende ao tipo real do objeto.

Exemplo: decimal valor = 
                    veiculo.CalcularValorLocacao(quantidadeDias);

## RESULTADO ESPERADO

Ao final, a aplicação deverá permitir que a locadora:

    * Consulte os veiculos disponiveis e alugados
    * Consulte os clientes previamente cadastrados
    * Calcule cotações
    * Registre uma locação associando cliente a veículo
    * Calcule automaticamente a data esperada para a devolução
    * Consulte as locações realizadas
    * Registre devoluções
    * Mantenha o estado da frota consistente.

*/

using POO_Polimorfismo.Entity;

List<Cliente> clientes = new List<Cliente>()
{
    new Cliente(1, "Ana Souza"),
    new Cliente(2, "Carlos Oliveira"),
    new Cliente(3, "Marina Santos"),
};

List<Veiculo> frota = new List<Veiculo>()
{
    new Carro ("ABC-1234", "Honda Civic", 250, 4, true),
    new Carro ("DEF-5678", "Renaault Kwird", 150, 4, false),
    new Moto("JKL-3452", "Honda CB 650R", 300, 650),
    new Caminhao("MNO-9843", "Volvo VM", 700, 8)
};

List<Locacao> locacoes = new List<Locacao>();

int proximoIdLocacao = 1;
string opcao;

do
{
    Console.WriteLine("=====================================");
    Console.WriteLine("     SISTEMA DE LOCAÇÃO DE FROTA     ");
    Console.WriteLine("=====================================");

    Console.WriteLine();
    Console.WriteLine("1 - Consultar Frota");
    Console.WriteLine("2 - Consultar Cliente");
    Console.WriteLine("3 - Calcular Cotação");
    Console.WriteLine("4 - Registrar Locação");
    Console.WriteLine("5 - Registrar Devolução");
    Console.WriteLine("6 - Consultar Locações");
    Console.WriteLine("7 - Alterar Valor da Diária");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("=====================================");

    Console.Write("\nNavegação --> ");
    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            ConsultarFrota(frota);
            break;
        case "2":
            ConsultarCliente(clientes);
            break;
        case "3":
            CalcularCotacao(frota);
            break;
        case "4":
            RegistrarLocacao(clientes, frota, locacoes, ref proximoIdLocacao);
            break;
        case "5":
            RegistrarDevolucao(locacoes);
            break;
        case "6":
            ConsultarLocacoes(locacoes);
            break;
        case "7":
            AlterarValorDiaria(frota);
            break;
        case "0":
            Console.WriteLine("\nFinalizando aplicação...");
            break;
        default:
            Console.WriteLine("\nOpção não disponível!");
            return;
    }

} while (opcao != "0");

static void ConsultarFrota(List<Veiculo> frota)
{
    Console.WriteLine("\n***** CONSULTAR FROTA *****");

    foreach (var veiculo in frota)
    {
        veiculo.ExibirInformacoes();
        Console.WriteLine("---------------------------");
    }
}

static void ConsultarCliente(List<Cliente> clientes)
{
    Console.WriteLine("\n***** CONSULTAR CLIENTE *****\n");

    foreach (var cliente in clientes)
    {
        cliente.ExibirInformacoes(cliente);
    }

    Console.WriteLine();
}

static void CalcularCotacao(List<Veiculo> frota)
{
    Console.WriteLine("\n***** COTAÇÃO DE LOCAÇÃO *****\n");

    Console.Write("Informa a quantidade de dias --> ");
    var quantidadeDias = Console.ReadLine();

    if (!int.TryParse(quantidadeDias, out int qndDias))
    {
        Console.WriteLine("\nQuantidade de dias inválido.");
        return;
    }

    var veiculo = BuscarVeiculoPorPlaca(frota);
    if (veiculo == null) return;

    try
    {
        decimal valor = veiculo.CalcularValorLocacao(qndDias);

        Console.WriteLine("");
        Console.WriteLine($"Modelo: {veiculo.Modelo}");
        Console.WriteLine($"Placa: {veiculo.Placa}");
        Console.WriteLine($"Período: {qndDias} dias");
        Console.WriteLine($"Valor: {valor:C}");
    }
    catch (Exception ex) { Console.WriteLine(ex.Message); }
}

static Veiculo BuscarVeiculoPorPlaca(List<Veiculo> frota)
{
    Console.Write("Informe a placa do veículo --> ");
    var placa = Console.ReadLine();

    var veiculo = frota.FirstOrDefault(x => x.Placa.Trim().ToUpper() == placa);

    if (veiculo == null)
    {
        Console.WriteLine($"\nNenhum veículo encontrado com a placa {placa}.");
    }

    return veiculo;
}

static void RegistrarLocacao(List<Cliente> clientes, List<Veiculo> frota, List<Locacao> locacoes, ref int proximoIdLocacao)
{
    Console.WriteLine("\n***** NOVA LOCAÇÃO *****\n");

    var veiculo = BuscarVeiculoPorPlaca(frota);
    if (veiculo == null) return;

    Console.Write("ID do cliente: ");

    if (!int.TryParse(Console.ReadLine(), out int idCliente))
    {
        Console.WriteLine("\nId de cliente inválido.");
        return;
    }

    var cliente = clientes.FirstOrDefault(x => x.Id == idCliente);
    if (cliente is null)
    {
        Console.WriteLine("\nCliente não encontrado!");
        return;
    }

    Console.Write("Informe a data de retirada: ");
    if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataRetirada))
    {
        Console.WriteLine("\nData de Retirada inválida.");
        return;
    }

    Console.Write("Informa a quantidade de dias: ");
    if (!int.TryParse(Console.ReadLine(), out int quantidadeDias))
    {
        Console.WriteLine("\nQuantidade de dias inválida.");
        return;
    }

    try
    {
        var locacao = new Locacao(proximoIdLocacao, cliente, veiculo, dataRetirada, quantidadeDias);
        locacoes.Add(locacao);
        proximoIdLocacao++;
        Console.WriteLine("\nLocação registrada com sucesso!");

        locacao.ExibirInformacoes();
    }
    catch (Exception ex)
    {

        Console.WriteLine(ex.Message);
    }
}

static void RegistrarDevolucao(List<Locacao> locacoes)
{
    Console.WriteLine("\n***** DEVOLVER VEICULO *****\n");

    if (locacoes.Count == 0)
    {
        Console.WriteLine("\nNenhuma locação registrada.");
        return;
    }

    Console.Write("Informe o ID da locação: ");

    if (!int.TryParse(Console.ReadLine(), out int idLocacao))
    {
        Console.WriteLine("\nID de locação inválido.");
        return;
    }

    var locacao = locacoes.FirstOrDefault(x => x.Id == idLocacao);
    if (locacao == null)
    {
        Console.WriteLine("\nLocação não encontrada");
        return;
    }

    try
    {
        locacao.Devolver();
        Console.WriteLine("\nLocação devolvida com sucesso!");
    }
    catch (Exception ex)
    {

        Console.WriteLine(ex.Message);
    }
}

static void ConsultarLocacoes(List<Locacao> locacoes)
{
    Console.WriteLine("\n***** CONSULTAR LOCAÇÕES *****\n");

    if (locacoes.Count == 0)
    {
        Console.WriteLine("\nNenhuma locação registrada");
        return;
    }

    foreach (var locacao in locacoes)
    {
        locacao.ExibirInformacoes();
        Console.WriteLine();
    }
}

static void AlterarValorDiaria(List<Veiculo> frota)
{
    Console.WriteLine("\n***** ALTERAR VALOR DA DIÁRIA *****\n");

    var veiculo = BuscarVeiculoPorPlaca(frota);
    if (veiculo is null)
    {
        Console.WriteLine("\nVeículo não encontrado.");
        return;
    }

    Console.WriteLine($"Valor da Diaria atual: R$ {veiculo.ValorDiaria}");
    Console.Write("Informe o novo valor --> R$ ");

    if (!decimal.TryParse(Console.ReadLine(), out decimal novoValor))
    {
        Console.WriteLine("\nValor Inválido.");
        return;
    }

    try
    {
        veiculo.AlterarValorDiaria(novoValor);
        Console.WriteLine("\nValor Alterado com sucesso!");
    }
    catch (Exception ex)
    {

        Console.WriteLine(ex.Message);
    }
}