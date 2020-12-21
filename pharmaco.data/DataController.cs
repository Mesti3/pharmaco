using pharmaco.model;
using System;
using System.Collections.Generic;

namespace pharmaco.data
{
    public class DataController
    {
        protected string client_id;
        private BaseDataController dataController;

        public order ReloadOrder { get; set; }

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
        public List<order> GetAllOrders(DateTime? time_from, DateTime? time_to, List<int> ids, orderstate order_state = orderstate.all, int count = 1000, int offset = 0)
        {
            return dataController.GetAllOrders(time_from, time_to, ids, order_state, count, offset);
        }

#nullable enable
        public void UpdateOrderState (int order_id, orderstate new_state, string? user)
        {
            dataController.UpdateOrderState(order_id, new_state, user);
        }
#nullable disable
        public Tuple<orderstate, string> ReloadOrderHeader(int order_id)
        {
            return dataController.ReloadOrderHeader(order_id);
        }
        public void LogActivity( activity_log log)
        {
            dataController.LogActivity(log);
        }
    }
}
