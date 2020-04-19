using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public class TableMySqlRepository : ITableRepository
    {

        DataAccessLayer _DAL;
        private readonly Lazy<BindingList<TableModel>> _tables;
        public TableMySqlRepository()
        {
            _tables = new Lazy<BindingList<TableModel>>(() =>
            {
                return generateList();
            });

        }
        public BindingList<TableModel> GetAllTables()
        {
            return _tables.Value;
        }

        public TableModel GetATable(int id)
        {
            return _tables.Value[id];
        }

        private BindingList<TableModel> generateList()
        {
            var ret = new BindingList<TableModel>();
            var result = getTableDetails();
            if (result.Rows.Count < 1)
            {
                return null;
            }
            foreach (DataRow row in result.Rows)
            {

                DateTime timeIn = (row["TIME STARTED"].ToString().Count() > 0 ? DateTime.Parse(row["TIME STARTED"].ToString()) : DateTime.MinValue);
                DateTime timeEnded = (row["TIME ENDED"].ToString().Count() > 0 ? DateTime.Parse(row["TIME ENDED"].ToString()) : DateTime.MinValue);
                var transaction = new TransactionBuilder()
                    .SetRackRate(Convert.ToInt32(row["GAME RATE"].ToString()))
                    .SetHourlyRate(Convert.ToInt32(row["HOURLY RATE"].ToString()))
                    .SetTotalRacks(0)
                    .SetTimeStarted(timeIn)
                    .SetTimeEnded(timeEnded).Construct();

                var transType = TableTransactionFactory.GetTransType(Convert.ToInt32(row["TRANSACTION"].ToString()));
                var tableState = TableStateFactory.getTableStateByCode(Convert.ToInt32(row["STATE"].ToString()));
                var temp = new DbTableBuilder(transType,tableState,transaction)
                    .SetTabledId(Convert.ToInt32(row["TABLE"].ToString())).Construct();

                ret.Add(temp);
            }
            return ret;
        }
        private DataTable getTableDetails()
        {
            _DAL = new DataAccessLayer();
            _DAL.clearParameter();
            //_DAL.addParameter("_neutralStatus", DbType.String, "NOT OCCUPIED");
            return _DAL.getDataTable("getTableStatus");
        }

        public Action<TableModel> saveAction()
        {
            Action<TableModel> saveAction = (table) =>
            {
                TableMySqlRepository.saveTableTransaction(table);
            };
            return saveAction;
        }
        public Action<TableModel> saveCurrentTransaction()
        {
            Action<TableModel> saveAction = (table) =>
            {
                TableMySqlRepository.saveCurrentTransaction(table);
            };
            return saveAction;
        }
        public Action<TableModel> saveCheckOutTransaction()
        {
            Action<TableModel> saveAction = (table) =>
            {
                TableMySqlRepository.saveCheckedOutTransaction(table);
            };
            return saveAction;
        }
        private static void saveTableTransaction(TableModel table)
        {
            var oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_tableId", DbType.Int32, table.TableId);
            oDAL.addParameter("_TimeStarted", DbType.DateTime, table.GetTransaction().TimeStarted);
            oDAL.addParameter("_TimeEnded", DbType.DateTime, table.GetTransaction().TimeEnded);
            oDAL.addParameter("_RentDuration", DbType.Time, table.GetTransaction().TotalRentTime);
            oDAL.addParameter("_status", DbType.Int32, table.TransactionTypeCode);
            oDAL.addParameter("_AmountPaid", DbType.Double, table.TransactionAmount);
            oDAL.getDataTable("saveTableTransaction");
        }
        private static void saveCurrentTransaction(TableModel table)
        {
            var oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_tableId", DbType.Int32, table.TableId);
            oDAL.addParameter("_timeStarted", DbType.DateTime, table.GetTransaction().TimeStarted);
            oDAL.addParameter("_Transaction", DbType.Int32, table.TransactionTypeCode);
            oDAL.addParameter("_State", DbType.Int32, table.GetTableStateCode);
            oDAL.getDataTable("setTableTransaction");
        }
        private static void saveCheckedOutTransaction(TableModel table)
        {
            var oDAL = new DataAccessLayer();
            oDAL.clearParameter();
            oDAL.addParameter("_tableId", DbType.Int32, table.TableId);
            oDAL.addParameter("_timeEnded", DbType.DateTime, table.GetTransaction().TimeEnded);
            oDAL.addParameter("_Transaction", DbType.Int32, table.TransactionTypeCode);
            oDAL.addParameter("_State", DbType.Int32, table.GetTableStateCode);
            oDAL.getDataTable("setCheckOutTable");
        }

    }
}
