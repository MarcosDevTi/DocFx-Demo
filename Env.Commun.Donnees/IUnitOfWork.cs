using System.Threading.Tasks;

namespace Env.Commun.Donnees
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}