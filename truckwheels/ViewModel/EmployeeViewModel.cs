namespace truckwheels.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }    
        public string? Email { get; set; }

        public long Telefone { get; set; }
        public required string Detalhes { get; set; }
        public IFormFile? Photo { get; set; }

      
    }
}
