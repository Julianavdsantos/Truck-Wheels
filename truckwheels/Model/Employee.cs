using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace truckwheels.Model
{
    [Table("employee")]
    public class Employee
    {
    
        [Key]
        public int Id { get; private set; }
        public string? Nome { get; private set; }
        public  long? Telefone { get; private set; }

        public string? Email { get; private set; }
        public string? Detalhes { get; private set; }
        public  string? Photo { get; private set; }

        // Construtor padrão
        public Employee() { }

        // Construtor personalizado
      
              
     
        public Employee(string nome, string email, long telefone, string detalhes, string photo) 
        {
            Email = email;
            Telefone = telefone;
            Detalhes = detalhes;
            this.Photo = photo;
        }
    }
}
