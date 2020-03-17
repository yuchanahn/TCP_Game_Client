using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace YCEM
{
    public static class YC_EM
    {
        public static string get_string(this char[] array)
        {
            return new string((from c in array
                               where c != '\0'
                               select c).ToArray());
        }
        public static void CopyFrom(this char[] array, string s)
        {
            Array.Copy(s.ToArray(), 0, array, 0, s.Length);
        }

    }
}
