using System.Collections.Generic;

namespace FileSource.Abstractions.Models.Queries
{
    public class PagedQuery
    {
        public PagedQuery()
        {
            Offset = 0;
            Limit = 100;
            Order = string.Empty;
            Search = string.Empty;
        }

        public int Offset { get; set; }

        public int Limit { get; set; }

        public string Order { get; set; }

        public string Search { get; set; }

        public Dictionary<string, string> Filter { get; set; }
    }
}
