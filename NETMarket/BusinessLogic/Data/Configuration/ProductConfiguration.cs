﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(250);
        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(p => p.Image)
            .HasMaxLength(1000);
        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)");
        builder.HasOne(p => p.Trademark)
            .WithMany()
            .HasForeignKey(p => p.TrademarkId);
        builder.HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId);
    }
}