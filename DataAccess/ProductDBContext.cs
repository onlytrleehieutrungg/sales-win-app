using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class ProductDBContext:BaseDal
    {
        private static ProductDBContext instance = null;
        private static readonly object instanceLock = new object();
        private ProductDBContext()
        {

        }
        public static ProductDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDBContext();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Product> GetProductList()
        {
            IDataReader dataReader = null;
            String SQLSelect = "Select ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitsInStock from Product";     
            var products = new List<Product>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    products.Add(new Product
                    {
                        ProductId = dataReader.GetInt32(0),
                        CategoryId = dataReader.GetInt32(1),
                        ProductName = dataReader.GetString(2),
                        Weight = dataReader.GetString(3),
                        UnitPrice = dataReader.GetDecimal(4),
                        UnitsInStock = dataReader.GetInt32(5)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            } 
            return products;
        }

        public Product GetProductByID(int productId)
        {
            Product product = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select CategoryId, ProductName, Weight, UnitPrice, UnitsInStock " +
                            " from Product where ProductId = @ProductId";
            try
            {
                var param = dataProvider.CreateParameter("@ProductId", 4, productId, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    product = new Product
                    {
                        ProductId = dataReader.GetInt32(0),
                        CategoryId = dataReader.GetInt32(1),
                        ProductName = dataReader.GetString(2),
                        Weight = dataReader.GetString(3),
                        UnitPrice = dataReader.GetDecimal(4),
                        UnitsInStock = dataReader.GetInt32(5)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return product;
        }

        public void AddNew(Product product)
        {
            try
            {
                Product pro = GetProductByID(product.ProductId);
                if (pro == null)
                {
                    string SQLInsert = "Insert Product values(@ProductId,@CategoryId,@ProductName,@Weight,@UnitPrice,@UnitsInStock)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@ProductId", 4, product.ProductId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@CategoryId", 4, product.CategoryId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@ProductName", 50, product.ProductName, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Weight", 20, product.Weight, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@UnitPrice", 8, product.UnitPrice, DbType.Decimal));
                    parameters.Add(dataProvider.CreateParameter("@UnitsInStock", 4, product.UnitsInStock, DbType.Int32));
                    dataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The Product is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(Product product)
        {
            try
            {
                Product pro = GetProductByID(product.ProductId);
                if (pro != null)
                {
                    string SQLInsert = "Update Product set CategoryId = @CategoryId,ProductName = @ProductName,"
                        + " Weight = @Weight,UnitPrice = @UnitPrice,UnitsInStock = @UnitsInStock Where ProductId = @ProductId";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@ProductId", 4, product.ProductId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@CategoryId", 4, product.CategoryId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@ProductName", 50, product.ProductName, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Weight", 20, product.Weight, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@UnitPrice", 8, product.UnitPrice, DbType.Decimal));
                    parameters.Add(dataProvider.CreateParameter("@UnitsInStock", 4, product.UnitsInStock, DbType.Int32));
                    dataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());

                }
                else
                {
                    throw new Exception("The Product does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }


        public void Remove(int productId)
        {
            try
            {
                Product product = GetProductByID(productId);
                if (product != null)
                {
                    String SQLDelete = "Delete Product Where ProductId = @ProductId";
                    var param = dataProvider.CreateParameter("@ProductId", 4, productId, DbType.Int32);
                    dataProvider.Delete(SQLDelete, CommandType.Text, param);

                }
                else
                {
                    throw new Exception("The Product is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
            public IEnumerable<Product> SearchProduct(int id)
            {
                IEnumerable<Product> searchResult = null;
                IEnumerable<Product> products = GetProductList();

                var productSearch = from product in products
                                   where product.ProductId == id
                                   select product;
                searchResult = productSearch;

                return searchResult;
            }


        public IEnumerable<Product> SearchProduct(String name)
        {
            IEnumerable<Product> searchResult = null;
            IEnumerable<Product> products = GetProductList();

            var productSearch = from product in products
                                where product.ProductName.ToLower().Contains(name.ToLower())
                                select product;
            searchResult = productSearch;

            return searchResult;
        }




    }
}
