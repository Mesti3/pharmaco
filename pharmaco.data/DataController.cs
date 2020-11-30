using pharmaco.model;
using System.Collections.Generic;

namespace pharmaco.data
{
    public class DataController
    {
        protected string client_id;
        private BaseDataController dataController;
        public DataController(string client_id)
        {
            this.client_id = client_id;
            switch (System.Configuration.ConfigurationManager.AppSettings["DataMode"])
            {
                case "SQL": { dataController = new DBDataCotroller.DBController(client_id); break; }
            }
        }

        public List<medicine> GetMedicinesInCategory(List<string> categories_ids, int count=1000, int offset=0)
        {
        return dataController.GetMedicinesInCategory(categories_ids, count, offset);
        }
        public List<medicine> GetMedicines(string name, int count=1000, int offset=0)
        {
            return dataController.GetMedicines(name,count,offset);
        }
        public  List<category> GetCategories()
        {
            return dataController.GetCategories();
        }
        public  string SaveOrder(order order)
        {
            return dataController.SaveOrder(order);
        }
        public List<medicine> GetMainPageProducts(int count =1000,int offset=0 )
        {
            return dataController.GetMainPageProducts(count, offset);
        }
        public List<string> GetAllProductNames()
        {
            return dataController.GetAllProductNames();
        }
        public List<marketing> GetMarketing()
        {
            return dataController.GetMarketing();
        }
        public List<medicine> GetProductsForMarketing(int marketing_id,int count=1000, int offset=0)
        {
            return dataController.GetProductsForMarketing(marketing_id, count, offset);
        }
    }
}
