using InvoicingData.Core;
using InvoicingData.Model;
using InvoicingRepository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

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
        public bool Create(Customer pCustomer)
        {
            bool bolResult = false;
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

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                bolResult = _SqlDataReader.GetBoolean(0);
                            }
                        }
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
                return bolResult;
            }
        }

        /// <summary>
        /// Actualizar la columna "State" del cliente para inabilitarlo
        /// </summary>
        /// <param name="pDocument"></param>
        /// <returns> Retorna true si la eliminación en correcta o false si se presento algún error al momento de la eliminación </returns>
        public bool Delete(int pDocument)
        {
            bool bolResult = false;
            //Se declara una transaccion para evitar otros movimientos al momento de la actualización
            using (TransactionScope _TransactionScope = new())
            {
                using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
                {
                    try
                    {
                        try
                        {
                            _SqlConnection.Open();
                            SqlCommand _SqlCommand = new("UPDATE dbo.Customer SET State = 0 WHERE Document = @Document", _SqlConnection)
                            {
                                CommandType = CommandType.Text
                            };

                            _SqlCommand.Parameters.Add(new SqlParameter("@Document", pDocument));

                            var returnValue = _SqlCommand.ExecuteScalar();

                            if (returnValue != null)
                            {
                                bolResult = true;
                            }

                            using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                            {
                                while (_SqlDataReader.Read())
                                {
                                    bolResult = _SqlDataReader.GetBoolean(0);
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            throw new Exception(string.Concat("Delete(int pDocument) Exception: ", exception.Message));
                        }
                    }
                    finally
                    {
                        _SqlConnection.Close();
                        _SqlConnection.Dispose();
                    }
                    return bolResult;
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
                                    Document = _SqlDataReader.GetInt32(0)
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
        public Customer GetByDocument(int pDocument)
        {
            Customer objCustomer = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetCustomerByDocument", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@Document", pDocument);

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                objCustomer.Document = _SqlDataReader.GetInt32(0);
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("GetByDocument(int pDocument) Exception: ", exception.Message));
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
        public bool Update(Customer pCustomer)
        {
            bool bolResult = false;
            string strCustomerJson = JsonConvert.SerializeObject(pCustomer, Formatting.Indented);
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

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                bolResult = _SqlDataReader.GetBoolean(0);
                            }
                        }
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
                return bolResult;
            }
        }

        #endregion Methods
    }
}
