using System;
using System.Collections.Generic;
using CricketWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CricketWebApi.Data;

public partial class CricketContext : DbContext
{
    public CricketContext()
    {
    }

    public CricketContext(DbContextOptions<CricketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<MatchDetail> MatchDetails { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerRole> PlayerRoles { get; set; }

    public virtual DbSet<Series> Series { get; set; }

    public virtual DbSet<Stadium> Stadia { get; set; }

    public virtual DbSet<Team1> Team1s { get; set; }

    public virtual DbSet<Team2> Team2s { get; set; }

    public virtual DbSet<Toss> Tosses { get; set; }

    public virtual DbSet<Umpire> Umpires { get; set; }

    public virtual DbSet<UmpireRole> UmpireRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=CricketDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07547F2715");

            entity.ToTable("Category");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3214EC07E9CF1CF0");

            entity.ToTable("Country");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MatchDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MatchDet__3214EC0721D11CE7");

            entity.ToTable("MatchDetail");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Series).WithMany(p => p.MatchDetails)
                .HasForeignKey(d => d.SeriesId)
                .HasConstraintName("FK__MatchDeta__Serie__571DF1D5");

            entity.HasOne(d => d.Stadium).WithMany(p => p.MatchDetails)
                .HasForeignKey(d => d.StadiumId)
                .HasConstraintName("FK__MatchDeta__Stadi__5629CD9C");

            entity.HasOne(d => d.Team1).WithMany(p => p.MatchDetails)
                .HasForeignKey(d => d.Team1Id)
                .HasConstraintName("FK__MatchDeta__Team1__5441852A");

            entity.HasOne(d => d.Team2).WithMany(p => p.MatchDetails)
                .HasForeignKey(d => d.Team2Id)
                .HasConstraintName("FK__MatchDeta__Team2__5535A963");

            entity.HasOne(d => d.Toss).WithMany(p => p.MatchDetails)
                .HasForeignKey(d => d.TossId)
                .HasConstraintName("FK__MatchDeta__TossI__5812160E");

            entity.HasOne(d => d.UmpireRole).WithMany(p => p.MatchDetails)
                .HasForeignKey(d => d.UmpireRoleId)
                .HasConstraintName("FK__MatchDeta__Umpir__59063A47");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Player__3214EC0726808AD5");

            entity.ToTable("Player");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Players)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Player__CountryI__38996AB5");
        });

        modelBuilder.Entity<PlayerRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlayerRo__3214EC071C194EBC");

            entity.ToTable("PlayerRole");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ShortName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Series>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Series__3214EC07FC655D0E");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.Category).WithMany(p => p.Series)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Series__Category__3F466844");
        });

        modelBuilder.Entity<Stadium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stadium__3214EC07569B9075");

            entity.ToTable("Stadium");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Stadia)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Stadium__Country__4222D4EF");
        });

        modelBuilder.Entity<Team1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Team1__3214EC079908F91B");

            entity.ToTable("Team1");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Player).WithMany(p => p.Team1s)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK__Team1__PlayerId__44FF419A");

            entity.HasOne(d => d.PlayerRole).WithMany(p => p.Team1s)
                .HasForeignKey(d => d.PlayerRoleId)
                .HasConstraintName("FK__Team1__PlayerRol__45F365D3");
        });

        modelBuilder.Entity<Team2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Team2__3214EC077BB8905D");

            entity.ToTable("Team2");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Player).WithMany(p => p.Team2s)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK__Team2__PlayerId__48CFD27E");

            entity.HasOne(d => d.PlayerRole).WithMany(p => p.Team2s)
                .HasForeignKey(d => d.PlayerRoleId)
                .HasConstraintName("FK__Team2__PlayerRol__49C3F6B7");
        });

        modelBuilder.Entity<Toss>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Toss__3214EC079F9DA523");

            entity.ToTable("Toss");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Decision)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Winner)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Umpire>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Umpire__3214EC07A3B94F7D");

            entity.ToTable("Umpire");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Umpires)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Umpire__CountryI__4E88ABD4");
        });

        modelBuilder.Entity<UmpireRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UmpireRo__3214EC073DC91CCE");

            entity.ToTable("UmpireRole");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Umpire).WithMany(p => p.UmpireRoles)
                .HasForeignKey(d => d.UmpireId)
                .HasConstraintName("FK__UmpireRol__Umpir__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
