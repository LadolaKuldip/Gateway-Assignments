using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewLayer.Filters
{
    public class SetAuthorAttribute : Attribute, IResultFilter
    {
        string _value;
        public SetAuthorAttribute(string value)
        {
            _value = value;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {

        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Author", new string[] { _value });
        }
    }
}
