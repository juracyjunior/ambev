using Ambev.DeveloperEvaluation.AppService.Result;
using Bogus;

namespace Ambev.DeveloperEvaluation.UnitTest.AppService.TestData
{
    public static class UpdateOrderResultTestData
    {
        private static readonly Faker<UpdateOrderResult> faker = new Faker<UpdateOrderResult>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.SaleNumber, f => Guid.NewGuid())
            .RuleFor(c => c.SaleDate, f => f.Date.Past())
            .RuleFor(c => c.IdCustomer, f => Guid.NewGuid())
            .RuleFor(c => c.TotalAmount, f => f.Finance.Amount())
            .RuleFor(c => c.IdBranch, f => Guid.NewGuid())
            .RuleFor(c => c.Items, f => new Faker<UpdateOrderItemResult>()
                .RuleFor(i => i.Quantity, f => f.Random.Int(1, 10))
                .RuleFor(i => i.UnitPrice, f => f.Finance.Amount(1, 100))
                .RuleFor(i => i.Discount, f => f.Finance.Amount(0, 10))
                .RuleFor(i => i.TotalAmount, (f, i) => i.Quantity * i.UnitPrice - i.Discount)
                .RuleFor(i => i.IdProduct, f => Guid.NewGuid())
                .Generate(3))
            .RuleFor(c => c.IsCancelled, f => f.Random.Bool());


        public static UpdateOrderResult Generate()
        {
            return faker.Generate();
        }

        public static List<UpdateOrderResult> Generate(int count)
        {
            return faker.Generate(count);
        }
    }
}
