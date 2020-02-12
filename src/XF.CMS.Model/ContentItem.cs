using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CMS.Model
{
    [Serializable]
    public class ContentItem
    {
        public string Id { get; set; }
        public string Display { get; set; }
        public string Mime { get; set; }
        public string Body { get; set; }
        public List<string> Tags { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public List<string> Paths { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Display);
            sb.AppendLine($"\t{String.Join(", ", Tags)}");
            return sb.ToString();
        }
    }
}

