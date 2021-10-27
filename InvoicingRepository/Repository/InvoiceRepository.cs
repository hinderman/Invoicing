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
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IOptions<ConnectionStrings> _ConnectionStrings;

        public InvoiceRepository(IOptions<ConnectionStrings> pConnectionStrings)
        {
            _ConnectionStrings = pConnectionStrings;
        }

        #region Methods

        /// <summary>
        /// Crea una nueva factura
        /// </summary>
        /// <param name="pInvoice"></param>
        /// <returns> Retorna true si la creacion en correcta o false si se presento algún error al momento de la creación </returns>
        public bool Create(Invoice pInvoice)
        {
            bool bolResult = false;
            string strInvoiceJson = JsonConvert.SerializeObject(pInvoice, Formatting.Indented);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_CreateInvoice", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@InvoiceJson", strInvoiceJson);

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
                        throw new Exception(string.Concat("Create(Invoice pCustomer) Exception: ", exception.Message));
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
        /// Actualizar la columna "State" de la factura para inabilitarla
        /// </summary>
        /// <param name="pID"></param>
        /// <returns> Retorna true si la eliminación en correcta o false si se presento algún error al momento de la eliminación </returns>
        public bool Delete(int pID)
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
                            SqlCommand _SqlCommand = new("UPDATE dbo.Invoice SET State = 0 WHERE Id = @Id", _SqlConnection)
                            {
                                CommandType = CommandType.Text
                            };

                            _SqlCommand.Parameters.Add(new SqlParameter("@Id", pID));

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
                            throw new Exception(string.Concat("Delete(int pID) Exception: ", exception.Message));
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
        /// Obtener todos las facturas
        /// </summary>
        /// <returns> Retorna una lista de todos los clientes que esten activos </returns>
        public IEnumerable<Invoice> GetAll()
        {
            List<Invoice> lstInvoice  = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetAllInvoice", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                lstInvoice.Add(new Invoice()
                                {
                                    Id = _SqlDataReader.GetInt32(0)
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
                return lstInvoice;
            }
        }

        /// <summary>
        /// Obtener una factura por su id
        /// </summary>
        /// <param name="pID"></param>
        /// <returns> Retorna la información de la factura </returns>
        public Invoice GetById(int pID)
        {
            Invoice objInvoice = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetInvoiceById", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@Id", pID);

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                objInvoice.Id = _SqlDataReader.GetInt32(0);
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(string.Concat("GetById(int pID) Exception: ", exception.Message));
                    }
                }
                finally
                {
                    _SqlConnection.Close();
                    _SqlConnection.Dispose();
                }
                return objInvoice;
            }
        }

        /// <summary>
        /// Actualizar la informacion de una factura
        /// </summary>
        /// <param name="pInvoice"></param>
        /// <returns> Retorna true si la actualización en correcta o false si se presento algún error al momento de la actualización </returns>
        public bool Update(Invoice pInvoice)
        {
            bool bolResult = false;
            string strInvoiceJson = JsonConvert.SerializeObject(pInvoice, Formatting.Indented);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_UpdateInvoice", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@InvoiceJson", strInvoiceJson);

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
                        throw new Exception(string.Concat("Update(Invoice pInvoice) Exception: ", exception.Message));
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
