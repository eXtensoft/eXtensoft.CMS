using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CMS.Model
{
    public static class Extensions
    {
        public static List<PathNode> Expand(this List<PathNode> list)
        {
            List<PathNode> nodes = new List<PathNode>();
            foreach (var item in list.Unwind())
            {
                nodes.Add(new PathNode(item));
            }
            return nodes;
        }


        private static List<string> Unwind(this IEnumerable<PathNode> nodes)
        {
            List<string> list = new List<string>();
            HashSet<string> hs = new HashSet<string>();
            foreach (var node in nodes)
            {
                foreach (var item in node.Segments.Unwind())
                {
                    if (hs.Add(item))
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        private static List<string> Unwind(this List<string> segments)
        {
            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append(segments[0]);
            list.Add(sb.ToString());
            for (int i = 0; i < segments.Count; i++)
            {
                sb.Append("|" + segments[i]);
                list.Add(sb.ToString());
            }

            return list;
        }
    }
}
