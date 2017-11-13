using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Biblioteca.IO.CrossCutting.Exceptions;
using Biblioteca.IO.Entity;
using Biblioteca.IO.Repository.Interfaces;

namespace Biblioteca.IO.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private const string ConnectionString = "Server=LABINF01-14;Database=Biblioteca;Trusted_Connection=True;MultipleActiveResultSets=true;";

        public void Inserir(Usuario usuario)
        {
            SqlConnection cnn = null;



            try
            {
                cnn = new SqlConnection(ConnectionString);
                cnn.Open();

                var command = new SqlCommand
                {
                    CommandText = "spInserirUsuario",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cnn
                };

                command.Parameters.AddWithValue("Nome", usuario.Nome);
                command.Parameters.AddWithValue("Endereco", usuario.Endereco);
                command.Parameters.AddWithValue("Telefone", usuario.Telefone);
                command.Parameters.AddWithValue("Senha", usuario.Senha);

                command.ExecuteNonQuery();

            }
            catch (UsuarioNaoEncontradoException)
            {
                throw new UsuarioNaoEncontradoException();
            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                    cnn.Dispose();
                }
            }
        }

        public Usuario Obter(int id)
        {
            SqlConnection cnn = null;

            Usuario usuario = null;

            try
            {
                cnn = new SqlConnection(ConnectionString);
                cnn.Open();

                var command = new SqlCommand
                {
                    CommandText = "spObterUsuarioPorId",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cnn
                };

                command.Parameters.AddWithValue("Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = PreencherUsuario(reader);
                    }
                }
                
                return usuario;
            }
            catch (UsuarioNaoEncontradoException)
            {
                throw new UsuarioNaoEncontradoException();
            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                    cnn.Dispose();
                }
            }

        }

        public ICollection<Usuario> ObterPorNome(string nome)
        {
            throw new System.NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Atualizar(Usuario usuario)
        {
            SqlConnection cnn = null;



            try
            {
                cnn = new SqlConnection(ConnectionString);
                cnn.Open();

                var command = new SqlCommand
                {
                    CommandText = "spAtualizarUsuario",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cnn
                };

                command.Parameters.AddWithValue("@Nome", usuario.Nome);
                command.Parameters.AddWithValue("@Endereco", usuario.Endereco);
                command.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                command.Parameters.AddWithValue("@Senha", usuario.Senha);
                command.Parameters.AddWithValue("@Id", usuario.Id);

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                    cnn.Dispose();
                }
            }
        }

        public Usuario PreencherUsuario(SqlDataReader reader)
        {
            var idUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
            var nome = reader["Nome"].ToString();
            var endereco = reader["Endereco"].ToString();
            var telefone = reader["Telefone"].ToString();
            var senha = reader["Senha"].ToString();

            return new Usuario(idUsuario, nome, endereco, telefone, senha);
        }
    }
}