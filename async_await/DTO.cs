using System;
using System.Collections.Generic;
using System.Text;

namespace async_await
{
    public sealed class DTO
    {
        public DTO(string id , string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
