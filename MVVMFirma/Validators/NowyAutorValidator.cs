using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Validators
{
    public static class NowyAutorValidator
    {

        public static string ValidateString(string pole)
        {
                    if (string.IsNullOrEmpty(pole))
                    {
                        return "Pole nie może być puste";
                    }
                    else if (!char.IsUpper(pole, 0))
                    {
                        return "Pierwsza litera musi być duża";
                    }
            return string.Empty;
        }

        public static string ValidateDate(DateTime? pole)
        {
            if (pole > DateTime.Now)
            {
                return "Data urodzenia nie może być w przyszłości";
            }
            return string.Empty;

        }
    }
}
