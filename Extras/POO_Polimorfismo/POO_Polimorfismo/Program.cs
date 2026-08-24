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

*/

using POO_Polimorfismo.Entity;

List<Cliente> cliente = new List<Cliente>()
{
    new Cliente(1, "Ana Souza"),
    new Cliente(2, "Carlos Oliveira"),
    new Cliente(3, "Marina Santos"),
};

List<Veiculo> frota = new List<Veiculo>()
{
    new Carro ("ABC-1234", "Honda Civic", 250, 4, true),
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
    Console.WriteLine("6 - Consutlar Locações");
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
            ConsultarCliente(cliente);
            break;
        case "3":

            break;
        default:
            Console.WriteLine("\nOpção não disponível!");
            break;
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

static void RegistrarLocacao()
{

}