using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyStor.Core.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStor.Infrastructures.DAL.Categories
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(c => c.CategoryName).IsUnique();
            builder.Property(c => c.CategoryName).HasMaxLength(100).IsRequired();
            builder.HasData(
                new Category { CategoryId = 1, CategoryName = "Category 01" },
                new Category { CategoryId = 2, CategoryName = "Category 02" },
                new Category { CategoryId = 3, CategoryName = "Category 03" },
                new Category { CategoryId = 4, CategoryName = "Category 04" }
                );
        }
    }
}
