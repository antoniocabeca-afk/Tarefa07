using System;
using System.Data.SqlClient;
using BCrypt.Net;

class Program
{
    static void Main(string[] args)
    {
        // ---------------  REGISTO DO UTILIZADOR -----------------
        string password = "Sporting_1906";
        string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
        string saltedPassword = password + salt;
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(saltedPassword);

        Console.WriteLine("Password codificada: " + hashedPassword);
        Console.WriteLine("Salt: " + salt);
        Console.WriteLine("");

        // --------------- GUARDAR NA BASE DE DADOS -----------------

        string connectionString = "Server=ANTÓNIO_CABEÇA\\SQLEXPRESS;Database=Tarefa04;Trusted_Connection=True;";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = "INSERT INTO Users (Username, PasswordHash, Salt) VALUES (@u, @p, @s)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@u", "Antonio");
                cmd.Parameters.AddWithValue("@p", hashedPassword);
                cmd.Parameters.AddWithValue("@s", salt);

                cmd.ExecuteNonQuery();
            }
        }

        Console.WriteLine(" Dados guardados com sucesso!\n\n");

        // --------------- VERIFICAÇÃO DA PASSWORD NO LOGIN -----------------

        Console.Write(" ADIVINHE A PASSWORD: ");
        string xptopassword = Console.ReadLine();

       
        string storedSalt = salt; 
        string storedHash = hashedPassword; 
        string saltedInputPassword = xptopassword + storedSalt; 

       if (BCrypt.Net.BCrypt.Verify(saltedInputPassword, storedHash))
        {
            Console.WriteLine(" Login com sucesso!");
        }
        else
        {
            Console.WriteLine(" Password inválida!");
        }
    }
}
