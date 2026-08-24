namespace POO_Encapsulamento.Entity
{
    internal class Conta
    {
        public Cliente Cliente { get; }
        public string NumeroConta { get; }
        public decimal Saldo { get; private set; }
        public bool EstaAtiva { get; private set; }
        private int tentativasRestantes = 3;
        public string Situacao => EstaAtiva ? "Ativa" : "Bloqueada";

        public Conta(Cliente cliente, string numeroConta)
        {
            ValidarInformacoes(numeroConta, cliente);

            Cliente = cliente;
            NumeroConta = numeroConta;
            Saldo = 0;
            EstaAtiva = true;

            Console.WriteLine();
        }

        private void ValidarInformacoes(string numeroConta, Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(numeroConta)) { throw new ArgumentNullException("O numero da conta deve ser informado!"); }

            if (cliente == null) { throw new ArgumentNullException("O cliente deve ser informado"); }
        }

        public void Depositar(decimal valor, string senha, Conta conta)
        {
            if (!EstaAtiva)
            {
                Console.WriteLine("\nConta bloqueada. Não é possível realizar depósito nessa conta.");
                return;
            }

            if (valor <= 0)
            {
                Console.WriteLine("Valor inválido. Tente novamente.");
                return;
            }

            if (!Cliente.ValidarSenha(senha, conta))
            {
                Console.WriteLine("\nSenha incorreta.");
                BloquearContaPorTentativa(senha, conta);
                return;
            }

            Saldo += valor;
            Console.WriteLine($"\nDepósito: {valor:C} realizado com sucesso!\n");
        }

        public void Sacar(decimal valor, string senha, Conta conta)
        {
            if (!EstaAtiva)
            {
                Console.WriteLine("\nConta bloqueada. Não é possível realizar saque nessa conta.");
                return;
            }

            if (valor <= 0)
            {
                Console.WriteLine("Valor inválido para saque.");
                return;
            }

            if (valor > Saldo)
            {
                Console.WriteLine("Saldo insuficiente para saque.");
                return;
            }

            if (!Cliente.ValidarSenha(senha, conta))
            {
                Console.WriteLine("Senha incorreta.");
                return;
            }

            Saldo -= valor;
            Console.WriteLine($"\nSaque: {valor:C} realizado com sucesso!");
            Console.WriteLine($"Saldo atual: {Saldo:C}.\n");
        }

        public void Consultar(string senha, Conta conta)
        {
            Console.WriteLine();
            Console.WriteLine($"Titular: {Cliente.Nome}");
            Console.WriteLine($"CPF: {Cliente.CPF}");
            Console.WriteLine($"Saldo atual: {Saldo:C}");
            Console.WriteLine($"Status da Conta: {Situacao}");

            if (!EstaAtiva)
            {
                Console.Write("\nDeseja desbloquear sua conta? (S/N) --> ");
                string resposta = Console.ReadLine().ToUpper();

                if (resposta == "S")
                {
                    Console.Write("Confirmar senha: ");
                    string senhaConfirmada = Console.ReadLine();

                    Cliente.ValidarSenha(senha, conta);

                    EstaAtiva = true;
                }

                return;
            }
        }

        public bool BloquearContaPorTentativa(string senha, Conta conta)
        {
            if (!EstaAtiva)
            {
                Console.WriteLine("A conta já está bloqueada.");
                return false;
            }

            if (!Cliente.ValidarSenha(senha, conta))
            {
                tentativasRestantes--;
                Console.WriteLine($"Tentativas restantes: {tentativasRestantes}/3");

                if (tentativasRestantes <= 0)
                {
                    EstaAtiva = false;
                    Console.WriteLine($"Conta bloqueada por excesso de tentativas!");
                }

                return false;
            }

            tentativasRestantes = 3;
            return true;
        }

        public void DesbloquearConta(string senha, Conta conta)
        {
            if (!Cliente.ValidarSenha(senha, conta))
            {
                Console.WriteLine("\nSenha incorreta!");
                return;
            }

            //if (!EstaAtiva)
            //{
            //    Console.WriteLine("A conta já está ativa.");
            //    return;
            //}

            //EstaAtiva = true;
            //Console.WriteLine($"Conta deesbloqueada com sucesso!");
        }
    }
}