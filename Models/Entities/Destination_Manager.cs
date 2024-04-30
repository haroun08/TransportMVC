
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Destination_Manager : Manager
{



    private List<Destination> Destinations;

    public Destination_Manager()
    {
        Destinations = new List<Destination>();
    }

    public override void add(Object x)
    {
        Destination destination = x.getDestination();
        this.Destinations.Add(destination);
    }

    public override void display()
    {
        foreach (Destination destination in this.Destinations)
        {
            Console.WriteLine(destination.getName());
            Console.WriteLine(destination.getDescription());
        }
    }

    public override void modify(Object x)
    {
        Console.WriteLine("give me the new name of the destination");
        string name = Console.ReadLine();
        Console.WriteLine("give me the new description of the destination");
        string description = Console.ReadLine();
        x.getDestination().setName(name);
        x.getDestination().setDescription(description);
    }

    public override void delete(Object x)
    {
        Destination destination = x.getDestination();
        this.Destinations.RemoveAll(d => d.getName() == destination.getName() && d.getDescription() == destination.getDescription());
    }
}
