using EFC.DataAccess;

namespace EFC.IntegrationTests;
using NUnit.Framework;


public class IntegrationTests
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