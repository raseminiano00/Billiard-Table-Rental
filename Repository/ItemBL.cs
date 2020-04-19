using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableMonitoring.Model;

namespace TableMonitoring
{
    public class ItemBL
    {
        public static Item getItemFromDatabase(ItemBO bo)
        {
            var sqlResult= getItemFromDatabase(bo.itemCode);
            var temp = new Item();
            if (sqlResult.Rows.Count < 1)
            {
                return null;
            }
            foreach (DataRow row in sqlResult.Rows)
            {
                temp.quantity = 1;
                temp.itemCode = Convert.ToInt32(row["ITEMCODE"].ToString());
                temp.retailPrice = Convert.ToDouble(row["PRICE"].ToString());
                temp.taxValue = Convert.ToDouble(row["TAX"].ToString());
                temp.description = row["Description"].ToString();
            }
            return temp;
        }
        private static DataTable getItemFromDatabase(string itemCode)
        {
            var oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_itemCode", DbType.String, itemCode);
            return oDAL.getDataTable("getItem");
        }
        public static void saveTableTransaction(Table table)
        {
            var oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_tableId", DbType.Int32,table.tableId);
            oDAL.addParameter("_TimeStarted", DbType.DateTime, table.timeStarted);
            oDAL.addParameter("_TimeEnded", DbType.DateTime, table.timeEnded);
            oDAL.addParameter("_RentDuration", DbType.Time, table.totalRentTime);
            oDAL.addParameter("_status", DbType.Int32, table.Status);
            oDAL.addParameter("_AmountPaid", DbType.Double, table.runningRentAmount);
            oDAL.getDataTable("saveTableTransaction");
        }
        public static Action<Table> saveAction = (table) =>
        {
            ItemBL.saveTableTransaction(table);
        };
    }
}
