using MongoDB.Driver;
using API.Models;
using API.Services;
using AutoMapper;

public class CompraAppService : ICompraAppService
{
    private readonly IMongoCollection<Compra> _collection;

    public CompraAppService(IMongoDatabase database)
    {
        _collection = database.GetCollection<Compra>("Compras");
    }

    public async Task<List<Compra>> GetAllComprasAsync()
    {
        return await _collection.Find(FilterDefinition<Compra>.Empty).ToListAsync();
    }

}
