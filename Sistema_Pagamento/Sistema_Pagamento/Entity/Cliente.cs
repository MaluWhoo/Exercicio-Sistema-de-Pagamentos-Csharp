namespace Sistema_Pagamento.Entity
{
    internal class Cliente
    {
        public string Nome { get; }
        public string CPF { get; }

        public Cliente(string nome, string cpf)
        {
            ValidarInformacoes(nome, cpf);

            Nome = nome;
            CPF = cpf;
        }

        private void ValidarInformacoes(string nome, string cpf) 
        {
            if (string.IsNullOrEmpty(nome)) { throw new ArgumentException("\nUm nome deve ser registrado."); }

            if (string.IsNullOrWhiteSpace(cpf) || cpf.Trim().Length != 11) { throw new ArgumentException("\nO CPF deve ser informado e deve contém 11 números."); }
        }
    }
}