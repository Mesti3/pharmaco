﻿using pharmaco.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;

namespace pharmaco.data.DBDataCotroller
{
    public class DBController : BaseDataController
    {
        public override List<category> GetCategories()
        {
            var categories = new List<category>();
            string sql = DBAccess.ReadFirstResult("select value from pharmaco_db_access where [name] = 'select_categories_sql' ");
            if (!string.IsNullOrWhiteSpace(sql))
            {
                bool nextLevelNeeded = true;
                List<category> newIds = new List<category>();

                using (SqlConnection connection = DBAccess.CreateConnection())
                {
                    var sql0 = sql.Replace("@condition", " is null");
                    using (var command = new SqlCommand(sql0, connection))
                    {                        
                        using (var reader = command.ExecuteReader())
                        {
                            newIds = LoadCaterotyesFromReader(categories, reader);
                            nextLevelNeeded = newIds.Count > 0;
                        }
                    }
                    while (nextLevelNeeded)
                    {
                    //     parameter = new SqlParameter("name", "'" + string.Join("','", newIds.Select(x=>x.id)) + "'");
                        sql0 = sql.Replace("@condition", " in ('" + string.Join("','", newIds.Select(x => x.id)) + "')");
                        using (var command = new SqlCommand(sql0, connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                newIds = LoadCaterotyesFromReader(newIds, reader);
                                nextLevelNeeded = newIds.Count>0;
                            }
                        }
                    }
                }
            }
            else
                throw new KeyNotFoundException("ERROR>>null>>select_categories_sql");
            return categories;
        }

     

        public override List<medicine> GetMedicinesInCategory(List<string> categories_ids)
        {
            string sql = DBAccess.ReadFirstResult( "select value from pharmaco_db_access where [name] = 'select_medicine_by_category_sql' ");
            if (!string.IsNullOrWhiteSpace(sql))
            {
                SqlParameter parameter = new SqlParameter("@name", "'" + string.Join("','",categories_ids)+ "'");
                using (SqlConnection connection = DBAccess.CreateConnection())
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                            command.Parameters.Add(parameter);
                        using (var reader = command.ExecuteReader())
                        {
                            return LoadMedicineFromReader(reader);
                        }
                    }
                }
            }
            else 
                throw new KeyNotFoundException("ERROR>>null>>select_medicine_by_name_sql");
        }

        public override List<medicine> GetMedicines(string name)
        {
            string sql = DBAccess.ReadFirstResult("select value from pharmaco_db_access where [name] = 'select_medicine_by_name_sql' ");
            if (!string.IsNullOrWhiteSpace(sql))
            {
                using (SqlConnection connection = DBAccess.CreateConnection())
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        SqlParameter parameter = new SqlParameter("@medicinename", name);
                        command.Parameters.Add(parameter);
                        using (var reader = command.ExecuteReader())
                        {
                            return LoadMedicineFromReader(reader);
                        }
                    }
                }
            }
            else
                throw new KeyNotFoundException("ERROR>>null>>select_medicine_by_name_sql");

        }

        public override string SaveOrder(order order)
        {
            string tag = "***";
            using (SqlConnection connection = DBAccess.CreateConnection())
            {
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string sql = @"
                            declare @order_id int;  
                            insert into pharmaco_order (created, state, tag) values ('" + DBConversion.GetToDbDateTime(DateTime.Now) + @"', (select coalesce(max(tag)+1, 100) from pharmaco_order where datetime >  '" + DBConversion.GetToDbDateTime(DateTime.Now.Date) + @"' ));
                            set @order_id = SELECT SCOPE_IDENTITY();
                            ";

                        foreach (orderItem item in order.items)
                            sql += @"
                                    insert into pharmaco_order_item (order_id, medicine_id, quantity) values 
                                        (@order_id, " +DBConversion.GetToDbString(item.med.id)+ "," + DBConversion.GetToDbDecimal(item.quantity) + ");";
                        sql = "select top 1 tag from pharmaco_order where id = @order_id";
                        using (var command = new SqlCommand(sql, connection))
                        {
                            command.Transaction = transaction;
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                    tag =  reader[0].ToString();
                            }
                            // command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        //logovanie
                        
                    }
                }
            }
            return tag;
        }

        private List<category> LoadCaterotyesFromReader(List<category> lastLevelCategories, SqlDataReader reader)
        {
            List<category> newCategories = new List<category>();
            string parent_id = string.Empty;
            while (reader.Read())
            {
                category c = new category();
                c.id = DBConversion.GetFromDbString(reader["id"]);
                c.name =   DBConversion.GetFromDbString(reader["name"]);
                c.parent_category_id = DBConversion.GetFromDbString(reader["parent_category_id"]);
                newCategories.Add(c);
            }
            foreach (category category in newCategories)
            {
                var parent = lastLevelCategories.Where(x => x.id == category.parent_category_id).FirstOrDefault();
                if (parent == null)
                    lastLevelCategories.Add(category);
                else
                {
                    category.parent_category = parent;
                    parent.subcategories.Add(category);
                }
            }
            return newCategories;

        }
        private List<medicine> LoadMedicineFromReader(SqlDataReader reader)
        {
            List<medicine> medicines = new List<medicine>();
            while (reader.Read())
            {
                try
                {
                    medicine m = new medicine();
                    m.active_substances = DBConversion.GetFromDbString(reader["active_substances"]);
                    m.available_quantity = DBConversion.GetFromDbDecimal(reader["available_quantity"]);
                    m.available_quantity_as_string = DBConversion.GetFromDbString(reader["available_quantity_as_string"]);
                    //m.categories = DBConversion.GetFromDbString(reader["active_substances"]);
                    m.description = DBConversion.GetFromDbString(reader["description"]);
                    m.dosage = DBConversion.GetFromDbString(reader["dosage"]);
                    m.flyer = DBConversion.GetFromDbString(reader["flyer"]);
                    m.form = DBConversion.GetFromDbString(reader["form"]);
                    m.id = DBConversion.GetFromDbString(reader["id"]);
                    m.name = DBConversion.GetFromDbString(reader["name"]);
                    m.prescription_only = DBConversion.GetFromDbBoolean(reader["prescription_only"]);
                    m.price = DBConversion.GetFromDbDecimal(reader["price"]);
                    m.producer = DBConversion.GetFromDbString(reader["producer"]);
                    m.usage = DBConversion.GetFromDbString(reader["usage"]);
                    m.warning = DBConversion.GetFromDbString(reader["warning"]);
                    m.discountItem = GetDiscountItem(DBConversion.GetFromDbDecimal(reader["original_price"]), DBConversion.GetFromDbString(reader["discount_name"]));
                    m.photo_path = DBConversion.GetFromDbString(reader["photo_path"]);
                    medicines.Add(m);
                }
                catch (Exception ex)
                {
                   //  todo> logovanie 
                }

            }
            return medicines;
        }

        private discount GetDiscountItem(decimal? original_price, string text)
        {
            if (original_price.HasValue || !string.IsNullOrWhiteSpace(text))
            {
                return new discount() { originalPrice = original_price, text = text };
            }
            else
                return null;
        }
    }
}