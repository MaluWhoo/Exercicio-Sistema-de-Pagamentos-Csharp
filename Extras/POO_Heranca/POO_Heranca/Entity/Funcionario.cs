namespace POO_Heranca.Entity
{
    internal class Funcionario
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public decimal Salario { get; set; }

        // CONSTRUTOR
        public Funcionario(string nome, string cpf, decimal salario)
        {
            Nome = nome;
            Cpf = cpf;
            Salario = salario;
        }

        // METODO
        public void RegistrarEntrada()
        {
            Console.WriteLine($"{Nome} registrou entrada ás {DateTime.Now:HH:mm}.");
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine();
            Console.WriteLine("=== FUNCIONARIO ===");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"CPF: {Cpf}");
            Console.WriteLine($"Salário: {Salario:C}");
        }
    }
}
