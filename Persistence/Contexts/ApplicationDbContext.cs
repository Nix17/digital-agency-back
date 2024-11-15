﻿using Application.Interfaces.Services;

using Domain.Common;
using Domain.Entities;
using Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    private IDbContextTransaction _currentTransaction;
    private readonly IDateTimeService _dateTime;
    //private readonly IAuthenticatedUserService _authenticatedUser;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IDateTimeService dateTime
        ) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        _dateTime = dateTime;
        //Database.EnsureDeleted();
        Database.EnsureCreated(); 
    }

    public DbSet<SiteTypeEntity> SiteTypes { get; set; }
    public DbSet<SiteModulesEntity> SiteModules { get; set; }
    public DbSet<SiteDesignEntity> SiteDesigns { get; set; }
    public DbSet<OptionalDesignEntity> OptionalDesigns { get; set; }
    public DbSet<SiteSupportEntity> SiteSupports { get; set; }

    public DbSet<DevelopmentTimelineEntity> DevelopmentTimelines { get; set; }

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<OfferEntity> Offers { get; set; }
    public DbSet<OfferModulesEntity> OfferModules { get; set; }
    public DbSet<OfferSupportEntity> OfferSupports { get; set; }
    public DbSet<OfferOptionalDesignsEntity> OfferOptionalDesigns { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasPostgresExtension("uuid-ossp");
        builder.HasPostgresExtension("pg_stat_statements");
        builder.HasPostgresExtension("hstore");
        builder.HasPostgresExtension("ltree");

        builder.ApplyConfiguration(new SiteTypeConfiguration());
        builder.ApplyConfiguration(new SiteModulesConfiguration());
        builder.ApplyConfiguration(new SiteDesignConfiguration());
        builder.ApplyConfiguration(new OptionalDesignConfiguration());
        builder.ApplyConfiguration(new SiteSupportConfiguration());
        builder.ApplyConfiguration(new DevelopmentTimelineConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());

        builder.ApplyConfiguration(new OfferConfiguration());
        builder.ApplyConfiguration(new OfferModulesConfiguration());
        builder.ApplyConfiguration(new OfferOptionalDesignsConfiguration());
        builder.ApplyConfiguration(new OfferSupportConfiguration());
        builder.ApplyConfiguration(new OrderConfiguration());


        base.OnModelCreating(builder);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableIntIdEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = _dateTime.NowUtc;
                    entry.Entity.LastModified = _dateTime.NowUtc;
                    //entry.Entity.CreatedBy = _authenticatedUser.UserId;
                    //entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                    entry.Entity.CreatedBy = "root";
                    entry.Entity.LastModifiedBy = "root";
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = _dateTime.NowUtc;
                    //entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                    entry.Entity.LastModifiedBy = "root";
                    break;
            }
        }

        foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = _dateTime.NowUtc;
                    entry.Entity.LastModified = _dateTime.NowUtc;
                    //entry.Entity.CreatedBy = _authenticatedUser.UserId;
                    //entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                    entry.Entity.CreatedBy = "root";
                    entry.Entity.LastModifiedBy = "root";
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = _dateTime.NowUtc;
                    //entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                    entry.Entity.LastModifiedBy = "root";
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    #region Transaction Handling
    public async Task BeginTranAsync()
    {
        if (_currentTransaction != null)
        {
            return;
        }

        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
    }

    public async Task CommitTranAsync()
    {
        try
        {
            await _currentTransaction?.CommitAsync();
        }
        catch
        {
            await RollbackTranAsync();
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
    }

    public async Task RollbackTranAsync()
    {
        try
        {
            await _currentTransaction?.RollbackAsync();
        }
        finally
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
    }
    #endregion
}
