using AddressBookGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //delete();
            //change();
            //addContact();
            displayGUI();
        }
        public static void addContact()
        {
            Console.WriteLine("please enter the info about who you would like to add");
            Console.Write("First name: ");
            String name = Console.ReadLine();
            Console.Write("Last Name: ");
            String lname = Console.ReadLine();
            Console.Write("Email: ");
            String email = Console.ReadLine();
            Console.Write("Phone number:");
            String phone = Console.ReadLine();



            using (var db = new Entities())
            {
                Address a = new Address
                {
                    FirstName = name,
                    LastName = lname,
                    Email = email,
                    PhoneNumber = phone
                };

                db.Addresses.Add(a);
                db.SaveChanges();
            }
        }
        public static void displayGUI()
        {
            MainWindow ab = new MainWindow();
        }
        public static void change()
        {
            using(var db = new Entities())
            {
                Console.Write("whos phone number would you like to change");
                string nameToChange = Console.ReadLine();

                Address c = (from address in db.Addresses where address.FirstName == nameToChange select address).FirstOrDefault();

                if(c != null)
                {
                    Console.Write("what would you like to change the name to?:");
                    String newPhone = Console.ReadLine();
                    c.PhoneNumber = newPhone;
                }
                else
                {
                    Console.Write("this person does not exist");
                }
                db.SaveChanges();
            }
        }

        public static void delete()
        {
            using(var db = new Entities())
            {
                Console.Write("Who do you want to erase from your life");
                string personToDelete = Console.ReadLine();

                Address d = (from address in db.Addresses where address.FirstName == personToDelete select address).FirstOrDefault();
                if (d != null)
                {
                    db.Addresses.Remove(d);
                }
                else
                {
                    Console.Write("this person does not exist");

                }
                db.SaveChanges();
                }
        }
       /* public static void tui()
        {
            Console.Write("what would you like to do?");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "add":
                
            }
        }*/


    }
}
