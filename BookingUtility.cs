namespace mis_221_pa_5_sdanderson4
{
    public class BookingUtility
    {
       private Booking[] bookings;


       public BookingUtility()
       {
           bookings = new Booking[100];
       }




       public void GetAllBookingsFromFile(){
           System.Console.WriteLine("Please enter the name of the customer whose session you are looking for");
           string customerName = Console.ReadLine();


           StreamReader inFile = new StreamReader("transactions.txt");
           string line = inFile.ReadLine();


         
          
           while (line != null)
           {
              
               string[] temp = line.Split('#');
               if(temp[2] == customerName){
                   System.Console.WriteLine($"Session Available: {temp[8]} ");
               }
               else{
                    System.Console.WriteLine("Booking does not exist");
               }
               line = inFile.ReadLine();
           }


           inFile.Close();
         
      
       }
public void AddBooking(){
           System.Console.WriteLine("Please enter Session ID");
           Booking myBooking = new Booking();
           myBooking.SetSessionID(int.Parse(Console.ReadLine()));


           System.Console.WriteLine("Please enter customer ID");
           myBooking.SetCustomerID(int.Parse(Console.ReadLine()));


           System.Console.WriteLine("Please enter customer name");
           myBooking.SetCustomerName(Console.ReadLine());


           System.Console.WriteLine("Please enter customer email");
           myBooking.SetCustomerEmail(Console.ReadLine());


           System.Console.WriteLine("Please enter the number of sessions customer has attended");
           myBooking.SetCustomerSessions(int.Parse(Console.ReadLine()));


           System.Console.WriteLine("Please enter a valid training Date");
           myBooking.SetTrainingDate(Console.ReadLine());


           System.Console.WriteLine("Please enter the ID of trainer");
           myBooking.SetTrainerID(int.Parse(Console.ReadLine()));


           System.Console.WriteLine("Please enter the name of trainer");
           myBooking.SetTrainerName(Console.ReadLine());


           


           bool bookingStatus = true;
           myBooking.SetBookingStatus(bookingStatus);


           bookings[Booking.GetCount()] = myBooking;
           Booking.IncCount();


           Save();


              
       }
       private void Save()
       {
           StreamWriter outFile = new StreamWriter("transactions.txt");


           for (int i = 0; i < Booking.GetCount(); i++)
           {
               outFile.WriteLine(bookings[i].GetSessionID() + "#" + bookings[i].GetCustomerID() + "#" + bookings[i].GetTrainerName() + "#" + bookings[i].GetCustomerEmail() + "#" + bookings[i].GetCustomerSessions() + "#" + bookings[i].GetTrainingDate() + "#" + bookings[i].GetTrainerID() + "#" + bookings[i].GetTrainerName() + "#" + bookings[i].GetBookingStatus());
           }
           outFile.Close();
       }
     


       public void UpdateBooking(){
           StreamReader inFile = new StreamReader("transactions.txt");
           System.Console.WriteLine("What is the session ID of the booking needs to be updated?");
           int searchVal = int.Parse(Console.ReadLine());
           int foundIndex = Find(searchVal);


           if(foundIndex != -1){
               System.Console.WriteLine("Please enter Session ID");
               Booking myBooking = new Booking();
               bookings[foundIndex].SetSessionID(int.Parse(Console.ReadLine()));


               System.Console.WriteLine("Please enter customer ID");
               bookings[foundIndex].SetCustomerID(int.Parse(Console.ReadLine()));


               System.Console.WriteLine("Please enter customer name");
               bookings[foundIndex].SetCustomerName(Console.ReadLine());


               System.Console.WriteLine("Please enter customer email");
               bookings[foundIndex].SetCustomerEmail(Console.ReadLine());


               System.Console.WriteLine("Please enter a valid training Date");
               bookings[foundIndex].SetTrainingDate(Console.ReadLine());


               System.Console.WriteLine("Please enter ID of trainer");
               bookings[foundIndex].SetTrainerID(int.Parse(Console.ReadLine()));


               System.Console.WriteLine("Please enter the name of trainer");
               bookings[foundIndex].SetTrainerName(Console.ReadLine());


               System.Console.WriteLine("Has the booking been completed");


               DeleteBooking();


              
              
           }
           else{
               System.Console.WriteLine("Booking does not exist");
           }
           inFile.Close();
       }
       private int Find(int searchVal){
           StreamReader inFile = new StreamReader("transactions.txt");
           string num = inFile.ReadLine();


           string[] temp = num.Split("#");


           for(int i = 0; i < Booking.GetCount(); i++){
               if(temp[0] == searchVal.ToString()){
                   return i;
               }
           }
           inFile.Close();
           return -1;
       }
       public void DeleteBooking()
       {
           StreamReader inFile = new StreamReader("transactions.txt");
           Console.WriteLine("What is the session ID of the booking you want to delete");
           int searchVal = int.Parse(Console.ReadLine());
           int foundIndex = Find(searchVal);
  
           if (foundIndex != -1)
           {
               bookings[foundIndex].SetBookingStatus(false);
           Save();
           }
           else
           {
               Console.WriteLine("Booking does not exist");
           }
           inFile.Close();
       }


    }
}


 