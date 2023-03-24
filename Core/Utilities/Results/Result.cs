using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
                                                    // this classın kendisini belirtir.(Burada Result)
        public Result(bool success, string message) : this(success)
        {
            // Yalnızca aşağıda get etmemize rağmen biz buradaki işlemle set ettik
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
