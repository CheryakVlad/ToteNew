using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Service.Contracts.Common
{
    public interface IConnection<T>
    {
        object CreateListDto(SqlDataReader reader);
        void DefineDto(object obj, Func<SqlDataReader, object> body);
        SqlCommand GetCommand(SqlConnection connection, SqlCommand command, CommandType type, string commandText, IReadOnlyList<Parameter> parameters = null);
        T[] GetConnection(CommandType type, string commandText, IReadOnlyList<Parameter> parameters = null);
        int GetConnectionAddRate(CommandType type, string commandText, IReadOnlyList<Parameter> parameters = null);
        bool GetConnectionUpdate(CommandType type, string commandText, IReadOnlyList<Parameter> parameters = null);
    }
}
