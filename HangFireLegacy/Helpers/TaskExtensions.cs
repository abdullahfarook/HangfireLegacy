using System;
using System.Threading.Tasks;

namespace HangFireLegacy.Helpers
{
    public static class TaskExtensions
    {
        public static Task<TNewResult> OnCompletion<TNewResult, TResult>(this Task<TResult> task, Func<TResult, TNewResult> continuationFunction)
            => task.ContinueWith(x => continuationFunction(x.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
    }
}
