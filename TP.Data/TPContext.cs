using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Principal;
using TP.Data.Entities;
using TP.Core;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace TP.Data
{
    public class TPContext : DbContext
    {
        //private readonly IHttpContextAccessor _accessor;

        private readonly IConfiguration configuration;

        public TPContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            //this._accessor = accessor;
        }

        //private readonly string connectionString = "Data Source=GBUMCST01\\MCPROD_TEST;Database=TahsilatPortfoy;User id=mctest;password=mctest;";


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            

            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(type.ClrType))
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString, r => r.UseRowNumberForPaging());
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DefaultConnectionString"), r => r.UseRowNumberForPaging());
        }

        public virtual void Save()
        {
            base.SaveChanges();
        }
        //public int GetUserIdFromSession()
        //{
        //    if (_accessor.HttpContext == null)
        //        return 33;

        //    return Convert.ToInt32(_accessor.HttpContext.Session.GetString(Consts.CurrentDomainSessionUserIdKey));
        //}

        //public string GetUserFullNameFromSession()
        //{
        //    if (_accessor.HttpContext == null)
        //        return "Dakik System User";
                
        //    return Convert.ToString(_accessor.HttpContext.Session.GetString(Consts.CurrentDomainSessionUserFullNameKey));
        //}

        //public  string GetUsernameFromSession()
        //{
        //    if (_accessor.HttpContext == null)
        //        return "dakiksystemuser";

        //    return Convert.ToString(_accessor.HttpContext.Session.GetString(Consts.CurrentDomainSessionUsernameKey));
        //}
        //public string UserProvider
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(GetUsernameFromSession()))
        //            return GetUsernameFromSession();
        //        return string.Empty;
        //    }
        //}

        //public override int SaveChanges()
        //{
        //    TrackChanges();
        //    return base.SaveChanges();
        //}

        //private void TrackChanges()
        //{
        //    foreach (var entry in this.ChangeTracker.Entries())
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Added:
        //                ApplyCreateAudite(entry);
        //                break;

        //            case EntityState.Modified:
        //                ApplyUpdateAudite(entry);
        //                break;

        //            case EntityState.Deleted:
        //                ApplyUpdateAudite(entry);
        //                ApplyDeleteAudite(entry);
        //                break;
        //        }
        //    }
        //}

        
        //private void ApplyCreateAudite(EntityEntry entry)
        //{

        //    if (entry.Entity is ICreateAuditable auditable)
        //    {
                 
        //        auditable.CreatedById = 1;
        //        auditable.CreatedByCode = "local";
        //        auditable.CreatedTime = DateTime.Now;
        //    }
        //}

        //private void ApplyUpdateAudite(EntityEntry entry)
        //{
        //    if (entry.Entity is IUpdateAuditable auditable)
        //    {
        //        auditable.UpdatedById = 1;
        //        auditable.UpdatedByCode = "";
        //        auditable.UpdatedTime = DateTime.Now;
        //    }
        //}

        //private void ApplyDeleteAudite(EntityEntry entry)
        //{
        //    if (entry.Entity is ISoftDeletable auditable)
        //    {
        //        auditable.GcRecordId = Guid.NewGuid();
        //        entry.State = EntityState.Modified;
        //    }
        //}

        
        public DbSet<User> User { get; set; }

        public DbSet<Trit> Trit { get; set; }

        public DbSet<TritLike> TritLike { get; set; }

    }
}