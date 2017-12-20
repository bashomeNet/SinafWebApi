using Sinaf.WebApi.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sinaf.WebApi.Repositorio
{
    public class PessoaRepositorio
    {

        public string _connectionString { get; set; }

        public Pessoa pessoa { get; set; }
        public List<Pessoa> listaPessoa { get; set; }

        public PessoaRepositorio(string c)
        {
            pessoa = null;
            listaPessoa = null;
            _connectionString = c;
        }

        public int Incluir()
        {
            try
            {
                //Valida se o objeto está preenchido
                if (pessoa == null)
                {
                    throw new ArgumentNullException("Objeto Telefone não preenchido");
                }

                //bool resultado = false;

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "insert into TreinaWeb.dbo.Pessoa (tppes, nrcgccpf, nmpes, dtcad, dtnas, tpsex) VALUES (@tppes, @nrcgccpf, @nmpes, getdate(), @dtnas, @tpsex)";
                        command.Parameters.AddWithValue("tppes", pessoa.tppes);
                        command.Parameters.AddWithValue("nrcgccpf", pessoa.nrcgccpf);
                        command.Parameters.AddWithValue("nmpes", pessoa.nmpes);
                        command.Parameters.AddWithValue("dtnas", pessoa.dtnas);
                        command.Parameters.AddWithValue("tpsex", pessoa.tpsex);

                        int i = command.ExecuteNonQuery();

                        connection.Close();

                        return i;
                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Deletar(int p_cdpes)
        {
            try
            {
                //Valida se o objeto está preenchido
                if (p_cdpes <= 0)
                {
                    throw new ArgumentNullException("Objeto Telefone não preenchido");
                }

                //bool resultado = false;

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Deleta o Telefone
                        command.CommandText = "delete a from TreinaWeb.dbo.TelefonePessoa a where cdpes = @cdpes";
                        command.Parameters.AddWithValue("cdpes", p_cdpes);
                        command.ExecuteNonQuery();

                        //Deleta a Pessoa
                        command.Parameters.Clear();
                        command.CommandText = "delete a from TreinaWeb.dbo.Pessoa a where cdpes = @cdpes";
                        command.Parameters.AddWithValue("cdpes", p_cdpes);
                        int i = command.ExecuteNonQuery();

                        connection.Close();

                        return i;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public int SelecionarPorId(int p_cdpes)
        {
            try
            {
                //Valida se o objeto está preenchido
                //if (pessoa != null)
                //{
                //    throw new ArgumentNullException("Objeto Telefone não preenchido");
                //}

                //bool resultado = false;

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "select cdpes, tppes, nrcgccpf, nmpes, dtcad, dtnas, tpsex from TreinaWeb.dbo.Pessoa where cdpes = @cdpes";
                        command.Parameters.AddWithValue("cdpes", p_cdpes);

                        pessoa = null;

                        SqlDataReader reader = command.ExecuteReader();

                        int i = 0;

                        while (reader.Read())
                        {


                            pessoa = new Pessoa()
                            {
                                cdpes = reader["cdpes"] == DBNull.Value ? 0 : Convert.ToInt32(reader["cdpes"]),
                                tppes = reader["tppes"] == DBNull.Value ? 0 : Convert.ToInt32(reader["tppes"]),
                                nrcgccpf = reader["nrcgccpf"] == DBNull.Value ? null : reader["nrcgccpf"].ToString(),
                                nmpes = reader["nmpes"] == DBNull.Value ? null : reader["nmpes"].ToString(),
                                dtcad = reader["dtcad"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["dtcad"]),
                                dtnas = reader["dtnas"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["dtnas"]),
                                tpsex = reader["tpsex"] == DBNull.Value ? 0 : Convert.ToInt32(reader["tpsex"]),
                            };

                            i++;

                        }

                        connection.Close();

                        return i;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Selecionar()
        {
            try
            {
                //Valida se o objeto está preenchido
                //if (pessoa != null)
                //{
                //    throw new ArgumentNullException("Objeto Telefone não preenchido");
                //}

                //bool resultado = false;

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "select cdpes, tppes, nrcgccpf, nmpes, dtcad, dtnas, tpsex from TreinaWeb.dbo.Pessoa";

                        SqlDataReader reader = command.ExecuteReader();

                        listaPessoa = new List<Pessoa>();

                        while (reader.Read())
                        {


                            pessoa = new Pessoa()
                            {
                                cdpes = reader["cdpes"] == DBNull.Value ? 0 : Convert.ToInt32(reader["cdpes"]),
                                tppes = reader["tppes"] == DBNull.Value ? 0 : Convert.ToInt32(reader["tppes"]),
                                nrcgccpf = reader["nrcgccpf"] == DBNull.Value ? null : reader["nrcgccpf"].ToString(),
                                nmpes = reader["nmpes"] == DBNull.Value ? null : reader["nmpes"].ToString(),
                                dtcad = reader["dtcad"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["dtcad"]),
                                dtnas = reader["dtnas"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["dtnas"]),
                                tpsex = reader["tpsex"] == DBNull.Value ? 0 : Convert.ToInt32(reader["tpsex"]),
                            };

                            listaPessoa.Add(pessoa);

                        }

                        connection.Close();

                        return listaPessoa.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Alterar()
        {
            try
            {
                //Valida se o objeto está preenchido
                if (pessoa == null)
                {
                    throw new ArgumentNullException("Objeto Telefone não preenchido");
                }

                //bool resultado = false;

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "update a set tppes = @tppes, nrcgccpf = @nrcgccpf, nmpes = @nmpes, dtnas = @dtnas, tpsex = @tpsex from TreinaWeb.dbo.Pessoa a where cdpes = @cdpes";

                        command.Parameters.AddWithValue("cdpes", pessoa.cdpes);
                        command.Parameters.AddWithValue("tppes", pessoa.tppes);
                        command.Parameters.AddWithValue("nrcgccpf", pessoa.nrcgccpf);
                        command.Parameters.AddWithValue("nmpes", pessoa.nmpes);
                        command.Parameters.AddWithValue("dtnas", pessoa.dtnas);
                        command.Parameters.AddWithValue("tpsex", pessoa.tpsex);
                        

                        int i = command.ExecuteNonQuery();

                        connection.Close();

                        return i;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}