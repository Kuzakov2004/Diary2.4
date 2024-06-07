using Diary2._4;

class Program
{
    public static void Main(string[] args)
    {
        DatabaseRequests.CreateNewClient();
        
        foreach (var user in DatabaseServisce.GetDbContext().Clients)
            Console.WriteLine(
        $"Login: {user.Login} - Password: {user.Password}");

    }
} 