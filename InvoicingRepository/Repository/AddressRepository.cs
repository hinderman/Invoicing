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
    public class AddressRepository : IAddressRepository
    {
        private readonly IOptions<ConnectionStrings> _ConnectionStrings;

        public AddressRepository(IOptions<ConnectionStrings> pConnectionStrings)
        {
            _ConnectionStrings = pConnectionStrings;
        }

        #region Methods

        /// <summary>
        /// Crear un nuevo address
        /// </summary>
        /// <param name="pAddress"></param>
        public void Create(Address pAddress)
        {
            string strAddressJson = JsonConvert.SerializeObject(pAddress, Formatting.Indented);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_CreateAddress", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@AddressJson", strAddressJson);
                        _SqlCommand.ExecuteReader();

                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("Create(Address pAddress) Exception: ", exception.Message));
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
        /// Actualizar la columna "State" del address para inabilitarlo
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
                        SqlCommand _SqlCommand = new("dbo.aSp_DeleteAddressById", _SqlConnection)
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
        /// Obtener todos los addresss
        /// </summary>
        /// <returns> Retorna una lista de todos los addresss que esten activos </returns>
        public IEnumerable<Address> GetAll()
        {
            List<Address> lstAddress = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetAllAddress", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                lstAddress.Add(new Address()
                                {
                                    Id = _SqlDataReader.GetInt32(0),
                                    IdPerson = _SqlDataReader.GetInt32(1),
                                    Description = _SqlDataReader.GetString(2)
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
                return lstAddress;
            }
        }

        /// <summary>
        /// Obtener todos los addresss de una persona 
        /// </summary>
        /// <returns> Retorna una lista de todos los addresss que esten activos de una persona </returns>
        public IEnumerable<Address> GetByIdPerson(int pIdPerson)
        {
            List<Address> lstAddress = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetAddressByIdPerson", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@IdPerson", pIdPerson);

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                lstAddress.Add(new Address()
                                {
                                    Id = _SqlDataReader.GetInt32(0),
                                    IdPerson = _SqlDataReader.GetInt32(1),
                                    Description = _SqlDataReader.GetString(2)
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
                return lstAddress;
            }
        }

        /// <summary>
        /// Obtener un address por su id
        /// </summary>
        /// <param name="pId"></param>
        /// <returns> Retorna la información del address </returns>
        public Address GetById(int pId)
        {
            Address objAddress = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetAddressById", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@Id", pId);

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                objAddress.Id = _SqlDataReader.GetInt32(0);
                                objAddress.IdPerson = _SqlDataReader.GetInt32(1);
                                objAddress.Description = _SqlDataReader.GetString(2);
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
                return objAddress;
            }
        }

        /// <summary>
        /// Actualizar la informacion de un address
        /// </summary>
        /// <param name="pAddress"></param>
        public void Update(Address pAddress)
        {
            string strAddressJson = JsonConvert.SerializeObject(pAddress);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_UpdateAddress", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@AddressJson", strAddressJson);
                        _SqlCommand.ExecuteReader();

                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("Update(Address pAddress) Exception: ", exception.Message));
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
