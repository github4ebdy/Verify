using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Dto
{
    public class FilterDto
    {

        private int _pagenumber = 1;
        private int _pageSize = 10;

        /// <summary>**PageNumber** Page Number.</summary>
        /// <example>1</example>
        [Range(1, 999)]
        public int PageNumber
        {
            get
            {
                return _pagenumber;
            }
            set
            {
                _pagenumber = (value < 1) ? 1 : value;
            }
        }

        /// <summary>Records display in a page.</summary>
        ///// <example>10</example>
        [Range(10, 1000)]
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value < 1) ? 10 : value;
            }
        }

        /// <summary>**FilterBy**: Its a key-value list for define multiple filter condition.</summary>
        /// <example>["emailid": "testuser@exampleurl.com",
        ///           "firstname": "Shan"]</example>
        public Dictionary<string, string>? FilterBy { get; set; }
        public Dictionary<string, string>? SortBy { get; set; }
    }
}
