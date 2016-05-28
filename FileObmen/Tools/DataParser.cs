using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileObmen.Tools
{
    public class GuidData
    {
        public string Name { get; set; }
        public string Guid { get; set; }
        public string Url { get; set; }
    }

    public static class DataParser
    {
        public static List<string> ParseLinkData(string input)
        {
            var output = new List<string>();
            var str = "";
            foreach (var i in input)
            {
                if (i != ',')
                {
                    str += i;
                }
                else
                {
                    output.Add(str);
                    str = "";
                }
            }
            return output;
        }

        public static List<GuidData> ParseGuidData(string input)
        {
            var output = new List<GuidData>();
            var str = "";
            var data = new GuidData();
            foreach (var i in input)
            {
                if (i == '*')
                {
                    data.Name = str;
                    str = "";
                }
                if (i == ',')
                {
                    data.Guid = str;
                    output.Add(data);
                    str = "";
                    data = new GuidData();
                }
                if (i != ',' && i != '*')
                {
                    str += i;
                }
            }
            return output;
        } 
    }
}