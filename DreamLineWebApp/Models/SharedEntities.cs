using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nENTITIES = Entities;

namespace DreamLineWebApp.Models
{
    public class WebSearch
    {
        private nENTITIES.WebSearch webSearch = null;
        private List<string> contentTypes = null;

        public string SearchText
        {
            get
            {
                webSearch = webSearch ?? new nENTITIES.WebSearch();
                return webSearch.SearchText;
            }
            set
            {
                webSearch = webSearch ?? new nENTITIES.WebSearch();
                webSearch.SearchText = value;
            }
        }
        public string ContentType
        {
            get
            {
                webSearch = webSearch ?? new nENTITIES.WebSearch();
                return webSearch.ContentType;
            }
            set
            {
                webSearch = webSearch ?? new nENTITIES.WebSearch();
                webSearch.ContentType = value;
            }
        }
        public List<string> ContentTypes
        {
            get
            {
                if (contentTypes == null)
                {
                    //contentTypes = GetContentTypes();
                }
                return contentTypes;
            }
        }
        public nENTITIES.WebSearch Instance
        {
            get
            {
                webSearch = webSearch ?? new nENTITIES.WebSearch();
                return webSearch;
            }
            set
            {
                webSearch = value;
            }
        }
    }
    public class SearchResults
    {
        private nENTITIES.SearchResults obj = null;
        private List<SearchResult> results = null;
        public List<SearchResult> Results
        {
            get
            {
                return results;
            }
            set
            {
                results = value;
            }
        }
        public nENTITIES.SearchResults Instance
        {
            get
            {
                obj = obj ?? new nENTITIES.SearchResults();
                if (results != null && results.Count > 0)
                {
                    obj.Results = results.Select(itm => itm.Instance).ToList();
                }
                return obj;
            }
            set
            {
                obj = value;
                if (obj != null && obj.Results != null && obj.Results.Count > 0)
                {
                    results = new List<SearchResult>();
                    SearchResult itm = null;
                    foreach (nENTITIES.SearchResult res in obj.Results)
                    {
                        itm = new SearchResult();
                        itm.Instance = res;
                        results.Add(itm);
                    }
                }
            }
        }
    }

    public class SearchResult
    {
        private nENTITIES.SearchResult obj = null;
        public string ContentType
        {
            get
            {
                obj = obj ?? new nENTITIES.SearchResult();
                return obj.ContentType;
            }
            set
            {
                obj = obj ?? new nENTITIES.SearchResult();
                obj.ContentType = value;
            }
        }
        public string Category
        {
            get
            {
                obj = obj ?? new nENTITIES.SearchResult();
                return obj.Category;
            }
            set
            {
                obj = obj ?? new nENTITIES.SearchResult();
                obj.Category = value;
            }
        }
        public string Code
        {
            get
            {
                obj = obj ?? new nENTITIES.SearchResult();
                return obj.Code;
            }
            set
            {
                obj = obj ?? new nENTITIES.SearchResult();
                obj.Code = value;
            }
        }
        public string Logo_Url
        {
            get
            {
                obj = obj ?? new nENTITIES.SearchResult();
                return obj.Logo_Url;
            }
            set
            {
                obj = obj ?? new nENTITIES.SearchResult();
                obj.Logo_Url = value;
            }
        }
        public string Link_Url
        {
            get
            {
                obj = obj ?? new nENTITIES.SearchResult();
                return obj.Link_Url;
            }
            set
            {
                obj = obj ?? new nENTITIES.SearchResult();
                obj.Link_Url = value;
            }
        }
        public long Id
        {
            get
            {
                obj = obj ?? new nENTITIES.SearchResult();
                return obj.Id;
            }
            set
            {
                obj = obj ?? new nENTITIES.SearchResult();
                obj.Id = value;
            }
        }

        public nENTITIES.SearchResult Instance
        {
            get
            {
                obj = obj ?? new nENTITIES.SearchResult();
                return obj;
            }
            set
            {
                obj = value;
            }
        }
    }
}