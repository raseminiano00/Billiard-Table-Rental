using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableMonitoring.Model;

namespace TableMonitoring.Repository
{
    public class TableMysqlRepository : ITableRepository
    {
        DataAccessLayer _DAL;
        private readonly Lazy<BindingList<Table>> _tables;

        public TableMysqlRepository()
        {
            _tables = new Lazy<BindingList<Table>>(() =>
            {
                    return generateList();
            });

        }
        public IEnumerable<Table> GetAllTables()
        {
            return _tables.Value;
        }

        public Table GetATable(int id)
        {
            return _tables.Value[id];
        }

        private BindingList<Table> generateList()
        {
            var ret = new BindingList<Table>();
            var result = getTableDetails();
            if (result.Rows.Count < 1)
            {
                return null;
            }
            foreach (DataRow row  in result.Rows)
            {
                var temp = new Table();
                temp.tableid = Convert.ToInt32(row["TABLE"].ToString());
                temp.ratePerHour = Convert.ToDouble(row["HOURLY RATE"].ToString());
                temp.ratePerGame = Convert.ToDouble(row["GAME RATE"].ToString());
                if(row["TIME STARTED"].ToString().Count() > 0)
                {
                    temp.timeStarted = DateTime.Parse(row["TIME STARTED"].ToString());
                }
                if(row["RUNNING TIME"].ToString().Count() > 0){
                    temp.runningTime = TimeSpan.Parse(row["RUNNING TIME"].ToString());
                }
                ret.Add(temp);
            }
            return ret;
        }
        private DataTable getTableDetails()
        {
            _DAL = new DataAccessLayer();
            _DAL.clearParameter();
            _DAL.addParameter("_neutralStatus", DbType.String,"NOT OCCUPIED");
            return _DAL.getDataTable("getTableStatus");
        }

        BindingList<Table> ITableRepository.GetAllTables()
        {
            return _tables.Value;
        }

        public void updateTableToDb(Table table)
        {
            _DAL = new DataAccessLayer();
            _DAL.clearParameter();
            _DAL.addParameter("_tableid", DbType.Int32,table.tableid );
            _DAL.addParameter("_rateperhour", DbType.Double,table.ratePerHour );
            _DAL.addParameter("_ratepergame", DbType.Double, table.ratePerGame);
            _DAL.addParameter("_timestarted", DbType.DateTime, table.timeStarted);
            //_DAL.

        }
    }
}
