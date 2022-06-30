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
            .UseInMemoryDatabase(databaseName: "boxrec_test")
            .Options;


        // Insert seed data into the database using one instance of the db
        using (var db = new BoxrecContext(options))
        {
            db.Boxers.Add(new Boxer { ID = 1, Name = "Tyson", Surname = "Fury", DateOfBirth = System.DateTime.Today, Division_ID = 1 });
            db.Boxers.Add(new Boxer { ID = 2, Name = "Tyson", Surname = "Ziemniak", DateOfBirth = System.DateTime.Today, Division_ID = 1 });
            db.Boxers.Add(new Boxer { ID = 3, Name = "Tyson", Surname = "Karmel", DateOfBirth = System.DateTime.Today, Division_ID = 1 });
            db.SaveChanges();

        }

        //Use a clean instance of the db to run the test
        using (var db = new BoxrecContext(options))
        {
            List<Boxer> boxers = new List<Boxer>();
            boxers = db.Boxers.ToList();
            Assert.Equal(3, boxers.Count);
            db.Database.EnsureDeleted();
        }
    }

    [Fact]
    public void AddBoxerWithUrl_Test()
    {
        var options = new DbContextOptionsBuilder<BoxrecContext>()
            .UseInMemoryDatabase(databaseName: "boxrec_test")
            .Options;


        // Insert seed data into the database using one instance of the db
        using (var db = new BoxrecContext(options))
        {
            db.Boxers.Add(new Boxer { ID = 1, Name = "Tyson", Surname = "Fury", DateOfBirth = System.DateTime.Today, Division_ID = 1, Photo_Url="https://to/img.png" });
            db.SaveChanges();
        }

        //Use a clean instance of the db to run the test
        using (var db = new BoxrecContext(options))
        {
            List<Boxer> boxers = new List<Boxer>();
            boxers = db.Boxers.ToList();
            Assert.Equal("https://to/img.png", boxers[0].Photo_Url);
            db.Database.EnsureDeleted();
        }
    }

    [Fact]
    public void GetWinner_Test()
    {
        var options = new DbContextOptionsBuilder<BoxrecContext>()
            .UseInMemoryDatabase(databaseName: "boxrec_test")
            .Options;


        // Insert seed data into the database using one instance of the db
        using (var db = new BoxrecContext(options))
        {
            db.Boxers.Add(new Boxer { ID = 1, Name = "Tyson", Surname = "Fury", DateOfBirth = System.DateTime.Today, Division_ID = 1 });
            db.Boxers.Add(new Boxer { ID = 2, Name = "Joe", Surname = "Joyce", DateOfBirth = System.DateTime.Today, Division_ID = 1 });
            db.Fights.Add(new Fight { ID = 3, Boxer1_ID = 1, Boxer2_ID = 2, Winner_ID = 1, DateOfFight = System.DateTime.Today });
            db.SaveChanges();
        }

        //Use a clean instance of the db to run the test
        using (var db = new BoxrecContext(options))
        {
            var fights = db.Fights.ToList();
            Assert.Equal("Tyson Fury", fights[0].Winner);
            db.Database.EnsureDeleted();
        }
    }

    [Fact]
    public void AddFights_Test()
    {
        var options = new DbContextOptionsBuilder<BoxrecContext>()
            .UseInMemoryDatabase(databaseName: "boxrec_test")
            .Options;


        // Insert seed data into the database using one instance of the db
        using (var db = new BoxrecContext(options))
        {
            db.Fights.Add(new Fight { ID = 1, Boxer1_ID = 1, Boxer2_ID = 2, Winner_ID = 1, DateOfFight = System.DateTime.Today });
            db.Fights.Add(new Fight { ID = 2, Boxer1_ID = 1, Boxer2_ID = 2, Winner_ID = 1, DateOfFight = System.DateTime.Today });
            db.Fights.Add(new Fight { ID = 3, Boxer1_ID = 1, Boxer2_ID = 2, Winner_ID = 1, DateOfFight = System.DateTime.Today });
            db.Fights.Add(new Fight { ID = 4, Boxer1_ID = 1, Boxer2_ID = 3, Winner_ID = 1, DateOfFight = System.DateTime.Today });
            db.SaveChanges();
        }

        //Use a clean instance of the db to run the test
        using (var db = new BoxrecContext(options))
        {
            var fights = db.Fights.Count();
            Assert.Equal(4, fights);
            db.Database.EnsureDeleted();
        }
    }


    [Fact]
    public void GetBoxerDivision_Test()
    {
        var options = new DbContextOptionsBuilder<BoxrecContext>()
            .UseInMemoryDatabase(databaseName: "boxrec_test")
            .Options;


        // Insert seed data into the database using one instance of the db
        using (var db = new BoxrecContext(options))
        {
            db.Divisions.Add(new Division { ID = 1, Name = "Heavyweight" });
            db.Boxers.Add(new Boxer { ID = 2, Name = "Deontay", Surname = "Wilder", DateOfBirth = System.DateTime.Today, Division_ID = 1 });
            db.SaveChanges();
        }

        //Use a clean instance of the db to run the test
        using (var db = new BoxrecContext(options))
        {
            var boxers = db.Boxers.ToList();
            string division = (from d in db.Divisions where d.ID == boxers[0].Division_ID select d.Name).FirstOrDefault();
            Assert.Equal(division, "Heavyweight");
            db.Database.EnsureDeleted();
        }
    }

    [Fact]
    public void GetBoxerRecord_Test()
    {
        var options = new DbContextOptionsBuilder<BoxrecContext>()
            .UseInMemoryDatabase(databaseName: "boxrec_test")
            .Options;


        // Insert seed data into the database using one instance of the db
        using (var db = new BoxrecContext(options))
        {
            db.Boxers.Add(new Boxer { ID = 1, Name = "Tyson", Surname = "Fury", DateOfBirth = System.DateTime.Today, Division_ID = 1 });
            db.Boxers.Add(new Boxer { ID = 2, Name = "Deontay", Surname = "Wilder", DateOfBirth = System.DateTime.Today, Division_ID = 1 });
            db.Fights.Add(new Fight { ID = 1, Boxer1_ID = 1, Boxer2_ID = 2, Winner_ID = null, DateOfFight = System.DateTime.Today });
            db.Fights.Add(new Fight { ID = 2, Boxer1_ID = 1, Boxer2_ID = 2, Winner_ID = 1, DateOfFight = System.DateTime.Today });
            db.Fights.Add(new Fight { ID = 3, Boxer1_ID = 1, Boxer2_ID = 2, Winner_ID = 1, DateOfFight = System.DateTime.Today });

            db.SaveChanges();
        }

        //Use a clean instance of the db to run the test
        using (var db = new BoxrecContext(options))
        {
            var boxer = new Boxer { ID = 1, Name = "Tyson", Surname = "Fury", DateOfBirth = System.DateTime.Today, Division_ID = 1 };
            var fights = (from f in db.Fights where f.Boxer1_ID == boxer.ID || f.Boxer2_ID == boxer.ID select f).ToList();
            var wins = (from f in db.Fights where f.Winner_ID == boxer.ID select f).ToList();
            var loses = (from f in db.Fights where (f.Boxer1_ID == boxer.ID || f.Boxer2_ID == boxer.ID) && (f.Winner_ID != boxer.ID && f.Winner_ID != null) select f).ToList();
            var draws = (from f in db.Fights where (f.Boxer1_ID == boxer.ID || f.Boxer2_ID == boxer.ID) && f.Winner_ID == null select f).ToList();
            string record = $"{wins.Count}-{draws.Count}-{loses.Count}";
            Assert.Equal("2-1-0", record);
            db.Database.EnsureDeleted();
        }
        
    }

    [Fact]
    public void GetBoxerFullName_Test()
    {
        var options = new DbContextOptionsBuilder<BoxrecContext>()
            .UseInMemoryDatabase(databaseName: "boxrec_test")
            .Options;


        // Insert seed data into the database using one instance of the db
        using (var db = new BoxrecContext(options))
        {
            db.Boxers.Add(new Boxer { ID = 1, Name = "Paweł", Surname = "Jumper", DateOfBirth = System.DateTime.Today, Division_ID = 1 });
            db.SaveChanges();
        }

        //Use a clean instance of the db to run the test
        using (var db = new BoxrecContext(options))
        {
            var boxers = db.Boxers.ToList();
            Assert.Equal("Paweł Jumper", $"{boxers[0].Name} {boxers[0].Surname}" );
            db.Database.EnsureDeleted();
        }

    }
}