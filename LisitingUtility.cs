namespace mis_221_pa_5_sdanderson4
{
    public class ListingUtility
    {
        private Listing[] listings;


       public ListingUtility()
       {
           listings = new Listing[100];
       }


       public Listing[] GetAllListingsFromFile()
       {
          StreamReader inFile = new StreamReader("listing.txt");


           Listing.SetCount(0);
           string line = inFile.ReadLine();
           while (line != null)
           {
               string[] temp = line.Split("#");
               listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], temp[2], double.Parse(temp[3]),double.Parse(temp[4]));
               Listing.IncCount();
               line = inFile.ReadLine();
           }
           inFile.Close();
           return listings;
       }
       
       public void AddListings()
       {
          System.Console.WriteLine("Please enter the Session ID you want");
          Listing myListing = new Listing();
          myListing.SetSessionID(int.Parse(Console.ReadLine()));


           System.Console.WriteLine("Please enter the name of Trainer");
           myListing.SetTrainerName(Console.ReadLine());


           System.Console.WriteLine("Please enter the date of training Session");
           myListing.SetDate(Console.ReadLine());


           System.Console.WriteLine("Please enter the time of the session. Enter a valid time in the form of a decimal");
           myListing.SetTime(double.Parse(Console.ReadLine()));


           System.Console.WriteLine("Please enter the cost of session");
           myListing.SetCost(double.Parse(Console.ReadLine()));


           System.Console.WriteLine("Your session has been added to listing.txt with availabilty and deleted at the end.");


           bool available = true;
           myListing.SetAvailability(true);


           bool deleted = false;
           myListing.SetDeleted(deleted);


           listings[Listing.GetCount()] = myListing;
           Listing.IncCount();


           Save();
       }


       private void Save()
       {
           StreamWriter outFile = new StreamWriter("listing.txt");


           for (int i = 0; i < Listing.GetCount(); i++)
           {
               outFile.WriteLine(listings[i].GetSessionID() + "#" + listings[i].GetTrainerName() + "#" + listings[i].GetDate() + "#" + listings[i].GetTime() + "#" + listings[i].GetCost() + "#" + listings[i].GetAvailability() + "#" + listings[i].GetDeleted());
           }
           outFile.Close();
       }


       private int Find(int searchVal)
       {
           StreamReader inFile = new StreamReader("listing.txt");


           for (int i = 0; i < Listing.GetCount(); i++)
           {
               if (listings[i].GetSessionID() == searchVal)
               {
                   return i;
               }
           }
           inFile.Close();
           return -1;
       }
       
       public void UpdateListing()
       {
       Console.WriteLine("What is the Session ID of the listing that needs to be updated?");
       int searchVal = int.Parse(Console.ReadLine());
       int foundIndex = Find(searchVal);


       if (foundIndex != -1)
       {
           Console.WriteLine("Please enter the Session ID of Listing");
           listings[foundIndex].SetSessionID(int.Parse(Console.ReadLine()));


           Console.WriteLine("Please enter the name of Trainer");
           listings[foundIndex].SetTrainerName(Console.ReadLine());


           Console.WriteLine("Please enter the date of Session");
           listings[foundIndex].SetDate(Console.ReadLine());


           Console.WriteLine("Please enter the time of the session. Please enter a valid time in the form of a decimal");
           listings[foundIndex].SetTime(double.Parse(Console.ReadLine()));


           System.Console.WriteLine("Please enter the cost of session");
           listings[foundIndex].SetCost(double.Parse(Console.ReadLine()));


           System.Console.WriteLine("Your listing has been updated");


           
           Save();
       }
       else
       {
           Console.WriteLine("Listing does not exist");
       }
       }  
      
       public void DeleteListing()
       {
           Console.WriteLine("What is the Id of the Listing you want to delete");
           int searchVal = int.Parse(Console.ReadLine());
           int foundIndex = Find(searchVal);
  
           if (foundIndex != -1)
           {
               listings[foundIndex].SetDeleted(true);
           Save();
           }
           else
           {
               Console.WriteLine("Listing does not exist");
           }
       }


    }
}

       