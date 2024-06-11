using Diary2._4.Models;

namespace Diary2._4;

public class DatabaseServisce
{
    private static Gr624KudalContext db;

    public static Gr624KudalContext  GetDbContext()
    {
        if (db == null)
        {
            db = new Gr624KudalContext();
        }
        return db;
    }
}