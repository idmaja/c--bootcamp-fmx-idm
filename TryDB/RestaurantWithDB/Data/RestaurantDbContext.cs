using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class RestaurantDbContext : IdentityDbContext
{
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }    
    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var adminRoleId = "ROLE_ADMIN";
        var superAdminRoleId = "ROLE_SUPERADMIN";
        var userRoleId = "ROLE_USER";

        // add roles
        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name= "Admin",
                NormalizedName = "ADMIN",
                Id = adminRoleId,
                ConcurrencyStamp = adminRoleId
            },
            new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = superAdminRoleId,
                ConcurrencyStamp = superAdminRoleId
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = userRoleId,
                ConcurrencyStamp = userRoleId
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);

        // add Super Admin User
        var superAdminId = Guid.NewGuid().ToString().ToUpper();
        var superAdminEmail = "superadmin@gmail.com";
        var superAdminUser = new IdentityUser
        {
            Id = superAdminId,
            UserName = "superadmin",
            NormalizedEmail = "superadmin".ToUpper(),
            Email = superAdminEmail,
            NormalizedUserName = superAdminEmail.ToUpper(),
        };

        superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
            .HashPassword(superAdminUser, "Aa123!");

        builder.Entity<IdentityUser>().HasData(superAdminUser);

        var superAdminRoles = new List<IdentityUserRole<string>>
        {
            new IdentityUserRole<string>
            {
                RoleId = superAdminRoleId,
                UserId = superAdminId
            }
        };

        builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

        // add dummy restaurant
        builder.Entity<Restaurant>().HasData(new Restaurant
        {
            RestaurantName = "Resto A",
            RestaurantAddress = "CSharp Street 1st Floor",
            OwnerId = superAdminId,
            IsActive = true,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        });
    }
}