using System;
using System.Data.SqlTypes;
using System.IO;

namespace FormativeLibrary
{
    class Program
    {
        static string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static string studentIdFileName = "lhms_850000466";

        public static void DirectoryExOrCreate()
        {
            try
            {
                if (Directory.Exists(myDocuments + "\\Hotel"))
                {
                    Console.WriteLine("Directory Found");

                }

                else
                {
                    Console.WriteLine("Creating Directory 'Hotel' in My Documents...");
                    Directory.CreateDirectory(myDocuments + "\\Hotel");
                }
            }
            
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception has been handled");
            }
        }
        public static void FileExOrCreate()
        {
            try
            {
                string path = myDocuments + "\\Hotel\\" + studentIdFileName + ".txt";

                if (File.Exists(path))
                {
                    Console.WriteLine("File Exists");

                }
                else
                {
                    Console.WriteLine("File Does not Exist");
                    Console.WriteLine("Creating File...");
                    FileStream fs = new FileStream(myDocuments + "\\Hotel\\" + studentIdFileName + ".txt", FileMode.Create);
                    fs.Close();
                    Console.WriteLine("File Created");
                }

                string addPath = myDocuments + "\\Hotel\\roomlist_data.txt";

                if (File.Exists(addPath))
                {
                    Console.WriteLine("Opening Room List File...");

                }
                else
                {

                    Console.WriteLine("File Does not Exist\n");
                    Console.WriteLine("Creating Room List File...\n");
                    FileStream bs = new FileStream(myDocuments + "\\Hotel\\roomlist_data.txt", FileMode.Create);
                    bs.Close();

                }

                string pathAll = myDocuments + "\\Hotel\\roomAllocation_data.txt";

                if (File.Exists(pathAll))
                {
                    Console.WriteLine("Opening Room Allocation File...\n");

                }
                else
                {

                    Console.WriteLine("File Does not Exist\n");
                    Console.WriteLine("Creating File...\n");
                    FileStream bs = new FileStream(myDocuments + "\\Hotel\\roomAllocation_data.txt", FileMode.Create);
                    bs.Close();

                }
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                Console.Clear();
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception has been handled");
            }
            

        }
        public static void AddRooms()
        {
            try
            {
                Console.WriteLine("****************************************");
                Console.WriteLine("         Room Addition Page");
                Console.WriteLine("****************************************");
                Console.WriteLine("Please enter room number : ");
                string roomN = Console.ReadLine();
                Console.WriteLine("Please enter room floor : ");
                string roomF = Console.ReadLine();
                Console.WriteLine("Please enter room size (Single, Double, Queen, King)");
                string roomS = Console.ReadLine();
                Console.WriteLine("Created by :");
                string employeeN = Console.ReadLine();
                Console.WriteLine("Job Title :");
                string employeeT = Console.ReadLine();

                using (StreamWriter rooms = new StreamWriter(myDocuments + "\\Hotel\\roomlist_data.txt", true))
                {
                    rooms.WriteLine("\nRoom Added to System at : " + DateTime.Now + "\n Employee " + employeeN + ", \n " + employeeT);
                    rooms.WriteLine(" Room Number : " + roomN + "\n Floor : " + roomF + "\n Room Size : " + roomS);
                    rooms.WriteLine("****************************************");
                }

                Console.WriteLine("Press Enter to Return to Menu...");
                Console.ReadKey();
            }
            

            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception has been handled");
            }


        }
        public static void DisplayRooms()
        {
            try
            {
                Console.WriteLine("Hotel Rooms: ");
                string allfileText = File.ReadAllText(myDocuments + "\\Hotel\\roomlist_data.txt");
                Console.WriteLine(allfileText);
                Console.WriteLine("Press Enter to Return to Menu...");
                Console.ReadKey();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public static void RoomAllocate()                       
        {
            try
            {
                Console.WriteLine("****************************************");
                Console.WriteLine("           Room Allocation");
                Console.WriteLine("****************************************\n");

                Console.WriteLine("Please enter room floor : ");
                string roomF = Console.ReadLine();
                Console.WriteLine("Please enter room number : ");
                string roomN = Console.ReadLine();
                Console.WriteLine("Customer's Full Name : ");
                string customerName = Console.ReadLine();
                Console.WriteLine("Customer's Phone Number : ");
                string customerPh = Console.ReadLine();
                Console.WriteLine("Check In Date (dd/mm/yyyy)");
                string bookingInD = Console.ReadLine();
                Console.WriteLine("Check Out Date (dd/mm/yyyy)");
                string bookingOuD = Console.ReadLine();
                Console.WriteLine("Employee Name: ");
                string employeeN = Console.ReadLine();

                using (StreamWriter borrowed = new StreamWriter(myDocuments + "\\Hotel\\roomAllocation_data.txt", true))
                {
                    borrowed.WriteLine("\nRoom Allocated at : " + DateTime.Now);
                    borrowed.WriteLine(" Room : " + roomN);
                    borrowed.WriteLine(" Floor : " + roomN);
                    borrowed.WriteLine(" Customer Name: " + customerName);
                    borrowed.WriteLine(" Customer Phone Number: " + customerPh);
                    borrowed.WriteLine(" Checkin Date:  " + bookingInD);
                    borrowed.WriteLine(" Checkout Date:  " + bookingOuD);
                    borrowed.WriteLine(" Employee: " + employeeN);
                    borrowed.WriteLine("****************************************");
                }

                Console.WriteLine("Press Enter to Return to Menu...");
                Console.ReadKey();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception has been handled");
            }
            

        }
        public static void RoomDeallocate()
        {
            try
            {
                string path = myDocuments + "\\Hotel\\roomAllocation_data.txt";

                if (File.Exists(path))
                {
                    Console.WriteLine("Opening File\n");

                }
                else
                {

                    Console.WriteLine("File Does not Exist\n");
                    Console.WriteLine("Creating File...\n");
                    FileStream bs = new FileStream(myDocuments + "\\Hotel\\roomAllocation_data.txt", FileMode.Create);
                    bs.Close();

                }

                Console.WriteLine("****************************************");
                Console.WriteLine("           Room De-Allocation");
                Console.WriteLine("****************************************\n");
                Console.WriteLine("Please enter the details of the room to be de-allocated\n");
                Console.WriteLine("Floor : ");
                string roomF = Console.ReadLine();
                Console.WriteLine("Room : ");
                string roomN = Console.ReadLine();
                Console.WriteLine("Customer Name : ");
                string customerN = Console.ReadLine();
                Console.WriteLine("Customer's Phone Number : ");
                string customerPh = Console.ReadLine();
                Console.WriteLine("Employee Name: ");
                string employeeN = Console.ReadLine();

                using (StreamWriter borrowed = new StreamWriter(Path.Combine(myDocuments + "\\Hotel\\roomAllocation_data.txt"), true))
                {
                    borrowed.WriteLine("\nRoom Returned at : " + DateTime.Now);
                    borrowed.WriteLine(" Room : " + roomN + " on Floor " + roomF);
                    borrowed.WriteLine(" Customer : " + customerN + "\n Customer Phone Number : " + customerPh);
                    borrowed.WriteLine(" Employee : " + employeeN + "\n");
                    borrowed.WriteLine("****************************************");
                }

                Console.WriteLine("Press Enter to Return to Menu...");
                Console.ReadKey();
            }            

            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception has been handled");
            }

        }
        public static void RoomHistory()
        {
            string path = myDocuments + "\\Hotel\\roomAllocation_data.txt";

            if (File.Exists(path))
            {
                Console.WriteLine("Opening Room Allocation History");
                string[] readBor = File.ReadAllLines(path);

                foreach (string s in readBor)
                {
                    Console.WriteLine(s);
                }

            }
            else
            {
                Console.WriteLine("No Allocation History Found");

            }

            Console.WriteLine("Press Enter to Return to Menu...");
            Console.ReadKey();

        }
        public static void BackUpData()
        {
            Console.WriteLine();            
            string src = File.ReadAllText(myDocuments + "\\Hotel\\roomAllocation_data.txt");
            string src2 = File.ReadAllText(myDocuments + "\\Hotel\\roomlist_data.txt");
            string dest = myDocuments + "\\Hotel\\" + studentIdFileName + ".txt";

            using (StreamWriter newFile = new StreamWriter(dest))
            {
                newFile.WriteLine("****LANGHAM HOTEL ROOM DATA****\n");
                
                newFile.WriteLine("***************************");
                newFile.WriteLine("*        Room List        *");
                newFile.WriteLine("***************************");
                newFile.WriteLine(src2);
                newFile.WriteLine("***************************");
                newFile.WriteLine("* Room Allocation History *");
                newFile.WriteLine("***************************");
                newFile.WriteLine(src);
            }
            

            string destBack = myDocuments + "\\Hotel\\" + studentIdFileName + "_backup.txt";
            File.Copy(dest, destBack);

            using (FileStream fs = new FileStream(dest, FileMode.Open))
            {
                fs.SetLength(0);
            }
            Console.WriteLine("Back Up Created, original file reset...");
            
            Console.WriteLine("Press Enter to Return to Menu...");
            Console.ReadKey();
        }
        public static void DisplayFileData()
        {
            Console.WriteLine("Hotel Rooms: ");
            string allfileText = File.ReadAllText(myDocuments + "\\Hotel\\" + studentIdFileName + "_backup.txt");
            Console.WriteLine(allfileText);
            Console.WriteLine("Press Enter to Return to Menu...");
            Console.ReadKey();

        }
        public static void Exit()
        {
            return;
        }
        public static void Billing()
        {

            Console.WriteLine("Billing Feature is under constructions and will be added soon...");
            Console.WriteLine("Press Enter to Return to Menu...");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            try
            {
                Program.DirectoryExOrCreate();
                Program.FileExOrCreate();
                bool exit = false;

                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine(" ************************************** ");
                    Console.WriteLine("*                                      *");
                    Console.WriteLine("*    LANGHAM HOTEL  MANAGEMENT SYSTEM  *");
                    Console.WriteLine("*                MENU                  *");
                    Console.WriteLine("*                                      *");
                    Console.WriteLine(" ************************************** ");

                    Console.WriteLine("*  1. Add Rooms                        *");
                    Console.WriteLine("*  2. Display Rooms                    *");
                    Console.WriteLine("*  3. Allocate Rooms                   *");
                    Console.WriteLine("*  4. De-Allocate Rooms                *");
                    Console.WriteLine("*  5. Display Room Allocation Details  *");
                    Console.WriteLine("*  6. Billing                          *");
                    Console.WriteLine("*  7. Back up Hotel Room Data          *");
                    Console.WriteLine("*  8. Display Data from Back up file   *");
                    Console.WriteLine("*  0. Exit                             *");

                    Console.WriteLine(" ************************************** ");
                    Console.WriteLine("\nType the corresponding number and press enter to select");
                    int menuSelect = Convert.ToInt32(Console.ReadLine());



                    try
                    {
                        switch (menuSelect)
                        {
                            case 1:

                                Program.AddRooms(); break;
                            case 2:

                                Program.DisplayRooms(); break;
                            case 3:

                                Program.RoomAllocate(); break;
                            case 4:

                                Program.RoomDeallocate(); break;
                            case 5:

                                Program.RoomHistory(); break;
                            case 6:

                                Program.Billing(); break;
                            case 7:

                                Program.BackUpData(); break;
                            case 8:

                                Program.DisplayFileData();
                                break;
                            case 0:

                                Console.WriteLine("Exiting... See You Next time!");
                                exit = true;
                                break;

                        }
                    }
                    
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception has been handled");
            }
            
                                    
            
        }






    }
}
