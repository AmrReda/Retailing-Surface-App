namespace SurfaceRetailingApp.Models
{
    /// <summary>
    /// Product class 
    /// </summary>
    public class Product
    {

        #region Private fields

        private string productName;
        private string price;
        private string imageUrl;

        #endregion

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// The name of the product.
        /// </value>
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        public string ImageUrl
        {
            get { return "Resources/" + imageUrl; }
            set { imageUrl = value; }
        }
    }
}