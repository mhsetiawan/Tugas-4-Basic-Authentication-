using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1;

public class User
{
    //Attribute
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Pass { get; set; }

    public User()
    {
    }

    public User(string firstName, string lastName, string pass)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = $"{firstName[..2]}{lastName[..2]}";
        Pass = pass;
    }

    public void InputNewUser(User newUser) 
    {
        bool validPass = true;
        Console.Write("First Name :");
        newUser.FirstName = Console.ReadLine();
        Console.Write("Last Name :");
        newUser.LastName = Console.ReadLine();
        do
        {
            Console.Write("Password :");
            newUser.Pass = Console.ReadLine();
            //cek syarat password
            Regex r1 = new Regex("[0-9]");
            Regex r2 = new Regex("[a-z]");
            Regex r3 = new Regex("[A-Z]");
            if (newUser.Pass.Length < 8 || !r1.IsMatch(newUser.Pass) || !r2.IsMatch(newUser.Pass) || !r3.IsMatch(newUser.Pass))
            {
                Console.WriteLine("Password harus terdiri dari minimal 8 karakter" +
                    ", minimal satu huruf kapital, minimal satu huruf kecil, dan satu angka");
                validPass = false;
            }
            else 
            {
                validPass = true;
            }
        } while (!validPass);
        newUser.Username = $"{newUser.FirstName[..2]}{newUser.LastName[..2]}";
    }

    public void PrintUser() 
    {
        Console.WriteLine("Name     :" + FirstName + " " + LastName);
        Console.WriteLine("Username :" + Username);
        Console.WriteLine("Password :" + Pass);
    }
 
}