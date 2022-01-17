﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBridgeTestTask.DAL.Helpers
{
    public class PagingParams
    {
        const int maxPageSize = 50;
        [FromQuery(Name = "pageNumber")]
        public int PageNumber { get; set; } = 1;
        private int? _pageSize = null;
        [FromQuery(Name = "pageSize")]
        public int? PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value.Value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
