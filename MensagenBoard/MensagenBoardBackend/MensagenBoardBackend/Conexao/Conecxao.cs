using MySql.Data.MySqlClient;


namespace MensagenBoardBackend.Conexao
{
    public class Conecxao
    {
        public MySqlConnection Con { get; set; }
        public MySqlCommand Comando { get; set; }

        public Conecxao()
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
