namespace POO_Polimorfismo.Entity
{
    internal class Cliente
    {
        public int Id { get; }
        public string Nome { get; }

        public Cliente(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void ExibirInformacoes(Cliente cliente) 
        {
            Console.WriteLine($"{Id} - {Nome}");
        }
    }
}
