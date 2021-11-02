using InvoicingData.Core;
using InvoicingData.Model;
using InvoicingRepository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace InvoicingRepository.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IOptions<ConnectionStrings> _ConnectionStrings;

        public EmailRepository(IOptions<ConnectionStrings> pConnectionStrings)
        {
            _ConnectionStrings = pConnectionStrings;
        }

        #region Methods

        /// <summary>
        /// Crear un nuevo email
        /// </summary>
        /// <param name="pEmail"></param>
        public void Create(Email pEmail)
        {
            string strEmailJson = JsonConvert.SerializeObject(pEmail, Formatting.Indented);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_CreateEmail", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@EmailJson", strEmailJson);
                        _SqlCommand.ExecuteReader();

                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("Create(Email pEmail) Exception: ", exception.Message));
                    }
                }
                finally
                {
                    _SqlConnection.Close();
                    _SqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// Actualizar la columna "State" del email para inabilitarlo
        /// </summary>
        /// <param name="pId"></param>
        public void Delete(int pId)
        {
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_DeleteEmailById", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = pId;
                        _SqlCommand.ExecuteReader();

                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("Delete(int pId) Exception: ", exception.Message));
                    }
                }
                finally
                {
                    _SqlConnection.Close();
                    _SqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// Obtener todos los emails
        /// </summary>
        /// <returns> Retorna una lista de todos los emails que esten activos </returns>
        public IEnumerable<Email> GetAll()
        {
            List<Email> lstEmail = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetAllEmail", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                lstEmail.Add(new Email()
                                {
                                    Id = _SqlDataReader.GetInt32(0),
                                    IdPerson = _SqlDataReader.GetInt32(1),
                                    EmailAddress = _SqlDataReader.GetString(2)
                                });
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("GetAll() Exception: ", exception.Message));
                    }
                }
                finally
                {
                    _SqlConnection.Close();
                    _SqlConnection.Dispose();
                }
                return lstEmail;
            }
        }

        /// <summary>
        /// Obtener todos los emails de una persona 
        /// </summary>
        /// <returns> Retorna una lista de todos los emails que esten activos de una persona </returns>
        public IEnumerable<Email> GetByIdPerson(int pIdPerson)
        {
            List<Email> lstEmail = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetEmailByIdPerson", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@IdPerson", pIdPerson);

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                lstEmail.Add(new Email()
                                {
                                    Id = _SqlDataReader.GetInt32(0),
                                    IdPerson = _SqlDataReader.GetInt32(1),
                                    EmailAddress = _SqlDataReader.GetString(2)
                                });
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("GetByIdPerson(int pIdPerson) Exception: ", exception.Message));
                    }
                }
                finally
                {
                    _SqlConnection.Close();
                    _SqlConnection.Dispose();
                }
                return lstEmail;
            }
        }

        /// <summary>
        /// Obtener un email por su id
        /// </summary>
        /// <param name="pId"></param>
        /// <returns> Retorna la información del email </returns>
        public Email GetById(int pId)
        {
            Email objEmail = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetEmailById", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@Id", pId);

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                objEmail.Id = _SqlDataReader.GetInt32(0);
                                objEmail.IdPerson = _SqlDataReader.GetInt32(1);
                                objEmail.EmailAddress = _SqlDataReader.GetString(2);
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("GetById(int pId) Exception: ", exception.Message));
                    }
                }
                finally
                {
                    _SqlConnection.Close();
                    _SqlConnection.Dispose();
                }
                return objEmail;
            }
        }

        /// <summary>
        /// Actualizar la informacion de un email
        /// </summary>
        /// <param name="pEmail"></param>
        public void Update(Email pEmail)
        {
            string strEmailJson = JsonConvert.SerializeObject(pEmail);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_UpdateEmail", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@EmailJson", strEmailJson);
                        _SqlCommand.ExecuteReader();

                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("Update(Email pEmail) Exception: ", exception.Message));
                    }
                }
                finally
                {
                    _SqlConnection.Close();
                    _SqlConnection.Dispose();
                }
            }
        }

        #endregion Methods
    }
}
