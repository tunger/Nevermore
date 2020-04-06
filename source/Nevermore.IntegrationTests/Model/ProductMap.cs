using System;
using System.Collections.Generic;
using Nevermore.Contracts;
using Nevermore.Mapping;

namespace Nevermore.IntegrationTests.Model
{
    public class ProductMap<TProduct> : DocumentHierarchyMap<TProduct, ProductType> where TProduct : Product
    {
        public ProductMap(RelationalStoreConfiguration relationalStoreConfiguration) : base(relationalStoreConfiguration)
        {
            Column(m => m.Name);
            Column(m => m.Type);
        }
        
        readonly Dictionary<ProductType, Type> derivedTypeMappings = new Dictionary<ProductType, Type>
        {
            {ProductType.Dodgy, typeof(DodgyProduct)},
            {ProductType.Special, typeof(SpecialProduct)},
            {ProductType.Normal, typeof(Product)}
        };

        protected override IDictionary<ProductType, Type> DerivedTypeMappings => derivedTypeMappings;
        protected override string TypeDesignatingPropertyName => "Type";
    }

    public class SpecialProductMap : ProductMap<SpecialProduct>
    {
        public SpecialProductMap(RelationalStoreConfiguration relationalStoreConfiguration) : base(relationalStoreConfiguration)
        {
            TableName = typeof(Product).Name;
            Column(m => m.BonusMaterial).IsNullable = true;
        }

        readonly Dictionary<ProductType, Type> derivedTypeMappings = new Dictionary<ProductType, Type>
        {
            {ProductType.Special, typeof(SpecialProduct)}
        };

        protected override IDictionary<ProductType, Type> DerivedTypeMappings => derivedTypeMappings;
    }

    public class ProductToTestSerialization : IDocument
    {
        public string Id { get; set; }
        public string Name { get; set; }
     
        public string Type { get; set; }
        public string JSON { get; set; }
    }

    public class ProductToTestSerializationMap : DocumentMap<ProductToTestSerialization>
    {
        public ProductToTestSerializationMap(RelationalStoreConfiguration relationalStoreConfiguration) : base(relationalStoreConfiguration)
        {
            TableName = "Product";
            Column(x => x.Name);
            Column(x => x.Type);
            Column(x => x.JSON);
        }
    }
}