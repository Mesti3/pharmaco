using pharmaco.log;
using pharmaco.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace pharmaco.data.DBDataCotroller
{
    public class DBController : BaseDataController
    {
        public DBController(string client_id)
        {
            this.client_id = client_id;
        }

        private string client_id;

        public override List<category> GetCategories()
        {
            var categories = new List<category>();
            string sql = "";
            var sql0 = "";
            try
            {
                sql = DBAccess.ReadFirstResult("select value from pharmaco_db_access where [name] = 'select_categories_sql' ");
                if (!string.IsNullOrWhiteSpace(sql))
                {
                    bool nextLevelNeeded = true;
                    List<category> newIds = new List<category>();

                    using (SqlConnection connection = DBAccess.CreateConnection())
                    {
                         sql0 = sql.Replace("@condition", " is null");
                        using (var command = new SqlCommand(sql0, connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                newIds = LoadCategoriesFromReader(categories, reader);
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
                                    newIds = LoadCategoriesFromReader(newIds, reader);
                                    nextLevelNeeded = newIds.Count > 0;
                                }
                            }
                        }
                    }
                }
                else
                    throw new KeyNotFoundException("ERROR>>null>>select_categories_sql");
                return categories;
            }
            catch (Exception ex)
            {
                ex.Data.Add("function", "GetCategories");
                ex.Data.Add("sql", sql0);
                ex.Data.Add("datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ex.Data.Add("stack_trace", ex.StackTrace.ToString());

                throw ex;
            }
        }



        public override List<medicine> GetMedicinesInCategory(List<string> categories_ids, int count, int offset)
        {
            string sql = "";
            try
            {
                 sql = DBAccess.ReadFirstResult("select value from pharmaco_db_access where [name] = 'select_medicine_by_category_sql' ");
                if (!string.IsNullOrWhiteSpace(sql))
                {
                    // SqlParameter parameter = new SqlParameter("@ids", "'" + string.Join("','", categories_ids) + "'");
                    using (SqlConnection connection = DBAccess.CreateConnection())
                    {
                        sql = sql.Replace("@ids", "'" + string.Join("','", categories_ids) + "'");
                        sql += " OFFSET " + offset + " ROWS FETCH FIRST " + count + " ROWS ONLY; ";
                        using (var command = new SqlCommand(sql, connection))
                        {
                            // command.Parameters.Add(parameter);
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
            catch (Exception ex)
            {
                ex.Data.Add("function", "GetMedicinesInCategory");
                ex.Data.Add("input categories_id", string.Join("|", categories_ids) );
                ex.Data.Add("input count", count);
                ex.Data.Add("input offset", offset);
                ex.Data.Add("sql", sql);
                ex.Data.Add("datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ex.Data.Add("stack_trace", ex.StackTrace.ToString());

                throw ex;
            }
        }

        public override List<medicine> GetMedicines(string name, int count, int offset)
        {
            string sql = "";
            try
            {
                 sql = DBAccess.ReadFirstResult("select value from pharmaco_db_access where [name] = 'select_medicine_by_name_sql' ");
                if (!string.IsNullOrWhiteSpace(sql))
                {
                    using (SqlConnection connection = DBAccess.CreateConnection())
                    {
                        sql += " OFFSET " + offset + " ROWS FETCH FIRST " + count + " ROWS ONLY; ";
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
            catch (Exception ex)
            {
                ex.Data.Add("function", "GetMedicines");
                ex.Data.Add("input name", name);
                ex.Data.Add("input count", count);
                ex.Data.Add("input offset", offset);
                ex.Data.Add("sql", sql);
                ex.Data.Add("datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ex.Data.Add("stack_trace", ex.StackTrace.ToString());

                throw ex;
            }
        }

        private List<category> LoadCategoriesFromReader(List<category> lastLevelCategories, SqlDataReader reader)
        {
            List<category> newCategories = new List<category>();
            string parent_id = string.Empty;
            while (reader.Read())
            {
                category c = new category();
                c.id = DBConversion.GetFromDbString(reader["id"]);
                c.name = DBConversion.GetFromDbString(reader["name"]);
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
                catch (Exception )
                {
                    throw;
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

        public override List<medicine> GetMainPageProducts(int count, int offset) /*todo - odstránenie zbytočných funkcií*/
        {
            string sql= "";
            try
            {
                sql = DBAccess.ReadFirstResult("select value from pharmaco_db_access where [name] = 'select_medicine_for_main_page_sql' ");
                if (!string.IsNullOrWhiteSpace(sql))
                {
                    using (SqlConnection connection = DBAccess.CreateConnection())
                    {
                        using (var command = new SqlCommand(sql, connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                return LoadMedicineFromReader(reader);
                            }
                        }
                    }
                }
                else
                    throw new KeyNotFoundException("ERROR>>null>>select_medicine_for_main_offset_sql");
            }
            catch(Exception ex)
            {
                ex.Data.Add("function", "GetMainPageProducts");
                ex.Data.Add("input count", count);
                ex.Data.Add("input offset", offset);
                ex.Data.Add("sql", sql);
                ex.Data.Add("datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ex.Data.Add("stack_trace", ex.StackTrace.ToString());

                throw ex;
            }

        }
        public override List<string> GetAllProductNames() /*todo - odstránenie zbytočných funkcií*/
        {
            string sql = "";
            try
            {
                List<string> result = new List<string>();
                sql = DBAccess.ReadFirstResult("select value  from pharmaco_db_access where [name] = 'select_product_names_sql' ");
                if (!string.IsNullOrWhiteSpace(sql))
                {
                    using (SqlConnection connection = DBAccess.CreateConnection())
                    {
                        using (var command = new SqlCommand(sql, connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    result.Add(reader[0].ToString());
                            }
                        }
                    }
                    return result;
                }
                else
                    throw new KeyNotFoundException("ERROR>>null>>select_medicine_for_main_offset_sql");
            }
            catch (Exception ex)
            {
                ex.Data.Add("function", "GetAllProductNames");
                ex.Data.Add("sql", sql);
                ex.Data.Add("datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ex.Data.Add("stack_trace", ex.StackTrace.ToString());

                throw ex;
            }
        }
        public override List<marketing> GetMarketing()
        {
            string sql = "";
            List<marketing> result = new List<marketing>();

            try
            {
                sql = DBAccess.ReadFirstResult("select value from pharmaco_db_access where [name] = 'select_marketing_sql' ");
                if (!string.IsNullOrWhiteSpace(sql))
                {
                    using (SqlConnection connection = DBAccess.CreateConnection())
                    {
                        using (var command = new SqlCommand(sql, connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                List<medicine> medicines = new List<medicine>();
                                while (reader.Read())
                                {
                                    try
                                    {
                                        marketing m = new marketing();
                                        m.name = DBConversion.GetFromDbString(reader["name"]);
                                        m.description = DBConversion.GetFromDbString(reader["description"]);
                                        m.id = DBConversion.GetFromDbInt(reader["id"]).Value;
                                        m.horizontal_banner_path = DBConversion.GetFromDbString(reader["horizontal_banner_path"]);
                                        m.vertical_banner_path = DBConversion.GetFromDbString(reader["vertical_banner_path"]);

                                        result.Add(m);
                                    }
                                    catch (Exception ex)
                                    {
                                        ex.Data.Add("function", "GetMarketing");
                                        ex.Data.Add("sql", sql);
                                        ex.Data.Add("datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        ex.Data.Add("stack_trace", ex.StackTrace.ToString());

                                        logger.send_email(ex, client_id);
                                    }

                                }
                                return result;

                            }
                        }
                    }
                }
                else
                    throw new KeyNotFoundException("ERROR>>null>>select_marketing_sql");
            }
            catch (Exception ex)
            {
                ex.Data.Add("function", "GetMarketing");
                ex.Data.Add("sql", sql);
                ex.Data.Add("datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ex.Data.Add("stack_trace", ex.StackTrace.ToString());

                throw ex;
            }
        }
        public override List<medicine> GetProductsForMarketing(int marketing_id, int count, int offset)
        {
            string sql = "";
            try
            {
                 sql = DBAccess.ReadFirstResult("select value from pharmaco_db_access where [name] = 'select_medicine_by_marketing_id_sql' ");
                if (!string.IsNullOrWhiteSpace(sql))
                {
                    sql += " OFFSET " + offset + " ROWS FETCH FIRST " + count + " ROWS ONLY; ";
                    SqlParameter parameter = new SqlParameter("@param", marketing_id);
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
                    throw new KeyNotFoundException("ERROR>>null>>select_medicine_by_marketing_id_sql");
            }
               catch (Exception ex)
            {
                ex.Data.Add("function", "GetProductsForMarketing");
                ex.Data.Add("input marketing_id",marketing_id);
                ex.Data.Add("input count", count);
                ex.Data.Add("input offset",offset);
                ex.Data.Add("sql", sql);
                ex.Data.Add("datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ex.Data.Add("stack_trace", ex.StackTrace.ToString());

                throw ex;
            }
        }
        public override List<order> GetAllOrders(DateTime? time_from, DateTime? time_to, List<int> ids, orderstate order_state, int count, int offset)
        {
            string sql = "";
            try
            {
                //tabuľa je naša, nepotrebujeme načítaať query z databázy
                //  sql = DBAccess.ReadFirstResult("select value from pharmaco_db_access where [name] = 'select_all_orders' ");
                //  if (!string.IsNullOrWhiteSpace(sql))
                //  {
                sql = @"
select o.tag as tag, o.[state] as state , o.created as created, o.id as id, o.[user] as [user],
oi.quantity as quantity, oi.[name] as name
from pharmaco_order o
join pharmaco_order_item oi on oi.order_id=o.id
where 1=1   ";
                if (time_from.HasValue)
                    sql += " and [created] >= " + DBConversion.GetToDbDateTime(time_from.Value);
                if (time_to.HasValue)
                    sql += " and [created] <= " + DBConversion.GetToDbDateTime(time_to.Value);
                if (order_state != orderstate.all)
                    sql += " and [state] = " + (int)order_state;
                if (ids != null && ids.Any())
                    sql += " and o.id in (" + string.Join(",", ids) + ")";

                sql += " order by [created],tag OFFSET " + offset + " ROWS FETCH FIRST " + count + " ROWS ONLY; ";

                using (SqlConnection connection = DBAccess.CreateConnection())
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            return LoadOrderFromReader(reader);
                        }
                    }
                }
             //   }
             //   else
             //       throw new KeyNotFoundException("ERROR>>null>>pharmaco_db_access");
            }
            catch (Exception ex)
            {
                ex.Data.Add("function", "GetAllOrders");
                ex.Data.Add("input time_from", time_from?.ToString("yyyy-MM-dd HH:mm:ss") ?? "null");
                ex.Data.Add("input time_to", time_to?.ToString("yyyy-MM-dd HH:mm:ss") ?? "null");
                ex.Data.Add("input order_state", order_state.ToString());
                ex.Data.Add("input ids", (ids== null ) ? "null":string.Join(",", ids));
                ex.Data.Add("input count", count);
                ex.Data.Add("input offset", offset);
                ex.Data.Add("sql", sql);
                ex.Data.Add("datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ex.Data.Add("stack_trace", ex.StackTrace.ToString());

                throw ex;
            }
        }
       
        private List<order> LoadOrderFromReader(SqlDataReader reader)
        {
            List<order> orders = new List<order>();
            int old_id = 0;
            int new_id = 0;
            order m = new order();
            while (reader.Read())
            {
                try
                {
                    new_id = DBConversion.GetFromDbInt(reader["id"]).Value;
                    if (new_id != old_id)
                    {
                        if (old_id!=0)
                            orders.Add(m);
                        m = new order();
                        m.id = new_id;
                        m.tag = DBConversion.GetFromDbString(reader["tag"]);
                        m.user = DBConversion.GetFromDbString(reader["user"]);
                        m.created =(DateTime)reader["created"] ;
                        m.state =(orderstate)DBConversion.GetFromDbInt(reader["state"]).Value;
                        old_id = new_id;
                    }
                    orderItem oi = new orderItem();
                    oi.quantity = DBConversion.GetFromDbDecimal(reader["quantity"]).Value;
                    oi.name = DBConversion.GetFromDbString(reader["name"]);

                    m.items.Add(oi);
                }
                catch (Exception)
                {
                    throw;
                }

            }
            if (old_id != 0)
                orders.Add(m);

            return orders;
        }

        public override string SaveOrder(order order)
        {
            string tag = "***";
            using (SqlConnection connection = DBAccess.CreateConnection())
            {
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    SqlParameter outputIdParam = new SqlParameter("@newtag", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    string sql = "";
                    try
                    {
                        sql = @"
                            declare @order_id int;  
                            set @newtag = (select coalesce(max(tag)+1, 100) from pharmaco_order where created >  " + DBConversion.GetToDbDateTime(DateTime.Now.Date) + @" ); 
                            insert into pharmaco_order (created, state, tag, price) values (" + DBConversion.GetToDbDateTime(DateTime.Now) + @",1,  @newtag,"+ DBConversion.GetToDbString(order.price) + @" );
                            set @order_id =( SELECT SCOPE_IDENTITY());
                            ";

                        foreach (orderItem item in order.items)
                            sql += @"
                                    insert into pharmaco_order_item (order_id, medicine_id, quantity, [name], [source], price ) values 
                                        (@order_id, " + DBConversion.GetToDbString(item.med.id) + "," + DBConversion.GetToDbDecimal(item.quantity) + "," + DBConversion.GetToDbString(item.med.name) + "," + DBConversion.GetToDbString((int)item.source) +"," + DBConversion.GetToDbString(item.price)  + ");";

                        using (var command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.Add(outputIdParam);
                            command.Transaction = transaction;
                            var t = command.ExecuteNonQuery();
                            transaction.Commit();
                            tag = outputIdParam.Value.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        ex.Data.Add("function", "SaveOrder");
                        ex.Data.Add("sql", sql);
                        ex.Data.Add("tag", tag);
                        ex.Data.Add("datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ex.Data.Add("order_as_string", order.ToString());
                        ex.Data.Add("stack_trace", ex.StackTrace.ToString());

                        throw ex;
                        //logovanie

                    }
                }
            }
            return tag;
        }

        public override void UpdateOrderState(int order_id, orderstate new_state, string? user)
        {
            using (SqlConnection connection = DBAccess.CreateConnection())
            {
            //    using (SqlTransaction transaction = connection.BeginTransaction())
              //  {
                    string sql = "";
                    try
                    {
                        sql = @"
                            update pharmaco_order set [state] = " + (int)new_state +", [user] =" + (user != null ? (DBConversion.GetToDbString(user)) : "null" )+ @" 
                           where id = " + order_id;
                           
                       
                        using (var command = new SqlCommand(sql, connection))
                        {
                           // command.Transaction = transaction;
                            var t = command.ExecuteNonQuery();
                          //  transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                       // transaction.Rollback();

                        ex.Data.Add("function", "UpdateOrderState");
                        ex.Data.Add("sql", sql);
                        ex.Data.Add("datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        ex.Data.Add("stack_trace", ex.StackTrace.ToString());

                        throw ex;
                        //logovanie

                    }
              //  }
            }
        }
        public override Tuple<orderstate, string> ReloadOrderHeader(int order_id)
        {
            string sql = "";
            try
            {
                sql ="select [state] as state , [user] as [user] from pharmaco_order where id = " + order_id;
              
                    using (SqlConnection connection = DBAccess.CreateConnection())
                    {
                        using (var command = new SqlCommand(sql, connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                    return new Tuple<orderstate, string>((orderstate)DBConversion.GetFromDbInt(reader["state"]).Value, DBConversion.GetFromDbString(reader["user"]));
                                else
                                    throw new Exception("order "  + order_id + " not found");
                            }
                        }
                    }
            
            }
            catch (Exception ex)
            {
                ex.Data.Add("function", "ReloadOrderHeader");
                ex.Data.Add("input order_id", order_id);
                ex.Data.Add("sql", sql);
                ex.Data.Add("datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ex.Data.Add("stack_trace", ex.StackTrace.ToString());

                throw ex;
            }
        }
        public override void LogActivity(activity_log log)
        {
            string sql = "";
            try
            {
                sql = "insert into pharmaco_log ([type], referenced_object_id, additional_data) values (" + (int)log.type + "," + DBConversion.GetToDbString(log.referenced_object_id) + "," + DBConversion.GetToDbString(log.additional_data) + ")";

                using (SqlConnection connection = DBAccess.CreateConnection())
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("function", "LogActivity");
                ex.Data.Add("input log.type", (int)log.type);
                ex.Data.Add("input log.additional_data", log.additional_data);
                ex.Data.Add("sql", sql);
                ex.Data.Add("datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ex.Data.Add("stack_trace", ex.StackTrace.ToString());

                throw ex;
            }
        }
    }
}
