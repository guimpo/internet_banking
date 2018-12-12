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

        public double ValorInvestido(int id_conta, int id_tipo_investimento) 
        { 
            Conexao conexao = new Conexao();
            try
            {
                string comand = "SELECT SUM(valor) FROM investimento WHERE tipo_investimento_id = @tipo_id AND conta_id = @conta_id AND status = false;";

                conexao.Comando.CommandText = comand;
                conexao.Comando.Parameters.AddWithValue("@tipo_id", id_tipo_investimento);
                conexao.Comando.Parameters.AddWithValue("@conta_id", id_conta);

                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    double total;
                    reader.Read();
                    Object value = reader["SUM(valor)"];

                    if(value != DBNull.Value)
                    {
                        total = Convert.ToDouble(reader["SUM(valor)"]);
                    } else
                    {
                        return 0;
                    }
                    return total;
                }
                else
                {
                    return 0;
                }
                
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

        public void Bloqueia()
        {
            Conexao conexao = new Conexao();
            try
            {
                string comand = "UPDATE investimento SET status = true WHERE conta_id = 7 AND tipo_investimento_id = 1";

                conexao.Comando.CommandText = comand;
                conexao.Comando.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            finally
            {
                conexao.Fechar();
            }
        }
    }
}
