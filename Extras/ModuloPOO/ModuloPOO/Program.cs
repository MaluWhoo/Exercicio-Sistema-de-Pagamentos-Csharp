/*
    EXERCICIO: CADASTRO DE FUNCIONARIOS

Crie uma aplicação Console em C# para representar e gerenciar informações de funcionários de uma empresa.

Desenvolva uma classe chamada 'Funcionario' contendo as propriedades: 
    * Nome 
    * Cargo
    * Salário
    * Horas Trabalhadas

A classe támbém deverá possuir os seguinte métodos:
    * 'RegistrarHoras', responsável por adicionar horas trabalhadas ao funcionário.
    * 'AumentarSalario', responsável por aplicar um aumento porcentual ao salário.
    * 'CalulcarValoraHora', responsável por calcular o valor da hora trabalhada.
    * 'ExibirInformacoes', responsável por apresentar os dados completos do funcionário no console.
    
 
Considere as seguintes regras:
    * A quantidade de horas trabalhadas deve ser maior que zero.
    * O percentual de aumento salario deve ser maior que zero.
    * O Salario não pode ser alterado diretamente fora da classe.
    * O valor da hora deve ser calculado dividindo o salário pela quantidade de horas trabalhadas.
    * O Cálculo do valor da hora não deve ser realizado caso ainda não existam horas registradas.

No 'Program.cs' crie pelo menos 2 funcionários, registre suas horas, 
aplique aumentos salariais e exiba suas informações.

Como desafio extra: Trate a tentativa de calcular o valor da hora de um funcionário 
que ainda não possui horas de trabalho
 
 */

using ModuloPOO;

Funcionario funcionario1 = new Funcionario("Pedro Henrique", "Estagiário", 100);
Funcionario funcionario2 = new Funcionario("Allan", "CEO", 5000);

Console.WriteLine();
var valorHora = funcionario1.CalcularValorHora();
funcionario1.RegistrarHoras(100);
funcionario1.AumentarSalario(10);

Console.WriteLine();
funcionario2.RegistrarHoras(250);
funcionario2.AumentarSalario(15);

funcionario1.ExibirInformacoes();
funcionario2.ExibirInformacoes();