using Nevermore.IntegrationTests.Model;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;

namespace Nevermore.IntegrationTests.RelationalTransaction
{
    public class DeleteFixture : FixtureWithRelationalStore
    {
        public DeleteFixture(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void DeleteByEntity()
        {
            var id = AddTestProduct();

            using (var trn = Store.BeginTransaction())
            {
                var product = trn.Load<Product>(id);
                trn.Delete(product);
                trn.Commit();
            }

            using (var trn = Store.BeginTransaction())
                trn.Load<Product>(id).Should().BeNull();
        }

        [Fact]
        public void DeleteById()
        {
            var id = AddTestProduct();

            using (var trn = Store.BeginTransaction())
            {
                trn.DeleteById<Product>(id);
                trn.Commit();
            }

            using (var trn = Store.BeginTransaction())
                trn.Load<Product>(id).Should().BeNull();
        }

        [Fact]
        public void DeleteManyByEntity()
        {
            var productIds = new[]
            {
                AddTestProduct(),
                AddTestProduct("bar"),
                AddTestProduct("baz")
            };

            using (var trn = Store.BeginTransaction())
            {
                var products = trn.Load<Product>(productIds);
                trn.DeleteMany(products);
                trn.Commit();
            }

            using (var trn = Store.BeginTransaction())
                trn.Load<Product>(productIds).Should().BeNullOrEmpty();
        }

        [Fact]
        public void DeleteManyById()
        {
            var productIds = new[]
            {
                AddTestProduct(),
                AddTestProduct("bar"),
                AddTestProduct("baz")
            };

            using (var trn = Store.BeginTransaction())
            {
                trn.DeleteManyById<Product>(productIds);
                trn.Commit();
            }

            using (var trn = Store.BeginTransaction())
                trn.Load<Product>(productIds).Should().BeNullOrEmpty();
        }

        string AddTestProduct(string name = "foo")
        {
            using (var trn = Store.BeginTransaction())
            {
                var product = new Product()
                {
                    Name = name
                };
                trn.Insert(product);
                trn.Commit();
                return product.Id;
            }
        }
    }
}