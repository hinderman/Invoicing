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
    public class ProductRepository : IProductRepository
    {
        private readonly IOptions<ConnectionStrings> _ConnectionStrings;

        public ProductRepository(IOptions<ConnectionStrings> pConnectionStrings)
        {
            _ConnectionStrings = pConnectionStrings;
        }

        #region Methods

        /// <summary>
        /// Crea un nuevo producto
        /// </summary>
        /// <param name="pProduct"></param>
        /// <returns> Retorna true si la creacion en correcta o false si se presento algún error al momento de la creación </returns>
        public bool Create(Product pProduct)
        {
            bool bolResult = false;
            string strProductJson = JsonConvert.SerializeObject(pProduct, Formatting.Indented);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_CreateProduct", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@ProductJson", strProductJson);

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
                        throw new Exception(string.Concat("Create(Product pProduct) Exception: ", exception.Message));
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
        /// Actualizar la columna "State" del producto para inabilitarlo
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
                            SqlCommand _SqlCommand = new("UPDATE dbo.Product SET State = 0 WHERE Id = @Id", _SqlConnection)
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
        /// Obtener todos los productos
        /// </summary>
        /// <returns> Retorna una lista de todos los productos que esten activos </returns>
        public IEnumerable<Product> GetAll()
        {
            List<Product> lstProduct = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetAllProduct", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                lstProduct.Add(new Product()
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
                return lstProduct;
            }
        }

        /// <summary>
        /// Obtener un producto por su id
        /// </summary>
        /// <param name="pID"></param>
        /// <returns> Retorna la información del producto </returns>
        public Product GetById(int pID)
        {
            Product objProduct = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetProductById", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@Id", pID);

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                objProduct.Id = _SqlDataReader.GetInt32(0);
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
                return objProduct;
            }
        }

        /// <summary>
        /// Actualizar la informacion de un producto
        /// </summary>
        /// <param name="pProduct"></param>
        /// <returns> Retorna true si la actualización en correcta o false si se presento algún error al momento de la actualización </returns>
        public bool Update(Product pProduct)
        {
            bool bolResult = false;
            string strProductJson = JsonConvert.SerializeObject(pProduct, Formatting.Indented);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_UpdateProduct", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@ProductJson", strProductJson);

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
                        throw new Exception(string.Concat("Update(Product pProduct) Exception: ", exception.Message));
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
