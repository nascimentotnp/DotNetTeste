using DotNetTestetec.Modal;

namespace DotNetTestetec.DAL;
using System.Data;
using MySql.Data.MySqlClient;
public class ClienteDataAccess
{
    public static string conString = @"server=localhost; port=3306; Cliente=root; password=root; database=Clienteinfo";
    public static List<Cliente> GetAllUsers()
    {
        List<Cliente> allNotes = new List<Cliente>();
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            string query = "select * from Clientes";
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
                    Clienteid = Guid.Parse(row["clienteid"].ToString()),      
                    username = row["Clientename"].ToString(),
                    
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
    public static void SaveNewUser(Cliente Cliente)
    {
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = $"insert into Clientes(username) values('{Cliente.username}')";
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
    public static void DeleteUserById(int id)
    {
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = "delete from clientes where clienteid =" + id;
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
    public static void UpdateUser(int id, Cliente cliente)
    {
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = $"update clientes set username='{cliente.username}' where clienteid={id}";
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
}