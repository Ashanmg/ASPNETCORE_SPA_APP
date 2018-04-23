using System.Threading.Tasks;

namespace VEGA.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}