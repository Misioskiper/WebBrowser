using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Przegladarka.Logic
{
    public class Favorite
    {
        public string Name { get; set; }
        public string SiteUrl { get; set; }

        public Favorite(string Name, string SiteUrl)
        {
            this.Name = Name;
            this.SiteUrl = SiteUrl;
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public void SaveToFile()
        {
            if (!Directory.Exists(@"D:\test\MisioskiperDEV"))
            {
                Directory.CreateDirectory(@"D:\test\MisioskiperDEV");
            }

            using (var sw = new StreamWriter(@"D:\test\MisioskiperDEV\favorites.txt", true))
            {
                sw.WriteLine("{0}|{1}|", Name, SiteUrl);
            }
        }
    }
}
