
namespace ModuloPOO
{
    internal class Funcionario
    {
        // PROPIEDADE   
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
        public int HorasTrabalhadas { get; set; }

        // CONSTRUTOR
        public Funcionario(string nome, string cargo, decimal salario)
        {
            Nome = nome;
            Cargo = cargo;
            Salario = salario;
        }

        // METODOS
        // Modificador de acesso + tipo de retorno() + caso paramentros: o tipo e nome
        public void RegistrarHoras(int horas)
        {
            if (horas <= 0)
            {
                Console.WriteLine("A quantidade de horas deve ser maior que zero.");
                return;
            }

            HorasTrabalhadas += horas;
            Console.WriteLine($"{horas} hora(s) registrada(s) para {Nome}");
        }

        public void AumentarSalario(decimal percentual)
        {
            if (percentual <= 0)
            {
                Console.WriteLine("O Percentual deve ser maior que zero.");
                return;
            }

            decimal valorAumento = Salario * percentual / 100;
            Salario += valorAumento;

            Console.WriteLine($"O Salário de {Nome} aumentado em {percentual}%");
            Console.WriteLine($"Salario atual: {Salario:C}");
        }

        public decimal CalcularValorHora()
        {
            if (HorasTrabalhadas <= 0)
            {
                Console.WriteLine($"Não é possível calcular o valor da hora de {Nome}. Ainda não existem horas registradas.");
                return 0;
            }

            return Salario / HorasTrabalhadas;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"\n== DADOS DO FUNCIONÁRIO ==");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Cargo: {Cargo}");
            Console.WriteLine($"Salário: {Salario:C}");
            Console.WriteLine($"Horas Trabalhadas: {HorasTrabalhadas}");

            if (HorasTrabalhadas > 0)
                Console.WriteLine($"Valor/Hora: {CalcularValorHora()}");
            else
                Console.WriteLine("Valor/Hora: Não disponível.");
        }
    }
}