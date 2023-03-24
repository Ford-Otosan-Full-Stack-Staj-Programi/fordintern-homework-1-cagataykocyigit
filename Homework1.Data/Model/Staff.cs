using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Data.Model;

public class Staff : BaseModel
{
   
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string AddressLine1 { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Province { get; set; }
    //NotMapped
    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }



}
