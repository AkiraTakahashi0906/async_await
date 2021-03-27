using System.Collections.Generic;
using System.Threading;

namespace async_await
{
    public interface IDTORepository
    {
        List<DTO> GetData(CancellationToken token);
    }
}
