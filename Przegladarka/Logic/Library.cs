using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Przegladarka.Logic
{
    public class Library
    {
        public List<Favorite> Favorites { get; private set; }

        public Library()
        {
            Favorites = new List<Favorite>();
        }

        public void AddFavorite(Favorite favorite)
        {
            if (!Favorites.Contains(favorite))
                Favorites.Add(favorite);
        }

        public void RemoveGames(Favorite favorite)
        {
            Favorites.Remove(favorite);
        }

        public List<Favorite> GetFavorites()
        {
            return Favorites;
        }

        public void ImportFromFile()
        {

            if (!Directory.Exists(@"D:\test\MisioskiperDEV"))
            {
                Directory.CreateDirectory(@"D:\test\MisioskiperDEV");
                File.Create(@"D:\test\MisioskiperDEV\favorites.txt");
            }

            if (!File.Exists(@"D:\test\MisioskiperDEV\favorites.txt"))
            {
                File.Create(@"D:\test\MisioskiperDEV\favorites.txt");
            }

            using (var sr = new StreamReader(@"D:\test\MisioskiperDEV\favorites.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var values = line.Split('|');
                    var name = values[0];
                    var siteUrl = values[1];
                    var favorite = new Favorite(name, siteUrl);

                    AddFavorite(favorite);
                }
            }
        }

        public void SaveGamesToFile()
        {
            foreach (Favorite fav in Favorites)
            {
                using (var sw = new StreamWriter(@"D:\test\MisioskiperDEV\favorites.txt"))
                {
                    sw.WriteLine($"{fav.Name}|{fav.SiteUrl}");
                }
            }
        }

    }
}
