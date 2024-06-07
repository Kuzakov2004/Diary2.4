using Diary2._4.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Diary2._4;

public static class DatabaseRequests
{
    
    public static int activeUser = 0;
    
    public static void CreateNewClient()
    {
        Console.WriteLine("Введите login ");
        string login = Console.ReadLine();
        Console.WriteLine("Введите password ");
        string password = Console.ReadLine();

        Models.Client newClient = new Client()
        {
            Login = login,
            Password = password
        };
        DatabaseServisce.GetDbContext().Clients.Add(newClient);
        DatabaseServisce.GetDbContext().SaveChanges();
    }
    
    public static void EnterClient()
    {
        Console.WriteLine("Введите login ");
        string login = Console.ReadLine();
        Console.WriteLine("Введите password ");
        string password = Console.ReadLine();

        var searchedUser = DatabaseServisce.GetDbContext().Clients
            .FirstOrDefault(n => n.Login == login && n.Password == password);

        if (searchedUser.Id == 0)
        {
            return;
        }
    }
}