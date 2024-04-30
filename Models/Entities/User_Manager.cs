
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class User_Manager : Manager
{
    public Guid Id { get; set; }


    private List<User> Users;

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
            Console.WriteLine(user.getUsername());
            Console.WriteLine(user.getPassword());
            Console.WriteLine(user.getRole());
        }
    }

    public override void modify(Object x)
    {
        User user = x.getUser();
        Console.WriteLine("Give me the new username \n");
        string username = Console.ReadLine();
        x.getUser().setUsername(username);
        Console.WriteLine("Give me the new Password \n");
        string password = Console.ReadLine();
        x.getUser().setPassword(password);
        Console.WriteLine("Give me the new Role \n");
        string role = Console.ReadLine();
        x.getUser().setRole(role);
    }

    public override void delete(Object x)
    {
        User user = x.getUser();
        this.Users.RemoveAll(u => u.getUsername() == user.getUsername() && u.getPassword() == user.getPassword() && u.getRole() == user.getRole());
    }
}