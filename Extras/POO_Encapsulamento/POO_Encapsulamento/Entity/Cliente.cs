using System.Runtime.Serialization;

namespace POO_Encapsulamento.Entity
{
    internal class Cliente
    {
        public string Nome { get; }
        public string CPF { get; }
        private string Senha;

        public Cliente(string nome, string cpf, string senha)
        {
            ValidarInformacoes(nome, cpf, senha);

            Nome = nome;
            CPF = cpf;
            Senha = senha;

            Console.WriteLine();
        }

        private void ValidarInformacoes(string nome, string cpf, string senha)
        {
            if (string.IsNullOrWhiteSpace(nome)) { throw new ArgumentNullException((nome), "Um nome deve ser informado."); }

            if (string.IsNullOrWhiteSpace(cpf) || cpf.Trim().Length != 11) { throw new ArgumentNullException((nome), "O CPF deve ser informado e deve contém 11 números."); }

            if (string.IsNullOrWhiteSpace(senha) || senha.Trim().Length != 4) { throw new ArgumentNullException((senha), "Insirá uma senha válida. A senha precisa ter 4 caracteres."); }
        }

        public bool ValidarSenha(string senha, Conta conta)
        {
            if (string.IsNullOrWhiteSpace(senha) || senha.Trim().Length != 4) { throw new ArgumentNullException((senha), "Insirá uma senha válida."); }

            return Senha == senha;
        }
    }
}
