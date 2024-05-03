using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Destination
{

    public Guid Id { get; set; }

    public Destination()
    {
    }

    public string Name;
    public string Description;

    public string getName()
    {
        return Name;
    }

    public void setName(string name)
    {
        this.Name = name;
    }

    public string getDescription()
    {
        return Description;
    }

    public void setDescription(string description)
    {
        this.Description = description;
    }
}