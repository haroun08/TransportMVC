public class Object
{

    public Guid Id { get; set; }


    User user;
    Package package;
    Reservation reservation;
    Destination destination;

    public Object()
    {
        this.user = null;
        this.package = null;
        this.reservation = null;
        this.destination = null;
    }

    public void setUser(User user)
    {
        this.user = user;
    }

    public User getUser()
    {
        return user;
    }

    public void setPackage(Package package)
    {
        this.package = package;
    }

    public Package getPackage()
    {
        return package;
    }

    public void setReservation(Reservation reservation)
    {
        this.reservation = reservation;
    }

    public Reservation getReservation()
    {
        return reservation;
    }

    public void setDestination(Destination destination)
    {
        this.destination = destination;
    }

    public Destination getDestination()
    {
        return destination;
    }
}
