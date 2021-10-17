using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            var following = "following";
            var followed = "followed";

            for (int i = 0; i < int.MaxValue - 1; i++)
            {
                var line = Console.ReadLine();

                if (line == "Statistics")
                {
                    var totalCountOfVloggers = vloggers.Select(x => x.Value).Count();
                    var mostFollowedVloggers = vloggers.OrderByDescending(x => x.Value[followed].Count).ThenBy(x => x.Value[following].Count);
                    break;
                }

                var splitLine = line.Split().ToList();
                if (splitLine.Contains("joined"))
                {
                    var vlogger = splitLine.First();
                    if (!vloggers.ContainsKey(vlogger))
                    {
                        vloggers.Add(vlogger, new Dictionary<string, HashSet<string>>());
                        vloggers[vlogger].Add(followed, new HashSet<string>());
                        vloggers[vlogger].Add(following, new HashSet<string>());
                    }
                }
                
                if (splitLine.Contains("followed"))
                {
                    var follower = splitLine.First();
                    var vlogger = splitLine.Last();
                    if (vloggers.ContainsKey(vlogger) && vloggers.ContainsKey(follower) && follower != vlogger)
                    {
                        vloggers[vlogger][followed].Add(follower);
                        vloggers[follower][following].Add(vlogger);
                    }
                }
            }
        }
    }
}