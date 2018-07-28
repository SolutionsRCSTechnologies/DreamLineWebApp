using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WebSearch : Serializable<WebSearch>
    {
        public string SearchText
        {
            get;
            set;
        }

        public string ContentType
        {
            get;
            set;
        }
    }

    public class SearchResults : Serializable<SearchResults>
    {
        public List<SearchResult> Results
        {
            get;
            set;
        }
    }

    public class SearchResult : Serializable<SearchResult>
    {
        public string ContentType
        {
            get;
            set;
        }
        public string Category
        {
            get;
            set;
        }
        public string Code
        {
            get;
            set;
        }
        public string Logo_Url
        {
            get;
            set;
        }
        public string Link_Url
        {
            get;
            set;
        }
        public long Id
        {
            get;
            set;
        }
    }
}
