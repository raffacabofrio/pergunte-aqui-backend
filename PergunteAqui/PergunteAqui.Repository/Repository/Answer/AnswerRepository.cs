using PergunteAqui.Domain;
using System.Threading.Tasks;

namespace PergunteAqui.Repository
{
    public class AnswerRepository : RepositoryGeneric<Answer>, IAnswerRepository
    {
        public AnswerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
