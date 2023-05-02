namespace mis_221_pa_5_sdanderson4
{
    public class ReportingUtility
    {
        public Report[] reports;


       public void ReportUtility(Report[] report){
           this.reports = reports;
       }




       
       public void IndividualCustomerSessions(){
           System.Console.WriteLine("Please enter the customer email you are trying to find");
           string customerEmail = Console.ReadLine();


           StreamReader inFile = new StreamReader("transactions.txt");
           string line = inFile.ReadLine();


         
          
           while (line != null)
           {
              
               string[] temp = line.Split("#");
               if(temp[3] == customerEmail){
                   System.Console.WriteLine($" This customer has {temp[4]} Number of sessions");
               }
               else{
                   System.Console.WriteLine("Customer does not exist try again");
               }
               line = inFile.ReadLine();
           }
           inFile.Close();
       }
       
       public void HistoricalCustomerSessions(){
           System.Console.WriteLine("Please enter the customer ID you are trying to find");
           int searchVal = int.Parse(Console.ReadLine());
           int foundIndex = Find(searchVal);


           string customerName = Console.ReadLine();


           StreamReader inFile = new StreamReader("transactions.txt");
           string line = inFile.ReadLine();


          
           for(int i = 0; i < Report.GetCount() -1; i++){
               int min = i;
               for(int j = i + 1; j < Report.GetCount(); j++){
                   if(reports[j].GetCustomerName().CompareTo(reports[min].GetCustomerName()) < 0 ||
                   reports[j].GetCustomerName() == reports[min].GetCustomerName() && reports[j].GetTrainingDate() < reports[min].GetTrainingDate())
                  
                   {
                       min = j;
                   }
               }
               if(min != 1) {
                   Swap(min, 1);
               }
           }
           string currentCustomer = "";
           int numSessions = 0;


           while (line != null){
               Report report = new Report();
               if (report.GetCustomerName() != currentCustomer){
                   if (currentCustomer != ""){
                       if (customerName == "" || currentCustomer == customerName){
                           System.Console.WriteLine($"Customer: {currentCustomer}, Number of Sessions: {numSessions}");
                       }
                   }
                   currentCustomer = report.GetCustomerName();
                   numSessions = 0;
               }


               numSessions += report.GetNumSessions();
               string[] temp = line.Split("#");
               if (customerName == "" || currentCustomer == customerName){
                   System.Console.WriteLine($"Customer: {temp[1]}, Date: {temp[5]}, Number of Sessions: {temp[4]}");
               }


           line = inFile.ReadLine();
           }


           if (customerName == "" || currentCustomer == customerName){
               System.Console.WriteLine($"Customer: {currentCustomer}, Number of Sessions: {numSessions}");
           }


       }


       private int Find(int searchVal)
       {
           StreamReader inFile = new StreamReader("transactions.txt");


           for (int i = 0; i < Report.GetCount(); i++)
           {
               if (reports[i].GetCustomerID() == searchVal)
               {
                   return i;
               }
           }
           inFile.Close();
           return -1;
       }
      
      
       private void Swap(int x, int y){
           Report temp = reports[x];
           reports[x] = reports[y];
           reports[y] = temp;
       }
       
       public void HistoricalRevenueReport(){


       }


    }
}

        