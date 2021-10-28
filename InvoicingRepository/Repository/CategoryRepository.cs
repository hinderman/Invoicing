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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IOptions<ConnectionStrings> _ConnectionStrings;

        public CategoryRepository(IOptions<ConnectionStrings> pConnectionStrings)
        {
            _ConnectionStrings = pConnectionStrings;
        }

        #region Methods

        /// <summary>
        /// Cracion de una nueva categoria
        /// </summary>
        /// <param name="pCategory"></param>
        /// <returns> Retorna true si la creacion en correcta o false si se presento algún error al momento de la creación </returns>
        public bool Create(Category pCategory)
        {
            bool bolResult = false;
            string strCategoryJson = JsonConvert.SerializeObject(pCategory, Formatting.Indented);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_CreateCategory", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@CategoryJson", strCategoryJson);

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
                        throw new Exception(string.Concat("Create(Category pCategory) Exception: ", exception.Message));
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
        /// Actualizar la columna "State" de la categoria para inabilitarlo
        /// </summary>
        /// <param name="pID"></param>
        /// <returns> Retorna true si la eliminacion en correcta o false si se presento algún error al momento de la eliminacion </returns>
        public bool Delete(int pID)
        {
            bool bolResult = false;
            //Se declara una transaccion para evitar otros movimientos en la tabla al momento de la actualización
            using (TransactionScope _TransactionScope = new())
            {
                using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
                {
                    try
                    {
                        try
                        {
                            _SqlConnection.Open();
                            SqlCommand _SqlCommand = new("UPDATE dbo.Category SET State = 0 WHERE Id = @pID", _SqlConnection)
                            {
                                CommandType = CommandType.Text
                            };

                            _SqlCommand.Parameters.Add(new SqlParameter("@pID", pID));

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
        /// Obtener todas las categorias
        /// </summary>
        /// <returns> Retorna una lista de todas las categorias que esten activas </returns>
        public IEnumerable<Category> GetAll()
        {
            List<Category> ltsCustomer = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetAllCategory", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                ltsCustomer.Add(new Category()
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
                return ltsCustomer;
            }
        }

        /// <summary>
        /// Obtener una categoria por su id
        /// </summary>
        /// <param name="pID"></param>
        /// <returns> Retorna la información de la categoria </returns>
        public Category GetById(int pID)
        {
            Category objCustomer = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetCategoryById", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@Id", pID);

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                objCustomer.Id = _SqlDataReader.GetInt32(0);
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
                return objCustomer;
            }
        }

        /// <summary>
        /// Actualizar una categoria
        /// </summary>
        /// <param name="pCategory"></param>
        /// <returns> Retorna true si la actualización en correcta o false si se presento algún error al momento de la actualización </returns>
        public bool Update(Category pCategory)
        {
            bool bolResult = false;
            string strCategoryJson = JsonConvert.SerializeObject(pCategory, Formatting.Indented);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_UpdateCategory", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@CategoryJson", strCategoryJson);

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
                        throw new Exception(string.Concat("Update(Category pCategory) Exception: ", exception.Message));
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
