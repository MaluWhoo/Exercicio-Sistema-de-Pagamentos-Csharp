namespace POO_Heranca.Entity
{
    internal class Desenvolvedor : Funcionario
    {
        public string LinguagemPrincipal { get; set; }
        public string Nivel { get; set; }

        public Desenvolvedor(string nome, string cpf, decimal salario, string linguagemPrincipal, string nivel) :
            base(nome, cpf, salario)
        {
            LinguagemPrincipal = linguagemPrincipal;
            Nivel = nivel;
        }

        //  METODO
        public void DesenvolverFuncionalidade()
        {
            Console.WriteLine($"{Nome} está desenvolvendo uma funcionalidade em {LinguagemPrincipal}.");
        }

        public void ExibirDadosDesenvolvedor()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Linguagem Principal: {LinguagemPrincipal}");
            Console.WriteLine($"Nível Técnico: {Nivel}");
        }
    }
}