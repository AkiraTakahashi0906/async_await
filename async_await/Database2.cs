using System;
using System.Collections.Generic;
using System.Text;

namespace async_await
{
    internal class Database2
    {
        internal List<DTO> GetData(System.Threading.CancellationToken token)
        {
            var result = new List<DTO>();
            for (int i = 0; i < 5; i++)
            {
                token.ThrowIfCancellationRequested();
                System.Threading.Thread.Sleep(1000);
                result.Add(new DTO("ID" + i, "name" + i));
            }
            return result;
        }
    }
}
