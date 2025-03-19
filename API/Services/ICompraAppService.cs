using API.Models;

namespace API.Services
{
    public interface ICompraAppService
    {
        Task<List<Compra>> GetAllComprasAsync();
    }
}
