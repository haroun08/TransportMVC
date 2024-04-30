
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Coordinator {

    public Coordinator()
    {
    }

    private int Id;
    private string Name;
    private int Phone_Number;
    private string Mail;

    public int getId() { return Id; }
    public string getName() { return Name; }
    public int getPhone_Number() { return Phone_Number; }
    public string getMail() { return Mail; }

    public void setId(int id) { this.Id = id; }
    public void setName(string name) { this.Name = name; }
    public void setPhone_Number(int number) { this.Phone_Number = number; }
    public void setMail(string mail) { this.Mail = mail; }



}