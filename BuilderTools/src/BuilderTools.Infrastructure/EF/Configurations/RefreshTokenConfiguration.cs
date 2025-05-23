﻿using BuilderTools.Core.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BuilderTools.Infrastructure.EF.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("RefreshTokens");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                   .IsRequired();

            builder.Property(x => x.Token)
                   .IsRequired()
                   .HasMaxLength(512);

            builder.Property(x => x.ExpiresAt)
                   .IsRequired();

            builder.Property(x => x.Revoked)
                   .HasDefaultValue(false);
        }
    }
}
