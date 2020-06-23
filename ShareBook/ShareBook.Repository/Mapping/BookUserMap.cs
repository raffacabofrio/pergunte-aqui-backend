﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareBook.Domain;

namespace ShareBook.Repository.Mapping
{
    public class BookUserMap
    {
        public BookUserMap(EntityTypeBuilder<BookUser> entityBuilder)
        {

            entityBuilder
             .HasKey(bu => new { bu.Id, bu.BookId, bu.UserId });

            entityBuilder
                .HasOne(bu => bu.Book)
                .WithMany(b => b.BookUsers)
                .HasForeignKey(bu => bu.BookId);

            entityBuilder
                 .HasOne(bu => bu.User)
                .WithMany(u => u.BookUsers)
                .HasForeignKey(bu => bu.UserId);

            entityBuilder.Property(bu => bu.Note)
               .HasColumnType("varchar(2000)")
               .HasMaxLength(2000);

            entityBuilder.Property(bu => bu.Reason)
                .HasColumnType("varchar(2000)")
                .HasMaxLength(2000);

            entityBuilder.Property(bu => bu.NickName)
                .HasColumnType("varchar(64)")
                .HasMaxLength(64);
        }
    }
}
