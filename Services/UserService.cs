using Audiophile_e_commerce_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Audiophile_e_commerce_API.Services;

public class UserService(EcommerceContext dbcontext) : IUserService {
    readonly EcommerceContext context = dbcontext;

    public IEnumerable<User> GetUsers() {
        return context.Users;
    }

    public async Task Save(User user) {
        user.CreatedAt= DateTime.Now;
        context.Add(user);
        await context.SaveChangesAsync();
    }

        public async Task Update(Guid id, User user)
    {
        var userActual = context.Users.Find(id);

        if(userActual != null)
        {
            userActual.FirstName = user.FirstName;
            userActual.LastName = user.LastName;
            userActual.Address = user.Address;
            userActual.Telephone = user.Telephone;
            userActual.Password = user.Password;

            await context.SaveChangesAsync();
        }
    }

        public async Task Delete(Guid id)
    {
        var userActual = context.Users.Find(id);

        if(userActual != null)
        {
            context.Remove(userActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface IUserService {
    IEnumerable<User> GetUsers();
    Task Save(User user);
    Task Update(Guid id, User user);
    Task Delete(Guid id);
}