using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class AlunoBusiness
    {
        public IEnumerable<Aluno> getAlunos()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;

            List<Aluno> alunos = new List<Aluno>();

            try
            {
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GetAlunos", conexao);
                    command.CommandType = CommandType.StoredProcedure;
                    conexao.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    while(dataReader.Read())
                    {
                        Aluno aluno = new Aluno();
                        aluno.Id = Convert.ToInt32(dataReader["Id"]);
                        aluno.Nome = dataReader["Nome"].ToString();
                        aluno.Email = dataReader["Email"].ToString();
                        aluno.Idade = Convert.ToInt32(dataReader["Idade"]);
                        aluno.DataInscricao = Convert.ToDateTime(dataReader["DataInscricao"]);
                        aluno.Sexo = dataReader["Sexo"].ToString();
                        aluno.Foto = dataReader["Foto"].ToString();
                        aluno.Texto = dataReader["Texto"].ToString();
                        alunos.Add(aluno);
                    }
                }
                return alunos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void IncluirAluno(Aluno aluno)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;
            try
            {
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("IncluirAluno", conexao);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramNome = new SqlParameter();
                    paramNome.ParameterName = "@Nome";
                    paramNome.Value = aluno.Nome;
                    command.Parameters.Add(paramNome);

                    SqlParameter paramEmail = new SqlParameter();
                    paramEmail.ParameterName = "@Email";
                    paramEmail.Value = aluno.Email;
                    command.Parameters.Add(paramEmail);

                    SqlParameter paramIdade = new SqlParameter();
                    paramIdade.ParameterName = "@Idade";
                    paramIdade.Value = aluno.Idade;
                    command.Parameters.Add(paramIdade);

                    SqlParameter paramDataInscricao = new SqlParameter();
                    paramDataInscricao.ParameterName = "@DataInscricao";
                    paramDataInscricao.Value = aluno.DataInscricao;
                    command.Parameters.Add(paramDataInscricao);

                    SqlParameter paramSexo = new SqlParameter();
                    paramSexo.ParameterName = "@Sexo";
                    paramSexo.Value = aluno.Sexo;
                    command.Parameters.Add(paramSexo);

                    SqlParameter paramFoto = new SqlParameter();
                    paramSexo.ParameterName = "@Foto";
                    paramSexo.Value = aluno.Foto;
                    command.Parameters.Add(paramFoto);

                    SqlParameter paramTexto = new SqlParameter();
                    paramSexo.ParameterName = "@Texto";
                    paramSexo.Value = aluno.Texto;
                    command.Parameters.Add(paramTexto);

                    conexao.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AtualizarAluno(Aluno aluno)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;

            try
            {
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("AtualizarAluno", conexao);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramId = new SqlParameter();
                    paramId.ParameterName = "@Id";
                    paramId.Value = aluno.Id;
                    command.Parameters.Add(paramId);

                    SqlParameter paramNome = new SqlParameter();
                    paramNome.ParameterName = "@Nome";
                    paramNome.Value = aluno.Nome;
                    command.Parameters.Add(paramNome);

                    SqlParameter paramEmail = new SqlParameter();
                    paramEmail.ParameterName = "@Email";
                    paramEmail.Value = aluno.Email;
                    command.Parameters.Add(paramEmail);

                    SqlParameter paramIdade = new SqlParameter();
                    paramIdade.ParameterName = "@Idade";
                    paramIdade.Value = aluno.Idade;
                    command.Parameters.Add(paramIdade);

                    SqlParameter paramDataInscricao = new SqlParameter();
                    paramDataInscricao.ParameterName = "@DataInscricao";
                    paramDataInscricao.Value = aluno.DataInscricao;
                    command.Parameters.Add(paramDataInscricao);

                    SqlParameter paramSexo = new SqlParameter();
                    paramSexo.ParameterName = "@Sexo";
                    paramSexo.Value = aluno.Sexo;
                    command.Parameters.Add(paramSexo);

                    conexao.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        public void ExcluirAluno(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;
            try
            {
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("ExcluirAluno", conexao);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramId = new SqlParameter();
                    paramId.ParameterName = "@Id";
                    paramId.Value = id;
                    command.Parameters.Add(paramId);

                    conexao.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
