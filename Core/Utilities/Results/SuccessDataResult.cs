using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        // Programcıya kullanacağı versiyonları burada yazıyoruz.
        // base kalıtım aldığın class'ı işaret eder. Onun ctor'unu kullan demek.
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
            // Bu sistemi kullanacak programcıya diyoruz ki bu yazdıklarımızla hem data ver hem mesaj ver.
        }
        public SuccessDataResult(T data) : base(data, true)
        {
            // Bu sistemi kullanacak programcıya diyoruz ki yalnızca data ver.
        }
        public SuccessDataResult(string message) : base(default, true, message)
        {
            // Bu sistemi kullanacak programcıya diyoruz ki yalnızca mesaj ver.
        }
        public SuccessDataResult() : base(default, true)
        {
            // Bu sistemi kullanacak programcıya diyoruz ki hiçbir şey verme.
        }
    }
}
