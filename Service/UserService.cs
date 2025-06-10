namespace Service;

public class UserService
{
    private AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    
}