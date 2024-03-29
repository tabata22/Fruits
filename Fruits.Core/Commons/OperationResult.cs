﻿namespace Fruits.Core.Commons
{
    public abstract class BaseOperationResult
    {
        public BaseOperationResult(string message, bool isSuccess)
        {
            Message = message;
            IsSuccess = isSuccess;
        }

        public string Message { get; }
        public bool IsSuccess { get; }
    }

    public class OperationResult : BaseOperationResult
    {
        public OperationResult(string message, bool isSuccess) : base(message, isSuccess)
        {
        }

        public static OperationResult Success() => new ("OK", true);
    }

    public class OperationResult<TResult> : BaseOperationResult where TResult : class
    {
        public OperationResult(string message, bool isSuccess, TResult result) : base(message, isSuccess) => Result = result;

        public TResult Result { get; }
    }
}
