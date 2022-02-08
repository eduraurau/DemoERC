using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoERC.Dto
{
    public class FileResponse
    {
        public FileResponse(string value)
        {
            this.value = value;
        }
        public string value { get; set; }
    }
}
