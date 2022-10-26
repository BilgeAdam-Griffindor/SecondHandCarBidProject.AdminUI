using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.AdminUI.Validator
{
    public static class ValidationValues
    {
        public static int maxImageSizeInMB = 1;
        public static int maxImageSizeInBytes = maxImageSizeInMB * 1024 * 1024;
        public static int maxImageCount = 5;
        public static short minYear = 1950;
        public static short maxYear = (short)DateTime.Now.Year;
    }
}
