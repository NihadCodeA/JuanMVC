using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JuanMVC.Models
{
    public class JuanDb : DbContext
    {
        public JuanDb(DbContextOptions<JuanDb> options):base(options) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<BannerProduct> BannerProducts { get; set; }

    }
}
