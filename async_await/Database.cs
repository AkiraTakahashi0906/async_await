using System;
using System.Collections.Generic;
using System.Text;

namespace async_await
{
    internal class Database
    {
        private bool _isCancel = false;
        internal bool IsCancel
        {
            get
            {
                return _isCancel;
            }
        }

        internal List<DTO> GetData()
        {
            _isCancel = false;
            var result = new List<DTO>();
            for (int i = 0; i < 5; i++)
            {
                if (_isCancel)
                {
                    return null;
                }
                System.Threading.Thread.Sleep(1000);
                result.Add(new DTO("ID" + i, "name" + i));
            }
            return result;
        }

        internal void Cancel()
        {
            _isCancel = true;
        }

    }
}
