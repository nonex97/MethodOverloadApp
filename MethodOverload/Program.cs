using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverload
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new PersonModel("Neven", "Grguric");

            person.GenerateEmail("live.de", true);

            Console.WriteLine(person.Email);

            Console.WriteLine(); // WriteLine has 19 different overloads (can take nothing, bool, int, ...)
            
            Console.ReadLine();
        }
    }
}

public class PersonModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    // We have 3 different overloads for this constructor (any of 3 can be chosen)
    public PersonModel()
    {
        
    }

    public PersonModel(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public PersonModel(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    /* CODE BEFORE CLEARING IT UP
    public void GenerateEmail()
    {
        Email = $"{ FirstName }.{LastName}@gmail.com";
    }

    public void GenerateEmail(string domain)
    {
        Email = $"{FirstName}.{LastName}@{domain}";
    }

    public void GenerateEmail(bool firstInitialMethod) // if true it takes only first letter of first name + surname
    {
        if (firstInitialMethod == true)
        {
            Email = $"{FirstName.Substring(0,1)}{LastName}@gmail.com";
        }
        else
        {
            Email = $"{FirstName}.{LastName}@gmail.com";
        }
    }
    */

    // Here we will call the most versatile function (GenerateEmail(string domain, bool firstInitialMethod)) in other functions to clear up the code.
    // One method does the actual work, and three methods just call that method with different configuration.
    public void GenerateEmail()
    {
        GenerateEmail("gmail.com", false);
    }

    public void GenerateEmail(string domain)
    {
        GenerateEmail(domain, false);
    }

    public void GenerateEmail(bool firstInitialMethod) // if true it takes only first letter of first name + surname
    {
        GenerateEmail("gmail.com", firstInitialMethod);
    }

    public void GenerateEmail(string domain, bool firstInitialMethod)
    {
        if (firstInitialMethod == true)
        {
            Email = $"{FirstName.Substring(0, 1)}{LastName}@{domain}";
        }
        else
        {
            Email = $"{FirstName}.{LastName}@{domain}";
        }
    }

    // Now we have 4 different methods to generate an email, based on which way we want to do it
}