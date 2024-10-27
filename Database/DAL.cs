using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    static class DAL
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["Database.Properties.Settings.DatabaseConnectionString"].ConnectionString;
        public static SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

        public static DataTable LoadEntireEntity(string entity)
        {
            try
            {
                string[] entities = { entity };
                InTableColumnWhitelist(entities);
            }
            catch (ArgumentException)
            {
                throw;
            }
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (SqlException) when (sqlConnection.State == ConnectionState.Closed)
                {
                    throw;
                }
                string sqlQuery = $"SELECT * FROM {entity}";
                sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
                return dataTable;
            }
        }

        // Adds a record
        public static int Add(string entity, string[] fieldNames, string[] record, bool skipFirstId)
        {
            try
            {
                string[] entities = { entity };
                InTableColumnWhitelist(entities);
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (SqlException) when (sqlConnection.State == ConnectionState.Closed)
                {
                    throw;
                }
                int tempI = 0;
                if (fieldNames[0] != null && fieldNames[0].Substring(fieldNames[0].Length - 2, 2) == "Id" && skipFirstId == true)
                {
                    tempI = 1;
                }
                string sqlQuery = $"INSERT INTO {entity}(";
                for (int i = tempI; i < record.Count(); i++)
                {
                    sqlQuery += $"{fieldNames[i]}, ";
                }
                sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 2);
                sqlQuery += $") VALUES(";
                for (int i = tempI; i < record.Count(); i++)
                {
                    sqlQuery += $"@{fieldNames[i]}, ";
                }
                sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 2);
                sqlQuery += $");";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                for (int i = tempI; i < record.Count(); i++)
                {
                    sqlCommand.Parameters.AddWithValue($"@{fieldNames[i]}", $"{record[i]}");
                }
                int rowsAffected = 0;
                try
                {
                    rowsAffected = sqlCommand.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                sqlConnection.Close();
                return rowsAffected;
            }
        }

        // Edits a record
        public static int Edit(string entity, string[] fieldNames, string idAttribute, int id, string[] record, bool skipFirstId)
        {
            try
            {
                string[] entities = { entity, idAttribute };
                InTableColumnWhitelist(entities);
            }
            catch (ArgumentException)
            {
                throw;
            }
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (SqlException) when (sqlConnection.State == ConnectionState.Closed)
                {
                    throw;
                }
                int tempI = 0;
                int rowsAffected = 0;
                if (fieldNames[0] != null && fieldNames[0].Substring(fieldNames[0].Length - 2, 2) == "Id" && skipFirstId == true)
                {
                    tempI = 1;
                }
                string sqlQuery = $"UPDATE {entity} SET ";
                for (int i = tempI; i < record.Count(); i++)
                {
                    sqlQuery += $"{fieldNames[i]} = @{fieldNames[i]}, ";
                }
                sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 2);
                sqlQuery += $" WHERE {idAttribute} = @{idAttribute};";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    for (int i = tempI; i < record.Count(); i++)
                    {
                        sqlCommand.Parameters.AddWithValue($"@{fieldNames[i]}", $"{record[i]}");
                    }
                    sqlCommand.Parameters.AddWithValue($"@{idAttribute}", $"{id}");
                    rowsAffected = sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
                return rowsAffected;
            }
        }

        // Deletes a record
        public static int Delete(string entity, string[] idFieldNames, List<int> ids, bool manyToMany)
        {
            try
            {
                string[] entities = new string[idFieldNames.Count() + 1];
                entities[0] = entity;
                idFieldNames.CopyTo(entities, 1);
                InTableColumnWhitelist(entities);
            }
            catch (ArgumentException)
            {
                throw;
            }
            /*for (int i = 0; i < idFieldNames.Count(); i++)
            {
                if (InTableColumnWhitelist(idFieldNames[i]) == false)
                {
                    return 0;
                }
            }*/
            if (ids.Count() > 0)
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    int rowsAffected = 0;
                    int parameterCount = 0;
                    try
                    {
                        sqlConnection.Open();
                    }
                    catch (SqlException) when (sqlConnection.State == ConnectionState.Closed)
                    {
                        throw;
                    }
                    string sqlQuery = ($"DELETE FROM {entity} WHERE ");
                    for (int i = 0; i < ids.Count(); i++)
                    {
                        sqlQuery += $"{idFieldNames[i]} = @{idFieldNames[i]}#{parameterCount} AND ";
                        parameterCount++;
                    }
                    sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 5);
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        for (int i = 0; i < parameterCount; i++)
                        {
                            sqlCommand.Parameters.AddWithValue($"{idFieldNames[i]}#{i}", $"{ids[i]}");
                        }
                        rowsAffected = sqlCommand.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                    return rowsAffected;
                }
            }
            return 0;
        }

        // Gets all field values and column names of a record. May be used to find only matching records from another entity.
        public static DataTable SearchRecords(string entity0, string entity1, string linkingEntity, string attribute, string entity0Field, string entity1Field, bool searchAllFields, List<int> selectedIds, bool exactSearch, bool onlyLinkedRecords, bool allLinkedRecords, bool manyToMany)
        {
            //TODO: ManyToMany searches should search for a match in both ClassId and DogId
            try
            {
                string[] entities = { entity0 };
                InTableColumnWhitelist(entities);
            }
            catch (ArgumentException)
            {
                throw;
            }
            // Mostly prevents 'attribute' from containing SQL injection attacks
            if (attribute != null)
            {
                for (int i = 0; i < attribute.Count(); i++)
                {
                    if (char.IsLetterOrDigit(attribute[i]) == false && (attribute[i] != '@' && attribute[i] != '\'' && attribute[i] != ',') && !(i == 0 && attribute[i] == '-'))
                    {
                        throw new FormatException("Illegal character(s) detected.");
                    }
                }
            }
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                List<List<string>> recordData = new List<List<string>>();
                string[] fieldNames = GetSchemaInfo(entity0, "COLUMNS", "COLUMN_NAME");
                List<int> usedFieldNameIndexes = new List<int>();
                try
                {
                    sqlConnection.Open();
                }
                catch (SqlException) when (sqlConnection.State == ConnectionState.Closed)
                {
                    throw;
                }
                string sqlQuery;
                string[] columnDataTypes = GetSchemaInfo(entity0, "COLUMNS", "DATA_TYPE");
                int parameterCount = 0;
                int idCount = 0;
                int IdStartIndex = 0;
                int IdEndIndex = 0;
                if (entity1 == null && attribute != null) // Non-Linked (only searches entity0)
                {
                    sqlQuery = ($"SELECT * FROM {entity0} WHERE (");
                    if (searchAllFields == false) // Only searches in entity0Field
                    {
                        if (exactSearch == true)
                        {
                            sqlQuery += ($"{entity0Field} = @{entity0Field}"); // Exact match
                        }
                        else
                        {
                            sqlQuery += ($"{entity0Field} LIKE '%' + @{entity0Field} + '%'"); // Contains
                        }
                        sqlQuery += $")";
                    }
                    else // Searches in every field
                    {
                        var tempParameter = ConvertToSQLCompatibleType(attribute);
                        for (int i = 0; i < fieldNames.Count(); i++)
                        {
                            SqlDbType sqlDbType = SetSqlDbType(columnDataTypes[i]);
                            if (sqlDbType.ToString() == "Int" && tempParameter is string) // Skips if tempParameter is string and column is int
                            {
                                continue;
                            }
                            if ((tempParameter is int && sqlDbType.ToString() == "Int") || exactSearch == true)
                            {
                                sqlQuery += $"{fieldNames[i]} = @{fieldNames[i]}#{parameterCount} OR "; // Exact match
                                parameterCount++;
                            }
                            else
                            {
                                sqlQuery += $"{fieldNames[i]} LIKE '%' + @{fieldNames[i]}#{parameterCount} + '%' OR "; // Contains
                                parameterCount++;
                            }
                            usedFieldNameIndexes.Add(i);
                        }
                        sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 4);
                        sqlQuery += $")";
                    }
                }
                else // Linked (searches entity0 and entity1, only returning records in entity0 with matches in entity1)
                {
                    if (manyToMany == true)
                    {
                        entity0Field = entity1 + "Id";
                        entity1Field = entity0 + "Id";
                    }
                    sqlQuery = ($"SELECT * FROM {entity0} WHERE ");
                    string tempEntityField = manyToMany == true ? entity0 + "Id" : entity1Field;
                    string tempEntity = manyToMany == true ? linkingEntity : entity1;
                    sqlQuery += $"({tempEntityField} IN (SELECT {tempEntityField} FROM {tempEntity} "; //FROM {entity1} //entity0Field / linkingEntity
                    if (selectedIds != null && selectedIds.Count > 0 && allLinkedRecords == false)
                    {
                        sqlQuery += $"WHERE ";
                        IdStartIndex = parameterCount;
                        sqlQuery += $"(";
                        if (fieldNames != null && fieldNames.Count() > 0 && manyToMany == false)
                        {
                            sqlQuery += $"(";
                        }
                        //TODO: Flip entityField used if the one before it was the same if manyToMany == true
                        for (int i = 0; i < selectedIds.Count(); i++) // SelectedIds
                        {
                            sqlQuery += $"{entity0Field} = @{entity0Field}#{parameterCount} OR "; // Exact match
                            parameterCount++;
                            idCount++;
                        }
                        IdEndIndex = parameterCount;
                        sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 4);
                    }
                    else
                    {
                        //sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 1);
                    }
                    if (attribute != null)// && allLinkedRecords == true) //else //fieldNames != null && fieldNames.Count() > 0
                    {
                        if (selectedIds != null && selectedIds.Count > 0)
                        {
                            sqlQuery += $") AND ";
                        }
                        else
                        {
                            sqlQuery += $"WHERE ";
                        }
                        sqlQuery += $"(";
                        if (fieldNames != null && fieldNames.Count() > 0)
                        {
                            var tempParamameter = ConvertToSQLCompatibleType(attribute);
                            for (int i = 0; i < fieldNames.Count(); i++) // FieldNames
                            {
                                SqlDbType sqlDbType = SetSqlDbType(columnDataTypes[i]);
                                if (!(sqlDbType.ToString() == "Int" && tempParamameter is string))
                                {
                                    if (exactSearch == false && fieldNames[i] != entity0Field && sqlDbType.ToString() == "NVarChar")
                                    {
                                        sqlQuery += $"{fieldNames[i]} LIKE '%' + @{fieldNames[i]}#{parameterCount} + '%' OR "; // Contains
                                        parameterCount++;
                                    }
                                    else
                                    {
                                        sqlQuery += $"{fieldNames[i]} = @{fieldNames[i]}#{parameterCount} OR "; // Exact match
                                        parameterCount++;
                                    }
                                    usedFieldNameIndexes.Add(i);
                                }
                            }
                            sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 4);
                        }
                    }
                    sqlQuery = sqlQuery.Trim(' ');
                    int bracketOpenCount = 0;
                    int bracketCloseCount = 0;
                    foreach (char c in sqlQuery)
                    {
                        if (c == '(')
                        {
                            bracketOpenCount++;
                        }
                        else if (c == ')')
                        {
                            bracketCloseCount++;
                        }
                    }
                    if (bracketOpenCount > bracketCloseCount)
                    {
                        int bracketDifference = bracketOpenCount - bracketCloseCount;
                        for (int i = 0; i < bracketDifference; i++)
                        {
                            sqlQuery += $")";
                        }
                    }
                }
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    if (selectedIds != null && selectedIds.Count > 0)
                    {
                        for (int i = 0; i < parameterCount; i++) // SelectedId's //int i = IdStartIndex; i < IdEndIndex; i++
                        {
                            if (i >= IdStartIndex && i < IdEndIndex)
                            {
                                SqlDbType sqlDbType = SetSqlDbType(columnDataTypes[i]);
                                sqlCommand.Parameters.Add($"{entity0Field}#{i}", sqlDbType).Value = $"{selectedIds[i]}"; //{entity1Field}
                            }
                        }
                    }
                    if (searchAllFields == true && usedFieldNameIndexes != null && usedFieldNameIndexes.Count > 0)
                    {
                        var parameter = ConvertToSQLCompatibleType(attribute);
                        for (int i = 0; i < parameterCount; i++)
                        {
                            if ((i < IdStartIndex && i <= IdEndIndex) || (i > IdStartIndex && i >= IdEndIndex) || idCount == 0)
                            {
                                SqlDbType sqlDbType = SetSqlDbType(columnDataTypes[usedFieldNameIndexes[i - idCount]]);
                                sqlCommand.Parameters.Add($"{fieldNames[usedFieldNameIndexes[i - idCount]]}#{i}", sqlDbType).Value = parameter;
                            }
                        }
                    }
                    else if (attribute != null)
                    {
                        int fieldIndex = 0;
                        var parameter = ConvertToSQLCompatibleType(attribute);
                        for (int i = 0; i < fieldNames.Count(); i++)
                        {
                            if (fieldNames[i] == entity0Field) //entity0Field
                            {
                                fieldIndex = i;
                                break;
                            }
                        }
                        SqlDbType sqlDbType = SetSqlDbType(columnDataTypes[fieldIndex]);
                        sqlCommand.Parameters.Add($"{entity0Field}", sqlDbType).Value = $"{parameter}";
                    }
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                        DataTable dataTable = new DataTable();
                        try
                        {
                            sqlDataAdapter.Fill(dataTable);
                        }
                        catch (Exception)
                        {
                            return null;
                        }
                        sqlConnection.Close();
                        return dataTable;
                    }
                }
            }
        }

        // Gets all field values and field names of a record using a join
        private static DataTable EntityJoin(string entity0, string entity1, string entity0Field, string entity1Field, string joinType)
        {
            try
            {
                string[] entities = { entity0, entity1, entity0Field, entity1Field };
                InTableColumnWhitelist(entities);
            }
            catch (ArgumentException)
            {
                throw;
            }
            if (entity1Field == null)
            {
                entity1Field = entity0Field;
            }
            joinType = joinType.ToUpper();
            if (joinType == "INNER" || joinType == "LEFT" || joinType == "RIGHT" || joinType == "FULL")
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConnection.Open();
                    }
                    catch (SqlException) when (sqlConnection.State == ConnectionState.Closed)
                    {
                        throw;
                    }
                    string sqlQuery = sqlQuery = ($"SELECT * FROM {entity0} {joinType} JOIN {entity1} ON {entity0}.{entity0Field}={entity1}.{entity1Field}");
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                            DataTable dataTable = new DataTable();
                            sqlDataAdapter.Fill(dataTable);
                            sqlConnection.Close();
                            return dataTable;
                        }
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public static int Count(string entity, string[] fieldNamesToCount, string[] parameterValues, bool countAllRecords)
        {
            try
            {
                string[] entities = { entity };
                InTableColumnWhitelist(entities);
            }
            catch (ArgumentException)
            {
                throw;
            }
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (SqlException) when (sqlConnection.State == ConnectionState.Closed)
                {
                    throw;
                }
                int count = 0;
                int parameterCount = 0;
                string sqlQuery;
                string[] fieldNames = GetSchemaInfo(entity, "COLUMNS", "COLUMN_NAME");
                string[] columnDataTypes = GetSchemaInfo(entity, "COLUMNS", "DATA_TYPE");
                sqlQuery = $"SELECT COUNT(*) FROM {entity} WHERE (";
                if (countAllRecords == false)
                {
                    for (int i = 0; i < fieldNamesToCount.Count(); i++)
                    {
                        sqlQuery += $"{fieldNamesToCount[i]} = @{parameterValues[i]}#{parameterCount} AND ";
                        parameterCount++;
                    }
                    sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 5);
                    sqlQuery += $")";
                }
                else
                {
                    sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 8);
                }
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    if (countAllRecords == false)
                    {
                        for (int i = 0; i < parameterCount; i++)
                        {
                            SqlDbType sqlDbType = new SqlDbType();
                            for (int j = 0; i < fieldNames.Count(); j++)
                            {
                                if (fieldNamesToCount[i] == fieldNames[j])
                                {
                                    sqlDbType = SetSqlDbType(columnDataTypes[j]);
                                    break;
                                }
                            }
                            var parameter = ConvertToSQLCompatibleType(parameterValues[i]);
                            sqlCommand.Parameters.Add($"{parameterValues[i]}#{i}", sqlDbType).Value = parameter; //Move into above for-loop?
                        }
                    }
                    count = Convert.ToInt16(sqlCommand.ExecuteScalar()); //Convert.ToInt16(sqlCommand.ExecuteScalar())
                }
                return count;
            }
        }

        public static string[,] DataTableToStringArray(DataTable dataTable)
        {
            string[,] records = new string[dataTable.Rows.Count, dataTable.Columns.Count];
            for (int i = 0; i < records.GetLength(0); i++)
            {
                for (int o = 0; o < records.GetLength(1); o++)
                {
                    records[i, o] = Convert.ToString(dataTable.Rows[i][o]);
                }
            }
            return records;
        }

        public static string[] GetSchemaInfo(string entity, string schemaType, string type)
        {
            try
            {
                string[] entities = { entity };
                InTableColumnWhitelist(entities);
            }
            catch (ArgumentException)
            {
                throw;
            }
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                List<string> tempResults = new List<string>();
                string[] results;
                try
                {
                    sqlConnection.Open();
                }
                catch (SqlException) when (sqlConnection.State == ConnectionState.Closed)
                {
                    throw;
                }
                string sqlQuery = ($"SELECT {type} FROM INFORMATION_SCHEMA.{schemaType} WHERE TABLE_NAME = N'{entity}'");
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        for (int i = 0; i <= sqlDataReader.FieldCount - 1; i++)
                        {
                            tempResults.Add(sqlDataReader.GetString(i));
                        }
                    }
                }
                sqlConnection.Close();
                results = new string[tempResults.Count];
                tempResults.CopyTo(results);
                return results;
            }
        }

        private static SqlDbType SetSqlDbType(string dataType)
        {
            SqlDbType sqlDbType = SqlDbType.Bit;
            if (dataType == "bigint") { sqlDbType = SqlDbType.BigInt; }
            else if (dataType == "binary") { sqlDbType = SqlDbType.Binary; }
            else if (dataType == "bit") { sqlDbType = SqlDbType.Bit; }
            else if (dataType == "char") { sqlDbType = SqlDbType.Char; }
            else if (dataType == "date") { sqlDbType = SqlDbType.Date; }
            else if (dataType == "datetime") { sqlDbType = SqlDbType.DateTime; }
            else if (dataType == "datetime2") { sqlDbType = SqlDbType.DateTime2; }
            else if (dataType == "datetimeoffset") { sqlDbType = SqlDbType.DateTimeOffset; }
            else if (dataType == "decimal") { sqlDbType = SqlDbType.Decimal; }
            else if (dataType == "float") { sqlDbType = SqlDbType.Float; }
            else if (dataType == "image") { sqlDbType = SqlDbType.Image; }
            else if (dataType == "int") { sqlDbType = SqlDbType.Int; }
            else if (dataType == "money") { sqlDbType = SqlDbType.Money; }
            else if (dataType == "nchar") { sqlDbType = SqlDbType.NChar; }
            else if (dataType == "ntext") { sqlDbType = SqlDbType.NText; }
            else if (dataType == "nvarchar") { sqlDbType = SqlDbType.NVarChar; }
            else if (dataType == "real") { sqlDbType = SqlDbType.Real; }
            else if (dataType == "smalldatetime") { sqlDbType = SqlDbType.SmallDateTime; }
            else if (dataType == "smallint") { sqlDbType = SqlDbType.SmallInt; }
            else if (dataType == "smallmoney") { sqlDbType = SqlDbType.SmallMoney; }
            else if (dataType == "structured") { sqlDbType = SqlDbType.Structured; }
            else if (dataType == "text") { sqlDbType = SqlDbType.Text; }
            else if (dataType == "time") { sqlDbType = SqlDbType.Time; }
            else if (dataType == "timestamp") { sqlDbType = SqlDbType.Timestamp; }
            else if (dataType == "tinyint") { sqlDbType = SqlDbType.TinyInt; }
            else if (dataType == "udt") { sqlDbType = SqlDbType.Udt; }
            else if (dataType == "uniqueidentifier") { sqlDbType = SqlDbType.UniqueIdentifier; }
            else if (dataType == "varbinary") { sqlDbType = SqlDbType.VarBinary; }
            else if (dataType == "varchar") { sqlDbType = SqlDbType.VarChar; }
            else if (dataType == "variant") { sqlDbType = SqlDbType.Variant; }
            else if (dataType == "xml") { sqlDbType = SqlDbType.Xml; }
            return sqlDbType;
        }

        private static dynamic ConvertToSQLCompatibleType(string param)
        {
            /*if (param.GetType() == typeof(int)) { return Convert.ToInt32(obj); }
            else if (param.GetType() == typeof(string)) { return Convert.ToString(obj); }*/
            foreach (char c in param)
            {
                if (!char.IsDigit(c))
                {
                    return param;
                }
            }
            int result;
            if (int.TryParse(param, out result) == true)
            {
                return result;
            }
            return param;
        }

        // Checks whether a table or column name is whitelisted, to prevent SQL injection attacks
        private static void InTableColumnWhitelist(string[] entities)
        {
            for (int i = 0; i < entities.Count(); i++)
            {
                if (entities[i] != null)
                {
                    // Checks whether the parameter is a whitelisted table
                    string exceptionMessage = "No such entity exists";
                    if (entities[i] == "Dog") { return; }
                    else if (entities[i] == "Customer") { return; }
                    else if (entities[i] == "Session") { return; }
                    else if (entities[i] == "SessionTrainer") { return; }
                    else if (entities[i] == "ClassTrainer") { return; }
                    else if (entities[i] == "ClassDog") { return; }
                    else if (entities[i] == "WaitingDog") { return; }
                    else if (entities[i] == "Programme") { return; }
                    else if (entities[i] == "Class") { return; }
                    else if (entities[i] == "Customer") { return; }
                    else if (entities[i] == "Trainer") { return; }
                    else if (entities[i] == "PaymentType") { return; }
                    else if (entities[i] == "Payment") { return; }
                    else if (entities[i] == "Waiting") { return; }

                    // Checks whether the parameter is a whitelisted ID column
                    exceptionMessage = "No such ID field exists";
                    if (entities[i] == "DogId") { return; }
                    else if (entities[i] == "CustomerId") { return; }
                    else if (entities[i] == "SessionId") { return; }
                    else if (entities[i] == "SessionTrainerId") { return; }
                    else if (entities[i] == "ClassTrainerId") { return; }
                    else if (entities[i] == "ClassDogId") { return; }
                    else if (entities[i] == "WaitingDogId") { return; }
                    else if (entities[i] == "ProgrammeId") { return; }
                    else if (entities[i] == "ClassId") { return; }
                    else if (entities[i] == "CustomerId") { return; }
                    else if (entities[i] == "TrainerId") { return; }
                    else if (entities[i] == "PaymentTypeId") { return; }
                    else if (entities[i] == "PaymentId") { return; }
                    else if (entities[i] == "WaitingId") { return; }
                    else { throw new ArgumentException(exceptionMessage, entities[i]); }
                }
            }
        }
    }
}
