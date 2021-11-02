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
    public class PersonRepository : IPersonRepository
    {
        private readonly IOptions<ConnectionStrings> _ConnectionStrings;

        public PersonRepository(IOptions<ConnectionStrings> pConnectionStrings)
        {
            _ConnectionStrings = pConnectionStrings;
        }

        #region Methods

        /// <summary>
        /// Crear una nueva persona (Cliente, Vendedor)
        /// </summary>
        /// <param name="pPerson"></param>
        public void Create(Person pPerson)
        {
            string strPersonJson = JsonConvert.SerializeObject(pPerson, Formatting.Indented);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_CreatePerson", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@PersonJson", strPersonJson);
                        _SqlCommand.ExecuteReader();

                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("Create(Person pPerson) Exception: ", exception.Message));
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
        /// Actualizar la columna "State" de la persona (Cliente, vendedor) para inabilitarlo
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
                        SqlCommand _SqlCommand = new("dbo.aSp_DeletePersonById", _SqlConnection)
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
        /// Obtener todas las personas (cliente, vendedor)
        /// </summary>
        /// <returns> Retorna una lista de todas las personas (cliente, vendedor) que esten activas </returns>
        public IEnumerable<Person> GetAll()
        {
            List<Person> lstPerson = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetAllPerson", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                lstPerson.Add(new Person()
                                {
                                    Id = _SqlDataReader.GetInt32(0),
                                    Document = _SqlDataReader.GetInt32(1),
                                    FirstName = _SqlDataReader.GetString(2),
                                    LastName = _SqlDataReader.GetString(3),
                                    Age = _SqlDataReader.GetInt32(4)
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
                return lstPerson;
            }
        }

        /// <summary>
        /// Obtener un cliente por su documento
        /// </summary>
        /// <param name="pId"></param>
        /// <returns> Retorna la información del cliente </returns>
        public Person GetById(int pId)
        {
            Person objPerson = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetPersonById", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@Id", pId);

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                objPerson.Id = _SqlDataReader.GetInt32(0);
                                objPerson.Document = _SqlDataReader.GetInt32(1);
                                objPerson.FirstName = _SqlDataReader.GetString(2);
                                objPerson.LastName = _SqlDataReader.GetString(3);
                                objPerson.Age = _SqlDataReader.GetInt32(4);
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
                return objPerson;
            }
        }

        /// <summary>
        /// Actualizar la informacion de un cliente
        /// </summary>
        /// <param name="pPerson"></param>
        public void Update(Person pPerson)
        {
            string strPersonJson = JsonConvert.SerializeObject(pPerson);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_UpdatePerson", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@PersonJson", strPersonJson);
                        _SqlCommand.ExecuteReader();

                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("Update(Person pPerson) Exception: ", exception.Message));
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
