using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    public static class Numbers
    {
        public static int ToInteger(string s)
        {
            try
            {
                int ret = Int32.Parse(s);
                return ret;
            }
            catch
            {
                return -1;
            }
        }
    }
}
