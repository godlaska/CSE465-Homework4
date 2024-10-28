/* 
  Homework#4

  Add your name here: Keigen Godlaski

  You are free to create as many classes within the Hw4.cs file or across 
  multiple files as you need. However, ensure that the Hw4.cs file is the 
  only one that contains a Main method. This method should be within a 
  class named hw4. This specific setup is crucial because your instructor 
  will use the hw4 class to execute and evaluate your work.
  */
  // BONUS POINT:
  // => Used Pointers from lines 10 to 15 <=
  // => Used Pointers from lines 40 to 63 <=
  

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Hw4
{
    public static void Main(string[] args)
    {
        // Capture the start time
        // Must be the first line of this method
        DateTime startTime = DateTime.Now; // Do not change
        // ============================
        // Do not add or change anything above, inside the 
        // Main method
        // ============================





        // Create an instance of FileReader and read the file
        FileReader reader = new FileReader("zipcodes.txt");
        // Parses all the zipcode data and stores it in a List
        List<ZipCodeData> zipCodes = reader.ReadFile();




        // ================================= CommonCityNames.txt =================================

        // Set up a dictionary to store the cities for each state
        Dictionary<string, HashSet<string>> stateCities = new Dictionary<string, HashSet<string>>();

        // Creates a dictionary of all states and their cities, without
        // any duplicates
        foreach (var zipCode in zipCodes)
        {
            if (!stateCities.ContainsKey(zipCode.State))
            {
              // Adds state if it isn't already in the dictionary
              stateCities[zipCode.State] = new HashSet<string>();
            }
            stateCities[zipCode.State].Add(zipCode.City);
        }

        // Reads states.txt and creates a HashSet of just
        // those specified states
        var lines = File.ReadAllLines("states.txt");
        HashSet<string> targetStates = new HashSet<string>(lines);

        // SortedSet is used so there's no duplicate cities stored, and
        // the list is automatically sorted. targetStates.First() gets
        // the first state in states.txt
        SortedSet<string> commonCities = new SortedSet<string>(stateCities[targetStates.First()]);

        // Finds the intersection between the first state and every other state
        // provided in the text file
        foreach (var state in targetStates.Skip(1))
        {
            if (stateCities.ContainsKey(state))
            {
                // Adds the cities that are common in both states
                commonCities.IntersectWith(stateCities[state]);
            }
            else
            {
                // If any state has no cities, the intersection is empty
                commonCities.Clear();
                break;
            }
        }

        // Creates or overwrites the output file with all common cities
        File.WriteAllText("CommonCityNames.txt", string.Join(Environment.NewLine, commonCities));



        // ================================= LatLon.txt =================================

        var targetZipCodes = new HashSet<string>(File.ReadAllLines("zips.txt"));
        var zipCodeCoordinates = new Dictionary<string, (double Lat, double Lon)>();

        // Add the first lat/lon for each specified zip code
        foreach (var zipCode in zipCodes)
        {
            // Checks if the targeted zipcode has already been put in the dictionary
            if (targetZipCodes.Contains(zipCode.Zipcode) && !zipCodeCoordinates.ContainsKey(zipCode.Zipcode))
            {
                zipCodeCoordinates[zipCode.Zipcode] = (zipCode.Lat, zipCode.Long);
            }
        }

        // Write to LatLon.txt
        using (StreamWriter writer = new StreamWriter("LatLon.txt"))
        {
          foreach(var zipCode in targetZipCodes)
          {
              // Check if the zip code exists in zipCodeCoordinates
              if (zipCodeCoordinates.ContainsKey(zipCode))
              {
                  // Gets the coordinates from the dictionary
                  var coordinates = zipCodeCoordinates[zipCode];
                  writer.WriteLine($"{coordinates.Lat} {coordinates.Lon}");
              }
              else
              {
                  writer.WriteLine($"{zipCode} Not Found");
              }
          }
        }

        // ================================= CityStates.txt =================================


        

        // ============================
        // Do not add or change anything below, inside the 
        // Main method
        // ============================

        // Capture the end time
        DateTime endTime = DateTime.Now;  // Do not change
        
        // Calculate the elapsed time
        TimeSpan elapsedTime = endTime - startTime; // Do not change
        
        // Display the elapsed time in milliseconds
        Console.WriteLine($"Elapsed Time: {elapsedTime.TotalMilliseconds} ms");
    }

    // Class to store data for each zip code entry
  public class ZipCodeData
  {
      public int RecordNumber 
      { 
          get; set; 
      }
      
      public string Zipcode 
      { 
          get; set; 
      }
      
      public string ZipCodeType
      { 
          get; set;
      }
      
      public string City
      { 
          get; set;
      }
      
      public string State
      {
          get; set;
      }
      
      public string LocationType
      {
          get; set;
      }
      
      public double Lat 
      { 
          get; set; 
      }
      
      public double Long 
      { 
          get; set; 
      }
      
      public string Xaxis 
      { 
          get; set; 
      }
      
      public string Yaxis 
      { 
          get; set; 
      }
      
      public string Zaxis 
      { 
          get; set; 
      }
      
      public string WorldRegion 
      { 
          get; set; 
      }
      
      public string Country 
      { 
          get; set; 
      }
      
      public string LocationText 
      { 
          get; set; 
      }
      
      public string Location 
      { 
          get; set; 
      }
      
      public bool Decommissioned 
      { 
          get; set; 
      }
      
      public int TaxReturnsFiled 
      { 
          get; set; 
      }
      
      public int EstimatedPopulation 
      { 
          get; set; 
      }
      
      public int TotalWages 
      { 
          get; set; 
      }
      
      public string Notes 
      { 
          get; set; 
      }

      public override string ToString()
      {
      return $"RecordNumber: {RecordNumber}, Zipcode: {Zipcode}, ZipCodeType: {ZipCodeType}, City: {City}, " +
           $"State: {State}, LocationType: {LocationType}, Lat: {Lat}, Long: {Long}, Xaxis: {Xaxis}, " +
           $"Yaxis: {Yaxis}, Zaxis: {Zaxis}, WorldRegion: {WorldRegion}, Country: {Country}, " +
           $"LocationText: {LocationText}, Location: {Location}, Decommissioned: {Decommissioned}, " +
           $"TaxReturnsFiled: {TaxReturnsFiled}, EstimatedPopulation: {EstimatedPopulation}, " +
           $"TotalWages: {TotalWages}, Notes: {Notes}";
    }
  }

  public class FileReader 
  {
    private string filePath;

    public FileReader(string inputFilePath) 
    {
      filePath = inputFilePath;
    }

    // Puts record number, zipcode, city, etc. in a list of the class type
    // ZipCodeData to streamline reading the list after parsing each line
    public List<ZipCodeData> ReadFile()
    {
      var zipCodes = new List<ZipCodeData>();

      // StreamReader documentation found at https://learn.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-8.0
      try 
      {
        using (StreamReader reader = new StreamReader(filePath))
        {
          // Skips header line
          reader.ReadLine();

          string line;
          while ((line = reader.ReadLine()) != null)
          {
              // Each field is separated by a tab
              string[] fields = line.Split('\t');
              
              // Field parsing logic with assistance of ChatGPT
              // TryParse implementation provided by https://www.educative.io/answers/what-is-parse-and-tryparse-in-c-sharp-10
              var zipCodeData = new ZipCodeData
              {
                RecordNumber = fields.Length > 0 && int.TryParse(fields[0], out int recordNumber) ? recordNumber : 0,
                Zipcode = fields.Length > 1 ? fields[1] : "",
                ZipCodeType = fields.Length > 2 ? fields[2] : "",
                City = fields.Length > 3 ? fields[3] : "",
                State = fields.Length > 4 ? fields[4] : "",
                LocationType = fields.Length > 5 ? fields[5] : "",
                Lat = fields.Length > 6 && double.TryParse(fields[6], out double lat) ? lat : 0.0,
                Long = fields.Length > 7 && double.TryParse(fields[7], out double lng) ? lng : 0.0,
                Xaxis = fields.Length > 8 ? fields[8] : "",
                Yaxis = fields.Length > 9 ? fields[9] : "",
                Zaxis = fields.Length > 10 ? fields[10] : "",
                WorldRegion = fields.Length > 11 ? fields[11] : "",
                Country = fields.Length > 12 ? fields[12] : "",
                LocationText = fields.Length > 13 ? fields[13] : "",
                Location = fields.Length > 14 ? fields[14] : "",
                Decommissioned = fields.Length > 15 && bool.TryParse(fields[15], out bool decommissioned) ? decommissioned : false,
                TaxReturnsFiled = fields.Length > 16 && int.TryParse(fields[16], out int taxReturnsFiled) ? taxReturnsFiled : 0,
                EstimatedPopulation = fields.Length > 17 && int.TryParse(fields[17], out int estimatedPopulation) ? estimatedPopulation : 0,
                TotalWages = fields.Length > 18 && int.TryParse(fields[18], out int totalWages) ? totalWages : 0,
                Notes = fields.Length > 19 ? fields[19] : ""
              };

              // Add parsed line to the zipCodes list
              zipCodes.Add(zipCodeData);
          }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine("The file could not be read:");
        Console.WriteLine(e.Message);
      }

      return zipCodes;
    }  // End ReadFile

  }  // End FileReader

}  // End Hw4