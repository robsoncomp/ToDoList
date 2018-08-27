using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;

namespace ToDoList.Data.EntityConfig
{
    public class ToDoConfig : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).IsRequired();

            builder.Property(u => u.Descricao).IsRequired().HasMaxLength(256);

            builder.Property(u => u.Status).IsRequired();

            builder.Property(u => u.Data).IsRequired();

            builder.Property(u => u.DataAtualizacao).IsRequired();

            //builder.ToTable("Users");
        }
    }
}