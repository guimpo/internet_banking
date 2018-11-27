
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
      
        public ContaCadastro Alterar(ContaCadastro t)
        {
            throw new NotImplementedException();
        }

        public ContaCadastro BuscarPonrId(int id)
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

        public ContaCadastro Inserir(ContaCadastro t)
        {
            Conexao conecxao = new Conexao();
            try
            {
                string sql = "insert into conta_cadastrada (  id_conta, descricao, numero_conta ) values ( @id_conta, @descricao,  @numero);";
                conecxao.Comando.CommandText = sql;
                conecxao.Comando.Parameters.AddWithValue("@id_conta", t.id_conta);
                conecxao.Comando.Parameters.AddWithValue("@descricao", t.descricao);
                conecxao.Comando.Parameters.AddWithValue("@numero", t.codigo);

                if (conecxao.Comando.ExecuteNonQuery() > 0)
                {


                    return t;
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

        public List<ContaCadastro> ListarToDos()
        {
            Conexao conecxao = new Conexao();
            try
            {

                List<Models.ContaCadastro> contas = new List<Models.ContaCadastro> { };


                string comando = "select * from conta_cadastrada ;";
                conecxao.Comando.CommandText = comando;
                MySqlDataReader reader = conecxao.Comando.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        ContaCadastro t = new Models.ContaCadastro
                        {
                            id = Convert.ToInt32(reader["id"]),
                            id_conta = Convert.ToInt32(reader["id_conta"]),
                            descricao = reader["descricao"].ToString(),
                            codigo = reader["numero_conta"].ToString()
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
        public IEnumerable<Models.ContaCadastro> Get()
        {
            return ListarToDos();
        }

        //adiciona dado
        [HttpPost]
        public void Post([FromBody] Models.ContaCadastro conta)
        {

            Inserir(conta);
            
        }
        //delete 
        [HttpDelete("{id:int}")]
        public void Delet(Int32 id)
        {
            Deletar(id);
        }
    }
}
