using System.Collections.Generic;
using System.Linq;

namespace Tasker
{
    public static class Utils
    {

        private static Dictionary<int, string> ExpToRank = new Dictionary<int, string>
        {

            {1000, "Beginner"},
            {2000, "Amateur"},
            {3000, "Master"},
            {4000, "Knight"},
            {5000, "Lord"},
            {6000, "Angel"},
            {7000, "God"}
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
            return ExpToRank[expStages.Last()];
        }
        /*public static int GenerateUID(IAssignable[] collection)
        {
            return collection.Max(x => x.UID) + 1;
        }*/
        public static string[] Ranks { get => ExpToRank.OrderBy(x => x.Key).Select(x => x.Value).ToArray(); }

    }
    
}
