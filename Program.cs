using System;
using System.Linq;

namespace SafariAdventure
{
  class Program
  {

    static void SeedData()
    {
      var db = new SafariContext();
      var favoriteAdventure = new Safari
      {
        Species = "Stephen Gacio",
        CountOfTimesSeen = 123123,
        LocationOfLastSeen = "Outside of his natural environment"
      };
      var favoriteAdventure2 = new Safari
      {
        Species = "Lion",
        CountOfTimesSeen = 2,
        LocationOfLastSeen = "Safari"
      };
      var favoriteAdventure3 = new Safari
      {
        Species = "Cougar",
        CountOfTimesSeen = 400,
        LocationOfLastSeen = "Starbucks "
      };
      var favoriteAdventure4 = new Safari
      {
        Species = "Lion",
        CountOfTimesSeen = 420,
        LocationOfLastSeen = "walmart"
      };
      var favoriteAdventure5 = new Safari
      {
        Species = "Tiger",
        CountOfTimesSeen = 123123,
        LocationOfLastSeen = "My Driveway"
      };
      var favoriteAdventure6 = new Safari
      {
        Species = "Bear",
        CountOfTimesSeen = 1,
        LocationOfLastSeen = "Desert"
      };

      //   db.Safaris.Add(favoriteAdventure);
      //   db.Safaris.Add(favoriteAdventure2);
      //   db.Safaris.Add(favoriteAdventure3);
      //   db.Safaris.Add(favoriteAdventure4);
      //   db.Safaris.Add(favoriteAdventure5);
      //   db.Safaris.Add(favoriteAdventure6);
      db.SaveChanges();
    }

    static void ReadData()
    {
      var db = new SafariContext();
      var AllTheSpecies = db.Safaris.Select(safari => safari.Species);
      //thanks Mark for showing Stephen this, he showed me.
      foreach (var species in AllTheSpecies)
      {
        Console.WriteLine(species);
      }
    }

    //display animals seen in Safari, not Jungle... Sorry.
    static void ReadMoreData()
    {
      var db = new SafariContext();
      var AllTheJung = db.Safaris
        .Where(Safari => Safari.LocationOfLastSeen == "Safari")
        .Select(Safari => Safari.Species);

      System.Console.WriteLine(AllTheJung.FirstOrDefault());

    }
    static void UpdateData()
    {
      var db = new SafariContext();
      var updateSpecies = db.Safaris.FirstOrDefault(Safari => Safari.Species == "Stephen Gacio");
      updateSpecies.CountOfTimesSeen = 50;
      updateSpecies.LocationOfLastSeen = "SDG";
      db.SaveChanges();
    }

    static void RemoveTheDesert()
    {
      var db = new SafariContext();
      var removeDessert = db.Safaris.Where(Safari => Safari.LocationOfLastSeen == "Dessert");
      db.Safaris.RemoveRange(removeDessert);
      db.SaveChanges();

    }

    static void UsingSum()
    {
      var db = new SafariContext();
      var sumCountOfTimesSeen = db.Safaris.Sum(Safaris => Safaris.CountOfTimesSeen);
      Console.WriteLine(sumCountOfTimesSeen);
    }

    static void LtbOhMy()
    {
      var db = new SafariContext();
      var Ltb = db.Safaris.Where(Safari => Safari.Species == "Lion" || Safari.Species == " Tiger" || Safari.Species == "Bear").Sum(safari => safari.CountOfTimesSeen);
      System.Console.WriteLine(Ltb);
    }
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      SeedData();
      ReadData();
      UpdateData();
      ReadMoreData();
      RemoveTheDesert();
      UsingSum();
      LtbOhMy();
    }
  }
}
