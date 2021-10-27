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
    internal class SellerRepository : ISellerRepository
    {
        private readonly IOptions<ConnectionStrings> _ConnectionStrings;

        public SellerRepository(IOptions<ConnectionStrings> pConnectionStrings)
        {
            _ConnectionStrings = pConnectionStrings;
        }

        #region Methods

        public bool Create(Seller pSeller)
        {
            bool bolResult = false;
            string strSellerJson = JsonConvert.SerializeObject(pSeller, Formatting.Indented);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_CreateSeller", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@SellerJson", strSellerJson);

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
                        throw new Exception(string.Concat("Create(Seller pSeller) Exception: ", exception.Message));
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
                            SqlCommand _SqlCommand = new("UPDATE dbo.Seller SET State = 0 WHERE Document = @Document", _SqlConnection)
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

        public IEnumerable<Seller> GetAll()
        {
            List<Seller> lstSeller = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetAllSeller", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                lstSeller.Add(new Seller()
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
                return lstSeller;
            }
        }

        public Seller GetByDocument(int pDocument)
        {
            Seller objSeller = new();
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_GetSellerByDocument", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@Document", pDocument);

                        using (SqlDataReader _SqlDataReader = _SqlCommand.ExecuteReader())
                        {
                            while (_SqlDataReader.Read())
                            {
                                objSeller.Document = _SqlDataReader.GetInt32(0);
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
                return objSeller;
            }
        }

        public bool Update(Seller pSeller)
        {
            bool bolResult = false;
            string strSellerJson = JsonConvert.SerializeObject(pSeller, Formatting.Indented);
            using (SqlConnection _SqlConnection = new(_ConnectionStrings.Value.DefaultConnection))
            {
                try
                {
                    try
                    {
                        _SqlConnection.Open();
                        SqlCommand _SqlCommand = new("dbo.aSp_UpdateSeller", _SqlConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _SqlCommand.Parameters.AddWithValue("@SellerJson", strSellerJson);

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
                        throw new Exception(string.Concat("Update(Seller pSeller) Exception: ", exception.Message));
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
