using Diary2._4.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Diary2._4;

public static class DatabaseRequests
{
    
    public static int activeUser = 0;
    static string formattedDate = "";
    
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
        try
        {
            DatabaseServisce.GetDbContext().Clients.Add(newClient);
            DatabaseServisce.GetDbContext().SaveChanges();
        }
        catch 
        {
            Console.WriteLine("Такой пользователь уже сушествует");
        }
        
    }
    
    public static bool EnterClient()
    {
        Console.WriteLine("Введите login ");
        string login = Console.ReadLine();
        Console.WriteLine("Введите password ");
        string password = Console.ReadLine();

        var searchedUser = DatabaseServisce.GetDbContext().Clients
            .FirstOrDefault(n => n.Login == login && n.Password == password);

        if (searchedUser != null)
        {
            activeUser = searchedUser.Id;
            return true;
        }

        return false;
    }
    
    public static void CreateNewTask()
    {
        Console.WriteLine("Введите заголовок ");
        string title = Console.ReadLine();
        Console.WriteLine("Введите задачу ");
        string desckription = Console.ReadLine();
        Console.WriteLine("Введите дату в формате гггг-мм-дд ");
        DateOnly dateOfCompletion = new DateOnly();
        try
        {
            dateOfCompletion = DateOnly.Parse(Console.ReadLine());
            formattedDate = dateOfCompletion.ToString();
        }
        catch
        {
            Console.WriteLine("Неверный формат даты");
            return;
        }

        Models.Diary newDiary = new Diary()
        {
            UserId = activeUser,
            Title = title,
            Desckription = desckription,
            DateOfCompletion = dateOfCompletion
        };
        DatabaseServisce.GetDbContext().Diaries.Add(newDiary);
        DatabaseServisce.GetDbContext().SaveChanges();
    }
    
    public static void DeleteTask(int id)
    {
        var DeleteTask = DatabaseServisce.GetDbContext().Diaries.FirstOrDefault(n => n.Id == id && n.UserId == activeUser);
        if (DeleteTask != null)
        {
            DatabaseServisce.GetDbContext().Diaries.Remove(DeleteTask);
            DatabaseServisce.GetDbContext().SaveChanges();
        }
    }
    
    public static void UpdateTask(int id)
    {
        Console.WriteLine("Введите заголовок ");
        string title = Console.ReadLine();
        Console.WriteLine("Введите задачу ");
        string desckription = Console.ReadLine();
        Console.WriteLine("Введите дату в формате гггг-мм-дд ");
        DateOnly dateOfCompletion = new DateOnly();
        try
        {
            dateOfCompletion = DateOnly.Parse(Console.ReadLine());
            formattedDate = dateOfCompletion.ToString();
        }
        catch
        {
            Console.WriteLine("Неверный формат даты");
            return;
        }

        var updateTask = DatabaseServisce.GetDbContext().Diaries.FirstOrDefault(n => n.Id == id);
        if (updateTask != null)
        {
            updateTask.Title = title;
            updateTask.Desckription = desckription;
            updateTask.DateOfCompletion = dateOfCompletion;
            DatabaseServisce.GetDbContext().SaveChanges();
        }

    }
    
    public static void WriteTodayTasks()
    {
       
        formattedDate = DateOnly.FromDateTime(DateTime.Today).ToString();

        foreach (var task in DatabaseServisce.GetDbContext().Diaries)
        {
            if(task.UserId == activeUser && task.DateOfCompletion == DateOnly.Parse(formattedDate))
                Console.WriteLine($"Id: {task.Id} \nНазвание: {task.Title} \nЗадача: {task.Desckription} \nДата выполнения: {task.DateOfCompletion}");
        }
    }
    
    public static void WriteTomorrowTasks()
    {
        formattedDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)).ToString();
        
        foreach (var task in DatabaseServisce.GetDbContext().Diaries)
        {
            if(task.UserId == activeUser && task.DateOfCompletion == DateOnly.Parse(formattedDate))
                Console.WriteLine($"Id: {task.Id} \nНазвание: {task.Title} \nЗадача: {task.Desckription} \nДата выполнения: {task.DateOfCompletion}");
        }
    }
    
    public static void WriteWeekTasks()
    {
        int weekConvert = (int)DateTime.Today.DayOfWeek;
        if (weekConvert == 0)
        {
            weekConvert = 7;
        }

        formattedDate = DateOnly.FromDateTime(DateTime.Today).ToString();
        string formattedDateWeekConvert = DateOnly.FromDateTime(DateTime.Today.AddDays(7 - weekConvert)).ToString();
        
        foreach (var task in DatabaseServisce.GetDbContext().Diaries)
        {
            if(task.UserId == activeUser && task.DateOfCompletion >= DateOnly.Parse(formattedDate) && task.DateOfCompletion <= DateOnly.Parse(formattedDateWeekConvert))
                Console.WriteLine($"Id: {task.Id} \nНазвание: {task.Title} \nЗадача: {task.Desckription} \nДата выполнения: {task.DateOfCompletion}");
        }
    }
    
    public static void WriteAllTasks()
    {
        foreach (var task in DatabaseServisce.GetDbContext().Diaries)
        {
            if(task.UserId == activeUser)
                Console.WriteLine($"Id: {task.Id} \nНазвание: {task.Title} \nЗадача: {task.Desckription} \nДата выполнения: {task.DateOfCompletion}");
        }
    }
    
    public static void WriteUpcominTasks()
    {
        formattedDate = DateOnly.FromDateTime(DateTime.Today).ToString();
        
        foreach (var task in DatabaseServisce.GetDbContext().Diaries)
        {
            if(task.UserId == activeUser && task.DateOfCompletion >= DateOnly.Parse(formattedDate))
                Console.WriteLine($"Id: {task.Id} \nНазвание: {task.Title} \nЗадача: {task.Desckription} \nДата выполнения: {task.DateOfCompletion}");
        }
    }
    
    public static void WritePastTasks()
    {
        formattedDate = DateOnly.FromDateTime(DateTime.Today).ToString();
        
        foreach (var task in DatabaseServisce.GetDbContext().Diaries)
        {
            if(task.UserId == activeUser && task.DateOfCompletion <= DateOnly.Parse(formattedDate))
                Console.WriteLine($"Id: {task.Id} \nНазвание: {task.Title} \nЗадача: {task.Desckription} \nДата выполнения: {task.DateOfCompletion}");
        }
    }

}