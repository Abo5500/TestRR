using Application.Options;
using Application.PriceItems;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ApplicationUnitTests
{
    public class PriceItemTakerTests
    {
        /*[Fact]
        public async Task GetPriceItemsFromScvSuccess()
        {
            //Arrange
            string csvExample = "Номенклатура;Бренд;Артикул;Описание;Вес/Объем;Кратность отгрузки;Цена, руб.;Базовая цена, руб;Наличие;Срок поставки, дн.;Каталожный номер;OEМ Номер;Применимость;Вендор-код\r\nNSIN0018472693;555;SA1712L;Рычаг подвески | перед лев |;1,68;1;1343,68;2123,14;2;0;SA-1712L;\"SA-1712R;51376;0501-050;0501-051;0505-DEM;0524-DEM;D201-34-350A;HCA-3814L;\";MAZDA Demio DW3W 00- , KIA AVELLA 94- LOW L;SA1712L\r\nNSIN0018472694;555;SA1712R;Рычаг подвески | перед прав |;1,68;1;1343,68;2123,14;2;0;SA-1712R;\"SA-1712L;51377;D201-34-300E;HCA-3814R;D20134300A;D201-34-300B;D201-34-300C;\";MAZDA Demio DW3W 00- , KIA AVELLA 94- LOW R;SA1712R\r\n";
            SupplierOptions supplierOptions = new SupplierOptions()
            {
                Vendor = "Бренд",
                Number = "Каталожный номер",
                Description = "Описание",
                Price = "Цена, руб.",
                Count = "Наличие"
            };
            PriceItemTaker priceItemTaker = new();
            //Act
            List<PriceItem> priceItems = await priceItemTaker.GetPriceItemsFromScvAsync(csvExample, supplierOptions);
            //Assert
            Assert.Equal(2, priceItems.Count);
        }*/
    }
}
