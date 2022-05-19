using kursovay.DTO;
using kursovay.Tools;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovay.Model
{
    public class SqlModel
    {
        private SqlModel() { }
        static SqlModel sqlModel;
        public static SqlModel GetInstance()
        {
            if (sqlModel == null)
                sqlModel = new SqlModel();
            return sqlModel;

        }
        public int Insert<T>(T value)
        {
            string table;
            List<MetaValue> values;
            GetMetaData(value, out table, out values);
            var query = CreateInsertQuery(table, values);
            var db = MySqlDB.GetDB();
            // лучше эти 2 запроса объединить в один с помощью транзакции
            if (value is Postavki)
            {
                db.ExecuteNonQuery(query.Item1, query.Item2);
                return 0;
            }
            int id = db.GetNextID(table);
            db.ExecuteNonQuery(query.Item1, query.Item2);
            return id;
        }

        

        // обновляет объект в бд по его id
        public void Update<T>(T value) where T : BaseDTO
        {
            string table;
            List<MetaValue> values;
            GetMetaData(value, out table, out values);
            var query = CreateUpdateQuery(table, values, value.ID);
            var db = MySqlDB.GetDB();
            db.ExecuteNonQuery(query.Item1, query.Item2);
        }

        public void Delete<T>(T value) where T : BaseDTO
        {
            var type = value.GetType();
            string table = GetTableName(type);
            var db = MySqlDB.GetDB();
            string query = $"delete from `{table}` where id = {value.ID}";
            db.ExecuteNonQuery(query);
        }

        public int GetNumRows(Type type)
        {
            string table = GetTableName(type);
            return MySqlDB.GetDB().GetRowsCount(table);
        }

        private static string GetTableName(Type type)
        {
            var tableAtrributes = type.GetCustomAttributes(typeof(TableAttribute), false);
            return ((TableAttribute)tableAtrributes.First()).Table;
        }


        public List<Vrach> VrachSelect(int skip, int count)
        {
            var vrachs = new List<Vrach>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `vrach` LIMIT {skip},{count}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vrachs.Add(new Vrach
                        {
                            ID = dr.GetInt32("id"),
                            Name = dr.GetString("Name"),
                            LastName = dr.GetString("LastName"),
                            gender = dr.GetString("gender"),
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return vrachs;
        }

        public List<Reagent> ReagentSelect(int skip, int count)
        {
            var reagents = new List<Reagent>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `reagents` LIMIT {skip},{count}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        reagents.Add(new Reagent
                        {
                            ID = dr.GetInt32("id"),
                            Name = dr.GetString("Name"),
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return reagents;
        }
        public List<Postavshik> PostavshickSelect(int skip, int count)
        {
            var postavshiks = new List<Postavshik>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `postavshik` LIMIT {skip},{count}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        postavshiks.Add(new Postavshik
                        {
                            ID = dr.GetInt32("id"),
                            Name = dr.GetString("Name"),
                            
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return postavshiks;
        }


        public List<Kab> SelectKabs()
        {
            var kabs = new List<Kab>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `kab` LIMIT ";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        kabs.Add(new Kab
                        {
                            ID = dr.GetInt32("id"),
                            Nomer = dr.GetString("title"),
                            
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return kabs;
        }

       

        public List<Vrach> SelectVrachs()

        {
            var vrachs = new List<Vrach>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `vrach`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vrachs.Add(new Vrach
                        {
                            ID = dr.GetInt32("id"),
                            Name = dr.GetString("Name")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }

            return vrachs;
        }
        public List<Personal> SelectPersonals()

        {
            var personals = new List<Personal>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `personal` ";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        personals.Add(new Personal
                        {
                            ID = dr.GetInt32("id"),
                            Name = dr.GetString("Name"),
                            LastName = dr.GetString("LastName"),
                            gender = dr.GetString("gender"),

                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return personals;
        }

        public List<Postavshik> SelectPostavshiks()
        {
                var postavshiks = new List<Postavshik>();
                var mySqlDB = MySqlDB.GetDB();
                string query = $"SELECT * FROM `postavshik`";
                if (mySqlDB.OpenConnection())
                {
                    using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                    using (MySqlDataReader dr = mc.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            postavshiks.Add(new Postavshik
                            {
                                ID = dr.GetInt32("id"),
                                Name = dr.GetString("Name"),
                            });
                        }
                    }
                    mySqlDB.CloseConnection();
                }
                return postavshiks;
        }

        public List<Reagent> SelectReagents()
        {
            var reagents = new List<Reagent>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `reagents`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        reagents.Add(new Reagent
                        {
                            ID = dr.GetInt32("id"),
                            Name = dr.GetString("Name"),
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return reagents;
        }

        public List<PostavkiWithData> SelectPostavkiByVrach(Vrach selectVrachView)
            
            {
            int id = selectVrachView?.ID ?? 0;
            var result = new List<PostavkiWithData>();
                var mySqlDB = MySqlDB.GetDB();
                string query = $"SELECT idPostavshik, idreagents, r.Name as 'rname', p.Name as 'pname' FROM `postavka reagentov` LEFT JOIN reagents r ON idreagents = r.id left join postavshik p on idpostavshik = p.id where idvrach = " + selectVrachView.ID;
                if (mySqlDB.OpenConnection())
                {
                    using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                    using (MySqlDataReader dr = mc.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                        result.Add(new PostavkiWithData
                        {
                            Reagent = new Reagent { ID = dr.GetInt32("idreagents"), Name = dr.GetString("rname") },
                            Postavshik = new Postavshik { ID = dr.GetInt32("idPostavshik"), Name = dr.GetString("pname") },
                            Vrach = selectVrachView
                        }); ;
                        }
                    }
                    mySqlDB.CloseConnection();
                }
                return result;
            }

        public List<Reagent> SelectReagentsByPostavshiks(Postavshik postavshik)
        {
            var result = new List<Reagent>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `postavka reagentov` LEFT JOIN reagents r ON idreagents = r.id AND idpostavshik = " + postavshik.ID;
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.Add(new Reagent
                        {
                            ID = dr.GetInt32("id"),
                            Name = dr.GetString("Name"),
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return result;
        }

        
        private static (string, MySqlParameter[]) CreateInsertQuery(string table, List<MetaValue> values)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"INSERT INTO `{table}` set ");
            List<MySqlParameter> parameters = InitParameters(values, stringBuilder);
            return (stringBuilder.ToString(), parameters.ToArray());
        }

        private static (string, MySqlParameter[]) CreateUpdateQuery(string table, List<MetaValue> values, int id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"UPDATE `{table}` set ");
            List<MySqlParameter> parameters = InitParameters(values, stringBuilder);
            stringBuilder.Append($" WHERE id = {id}");
            return (stringBuilder.ToString(), parameters.ToArray());
        }

        private static List<MySqlParameter> InitParameters(List<MetaValue> values, StringBuilder stringBuilder)
        {
            var parameters = new List<MySqlParameter>();
            int count = 1;
            var rows = values.Select(s =>
            {
                parameters.Add(new MySqlParameter($"p{count}", s.Value));
                return $"{s.Name} = @p{count++}";
            });
            stringBuilder.Append(string.Join(",", rows));
            return parameters;
        }

        private static void GetMetaData<T>(T value, out string table, out List<MetaValue> values)
        {
            var type = value.GetType();
            var tableAtrributes = type.GetCustomAttributes(typeof(TableAttribute), false);
            table = ((TableAttribute)tableAtrributes.First()).Table;
            values = new List<MetaValue>();
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                var columnAttributes = prop.GetCustomAttributes(typeof(ColumnAttribute), false);
                if (columnAttributes.Length > 0)
                {
                    string column = ((ColumnAttribute)columnAttributes.First()).Column;
                    values.Add(new MetaValue { Name = column, Value = prop.GetValue(value) });
                }
            }
        }

        class MetaValue
        { 
            public string Name { get; set; }
            public object Value { get; set; }
        }
    }
}