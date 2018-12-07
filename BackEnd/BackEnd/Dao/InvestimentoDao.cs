using BackEnd.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dao
{
    public class InvestimentoDao 
    {
<<<<<<< HEAD
=======
        public Double ValorInvestido(int id_conta)
        {
            Double valor = 0;
            Conexao conexao = new Conexao();
            try
            {
   
    

    

    

               
                //conexao.Comando.CommandText = comando;
                //conexao.Comando.Parameters.AddWithValue("@id", id_conta);
                //MySqlDataReader reader = conexao.Comando.ExecuteReader();
                //if (reader.HasRows)
                //{
                //    reader.Read();
                //    valor = Convert.ToDouble(reader["valor"]);
                //}
                //return valor;
            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e);
                return valor;
            }
            finally
            {
                conexao.Fechar();
            }
            return valor;
        }

        public double ValorInvestido(int id_conta, int id_tipo_investimento) 
        { 
            Conexao conexao = new Conexao();
            try
            {
                string comand = "SELECT SUM(valor) FROM investimento WHERE tipo_investimento_id = @tipo_id AND conta_id = @conta_id;";

                conexao.Comando.CommandText = comand;
                conexao.Comando.Parameters.AddWithValue("@tipo_id", id_tipo_investimento);
                conexao.Comando.Parameters.AddWithValue("@conta_id", id_conta);

                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    double total = Convert.ToDouble(reader["SUM(valor)"]);
                    return total;
                }
                else
                {
                    return 0;
                }
                return total;
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return 0;
            }
            finally
            {
                conexao.Fechar();
            }
        }
        
        public bool AlterarResgatar(int id, double valor)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comando = "update investimento set valor = valor - @valor where id = @id;";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@valor", valor);
                conexao.Comando.Parameters.AddWithValue("@id", id);
                if (conexao.Comando.ExecuteNonQuery() > 0)
                {

                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
            finally
            {
                conexao.Fechar();
            }
        }

        public bool  AlterarAplicar(int id, double valor)
        {
            Conexao conexao = new Conexao();
            
            try
            {
                string comando = "update investimento set data_aplicacao = now(), valor = valor + @valor where id = @id;";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@valor", valor);
                conexao.Comando.Parameters.AddWithValue("@id", id); 
                if (conexao.Comando.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e )
            {

                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
            finally
            {
                conexao.Fechar();
            }
            

        }
>>>>>>> d293b6c750f2bc79f89a92814ed0c9ad89eb915d

        public Investimento BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Investimento Deletar(Investimento t)
        {
            throw new NotImplementedException();
        }

        public Investimento Inserir(Investimento t)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comand = "INSERT INTO investimento(data_aplicacao, valor,status,  tipo_investimento_id,  conta_id) VALUES (now(), @valor,@status, @tipo_investimento, @conta_id);";

                conexao.Comando.CommandText = comand;
                conexao.Comando.Parameters.AddWithValue("@valor", t.Valor);
                conexao.Comando.Parameters.AddWithValue("@status", false);
                conexao.Comando.Parameters.AddWithValue("@tipo_investimento", t.TipoInvestimento.Id_tipo_investimento);
                conexao.Comando.Parameters.AddWithValue("@conta_id", t.Conta.Id);

                if (conexao.Comando.ExecuteNonQuery() > 0)
                {
                    t.Id = Convert.ToInt32(conexao.Comando.LastInsertedId.ToString());
                    return t;
                }
                return null;
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            finally
            {
                conexao.Fechar();
            }
            return null;
        }
       
        public List<Investimento> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
