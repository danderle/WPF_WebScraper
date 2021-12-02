using System;
using System.Windows.Media;

namespace WebScraper
{
    public class EntryViewModel
    {
        public string Name { get; set; } = string.Empty;

        public EntryViewModel(string name)
        {
            Name = name;
        }
    }
}
