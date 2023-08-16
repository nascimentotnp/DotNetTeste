using DotNetTestetec.Modal;

namespace DotNetTestetec.DAL;
using System.Data;
using MySql.Data.MySqlClient;
public class ClienteDataAccess
{
    public static string conString = @"server=localhost; port=3306; user=root; password=root; database=testefullstack";
    public static List<Cliente> GetAllUsers()
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
                    Clienteid = Guid.Parse(row["clienteid"].ToString()),      
                    username = row["username"].ToString(),
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

            Guid novoClienteId = Guid.NewGuid();

            string query = $"SELECT COUNT(*) FROM clientes WHERE clienteid = @ClienteId";
            using (MySqlCommand command = new MySqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@ClienteId", novoClienteId);
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count == 0)
                {
                    string insertQuery = $"insert into clientes(clienteid, username) values('{novoClienteId}', '{Cliente.username}')";
                    MySqlCommand insertCommand = new MySqlCommand(insertQuery, con);
                    insertCommand.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("GUID já existe, gerando novo GUID...");
                }
            }
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
            string query = "delete from clientes where id =" + id;
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
            string query = $"update clientes set username='{cliente.username}' where id={id}";
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