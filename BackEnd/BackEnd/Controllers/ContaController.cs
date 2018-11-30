
using BackEnd.Dao;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController 
    {
      
        public DebitoAutomatico Alterar(DebitoAutomatico t)
        {
            throw new NotImplementedException();
        }

        public DebitoAutomatico BuscarPonrId(int id)
        {
            throw new NotImplementedException();
        }

        public string Deletar(int t)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comando = "delete from conta_cadastrada where id = @id";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id", t);
                if (conexao.Comando.ExecuteNonQuery() > 0)
                {
                    return "sucesso";
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException e)
            {

                return null;
            }
            finally
            {
                conexao.Fechar();
            }
        }

        public string Inserir(DebitoAutomatico t)
        {
            Conexao conecxao = new Conexao();
            try
            {
                string sql = "insert into conta_cadastrada (  id_conta, descricao, numero_conta ) values ( @id_conta, @descricao,  @numero);";
                conecxao.Comando.CommandText = sql;
                conecxao.Comando.Parameters.AddWithValue("@id_conta", t.Conta.Id);
                conecxao.Comando.Parameters.AddWithValue("@descricao", t.Descricao);
                conecxao.Comando.Parameters.AddWithValue("@numero", t.Codigo);

                if (conecxao.Comando.ExecuteNonQuery() > 0)
                {


                    return "sucesso";
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                return null;
            }
            finally
            {
                conecxao.Fechar();
            }
        }

        public List<DebitoAutomatico> ListarToDos()
        {
            Conexao conecxao = new Conexao();
            try
            {

                List<Models.DebitoAutomatico> contas = new List<Models.DebitoAutomatico> { };


                string comando = "select * from conta_cadastrada ;";
                conecxao.Comando.CommandText = comando;
                MySqlDataReader reader = conecxao.Comando.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        DebitoAutomatico t = new Models.DebitoAutomatico
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            //Conta = Convert.ToInt32(reader["id_conta"]),
                            Descricao = reader["descricao"].ToString(),
                            Codigo = Convert.ToInt32(reader["codigo"])
                        };
                        contas.Add(t);
                    }

                }
                return contas;

            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                conecxao.Fechar();
            }
        }

        // GET popular
        [HttpGet]
        public IEnumerable<Models.DebitoAutomatico> Get()
        {
            return ListarToDos();
        }

        //adiciona dado
        [HttpPost]
        public Bool Post([FromBody] Models.DebitoAutomatico conta)
        {
            Bool b = new Bool();
            string s = Inserir(conta);
            if (s.Equals("sucesso"))
                b.boolean = true;
            else
                b.boolean = false;
            return b;
            
            
        }
        //delete 
        [HttpDelete("{id:int}")]
        public Bool Delet(Int32 id)
        {
            Bool b = new Bool();
            string s = Deletar(id);
            if (s.Equals("sucesso"))
                b.boolean = true;
            else
                b.boolean = false;
            return b;
        }
    }
}
