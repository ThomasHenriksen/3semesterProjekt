using ArmysalgDataAccess.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ArmysalgDataAccess.Database
{
    public class SalesOrderDatabaseAccess : ISalesOrderDatabaseAccess
    {
        readonly string _connectionString;
        private ISalesLineItemDatabaseAcces _salelineitem;
        private IShippingDatabaseAccess _shipping;
        private IEmployeeDatabaseAccess _employee;
        private ICustomerDatabaseAccess _customer;

        public SalesOrderDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
            _salelineitem = new SalesLineItemDatabaseAccess(configuration);
            _shipping = new ShippingDatabaseAccess(configuration);
            _employee = new EmployeeDatabaseAccess(configuration);
            _customer = new CustomerDatabaseAccess(configuration);
        }

        // For test
        public SalesOrderDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
            _salelineitem = new SalesLineItemDatabaseAccess(inConnectionString);
            _shipping = new ShippingDatabaseAccess(inConnectionString);
            _employee = new EmployeeDatabaseAccess(inConnectionString);
            _customer = new CustomerDatabaseAccess(inConnectionString);
        }

        public int CreateSalesOrder(SalesOrder aSalesOrder)
        {
            int insertedSalesOrderId = -1;

            string insertSalesOrderString = "insert into SalesOrder (salesDate, paymentAmount, status, shipping_id_fk, employeeNo_fk, customerNo_fk) " +
            "OUTPUT INSERTED.salesNo values(@SalesDate, @PaymentAmount, @Status, @ShippingId, @EmployeeId, @CustomerId )";

            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand CreateCommand = new SqlCommand(insertSalesOrderString, con))
                {
                    SqlParameter shippingParam = new SqlParameter("@ShippingId", DBNull.Value);
                    SqlParameter employeeParam = new SqlParameter("@EmployeeId", DBNull.Value);
                    SqlParameter customerParam = new SqlParameter("@CustomerId", DBNull.Value);

                    SqlParameter salesDateParam = new SqlParameter("@SalesDate", aSalesOrder.SalesDate);
                    CreateCommand.Parameters.Add(salesDateParam);
                    SqlParameter paymentAmountParam = new SqlParameter("@PaymentAmount", aSalesOrder.PaymentAmount);
                    CreateCommand.Parameters.Add(paymentAmountParam);
                    SqlParameter statusParam = new SqlParameter("@Status", aSalesOrder.Status);
                    CreateCommand.Parameters.Add(statusParam);

                    //Set Shipping ID if Shipping is not null
                    if (aSalesOrder.Shipping != null)
                    {
                        shippingParam = new SqlParameter("@ShippingId", aSalesOrder.Shipping.Id);
                    }
                    CreateCommand.Parameters.Add(shippingParam);

                    //Set Employee ID if Employee is not null
                    if (aSalesOrder.Employee != null)
                    {
                        employeeParam = new SqlParameter("@EmployeeId", aSalesOrder.Employee.EmployeeNo);
                    }
                    CreateCommand.Parameters.Add(employeeParam);

                    //Set Customer ID if Customer is not null
                    if (aSalesOrder.Customer != null)
                    {
                        customerParam = new SqlParameter("@CustomerId", aSalesOrder.Customer.CustomerNo);
                    }
                    CreateCommand.Parameters.Add(customerParam);

                    con.Open();
                    insertedSalesOrderId = (int)CreateCommand.ExecuteScalar();
                }

                foreach (SalesLineItem salesLine in aSalesOrder.SalesLineItem)
                {
                    AddSalesLineItemToSalesOrder(salesLine, insertedSalesOrderId);
                }

                // The Complete method commits the transaction. If an exception has been thrown,
                // Complete is not called and the transaction is rolled back.
                scope.Complete();
            }
            return insertedSalesOrderId;
        }

        private bool AddSalesLineItemToSalesOrder(SalesLineItem aSalesLineItem, int salesOrderId)
        {
            int numRowsUpdated = 0;
            string queryString = "update SalesLineItem set cart_id_fk = @CartId, salesNo_fk = @SalesNo from SalesLineItem where id = @Id ";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                numRowsUpdated = con.Execute(queryString, new
                {
                    CartId = (int?)null,
                    SalesNo = salesOrderId,
                    Id = aSalesLineItem.Id
                });
            }

            return (numRowsUpdated == 1);
        }

        public SalesOrder GetSalesOrderById(int salesOrderId)
        {
            SalesOrder foundSalesOrder = null;

            string getSalesOrderIdString = "select salesNo, salesDate, paymentAmount, status, shipping_id_fk, employeeNo_fk, customerNo_fk from SalesOrder where salesNo = @Id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(getSalesOrderIdString, con))
            {
                SqlParameter idParam = new SqlParameter("@Id", salesOrderId);
                readCommand.Parameters.Add(idParam);
                con.Open();

                SqlDataReader salesOrderReader = readCommand.ExecuteReader();
                foundSalesOrder = new SalesOrder();
                while (salesOrderReader.Read())
                {
                    foundSalesOrder = GetSalesOrderFromReader(salesOrderReader);
                }
            }
            return foundSalesOrder;
        }

        private SalesOrder GetSalesOrderFromReader(SqlDataReader salesOrderReader)
        {
            SalesOrder foundSalesOrder;
            int tempId;
            Shipping tempShipping = null;
            Customer tempCustomer = null;
            Employee tempEmployee = null;
            string tempStatus;
            decimal tempPayMentAmount;
            DateTime tempSalesDate;
            List<SalesLineItem> tempSalesItem = null;
            int? tempShipId;
            int? tempEmpId;
            int? tempCusId;


            tempId = salesOrderReader.GetInt32(salesOrderReader.GetOrdinal("salesNo"));
            tempSalesDate = salesOrderReader.GetDateTime(salesOrderReader.GetOrdinal("salesDate"));
            tempPayMentAmount = salesOrderReader.GetDecimal(salesOrderReader.GetOrdinal("paymentAmount"));
            tempStatus = salesOrderReader.GetString(salesOrderReader.GetOrdinal("status"));


            if (!salesOrderReader.IsDBNull(salesOrderReader.GetOrdinal("shipping_id_fk")))
            {
                tempShipId = salesOrderReader.GetInt32(salesOrderReader.GetOrdinal("shipping_id_fk"));
                tempShipping = _shipping.GetShippingByShippingID(tempShipId);
            }

            if (!salesOrderReader.IsDBNull(salesOrderReader.GetOrdinal("employeeNo_fk")))
            {
                tempEmpId = salesOrderReader.GetInt32(salesOrderReader.GetOrdinal("employeeNo_fk"));
                tempEmployee = _employee.GetEmployeeByEmployeeNo(tempEmpId);
            }

            if (!salesOrderReader.IsDBNull(salesOrderReader.GetOrdinal("customerNo_fk")))
            {
                tempCusId = salesOrderReader.GetInt32(salesOrderReader.GetOrdinal("customerNo_fk"));
                tempCustomer = _customer.GetCustomerByCustomerNo(tempCusId);
            }

            tempSalesItem = _salelineitem.GetSalesLineItems(null, tempId);


            foundSalesOrder = new SalesOrder(tempId, tempSalesDate, tempPayMentAmount, Enum.Parse<SalesOrderStatus>(tempStatus), tempSalesItem, tempShipping, tempEmployee, tempCustomer);

            return foundSalesOrder;
        }
    }

}
