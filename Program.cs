using Diary2._4;
using System;

namespace Diary2._4;

internal class Program
{


    static void Main()
    {
        string choose = "";
        int IdTask = 0;
        bool flag = true;
        bool flag2 = true;
        
        while (flag2)
        {
            Console.WriteLine("1 - зарегистрироватся \n2 - Войти");
            choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    DatabaseRequests.CreateNewClient();
                    break;
                case "2":
                    DatabaseRequests.EnterClient();
                    if (DatabaseRequests.activeUser != 0)
                    {
                        flag2 = false;
                    } 
                    break;
                default:
                    Console.WriteLine("Неверный формат ввода");
                    break;
            }
        }
        
        while (flag)
        {
            Console.WriteLine(
                " \n Введите команду: \n 1 - Добавить задачу \n 2 - Удалить задачу \n 3 - Посмотреть все задачи \n 4 - Посмотреть все предстоящие задачи \n 5 - Посмотреть все прошедшие задачи \n 6 - Посмотреть все задачи на сегодня \n 7 - Посмотреть все задачи на завтра \n 8 - Посмотреть все задачи на эту неделю \n 9 - Изменить задачу \n 0 - Завершить работу программы");
            choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    DatabaseRequests.CreateNewTask();
                    break;
                case "2":
                    Console.WriteLine("Введите id задачи");
                    IdTask = int.Parse(Console.ReadLine());
                    DatabaseRequests.DeleteTask(IdTask);
                    break;
                case "3":
                    DatabaseRequests.WriteAllTasks();
                    break;
                case "4":
                    DatabaseRequests.WriteUpcominTasks();
                    break;
                case "5":
                    DatabaseRequests.WritePastTasks();
                    break;
                case "6":
                    DatabaseRequests.WriteTodayTasks();
                    break;
                case "7":
                    DatabaseRequests.WriteTomorrowTasks();
                    break;
                case "8":
                    DatabaseRequests.WriteWeekTasks();
                    break;
                case "9":
                    Console.WriteLine("Введите id задачи");
                    IdTask = int.Parse(Console.ReadLine());
                    DatabaseRequests.UpdateTask(IdTask);
                    break;
                case "0":
                    Console.WriteLine("Программа завершина ");
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Некоректный формат ввода комманды ");
                    break;
            }
        }
    }
}