using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Fruits.Core.Commons;
using Fruits.Data;
using Fruits.Data.Statements;

namespace Fruits.Core.Statements
{
    public class StatementService : IStatementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StatementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult> CreateStatementAsync(StatementModel statement, CancellationToken token = default)
        {
            await ValidateStatementAsync(statement);
            var statementDTO = _mapper.Map<StatementModel, Statement>(statement);

            statementDTO.IsApproved = false;
            await _unitOfWork.Statements.SaveAsync(statementDTO, token);
            _unitOfWork.Commit();

            return OperationResult.Success();
        }

        public async Task<OperationResult> ApproveStatementAsync(long statementId, CancellationToken token = default)
        {
            var statement = await _unitOfWork.Statements.GetAsync(statementId);
            await CheckQuantity(statement.ProductId, statement.Quantity);

            statement.IsApproved = true;
            await _unitOfWork.Statements.UpdateOneAsync(statement, token);

            await _unitOfWork.Products.ReduceProductAsync(statement.ProductId, statement.Quantity, token);
            _unitOfWork.Commit();

            return OperationResult.Success();
        }

        private async Task ValidateStatementAsync(StatementModel statement)
        {
            if (statement.AgentId <= 0)
                throw new ArgumentOutOfRangeException(nameof(statement.AgentId));

            if (statement.ProductId <= 0)
                throw new ArgumentOutOfRangeException(nameof(statement.ProductId));

            if (statement.Quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(statement.Quantity));

            var checkAgent = await _unitOfWork.Agents.Exists(x => x.Id == statement.AgentId && x.DeletedAt != null);
            if (checkAgent)
                throw new Exception("agent is deleted");

            await CheckQuantity(statement.ProductId, statement.Quantity);
        }

        private async Task CheckQuantity(long productId, int quantity)
        {
            var check = await _unitOfWork.Products.CheckProductAvailabilityAsync(productId, quantity);
            if (!check)
                throw new Exception("not enough product quantity");
        }
    }
}
