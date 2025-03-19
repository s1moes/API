using Abp.Application.Services.Dto;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class CompraDto : AuditedEntityDto<Guid>
    {
        
        public required string Produto { get; set; }
        
        public bool isChecked { get; set; }
    }
}
