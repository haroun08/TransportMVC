public class Package_Manager : Manager
{
    public Guid Id { get; set; }


    private List<Package> Packages;

    public Package_Manager()
    {
        Packages = new List<Package>();
    }

    public override void add(Object x)
    {
        Package package = x.getPackage();
        this.Packages.Add(package);
    }

    public override void display()
    {
        foreach (Package package in Packages)
        {
            Console.WriteLine(package.getDestination());
            Console.WriteLine(package.getStart_Date());
            Console.WriteLine(package.getDuration());
            foreach (string service in package.getServices())
            {
                Console.WriteLine(service);
            }
            Console.WriteLine(package.getTransport_Company());
            Console.WriteLine(package.getTransport_Option());
        }
    }

    public override void modify(Object x)
    {
        Package package = x.getPackage();
        //Console.WriteLine("Give me the new destination \n");
        //Destination destination = Console.ReadLine();
        //x.getPackage().setDestination(destination);
        Console.WriteLine("Give me the new Start Date using the following form DD/MM/YYYY \n");
        string start_date_str = Console.ReadLine();
        DateTime start_date = DateTime.Parse(start_date_str);
        x.getPackage().setStart_Date(start_date);
        Console.WriteLine("Give me the new Duration using the following form DD/MM/YYYY \n");
        string duration_str = Console.ReadLine();
        DateTime duration = DateTime.Parse(duration_str);
        x.getPackage().setDuration(duration);
        Console.WriteLine("Do you want to add (type 1) or remove (type 2) a Service");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 1)
        {
            Console.WriteLine("Enter the name of the Service that you want to add");
            string service = Console.ReadLine();
            x.getPackage().getServices().Add(service);
        }
        else
        {
            Console.WriteLine("Enter the name of the Service that you want to delete");
            string searched_service = Console.ReadLine();
            bool found = false;
            foreach (string service in x.getPackage().getServices())
            {
                if (service == searched_service)
                    found = true;
            }
            if (found)
                x.getPackage().getServices().Remove(searched_service);
            else
                Console.WriteLine("The name of the service that you typed is not found");
        }

        Console.WriteLine("Give me the name of the new transport option");
        string transport_option = Console.ReadLine();
        x.getPackage().setTransport_Option(transport_option);

        Console.WriteLine("Give me the name of the new transport company");
        string transport_company = Console.ReadLine();
        x.getPackage().setTransport_Company(transport_company);
    }

    public override void delete(Object x)
    {
        Package package = x.getPackage();
        this.Packages.RemoveAll(p => p.getDestination() == package.getDestination() && p.getStart_Date() == package.getStart_Date() && p.getDuration() == package.getDuration() && p.getServices() == package.getServices() && p.getTransport_Option() == package.getTransport_Option() && p.getTransport_Company() == package.getTransport_Company());
    }
}
