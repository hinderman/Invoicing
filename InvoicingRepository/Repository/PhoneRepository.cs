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
    public class PhoneRepository : IPhoneRepository
    {
        private readonly IOptions<ConnectionStrings> _ConnectionStrings;

        public PhoneRepository(IOptions<ConnectionStrings> pConnectionStrings)
        {
            _ConnectionStrings = pConnectionStrings;
        }

        #region Methods

        /// <summary>
        /// Crear un nuevo telefono
        /// </summary>
        /// <param name="pPhone"></param>
        public void Create(Phone pPhone)
        {
            string strPhoneJson = JsonConvert.SerializeObject(pPhone, Formatting.Indented);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_CreatePhone", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@PhoneJson", strPhoneJson);
                        _SqlCommand.ExecuteReader();

                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("Create(Phone pPhone) Exception: ", exception.Message));
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
        /// Actualizar la columna "State" del telefono para inabilitarlo
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
                        SqlCommand _SqlCommand = new("dbo.aSp_DeletePhoneById", _SqlConnection)
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
        /// Obtener todos los telefonos
        /// </summary>
        /// <returns> Retorna una lista de todos los telefonos que esten activos </returns>
        public IEnumerable<Phone> GetAll()
        {
            List<Phone> lstPhone = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetAllPhone", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                lstPhone.Add(new Phone()
                                {
                                    Id = _SqlDataReader.GetInt32(0),
                                    IdPerson = _SqlDataReader.GetInt32(1),
                                    Number = _SqlDataReader.GetString(2)
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
                return lstPhone;
            }
        }

        /// <summary>
        /// Obtener todos los telefonos de una persona 
        /// </summary>
        /// <returns> Retorna una lista de todos los telefonos que esten activos de una persona </returns>
        public IEnumerable<Phone> GetByIdPerson(int pIdPerson)
        {
            List<Phone> lstPhone = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetPhoneByIdPerson", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@IdPerson", pIdPerson);

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                lstPhone.Add(new Phone()
                                {
                                    Id = _SqlDataReader.GetInt32(0),
                                    IdPerson = _SqlDataReader.GetInt32(1),
                                    Number = _SqlDataReader.GetString(2)
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
                return lstPhone;
            }
        }

        /// <summary>
        /// Obtener un telefono por su id
        /// </summary>
        /// <param name="pId"></param>
        /// <returns> Retorna la información del telefono </returns>
        public Phone GetById(int pId)
        {
            Phone objPhone = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetPhoneById", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@Id", pId);

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                objPhone.Id = _SqlDataReader.GetInt32(0);
                                objPhone.IdPerson = _SqlDataReader.GetInt32(1);
                                objPhone.Number = _SqlDataReader.GetString(2);
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
                return objPhone;
            }
        }

        /// <summary>
        /// Actualizar la informacion de un telefono
        /// </summary>
        /// <param name="pPhone"></param>
        public void Update(Phone pPhone)
        {
            string strPhoneJson = JsonConvert.SerializeObject(pPhone);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_UpdatePhone", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@PhoneJson", strPhoneJson);
                        _SqlCommand.ExecuteReader();

                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("Update(Phone pPhone) Exception: ", exception.Message));
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
