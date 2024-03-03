using Audiophile_e_commerce_API.Models;

namespace Audiophile_e_commerce_API.Services;

public class UserService : IUserService {
    EcommerceContext context;

    public UserService(EcommerceContext dbcontext) {
        context = dbcontext;
    }

    public IEnumerable<User> GetUsers() {
        return context.Users;
    }
}

public interface IUserService {
    IEnumerable<User> GetUsers();
}