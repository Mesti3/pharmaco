using pharmaco.model;
using System.Collections.Generic;

namespace pharmaco.data
{
    public class DataController
    {
        private BaseDataController dataController;
        public DataController()
        {
            switch (System.Configuration.ConfigurationManager.AppSettings["DataMode"])
            {
                case "SQL": { dataController = new DBDataCotroller.DBController(); break; }
            }
        }

        public List<medicine> GetMedicinesInCategory(List<string> categories_ids)
        {
        return dataController.GetMedicinesInCategory(categories_ids);
        }
        public List<medicine> GetMedicines(string name)
        {
            return dataController.GetMedicines(name);
        }
        public  List<category> GetCategories()
        {
            return dataController.GetCategories();
        }
        public  string SaveOrder(order order)
        {
            return dataController.SaveOrder(order);
        }
        public List<medicine> GetMainPageProducts()
        {
            return dataController.GetMainPageProducts();
        }
        public List<string> GetAllProductNames()
        {
            return dataController.GetAllProductNames();
        }
        public List<marketing> GetMarketing()
        {
            return dataController.GetMarketing();
        }
        public List<medicine> GetProductsForMarketing(int marketing_id)
        {
            return dataController.GetProductsForMarketing(marketing_id);
        }
    }
}
