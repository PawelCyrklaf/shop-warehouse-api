﻿using Microsoft.EntityFrameworkCore;

namespace ShopWarehouse.API.Data.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}