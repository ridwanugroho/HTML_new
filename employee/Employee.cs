using System;
using System.Collections.Generic;


namespace EmployeeSys
{
    public class Employee
    {
        public int id{get; set;}
        public string avater_url{get; set;}
        public string employee_id{get; set;}
        public string first_name{get; set;}
        public string last_name{get; set;}
        public string username{get; set;}
        public DateTime birthday{get; set;}
        public List<Address> addresses{get; set;}
        public List<Phone> phones{get; set;}
        public List<DateTime> presence_list{get; set;}
        public double salary{get; set;}
        public Department department{get; set;}
        public Position position{get; set;}
    }

    public class Address
    {
        public string labe{get; set;}
        public string address{get; set;}
        public string city{get; set;}
    }

    public class Phone
    {
        public string label{get; set;}
        public string phone{get; set;}
    }

    public class Department
    {
        public string name{get; set;}
    }

    public class Position
    {
        public string name{get; set;}
    }
}