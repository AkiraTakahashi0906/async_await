using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace async_await
{
    public interface IMlRepository
    {
         Task<List<MlEntity>> GetML(CancellationToken token);
    }
}
