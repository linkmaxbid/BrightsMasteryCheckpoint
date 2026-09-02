using EFC.DataAccess;
using EFC.Domain;

namespace EFC.UnitTests;

public class Tests
{
    
    public DAO Dao = new DAO();
    
    [SetUp]
    public void Setup()
    {
        Dao.RebuildDatabase();
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}