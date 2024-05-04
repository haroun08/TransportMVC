
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Reservation : Object
{

    public Guid Id { get; set; }
    public Package Associated_Package{ get; set; }
    public string Benefiter_Name{ get; set; }
    public Reservation_Manager? reservation_Manager{ get; set; }

    public Reservation()
    {
    }

    public Package getAssociated_Package()
    {
        return Associated_Package;
    }

    public string getBenefiter_Name()
    {
        return Benefiter_Name;
    }

    public Reservation_Manager getReservation_Manager()
    {
        return reservation_Manager;
    }

    public void setAssociated_Package(Package package)
    {
        this.Associated_Package = package;
    }

    public void setBenefiter_Name(string name)
    {
        this.Benefiter_Name = name;
    }

    public void setReservation_Manager(Reservation_Manager reservation_manager)
    {
        this.reservation_Manager = reservation_manager;
    }
}