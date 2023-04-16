using WalletServices.Models;

namespace WalletServices.Data
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
            if (!context.Wallets.Any())
            {
                Console.WriteLine("--> Seeding Data.. <--");
                context.Wallets.AddRange(
                    new Wallet()
                    {
                        UserName = "Eka",
                        FullName = "Eka putri",
                        Cash = 45000
                    },
                    new Wallet()
                    {
                        UserName = "Arka",
                        FullName = "Arkatama Ardelio",
                        Cash = 80000
                    },
                    new Wallet()
                    {
                        UserName = "Alex",
                        FullName = "Alexandria asa",
                        Cash = 100000
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