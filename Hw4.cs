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





        // // Create an instance of FileReader and read the file
        // FileReader reader = new FileReader("zipcodes.txt");
        // List<ZipCodeData> zipCodes = reader.ReadFile();
        // Initialize FileReader with the path to your test file
        FileReader reader = new FileReader("test_zipcodes.txt");
        
        // Call ReadFile to parse data from the file
        List<ZipCodeData> zipCodes = reader.ReadFile();
        
        // Output the total count of zip codes read to confirm data loading
        Console.WriteLine($"Total records read: {zipCodes.Count}");

        // Print each record to verify parsing
        foreach (var zipCode in zipCodes)
        {
            Console.WriteLine(zipCode);
        }



        

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

  public class TestFileReader
{
    public static void TestReadFile()
    {
        // Initialize a FileReader with the test file path
        FileReader reader = new FileReader("test_zipcodes.txt");
        
        // Read the data from the test file
        List<ZipCodeData> zipCodes = reader.ReadFile();
        
        // Check if data was read by printing the count
        Console.WriteLine($"Total records read: {zipCodes.Count}");

        // Print each record to verify parsing
        foreach (var zipCode in zipCodes)
        {
            Console.WriteLine(zipCode);
        }
    }
}


}  // End Hw4


