using System.Threading.Tasks;

namespace BuildingBlocks.StoredProcedureHandlers
{
    public interface IStoredProcedureHandler<in TRequest, TOutput> 
        where TRequest : IStoredProcedureRequest
    {
        Task<TOutput> Execute(TRequest request);
    }
}