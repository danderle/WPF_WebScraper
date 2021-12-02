using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Web;

namespace WebScraper
{
    /// <summary>
    /// Class for scraping websites
    /// </summary>
    public class Scraper
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Scraper()
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Method to scrape the wanted data
        /// </summary>
        /// <returns></returns>
        public List<DataModel> ScrapeData()
        {
            HtmlWeb web = new();
            HtmlDocument doc = web.Load("https://en.wikipedia.org/wiki/List_of_animal_sounds");

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/div[5]/div[1]/table[1]/tbody/tr[position()>1]");

            List<DataModel> list = new List<DataModel>();

            foreach (HtmlNode node in nodes)
            {
                string name = HttpUtility.HtmlDecode(node.SelectSingleNode("td[2]/a").InnerText);

                var src = node.SelectSingleNode("td[1]/a/img").Attributes["src"].Value;
                using WebClient client = new WebClient();
                Uri relative = new Uri("https:" + src);
                using Stream stream = client.OpenRead(relative);
                using Bitmap bitmap = new Bitmap(stream);
                if (bitmap != null)
                {
                    string imgPath = @"Resources\Images\" + name + ".jpg";
                    bitmap.Save(imgPath, ImageFormat.Jpeg);
                    imgPath = Path.GetFullPath(imgPath);
                    list.Add(new DataModel(name, imgPath));
                }
            }
            return list;
        } 
        #endregion
    }
}
