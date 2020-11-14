
using pharmaco.model;
using System.Collections.Generic;

namespace pharmaco.data
{
    public abstract class BaseDataController
    {
        /// <summary>
        /// Find list of products included in category
        /// </summary>
        /// <param name="category_id">id of category to select</param>
        /// <returns>list of product in selected category and its subcategories</returns>
        public abstract List<medicine> GetMedicinesInCategory(List<string> categories_ids);
        /// <summary>
        /// Find list of products with name like param
        /// </summary>
        /// <param name="name">name of product to find</param>
        /// <returns>list of product in selected category and its subcategories</returns>
        public abstract List<medicine> GetMedicines(string name);
        /// <summary>
        /// Find categories
        /// </summary>
        /// <returns> listo of categoreies</returns>
        public abstract List<category> GetCategories();
        /// <summary>
        /// call functions to save order to db
        /// </summary>
        /// <param name="order">order to save</param>
        /// <returns>string to print on tag</returns>
        public abstract string SaveOrder(order order);
        /// <summary>
        /// function to get list of product for main page
        /// </summary>
        /// <returns>list of medicine</returns>
        public abstract List<medicine> GetMainPageProducts();
        /// <summary>
        /// function to get list of product names for main page
        /// </summary>
        /// <returns>list of names</returns>
        public abstract List<string> GetAllProductNames();

    }
}
