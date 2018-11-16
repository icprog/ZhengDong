using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class SystemDataType
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public SystemDataType(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
