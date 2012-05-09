using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using SurfaceRetailingApp.Models;

namespace SurfaceRetailingApp
{
    /// <summary>
    /// ModelManager is responsible of loading and manage Application state
    /// </summary>
    public class AppState : INotifyPropertyChanged
    {
        #region Public Properties
        
        public List<Product> Products;

        #endregion

        #region Model Manager Lazy Loader

        static AppState instance;

        //Lazy loading using Singleton Pattern
        static public AppState Instance
        {
            get
            {
                if (instance == null)
                    instance = new AppState();
                return instance;
            }
        } 
        #endregion


        /// <summary>
        /// Save Changes.
        /// </summary>
        public void Save()
        {
            var serializer = new XmlSerializer(typeof(List<Product>));
            TextWriter textWriter = new StreamWriter("Models\\ProductList.xml");
            serializer.Serialize(textWriter, Products);
            textWriter.Close();
        }


        /// <summary>
        /// Loads Products from xml file.
        /// </summary>
        public void Load()
        {
            var deserializer = new XmlSerializer(typeof(List<Product>));
            TextReader textReader = new StreamReader("Models\\ProductList.xml");

            Products = (List<Product>) deserializer.Deserialize(textReader);

        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}