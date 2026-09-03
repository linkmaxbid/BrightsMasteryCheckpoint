namespace EFC.Domain;

public class AppUser
{
    
    public int Id { get; set; } //PK
    
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    
    
    public ICollection<Trip>  Trips { get; set; } = new List<Trip>(); //Navigation property
    
    
    
    
}