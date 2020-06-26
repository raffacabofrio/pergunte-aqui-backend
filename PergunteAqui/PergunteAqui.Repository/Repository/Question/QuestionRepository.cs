using PergunteAqui.Domain;
using System.Threading.Tasks;

namespace PergunteAqui.Repository
{
    public class QuestionRepository : RepositoryGeneric<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
