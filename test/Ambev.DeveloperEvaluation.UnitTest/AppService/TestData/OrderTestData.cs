using Ambev.DeveloperEvaluation.AppService.Result;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.UnitTest.AppService.TestData
{
    public static class OrderTestData
    {
        private static readonly Faker<Order> OrderFaker = new Faker<Order>()
            .RuleFor(o => o.Id, f => Guid.NewGuid())
            .RuleFor(o => o.SaleNumber, f => Guid.NewGuid())
            .RuleFor(o => o.SaleDate, f => f.Date.Past())
            .RuleFor(o => o.Customer, f => new Faker<Customer>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Person.FullName)
                .Generate())
            .RuleFor(o => o.Branch, f => new Faker<Branch>()
                .RuleFor(b => b.Id, f => Guid.NewGuid())
                .RuleFor(b => b.Name, f => f.Company.CompanyName())
                .Generate())
            .RuleFor(o => o.Items, f => new Faker<OrderItem>()
                .RuleFor(b => b.Id, f => Guid.NewGuid())
                .RuleFor(i => i.Quantity, f => f.Random.Int(1, 20))
                .RuleFor(i => i.UnitPrice, f => f.Finance.Amount(1, 10000))
                .RuleFor(i => i.Discount, f => f.Finance.Amount(0, 10))
                .RuleFor(i => i.Product, f => new Faker<Product>()
                    .RuleFor(p => p.Id, f => Guid.NewGuid())
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .Generate())
                .Generate(3))
            .RuleFor(o => o.IsCancelled, f => f.Random.Bool());

        public static Order Generate()
        {
            return OrderFaker.Generate();
        }

        public static List<Order> Generate(int count)
        {
            return OrderFaker.Generate(count);
        }
    }
}
