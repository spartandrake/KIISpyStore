using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;

namespace KristopherCreelSpyStore.DAL.EF
{
    public class MyExecutionStrategy : ExecutionStrategy
    {
        public MyExecutionStrategy(ExecutionStrategyContext context) : base(context, ExecutionStrategy.DefaultMaxRetryCount, ExecutionStrategy.DefaultMaxDelay)
        {
        }
        public MyExecutionStrategy(ExecutionStrategyContext context, int maxRetryCount, TimeSpan maxRetryDelay): base(context, maxRetryCount, maxRetryDelay)
        {

        }
        protected override bool ShouldRetryOn(Exception exception)
        {
            return true;
        }
    }
}
