using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace async_await
{
    internal class Database3: IDTORepository
    {
        public  List<DTO> GetData(CancellationToken token)
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
