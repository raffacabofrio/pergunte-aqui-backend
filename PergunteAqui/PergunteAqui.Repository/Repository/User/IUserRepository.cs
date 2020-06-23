using PergunteAqui.Domain;
using System.Threading.Tasks;

namespace PergunteAqui.Repository
{
    public interface IUserRepository : IRepositoryGeneric<User>
    {
        Task<User> UpdatePassword(User user);
    }
}
