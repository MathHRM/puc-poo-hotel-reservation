using Models;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<User> CreateAsync(User user)
    {
        await _repository.AddAsync(user);
        await _repository.SaveChangesAsync();
        return user;
    }

    public async Task<bool> UpdateAsync(int id, User user)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return false;

        existing.Username = user.Username;
        existing.Email = user.Email;

        _repository.Update(existing);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null)
            return false;

        _repository.Delete(user);
        await _repository.SaveChangesAsync();
        return true;
    }
}
