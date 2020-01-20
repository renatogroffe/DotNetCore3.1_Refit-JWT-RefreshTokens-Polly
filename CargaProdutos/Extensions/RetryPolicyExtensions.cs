using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;
using CargaProdutos.Models;

namespace CargaProdutos.Extensions
{
    public static class RetryPolicyExtensions
    {
        public static Task<T> ExecuteWithRefreshTokenAsync<T>(
            this AsyncRetryPolicy retryPolicy,
            Token token,
            Func<Context, Task<T>> action)
        {
            return retryPolicy.ExecuteAsync(action,
                new Dictionary<string, object>
                {
                    { "AccessToken", token.AccessToken },
                    { "RefreshToken", token.RefreshToken }
                });
        }
    }
}