using System;
using System.Data;
using System.Data.Common;
using Nevermore.Mapping;

namespace Nevermore
{
    public class SqlCommandFactory : ISqlCommandFactory
    {
        public static readonly TimeSpan DefaultCommandTimeout = TimeSpan.FromSeconds(60);

        public DbCommand CreateCommand(DbConnection connection, DbTransaction transaction, string statement, CommandParameterValues args, DocumentMap mapping = null, TimeSpan? commandTimeout = null)
        {
            var command = connection.CreateCommand();

            try
            {
                command.CommandTimeout = (int)(commandTimeout ?? DefaultCommandTimeout).TotalSeconds;
                command.CommandText = statement;
                command.Transaction = transaction;
                args?.ContributeTo(command, mapping);
                return command;
            }
            catch
            {
                command.Dispose();
                throw;
            }
        }
    }
}