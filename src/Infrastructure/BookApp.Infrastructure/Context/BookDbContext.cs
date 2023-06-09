﻿using BookApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure.Context
{
	public class BookDbContext : IdentityDbContext<AppUser,AppRole, int>
	{
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {            
        }

		public DbSet<Book> Books { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Writer> Writers { get; set; }
		public DbSet<Publisher> Publishers { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}
