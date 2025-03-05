using System.Collections.Generic;

namespace FileSource.Abstractions.Models.Queries
{
    public class SuggestionQuery
    {
        public SuggestionQuery()
        {
            Limit = 5;
            Order = string.Empty;
            Search = string.Empty;
        }

        public int Limit { get; set; }

        public string Order { get; set; }

        public string Search { get; set; }

        public Dictionary<string, string[]> Filter { get; set; }
    }
}
