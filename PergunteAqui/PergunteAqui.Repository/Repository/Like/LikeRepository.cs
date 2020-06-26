using PergunteAqui.Domain;
using System.Threading.Tasks;

namespace PergunteAqui.Repository
{
    public class LikeRepository : RepositoryGeneric<Like>, ILikeRepository
    {
        public LikeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
