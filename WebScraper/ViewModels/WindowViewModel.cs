using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace WebScraper
{
    public class WindowViewModel : BaseViewModel
    {
        #region Fields

        private Window _window;

        #endregion

        public string UrlPath { get; set; } = string.Empty;

        public Scraper WebScraper { get; set; } = new();

        public ObservableCollection<EntryViewModel> Items { get; set; } = new();

        public ICommand ScrapeCommand { get; set; }

        #region Constructor

        public WindowViewModel(Window window)
        {
            _window = window;
            ScrapeCommand = new RelayCommand(Scrape);
        } 

        #endregion

        private void Scrape()
        {
            var items = WebScraper.ScrapeData(UrlPath);
            Items = new ObservableCollection<EntryViewModel>(items);
        }
    }
}
