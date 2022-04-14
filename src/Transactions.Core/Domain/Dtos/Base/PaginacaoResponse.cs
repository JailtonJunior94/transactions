namespace Transactions.Core.Domain.Dtos.Base
{
    public class PaginationResponse<T>
    {
        public PaginationResponse(IList<T> resultado, int total, int pagina, int quantidade)
        {
            Pagina = pagina;
            TotalPaginas = (int)Math.Ceiling(total / (double)quantidade);
            TotalRegistros = total;
            Resultado = resultado;
        }

        public int Pagina { get; }
        public int TotalPaginas { get; }
        public int TotalRegistros { get; }
        public IList<T> Resultado { get; }
    }
}
