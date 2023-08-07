using Contexts.Users.Domain;
using Microsoft.EntityFrameworkCore;

namespace Contexts.Users.Infraestruture;

public class UserRepositoryFromMySQL: IUserRepository
{
    private readonly AppDbContext  appDbContext;
    
    public UserRepositoryFromMySQL(AppDbContext _appDbContext)
    {
        appDbContext = _appDbContext;
    }

    public async Task<List<User>> GetAll()
    {
        return await appDbContext.Users.ToListAsync();
    }

    public async Task<User> GetById(string id)
    {
        return await appDbContext.Users.FindAsync(Guid.Parse(id));
    }
    public async Task<bool> Add(User user)
    {
        try
        {
            appDbContext.Add(user);
            await appDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    
    public async Task<bool> Update(User user)
    {
        try
        {
            appDbContext.Update(user);
            await appDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }    
    }

    public async Task<bool> Delete(User user)
    {
        try
        {
            appDbContext.Remove(user);
            await appDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }   
    }
}