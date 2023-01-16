using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNorthwind.UI
{
    internal class ReaderHelper
    {
        private readonly IDataReader _dataReader;

        public ReaderHelper(IDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        public int? GetNullableInt32(string fieldName)
        {
            return _dataReader[fieldName] == DBNull.Value
                ? default
                : (int)_dataReader[fieldName];
        }
    }
}
