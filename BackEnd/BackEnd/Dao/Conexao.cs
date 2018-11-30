using MySql.Data.MySqlClient;


namespace BackEnd.Dao
{
    public class Conexao
    {
        public MySqlConnection Con { get; set; }
        public MySqlCommand Comando { get; set; }

        public Conexao()
        {
            string strCon = "Server=localhost;database=banco;Uid=root;Pwd=''";
            Con = new MySqlConnection(strCon);
            Comando = Con.CreateCommand();
            Con.Open();

        }

        public void Fechar()
        {
            Con.Close();
        }
    }
}
