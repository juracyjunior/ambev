using Ambev.DeveloperEvaluation.AppService.Result;
using Bogus;

namespace Ambev.DeveloperEvaluation.UnitTest.AppService.TestData
{
    public static class GetOrderResultTestData
    {
        private static readonly Faker<GetOrderResult> GetOrderResultFaker = new Faker<GetOrderResult>()
            .RuleFor(o => o.Id, f => Guid.NewGuid())
            .RuleFor(o => o.SaleNumber, f => Guid.NewGuid())
            .RuleFor(o => o.SaleDate, f => f.Date.Past())
            .RuleFor(o => o.Customer, f => new Faker<CustomerResult>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Person.FullName)
                .Generate())
            .RuleFor(o => o.Branch, f => new Faker<BranchResult>()
                .RuleFor(b => b.Id, f => Guid.NewGuid())
                .RuleFor(b => b.Name, f => f.Company.CompanyName())
                .Generate())
            .RuleFor(o => o.Items, f => new Faker<GetOrderItemResult>()
                .RuleFor(i => i.Quantity, f => f.Random.Int(1, 20))
                .RuleFor(i => i.UnitPrice, f => f.Finance.Amount(1, 10000))
                .RuleFor(i => i.Discount, f => f.Finance.Amount(0, 10))
                .RuleFor(i => i.Product, f => new Faker<ProductResult>()
                    .RuleFor(p => p.Id, f => Guid.NewGuid())
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .Generate())
                .Generate(3))
            .RuleFor(o => o.IsCancelled, f => f.Random.Bool());

        public static GetOrderResult Generate()
        {
            return GetOrderResultFaker.Generate();
        }

        public static List<GetOrderResult> Generate(int count)
        {
            return GetOrderResultFaker.Generate(count);
        }
    }
}
