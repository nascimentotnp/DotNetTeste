using DotNetTestetec.Modal;

namespace DotNetTestetec.DAL;
using System.Data;
using MySql.Data.MySqlClient;
public class ClienteDataAccess
{
    public static string conString = @"server=localhost; port=3306; user=root; password=root; database=testefullstack";
    public static List<Cliente> GetAllCliente()
    {
        List<Cliente> allNotes = new List<Cliente>();
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            string query = "select * from clientes";
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;
            foreach (DataRow row in rows)
            {
                Cliente Cliente = new Cliente
                {
                    id = Guid.Parse(row["clienteid"].ToString()),      
                    username = row["username"].ToString(),
                    email = row["email"].ToString(),
                    phone = row["fone"].ToString(),

                };
                allNotes.Add(Cliente);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return allNotes;
    }
    public static List<Cliente> GetOneCliente(Guid id)
    {
        List<Cliente> allNotes = new List<Cliente>();
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            string query = $"select * from clientes where clienteid ='{id}'";
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;
            foreach (DataRow row in rows)
            {
                Cliente Cliente = new Cliente
                {
                    id = Guid.Parse(row["clienteid"].ToString()),      
                    username = row["username"].ToString(),
                    email = row["email"].ToString(),
                    phone = row["fone"].ToString(),
                };
                allNotes.Add(Cliente);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return allNotes;
    }
    public static void SaveNewCliente(Cliente cliente)
    {
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();

            Guid novoClienteId = Guid.NewGuid();

            string insertQuery = $"insert into clientes(clienteid, username, fone, email) values('{novoClienteId}'," +
                                 $"'{cliente.username}','{cliente.phone}','{cliente.email}')";
            MySqlCommand insertCommand = new MySqlCommand(insertQuery, con);
            insertCommand.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public static void DeleteClienteById(Guid id)
    {
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = $"delete from clientes where clienteid ='{id}'";
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }
    public static void UpdateCliente(Guid id, Cliente cliente)
    {
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
        
            string query = "update clientes set ";
            List<string> updateFields = new List<string>();
        
            if (!string.IsNullOrEmpty(cliente.username))
            {
                updateFields.Add($"username=@Username");
            }

            if (!string.IsNullOrEmpty(cliente.email))
            {
                updateFields.Add($"email=@Email");
            }

            if (!string.IsNullOrEmpty(cliente.phone))
            {
                updateFields.Add($"fone=@Phone");
            }

            query += string.Join(", ", updateFields);
            query += $" where clienteid=@Id";
        
            MySqlCommand command = new MySqlCommand(query, con);

            command.Parameters.AddWithValue("@Id", id);
        
            if (!string.IsNullOrEmpty(cliente.username))
            {
                command.Parameters.AddWithValue("@Username", cliente.username);
            }

            if (!string.IsNullOrEmpty(cliente.email))
            {
                command.Parameters.AddWithValue("@Email", cliente.email);
            }

            if (!string.IsNullOrEmpty(cliente.phone))
            {
                command.Parameters.AddWithValue("@Phone", cliente.phone);
            }

            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

}