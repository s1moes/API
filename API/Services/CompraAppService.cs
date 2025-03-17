using MongoDB.Driver;
using API_ToDo.Models;
using API_ToDo.Services;

public class CompraAppService : ICompraAppService
{
    private readonly IMongoCollection<Compra> _collection;

    public CompraAppService()
    {
        
    }

    //public async Task<Compra> CreateAsync(Compra input)
    //{
    //    var compra = new Compra
    //    {
    //        Produto = input.Produto,
    //        isChecked = input.isChecked
    //    };

    //    // Ensure the ID is set to a new Guid
    //    compra.Id = Guid.NewGuid();

    //    await _compraRepository.InsertAsync(compra);
    //    return _compraMapper.MapToDto(compra);
    //}

    public async Task<List<Compra>> GetAllComprasAsync()
    {
        var comprasBson = await _collection.Find(FilterDefinition<Compra>.Empty).ToListAsync();

        return comprasBson.ToList();
    }

    //public async Task DeleteAllComprasAsync()
    //{
    //    await _compraRepository.DeleteAllAsync();
    //}

    //public async Task<bool> DeleteByIdCompraAsync(Guid id)
    //{
    //    return await _compraRepository.DeleteByIdAsync(id);
    //}
}
