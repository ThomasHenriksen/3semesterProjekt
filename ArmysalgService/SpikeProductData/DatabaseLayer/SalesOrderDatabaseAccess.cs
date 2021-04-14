using ArmysalgDataAccess.ModelLayer;
using ArmysalgDataTest;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgDataAccess.DatabaseLayer
{
    public class SalesOrderDatabaseAccess : ISalesOrderAccess
    {
        readonly string _connectionString;

        public SalesOrderDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ArmysalgConnection");
        }

        // For test
        public SalesOrderDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }

        public int CreateSalesOrder(SalesOrder aSalesOrder)
        {
            int insertedSalesOrderId = -1;

            string insertSalesOrderString = "insert into SalesOrder (salesDate, paymentAmount, status, salesLineItem_id_kf, shipping_id_fk, employeeNo_fk, customerNo_fk) " +
            "OUTPUT INSERTED.salesNo values(@SalesDate, @PaymentAmount, @Status, @SalesLineItemsId, @ShippingId, @EmployeeId, @CustomerId)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertSalesOrderString, con))
            {
                SqlParameter salesDateParam = new SqlParameter("@SalesDate", aSalesOrder.SalesDate);
                CreateCommand.Parameters.Add(salesDateParam);
                SqlParameter paymentAmountParam = new SqlParameter("@PaymentAmount", aSalesOrder.PaymentAmount);
                CreateCommand.Parameters.Add(paymentAmountParam);
                SqlParameter statusParam = new SqlParameter("@Status", aSalesOrder.Status);
                CreateCommand.Parameters.Add(statusParam);
                SqlParameter salesLineItemParam = new SqlParameter("@SalesLineItemsId", aSalesOrder.SalesLineItem);
                CreateCommand.Parameters.Add(salesLineItemParam);
                SqlParameter shippingParam = new SqlParameter("@ShippingId", aSalesOrder.ShippingId);
                CreateCommand.Parameters.Add(shippingParam);
                SqlParameter employeeParam = new SqlParameter("@EmployeeId", aSalesOrder.EmployeeId);
                CreateCommand.Parameters.Add(employeeParam);
                SqlParameter customerParam = new SqlParameter("@CustomerId", aSalesOrder.CustomerId);
                CreateCommand.Parameters.Add(customerParam);

                con.Open();
                insertedSalesOrderId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedSalesOrderId;
        }
        public SalesOrder GetSalesOrderById(int salesOrderId)
        {
            SalesOrder foundSalesOrder = null;

            string getSalesOrderIdStrign = "select salesNo, salesDate, paymentAmount, status, salesLineItem_id_kf, shipping_id_fk, employeeNo_fk, customerNo_fk from SalesOrder where salesNo = @Id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(getSalesOrderIdStrign, con))
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
            return null;
        }

        private SalesOrder GetSalesOrderFromReader(SqlDataReader salesOrderReader)
        {
            SalesOrder foundSalesOrder;
            int tempId, tempSalesLineItem, tempShipping, tempCustomer, tempEmployee;
            string tempStatus;
            decimal tempPayMentAmount;
            DateTime tempSalesDate;

            tempId = salesOrderReader.GetInt32(salesOrderReader.GetOrdinal("salesNo"));
            tempSalesDate = salesOrderReader.GetDateTime(salesOrderReader.GetOrdinal("salesDate"));
            tempPayMentAmount = salesOrderReader.GetDecimal(salesOrderReader.GetOrdinal("purchasePrice"));
            tempStatus = salesOrderReader.GetString(salesOrderReader.GetOrdinal("status"));
            tempSalesLineItem = salesOrderReader.GetInt32(salesOrderReader.GetOrdinal("salesLineItem_id_kf"));
            tempShipping = salesOrderReader.GetInt32(salesOrderReader.GetOrdinal("shipping_id_fk"));
            tempEmployee = salesOrderReader.GetInt32(salesOrderReader.GetOrdinal("employeeNo_fk"));
            tempCustomer = salesOrderReader.GetInt32(salesOrderReader.GetOrdinal("customerNo_fk"));

            foundSalesOrder = new SalesOrder(tempId, tempSalesDate, tempPayMentAmount, tempStatus, tempSalesLineItem, tempShipping, tempEmployee, tempCustomer);           

            return foundSalesOrder;
        }
    }

}
