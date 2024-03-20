using Application.Interfaces.PriceItems;
using Application.Interfaces;
using Application.Options;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Options;

namespace Application.PriceItems.Commands.LoadPriceListFromEmailToDb
{
    public class LoadPriceListFromEmailToDbCommand : IRequest<int>
    {
        public string SupplierName { get; set; }
    }
    public class LoadPriceListFromEmailToDbCommandHandler : IRequestHandler<LoadPriceListFromEmailToDbCommand, int>
    {
        private readonly IPriceItemTaker _priceItemTaker;
        private readonly IEmailTaker _emailTaker;
        private readonly IPriceItemRepository _priceItemRepository;
        private readonly List<SupplierOptions> _supplierOptions;

        public LoadPriceListFromEmailToDbCommandHandler(IPriceItemTaker priceItemTaker, IEmailTaker emailTaker, IPriceItemRepository priceItemRepository, IOptions<List<SupplierOptions>> supplierOptions)
        {
            _priceItemTaker = priceItemTaker;
            _emailTaker = emailTaker;
            _priceItemRepository = priceItemRepository;
            _supplierOptions = supplierOptions.Value;
        }

        public async Task<int> Handle(LoadPriceListFromEmailToDbCommand request, CancellationToken cancellationToken)
        {
            SupplierOptions supplierOptions = _supplierOptions.First(o => o.Name == request.SupplierName);
            string csvFilePath = $"C:\\Users\\admin\\source\\repos\\TestRR\\Application\\CsvFiles\\{request.SupplierName}_{DateTime.Now:MM-dd-yy-HH-mm}.csv";
            await _emailTaker.LoadFileAsync(supplierOptions.Email, csvFilePath);
            int index = 0;
            int chunkSize = 500;
            int rowCount = 0;
            int GCindex = 0;
            List<PriceItem> priceItems = await _priceItemTaker.GetPriceItemsPartFromScvAsync(csvFilePath, index, chunkSize, supplierOptions);

            while (priceItems.Count != 0)
            {
                rowCount += await _priceItemRepository.AddPriceItemsAsync(priceItems);
                index += chunkSize;

                priceItems = await _priceItemTaker.GetPriceItemsPartFromScvAsync(csvFilePath, index, chunkSize, supplierOptions);
            }
            return rowCount;
        }
    }
}
