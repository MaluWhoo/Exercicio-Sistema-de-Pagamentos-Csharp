namespace POO_Heranca.Entity
{
    internal class Gerente : Funcionario
    {
        public string Setor { get; set; }
        public int QtddPessoasEquipe { get; set; }

        public Gerente(string nome, string cpf, decimal salario, string setor, int qtddPessoaEquipe) :
            base(nome, cpf, salario)
        {
            Setor = setor;
            QtddPessoasEquipe = qtddPessoaEquipe;
        }

        // METODO
        public void RealizarReuniao()
        {
            Console.WriteLine($"O Gerente {Nome}, está em reunião com sua equipe no setor {Setor}.");
        }

        public void ExibirDadosGerente() 
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Setor: {Setor}");
            Console.WriteLine($"Quantidade de pessoas na equipe: {QtddPessoasEquipe}");
        }
    }
}
