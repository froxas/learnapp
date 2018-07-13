using System.Collections.Generic;

namespace learnapp.Helpers
{
    public enum SearchType
    {
        OR, AND
    }
    public class SearchObject
    {
        public string Property { get; set; }
        public IEnumerable<string> Search { get; set; } = new List<string>();
        public SearchType SearchType { get; set; }
    }
}