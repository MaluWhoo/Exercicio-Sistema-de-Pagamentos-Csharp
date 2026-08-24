namespace Sistema_Pagamento.Entity
{
    public abstract class FormaPagamento
    {
        public abstract decimal CalcularValorFinal(decimal valor);
    }
}
