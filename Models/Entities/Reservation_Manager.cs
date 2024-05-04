
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Reservation_Manager : Manager
{

    public Guid Id { get; set; }
    private List<Reservation> Reservations;

    public Reservation_Manager()
    {
        Reservations = new List<Reservation>();
    }

    public override void add(Object x)
    {
        Reservation reservation = x.getReservation();
        this.Reservations.Add(reservation);
    }

    public override void display()
    {
        foreach (Reservation reservation in this.Reservations)
        {
            Console.WriteLine("this Package is :");
            Console.WriteLine(reservation.getAssociated_Package().getDestination());
            Console.WriteLine(reservation.getAssociated_Package().getStart_Date());
            Console.WriteLine(reservation.getAssociated_Package().getDuration());
            Console.WriteLine(string.Join(", ", reservation.getAssociated_Package().getServices()));
            Console.WriteLine(reservation.getAssociated_Package().getTransport_Option());
            Console.WriteLine(reservation.getAssociated_Package().getTransport_Company());
            Console.WriteLine(reservation.getBenefiter_Name());
        }
    }

    public override void modify(Object x)
    {
        Console.WriteLine("give me the benefiter name of the package");
        string name = Console.ReadLine();
        x.getReservation().setBenefiter_Name(name);
    }

    public override void delete(Object x)
    {
        Reservation reservation = x.getReservation();
        this.Reservations.RemoveAll(r => r.getPackage() == reservation.getPackage() && r.getBenefiter_Name() == r.getBenefiter_Name());
    }
}