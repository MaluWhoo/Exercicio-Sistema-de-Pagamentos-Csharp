/*
    ATIVIDADE: Hierarquia de Funcionários

Crie uma aplicação Console em C# para representar os diferentes tipos de funcionanrios
de uma empresa utilizando HERENÇA.

Desenvola uma classe base chamada 'Funcionario' contendo os dados e comportamento
comuns a todos os funcionario:
    * Nome 
    * CPF
    * Salário
    * 'RegistrarEntrada()'
    * 'ExibirInformacoes()'

Em seguida, crie duas classes derivadas:

### DESENVOLVEDOR

A Classe 'Desenvolvedor' deve herdar de 'Funcionario' e possuir:
    * Linguagem Principal
    * Nivel
    * Metodo 'DesenvolverFuncionalidade()'

### GERENTE

A Classe 'Gerente' deve herdar de 'Funcionario' e possuir:
    * Setor
    * Quantidade de pessoas na equipe
    * Método 'RealizarReuniao()'

As classes 'Desenvolvedor' e 'Gerente' devem utilizar seus contrutores para enviar
os dados comuns ao construtor da classe 'Funcionario' por meio da palavra-chave 'base.

No 'Program.cs', crie pelo menos um desenvolvedor e um gerente. Depois, 
execute os métodos herdados e os métodos específicos de cada classe.

### Regra importante

Os dados comuns, como nome, CPF e Sálario, não devem ser duplicados nas classes derivadas.]
Eles devem existir somente na classe 'Funcionario' e ser reutilizados por meio da herança.

*/


using POO_Heranca.Entity;

var gerente = new Gerente("Pedro Henrique", "12345678900", 3600, "Estágiario", 5);
var dev = new Desenvolvedor("Malu", "12345678901", 5500, "C#", "Junior");

Console.WriteLine("-- Dados do Desenvolvedor --");
dev.RegistrarEntrada();
dev.DesenvolverFuncionalidade();
dev.ExibirDadosDesenvolvedor();

Console.WriteLine();
Console.WriteLine("-- Dados do Gerente --");
gerente.RegistrarEntrada();
gerente.RealizarReuniao();
gerente.ExibirDadosGerente();
