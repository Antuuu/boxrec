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

    [Fact]
    public void GetFightResult_Test()
    {
        var options = new DbContextOptionsBuilder<BoxrecContext>()
            .UseInMemoryDatabase(databaseName: "boxrec")
            .Options;


        // Insert seed data into the database using one instance of the context
        using (var context = new BoxrecContext(options))
        {
            context.Boxers.Add(new Boxer { ID = 1, Name = "Tyson", Surname = "Fury", DateOfBirth = System.DateTime.Today, Division_ID = 1 });
            context.Boxers.Add(new Boxer { ID = 2, Name = "Joe", Surname = "Joyce", DateOfBirth = System.DateTime.Today, Division_ID = 1 });
            context.Fights.Add(new Fight { ID = 3, Boxer1_ID = 1, Boxer2_ID = 2, Winner_ID = 1, DateOfFight = System.DateTime.Today });
            context.SaveChanges();
        }

        //Use a clean instance of the context to run the test
        using (var context = new BoxrecContext(options))
        {
            var fights = context.Fights.ToList();
            Assert.Equal("Tyson Fury", fights[0].Winner);
            context.Database.EnsureDeleted();
        }
    }

    [Fact]
    public void AddFights_Test()
    {
        var options = new DbContextOptionsBuilder<BoxrecContext>()
            .UseInMemoryDatabase(databaseName: "boxrec")
            .Options;


        // Insert seed data into the database using one instance of the context
        using (var context = new BoxrecContext(options))
        {
            context.Fights.Add(new Fight { ID = 1, Boxer1_ID = 1, Boxer2_ID = 2, Winner_ID = 1, DateOfFight = System.DateTime.Today });
            context.Fights.Add(new Fight { ID = 2, Boxer1_ID = 1, Boxer2_ID = 2, Winner_ID = 1, DateOfFight = System.DateTime.Today });
            context.Fights.Add(new Fight { ID = 3, Boxer1_ID = 1, Boxer2_ID = 2, Winner_ID = 1, DateOfFight = System.DateTime.Today });
            context.Fights.Add(new Fight { ID = 4, Boxer1_ID = 1, Boxer2_ID = 3, Winner_ID = 1, DateOfFight = System.DateTime.Today });
            context.SaveChanges();
        }

        //Use a clean instance of the context to run the test
        using (var context = new BoxrecContext(options))
        {
            var fights = context.Fights.Count();
            Assert.Equal(4, fights);
            context.Database.EnsureDeleted();
        }
    }


    [Fact]
    public void GetBoxerDivision_Test()
    {
        var options = new DbContextOptionsBuilder<BoxrecContext>()
            .UseInMemoryDatabase(databaseName: "boxrec_test_record")
            .Options;


        // Insert seed data into the database using one instance of the context
        using (var db = new BoxrecContext(options))
        {
            db.Boxers.Add(new Boxer { ID = 2, Name = "Deontay", Surname = "Wilder", DateOfBirth = System.DateTime.Today, Division_ID = 1 });
            db.SaveChanges();
        }

        //Use a clean instance of the context to run the test
        using (var db = new BoxrecContext(options))
        {
            var boxers = db.Boxers.ToList();
            Assert.Equal("Lightweight", boxers[0].Division);
            db.Database.EnsureDeleted();
        }
    }
}