using Sinaf.WebApi.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Sinaf.WebApi.Repositorio
{
    public class TelefonePessoaRepositorio
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["BaseSinistro"].ToString();

        public TelefonePessoa telefonePessoa { get; set; }
        public List<TelefonePessoa> listaTelefonePessoa { get; set; }

        public TelefonePessoaRepositorio()
        {
            telefonePessoa = null;
            listaTelefonePessoa = null;
        }

        public int Incluir()
        {
            try
            {
                //Valida se o objeto está preenchido
                if (telefonePessoa == null)
                {
                    throw new ArgumentNullException("Objeto Telefone não preenchido");
                }

                //bool resultado = false;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "insert into TreinaWeb.dbo.TelefonePessoa (cdpes, cdddd, nrtel) VALUES (@cdpes, @cdddd, @nrtel)";

                        command.Parameters.AddWithValue("cdpes", telefonePessoa.cdpes);
                        command.Parameters.AddWithValue("cdddd", telefonePessoa.cdddd);
                        command.Parameters.AddWithValue("nrtel", telefonePessoa.nrtel);

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

        public int Deletar()
        {
            try
            {
                //Valida se o objeto está preenchido
                if (telefonePessoa != null)
                {
                    throw new ArgumentNullException("Objeto Telefone não preenchido");
                }

                //bool resultado = false;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "delete a from TreinaWeb.dbo.TelefonePessoa a where cdpes = @cdpes and nrseqtel = @nrseqtel";

                        command.Parameters.AddWithValue("cdpes", telefonePessoa.cdpes);
                        command.Parameters.AddWithValue("nrseqtel", telefonePessoa.nrseqtel );

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

        public int SelecionarPorId(int p_cdpes, int p_nrseqtel)
        {
            try
            {
                //Valida se o objeto está preenchido
                //if (telefonePessoa != null)
                //{
                //    throw new ArgumentNullException("Objeto Telefone não preenchido");
                //}

                //bool resultado = false;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "select cdpes, nrseqtel, cdddd, nrtel from TreinaWeb.dbo.TelefonePessoa where cdpes = @cdpes and nrseqtel = @nrseqtel"; 
                        command.Parameters.AddWithValue("cdpes", p_cdpes);
                        command.Parameters.AddWithValue("nrseqtel", p_nrseqtel);

                        telefonePessoa = null;

                        SqlDataReader reader = command.ExecuteReader();

                        int i = 0;

                        while (reader.Read())
                        {
                            

                            telefonePessoa = new TelefonePessoa()
                            {
                                cdpes = reader["cdpes"] == DBNull.Value ? 0 : Convert.ToInt32(reader["cdpes"]),
                                nrseqtel = reader["nrseqtel"] == DBNull.Value ? 0 : Convert.ToInt32(reader["nrseqtel"]),
                                cdddd = reader["cdddd"] == DBNull.Value ? 0 : Convert.ToInt32(reader["cdddd"]),
                                nrtel = reader["nrtel"] == DBNull.Value ? 0 : Convert.ToInt32(reader["nrtel"]),
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
                //if (telefonePessoa != null)
                //{
                //    throw new ArgumentNullException("Objeto Telefone não preenchido");
                //}

                //bool resultado = false;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "select cdpes, nrseqtel, cdddd, nrtel from TreinaWeb.dbo.TelefonePessoa where cdpes = @cdpes";
                        command.Parameters.AddWithValue("cdpes", telefonePessoa.cdpes);

                        SqlDataReader reader = command.ExecuteReader();

                        listaTelefonePessoa = new List<TelefonePessoa>();

                        while (reader.Read())
                        {


                            telefonePessoa = new TelefonePessoa()
                            {
                                cdpes = reader["cdpes"] == DBNull.Value ? 0 : Convert.ToInt32(reader["cdpes"]),
                                nrseqtel = reader["nrseqtel"] == DBNull.Value ? 0 : Convert.ToInt32(reader["nrseqtel"]),
                                cdddd = reader["cdddd"] == DBNull.Value ? 0 : Convert.ToInt32(reader["cdddd"]),
                                nrtel = reader["nrtel"] == DBNull.Value ? 0 : Convert.ToInt32(reader["nrtel"]),
                            };

                            listaTelefonePessoa.Add(telefonePessoa);

                        }

                        connection.Close();

                        return listaTelefonePessoa.Count;
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
                if (telefonePessoa == null)
                {
                    throw new ArgumentNullException("Objeto Telefone não preenchido");
                }

                //bool resultado = false;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "update a set cdddd = @cdddd,   nrtel = @nrtel from TreinaWeb.dbo.TelefonePessoa a where cdpes = @cdpes and nrseqtel = @nrseqtel";

                        command.Parameters.AddWithValue("cdpes", telefonePessoa.cdpes);
                        command.Parameters.AddWithValue("nrseqtel", telefonePessoa.nrseqtel);
                        command.Parameters.AddWithValue("cdddd", telefonePessoa.cdddd);
                        command.Parameters.AddWithValue("nrtel", telefonePessoa.nrtel);

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
