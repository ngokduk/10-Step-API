using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Models
{
    public class Student
    {
       
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string NameClass { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
        
    }
}
