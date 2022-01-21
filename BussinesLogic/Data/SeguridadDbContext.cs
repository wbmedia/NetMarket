using System;
using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BussinesLogic.Data
{
	public class SeguridadDbContext : IdentityDbContext
	{
		public SeguridadDbContext(DbContextOptions<SeguridadDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

