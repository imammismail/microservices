using OrderServices.Models;

namespace OrderServices.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateAsyncScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Orders.Any())
            {
                Console.WriteLine("--> Seeding Data.. <--");
                context.Orders.AddRange(
                    new Order()
                    {
                        ProductId = 2,
                        ProductName = "Apel",
                        Qty = 1,
                        Price = 20,
                        UserNameOrder = "arka"
                    });
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Sudah ada data <--");
            }
        }
    }
}