using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Models;

namespace Store.Classes
{
    public static class UtilsHtmlTag
    {
        public static string CreateInputTag(string str)
        {
            var res = $"<input class=\"form-control col-md-3\" type=\"text\" value=\"{str}>";

            return res;
        }
    }
}