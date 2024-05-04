
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class User_Manager : Manager
{
    public Guid Id { get; set; }


    public List<User> Users;

    public User_Manager()
    {
        Users = new List<User>();
    }

    public override void add(Object x)
    {
        User user = x.getUser();
        this.Users.Add(user);
    }

    public override void display()
    {
        foreach (User user in this.Users)
        {
            Console.WriteLine(user.Username);
            Console.WriteLine(user.Password);
            Console.WriteLine(user.Role);
        }
    }

    public override void modify(Object x)
    {
        User user = x.getUser();
        Console.WriteLine("Give me the new username: ");
        user.Username = Console.ReadLine();
        
        Console.WriteLine("Give me the new Password: ");
        user.Password = Console.ReadLine();
        
        Console.WriteLine("Give me the new Role: ");
        user.Role = Console.ReadLine();
    }

    public override void delete(Object x)
    {
        User user = x.getUser();
        this.Users.RemoveAll(u => u.Username == user.Username && u.Password == user.Password && u.Role == user.Role);
    }
}