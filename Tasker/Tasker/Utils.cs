using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker
{
    public static class Utils
    {

        private static Dictionary<int, string> ExpToRank = new Dictionary<int, string>
        {

            {0, "Beginner"},
            {1000, "Amateur"},
            {2000, "Master"},
            {3000, "Knight"},
            {4000, "Lord"},
            {5000, "Angel"},
            {6000, "God"}
        };
        public static string GetRankByExp(int exp)
        {
            int[] expStages = ExpToRank.Keys.OrderBy(x=>x).ToArray();
            foreach(int curStage in expStages)
            {
                if(exp < curStage)
                {
                    return ExpToRank[curStage];
                }
            }
            return ExpToRank[expStages[0]];
        }
        public static int GenerateUID(IAssignable[] collection)
        {
            return collection.Max(x => x.UID) + 1;
        }
        public static string[] Ranks { get => ExpToRank.OrderBy(x => x.Key).Select(x => x.Value).ToArray(); }

    }
    
}
