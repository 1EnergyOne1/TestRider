using Microsoft.EntityFrameworkCore;
using TestRider.Models;

namespace TestRider.Data;

public class UserContext: DbContext
{
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {}

    public DbSet<User> Users => Set<User>();
}