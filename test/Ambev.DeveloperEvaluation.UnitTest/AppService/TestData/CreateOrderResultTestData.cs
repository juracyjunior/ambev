using Bogus;
using Ambev.DeveloperEvaluation.AppService.Result;
using Ambev.DeveloperEvaluation.AppService.Command;
using Bogus.DataSets;

namespace Ambev.DeveloperEvaluation.UnitTest.AppService.TestData
{
    public static class CreateOrderResultTestData
    {
        private static readonly Faker<CreateOrderResult> faker = new Faker<CreateOrderResult>()
            .RuleFor(r => r.Id, f => Guid.NewGuid())
            .RuleFor(r => r.SaleNumber, f => Guid.NewGuid())
            .RuleFor(r => r.SaleDate, f => f.Date.Past())
            .RuleFor(r => r.IdCustomer, f => Guid.NewGuid())
            .RuleFor(r => r.TotalAmount, f => f.Finance.Amount())
            .RuleFor(r => r.IdBranch, f => Guid.NewGuid())
            .RuleFor(r => r.Items, f => new Faker<CreateOrderItemResult>()
                .RuleFor(i => i.Quantity, f => f.Random.Int(1, 10))
                .RuleFor(i => i.UnitPrice, f => f.Finance.Amount(1, 100))
                .RuleFor(i => i.Discount, f => f.Finance.Amount(0, 10))
                .RuleFor(i => i.TotalAmount, (f, i) => i.Quantity * i.UnitPrice - i.Discount)
                .RuleFor(i => i.IdProduct, f => Guid.NewGuid())
                .Generate(3))
            .RuleFor(r => r.IsCancelled, f => f.Random.Bool());

        public static CreateOrderResult Generate()
        {
            return faker.Generate();
        }

        public static List<CreateOrderResult> Generate(int count)
        {
            return faker.Generate(count);
        }
    }
}
