using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ_AC_Calculator
{
    static class Books
    {
        public static readonly Dictionary<string, int> Class2Number = new Dictionary<string, int>();
        public static readonly List<SoftCap> ACSoftCaps = new List<SoftCap>();

        public static void Load_Books()
        {
            Load_Class_List();
            Load_SoftCaps();
        }

        public static void Load_Class_List()
        {
            var lines = Properties.Resources.PlayerClasses.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            List<string> classes = lines.ToList();

            for (int i = 0; i < classes.Count; ++i)
            {
                Class2Number.Add(lines[i], i);
            }
        }

        public static void Load_SoftCaps()
        {
            var lines = Properties.Resources.ACMitigation.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            List<string> softcaps = lines.ToList();

            //Start with 1 because the first line (index 0) is the column headers.
            for (int i = 1; i < softcaps.Count; ++i)
            {
                var values = softcaps[i].Trim().Split('^');
                if (values.Length < 4)
                    continue;

                int ClassNumber = Convert.ToInt32(values[0]);
                int Level = Convert.ToInt32(values[1]);
                int Cap = Convert.ToInt32(values[2]);
                decimal Multiplier = Convert.ToDecimal(values[3]);

                SoftCap NewSoftCap = new SoftCap(ClassNumber, Level, Cap, Multiplier);

                ACSoftCaps.Add(NewSoftCap);
            }
        }

        public static int Get_Class_Number(string className)
        {
            if (Class2Number.ContainsKey(className))
            {
                return Class2Number[className];
            }
            else
            {
                return -1;
            }
        }
    }
}
