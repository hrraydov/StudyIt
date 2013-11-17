using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyIt.Web.Helpers
{
    public static class GroupTypeHelper
    {
        public static string GroupTypeToString(GroupType type)
        {
            string result;
            if (type == GroupType.Private)
            {
                result = "Частна";
            }
            else
            {
                result = "Публична";
            }
            return result;
        }
    }
}