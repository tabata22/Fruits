using System.Threading;
using System.Threading.Tasks;
using Fruits.Core.Commons;

namespace Fruits.Core.Statements
{
    public interface IStatementService
    {
        Task<OperationResult> CreateStatementAsync(StatementModel statement, CancellationToken token = default);
        Task<OperationResult> ApproveStatementAsync(long statementId, CancellationToken token = default);
    }
}
