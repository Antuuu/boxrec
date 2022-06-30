using boxrec;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BoxrecTests.Test;

public class UnitTest1
{
    [Fact]
    public void AddBoxers_Test()
    {
        var options = new DbContextOptionsBuilder<BoxrecContext>()
            .UseInMemoryDatabase(databaseName: "boxrec")
            .Options;


        // Insert seed data into the database using one instance of the context
        using (var context = new BoxrecContext(options))
        {
            context.Boxers.Add(new Boxer { ID = 1, Name = "Tyson", Surname = "Fury", DateOfBirth = System.DateTime.Today, Division_ID = 1 });
            context.Boxers.Add(new Boxer { ID = 2, Name = "Tyson", Surname = "Ziemniak", DateOfBirth = System.DateTime.Today, Division_ID = 1 });
            context.Boxers.Add(new Boxer { ID = 3, Name = "Tyson", Surname = "Karmel", DateOfBirth = System.DateTime.Today, Division_ID = 1 });
            context.SaveChanges();

        }

        //Use a clean instance of the context to run the test
        using (var context = new BoxrecContext(options))
        {
            List<Boxer> boxers = new List<Boxer>();
            boxers = context.Boxers.ToList();
            Assert.Equal(3, boxers.Count);
            context.Database.EnsureDeleted();
        }
    }
    [Fact]
    public void AddBoxerWithUrl_Test()
    {
        var options = new DbContextOptionsBuilder<BoxrecContext>()
            .UseInMemoryDatabase(databaseName: "boxrec")
            .Options;


        // Insert seed data into the database using one instance of the context
        using (var context = new BoxrecContext(options))
        {
            context.Boxers.Add(new Boxer { ID = 1, Name = "Tyson", Surname = "Fury", DateOfBirth = System.DateTime.Today, Division_ID = 1, Photo_Url="https://to/img.png" });
            context.SaveChanges();
        }

        //Use a clean instance of the context to run the test
        using (var context = new BoxrecContext(options))
        {
            List<Boxer> boxers = new List<Boxer>();
            boxers = context.Boxers.ToList();
            Assert.Equal("https://to/img.png", boxers[0].Photo_Url);
            context.Database.EnsureDeleted();
        }
    }
}