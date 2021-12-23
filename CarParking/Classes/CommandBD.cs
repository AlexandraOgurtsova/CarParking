using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовой.Classes
{
    class CommandBD
    {
        DataBase bd = new DataBase();

        internal DataBase DataBase
        {
            get => default;
            set
            {
            }
        }

        public DataTable Select(string tableFrom, string where, string where2)
        {
            return bd.Select(tableFrom, where, where2);
        }
       
        public void Delete(string table, string where, string where2)
        {
            bd.Delete(table, where, where2);
        }

        public DataTable SelectAll(string table)
        {
            return bd.SelectAll(table);
        }
        public void InsertIntoHistory(string tableTo, string operation, DateTime date)
        {
            bd.InsertIntoHistory(tableTo, operation, date);
        }

        public void UpdateUserParametr(string param1, string param2, string param3, string param4)
        {
            bd.UpdateUserParametr(param1, param2, param3, param4);
        }


    }
}
