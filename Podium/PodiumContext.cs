namespace Podium
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;
    using Podium.Models.DbModels;

    public class PodiumContext : DbContext
    {
        public PodiumContext(DbContextOptions <PodiumContext> options) : base(options) {}
        
        public DbSet<UserDbModel> Users { get; set; }
        public DbSet<UserSessionDbModel> UserSessions { get; set; }
    }
}