namespace EFC.Domain;

public class Scooter
{
    
    public int Id { get; set; } //PK
    
    public string Brand { get; set; }
    public int BatteryCapacity { get; set; }
    public Status Status { get; set; }
    
   
    
    
    public ICollection<Trip>  Trips { get; set; } = new List<Trip>(); //navigation property
    
    
    
    
}