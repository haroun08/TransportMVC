public class Package : Object
{


    public Package()
    {
    }

    public Guid Id { get; set; }
    public string Destination;
    public DateTime Start_Date;
    public DateTime Duration;
    public List<string> Services;
    public string Transport_Option;
    public string Transport_Company;
    public Package_Manager package_Manager;

    public string getDestination()
    {
        return Destination;
    }

    public void setDestination(string destination)
    {
        this.Destination = destination;
    }

    public DateTime getStart_Date()
    {
        return Start_Date;
    }

    public void setStart_Date(DateTime start_date)
    {
        this.Start_Date = start_date;
    }

    public DateTime getDuration()
    {
        return Duration;
    }

    public void setDuration(DateTime duration)
    {
        this.Duration = duration;
    }

    public List<string> getServices()
    {
        return Services;
    }

    public void setServices(List<string> services)
    {
        this.Services = services;
    }

    public string getTransport_Option()
    {
        return Transport_Option;
    }

    public void setTransport_Option(string transport_option)
    {
        this.Transport_Option = transport_option;
    }

    public string getTransport_Company()
    {
        return Transport_Company;
    }

    public void setTransport_Company(string transport_company)
    {
        this.Transport_Company = transport_company;
    }

    public Package_Manager getPackage_Manager()
    {
        return package_Manager;
    }

    public static bool operator ==(Package p1, Package p2)
    {
        if (p1.Destination != p2.Destination)
            return false;
        else if (p1.Start_Date != p2.Start_Date)
            return false;
        else if (p1.Duration != p2.Duration)
            return false;
        else if (p1.Services != p2.Services)
            return false;
        else if (p1.Transport_Option != p2.Transport_Option)
            return false;
        else if (p1.Transport_Company != p2.Transport_Company)
            return false;
        else
            return true;
    }

    public static bool operator !=(Package p1, Package p2)
    {
        return !(p1 == p2);
    }
}