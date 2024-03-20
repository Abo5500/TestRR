using Application.Options;
using Domain.Entities;

namespace Application.Interfaces.PriceItems
{
    public interface IPriceItemTaker
    {
        public Task<List<PriceItem>> GetPriceItemsPartFromScvAsync(string filePath, int index, int chunkSize, SupplierOptions supplierOptions);
    }
}
