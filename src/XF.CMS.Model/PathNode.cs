using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CMS.Model
{
    public class PathNode
    {
        public string Path { get; set; }
        public string Root { get; set; }
        public string Master { get; set; }
        public List<string> Segments { get; set; }
        public int Count { get; set; }
        public PathNode()
        {

        }
        public PathNode(string path, int count = -1)
        {
            Path = path;
            Count = count;
            Segments = new List<string>(path.Split(new char[] { '|', ';' }));
            if (Segments.Count > 1)
            {
                Root = Segments[0];
                StringBuilder sb = new StringBuilder();
                sb.Append(Root);
                for (int i = 0; i < Segments.Count-1; i++)
                {
                    sb.Append("|" + Segments[i]);
                }
                Master = sb.ToString();
            }
            else
            {
                Root = path;
                Master = "|";
            }
        }
    }
}
