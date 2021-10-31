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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IOptions<ConnectionStrings> _ConnectionStrings;

        public CustomerRepository(IOptions<ConnectionStrings> pConnectionStrings)
        {
            _ConnectionStrings = pConnectionStrings;
        }

        #region Methods

        /// <summary>
        /// Crear un nuevo cliente
        /// </summary>
        /// <param name="pCustomer"></param>
        /// <returns> Retorna true si la creacion en correcta o false si se presento algún error al momento de la creación </returns>
        public void Create(Customer pCustomer)
        {
            string strCustomerJson = JsonConvert.SerializeObject(pCustomer, Formatting.Indented);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_CreateCustomer", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@CustomerJson", strCustomerJson);
                        _SqlCommand.ExecuteReader();

                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("Create(Customer pCustomer) Exception: ", exception.Message));
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
        /// Actualizar la columna "State" del cliente para inabilitarlo
        /// </summary>
        /// <param name="pDocument"></param>
        /// <returns> Retorna true si la eliminación en correcta o false si se presento algún error al momento de la eliminación </returns>
        public void Delete(int pId)
        {
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_DeleteCustomerById", _SqlConnection)
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
        /// Obtener todos los clientes
        /// </summary>
        /// <returns> Retorna una lista de todos los clientes que esten activos </returns>
        public IEnumerable<Customer> GetAll()
        {
            List<Customer> lstCustomer = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetAllCustomer", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                lstCustomer.Add(new Customer()
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
                return lstCustomer;
            }
        }

        /// <summary>
        /// Obtener un cliente por su documento
        /// </summary>
        /// <param name="pDocument"></param>
        /// <returns> Retorna la información del cliente </returns>
        public Customer GetById(int pId)
        {
            Customer objCustomer = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetCustomerById", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@Id", pId);

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                objCustomer.Id = _SqlDataReader.GetInt32(0);
                                objCustomer.Document = _SqlDataReader.GetInt32(1);
                                objCustomer.FirstName = _SqlDataReader.GetString(2);
                                objCustomer.LastName = _SqlDataReader.GetString(3);
                                objCustomer.Age = _SqlDataReader.GetInt32(4);
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
                return objCustomer;
            }
        }

        /// <summary>
        /// Actualizar la informacion de un cliente
        /// </summary>
        /// <param name="pCustomer"></param>
        /// <returns> Retorna true si la actualización en correcta o false si se presento algún error al momento de la actualización </returns>
        public void Update(Customer pCustomer)
        {
            string strCustomerJson = JsonConvert.SerializeObject(pCustomer);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_UpdateCustomer", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@CustomerJson", strCustomerJson);
                        _SqlCommand.ExecuteReader();

                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("Update(Customer pCustomer) Exception: ", exception.Message));
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
