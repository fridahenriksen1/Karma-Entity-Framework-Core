using Karma_Entity_Framework_Core.Data;
using Karma_Entity_Framework_Core.Model;

namespace Karma_Entity_Framework_Core.Backend;

public class LoginManager
{
    public Customer TryLogin(string username, string password)
    {
        using var ctx = new FoodRescue();

        var query = ctx.customers
            .Where(u => u.Username == username)
            .Where(p => p.Password == password);


        //var sql = query.ToQueryString();
        var user = query.FirstOrDefault();
        return user;
    }
}