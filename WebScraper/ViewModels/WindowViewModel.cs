using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace WebScraper
{
    /// <summary>
    /// The main window view model
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Fields

        /// <summary>
        /// the window
        /// </summary>
        private Window _window;

        #endregion

        /// <summary>
        /// The web scraper
        /// </summary>
        public Scraper WebScraper { get; set; } = new();

        /// <summary>
        /// The items scraped
        /// </summary>
        public ObservableCollection<DataModel> Items { get; set; } = new();

        #region Commands

        /// <summary>
        /// The command to start scraping
        /// </summary>
        public ICommand ScrapeCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public WindowViewModel(Window window)
        {
            _window = window;
            ScrapeCommand = new RelayCommand(Scrape);
        }

        #endregion

        #region Command methods

        /// <summary>
        /// Methods to scrape
        /// </summary>
        private void Scrape()
        {
            var list = WebScraper.ScrapeData();
            Items = new ObservableCollection<DataModel>(list);
        } 
        #endregion
    }
}
