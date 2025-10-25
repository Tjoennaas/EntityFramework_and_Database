

//https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core-example.html
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
using Models;

namespace Data;



    public class RecipeContext : DbContext
{
    public RecipeContext(DbContextOptions<RecipeContext> options) : base(options) { }

    public DbSet<Recipe> Recipes => Set<Recipe>();

  protected override void OnModelCreating(ModelBuilder mb)
  {

//https://learn.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations#the-valueconverter-class
    // MySQL doesn’t know what a List<> is, so EF Core has to convert it into JSON (text) before saving it.
    var listToJson = new ValueConverter<List<string>, string>(
        v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null) ?? new()
    );




    mb.Entity<Recipe>(e =>{

    e.ToTable("RecipeDB");
    e.HasKey(p => p.Id);

    e.Property(p => p.Name)
     .HasMaxLength(100)
     .IsRequired();

    e.Property(p => p.Ingredients)
      .HasConversion(listToJson)
     .HasColumnType("json")
     .IsRequired();

      e.Property(p => p.Steps)
         .HasConversion(listToJson)
         .HasColumnType("json")
         .IsRequired();
         
    });
  } }


