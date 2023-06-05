using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFishing
{
    public partial class Card2
    {
        private static string[] names0 = new string[]
        {
           "","asów","dwójek","trójek","czwórek","piątek",
           "szóstek","siódemek","ósemek","dziewiątek",
           "dziesiątek","waletów","dam","króli"
        };
        private static string[] names1 = new string[]
        {
           "","asa","dwóję","trójkę","czwórkę","piątkę",
           "szóstkę","siódemkę","ósemkę","dziewiątkę",
           "dziesiątkę","waleta","damę","króla"
        };
        private static string[] names2andMore = new string[]
        {
           "","asy","dwójki","trójki","czwórki","piątki",
           "szóstki","siódemki","ósemki","dziewiątki",
           "dziesiątki","walety","damy","króle"
        };
        public static string Plural(Values value, int count)
        {
            if (count == 0)
                return names0[(int)value];
            if (count == 1)
                return names1[(int)value];

            return names2andMore[(int)value];
        }
    }
}
