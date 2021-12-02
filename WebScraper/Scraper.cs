using HtmlAgilityPack;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;

namespace WebScraper
{
    public class Scraper
    {

        public Scraper()
        {
        }

        public List<EntryViewModel> ScrapeData(string pageUrl)
        {
            HtmlWeb web = new ();
            HtmlDocument doc = web.Load("https://en.wikipedia.org/wiki/List_of_animal_sounds");

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/div[5]/div[1]/table[1]/tbody/tr[position()>1]");

            List < EntryViewModel > list = new List<EntryViewModel>();

            foreach (HtmlNode node in nodes)
            {
                var src = node.SelectSingleNode("td[1]/a/img").Attributes["src"].Value;
                string name = HttpUtility.HtmlDecode(node.SelectSingleNode("td[2]/a").InnerText);
                Debug.WriteLine(name);
                list.Add(new EntryViewModel(name));
            }
            return list;
        }
    }
}
