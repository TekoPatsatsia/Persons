using Persons.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persons.Infrastructure.Data.Configurations
{
    public static class UserConfiguration
    {
		public static void ConfigureTranslate(this ModelBuilder builder)
		{
			builder.Entity<User>()
		   .HasIndex(p => new{ p.IdNumber})
		   .IsUnique(true);
		}
	}
}
