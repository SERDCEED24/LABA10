using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA10
{
    public class VHS
    {
        public static int Input(string errorText, int minValue = -10000, int maxValue = 10000)
        {
            int x;
            string buf;
            bool isConvert;
            do
            {
                buf = Console.ReadLine();
                isConvert = int.TryParse(buf, out x);
                if (!((minValue <= x) && (x <= maxValue)))
                {
                    isConvert = false;
                }
                if (!isConvert)
                {
                    Console.WriteLine(errorText);
                }
            } while (!isConvert);
            return x;
        }
    }
}
