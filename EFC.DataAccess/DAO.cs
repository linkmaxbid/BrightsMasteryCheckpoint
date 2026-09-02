namespace EFC.DataAccess;
using Microsoft.EntityFrameworkCore;

public class DAO :IDAO
{
    
    public void RebuildDatabase()
    
    {
        using EFCDbContext db = new();

        //Deletes the entire database
        db.Database.EnsureDeleted();

        //Recreates the DB tables, based on the Migrations folder data.
        db.Database.Migrate();
    }
    
    
}