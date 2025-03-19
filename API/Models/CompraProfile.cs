using AutoMapper;

namespace API.Models
{
    public class CompraProfile : Profile
    {
        public CompraProfile()
        {
            CreateMap<Compra, CompraDto>();
        }
    }
}
