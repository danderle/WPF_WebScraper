namespace WebScraper
{
    /// <summary>
    /// The data scraped to be displayed
    /// </summary>
    public class DataModel
    {
        #region Properties

        /// <summary>
        /// The name of the data
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// the image path of the data
        /// </summary>
        public string ImagePath { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// The overloaded constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="imagePath"></param>
        public DataModel(string name, string imagePath)
        {
            Name = name;
            ImagePath = imagePath;
        } 

        #endregion
    }
}
