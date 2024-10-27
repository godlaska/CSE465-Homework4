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





        // Create an instance of FileReader and read the file
        FileReader reader = new FileReader("zipcodes.txt");
        List<ZipCodeData> zipCodes = reader.ReadFile();
        



        

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

    }
  }
}


