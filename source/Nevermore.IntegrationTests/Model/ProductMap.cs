using Nevermore.Mapping;

namespace Nevermore.IntegrationTests.Model
{
    public class ProductMap : DocumentMap<Product>
    {
        public ProductMap()
        {
            Column(m => m.Name);
            Column(m => m.Type);
            
            JsonStorageFormat = JsonStorageFormat.CompressedOnly;
        }
    }
}