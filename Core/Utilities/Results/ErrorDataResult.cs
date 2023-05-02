using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        // Programcıya kullanacağı versiyonları burada yazıyoruz.
        // base kalıtım aldığın class'ı işaret eder. Onun ctor'unu kullan demek.
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
            // Bu sistemi kullanacak programcıya diyoruz ki bu yazdıklarımızla hem data ver hem mesaj ver.
        }
        public ErrorDataResult(T data) : base(data, false)
        {
            // Bu sistemi kullanacak programcıya diyoruz ki yalnızca data ver.
        }
        public ErrorDataResult(string message) : base(default, false, message)
        {
            // Bu sistemi kullanacak programcıya diyoruz ki yalnızca mesaj ver.
        }
        public ErrorDataResult() : base(default, false)
        {
            // Bu sistemi kullanacak programcıya diyoruz ki hiçbir şey verme.
        }
    }
}
