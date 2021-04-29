using ArmysalgDataAccess.Model;
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
            //, shipping_id_fk, employeeNo_fk, customerNo_fk, salesLineItem_id_kf
            string insertSalesOrderString = "insert into SalesOrder (salesDate, paymentAmount, status) " +
            "OUTPUT INSERTED.salesNo values(@SalesDate, @PaymentAmount, @Status)";
            //, @ShippingId, @EmployeeId, @CustomerId, @SalesLineItemsId
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand CreateCommand = new SqlCommand(insertSalesOrderString, con))
                {
                    SqlParameter salesDateParam = new SqlParameter("@SalesDate", aSalesOrder.SalesDate);
                    CreateCommand.Parameters.Add(salesDateParam);
                    SqlParameter paymentAmountParam = new SqlParameter("@PaymentAmount", aSalesOrder.PaymentAmount);
                    CreateCommand.Parameters.Add(paymentAmountParam);
                    SqlParameter statusParam = new SqlParameter("@Status", aSalesOrder.Status);
                    CreateCommand.Parameters.Add(statusParam);
                    //SqlParameter salesLineItemParam = new SqlParameter("@SalesLineItemsId", aSalesOrder.SalesLineItem);
                    //CreateCommand.Parameters.Add(salesLineItemParam);

                    //SqlParameter shippingParam = new SqlParameter("@ShippingId", aSalesOrder.ShippingId);
                    //CreateCommand.Parameters.Add(shippingParam);
                    //SqlParameter employeeParam = new SqlParameter("@EmployeeId", aSalesOrder.EmployeeId);
                    //CreateCommand.Parameters.Add(employeeParam);
                    //SqlParameter customerParam = new SqlParameter("@CustomerId", aSalesOrder.CustomerId);
                    //CreateCommand.Parameters.Add(customerParam);

                    con.Open();
                    insertedSalesOrderId = (int)CreateCommand.ExecuteScalar();
                }
                scope.Complete();
            }
            return insertedSalesOrderId;
        }
        public SalesOrder GetSalesOrderById(int salesOrderId)
        {
            SalesOrder foundSalesOrder = null;

            string getSalesOrderIdString = "select salesNo, salesDate, paymentAmount, status from SalesOrder where salesNo = @Id"; //, shipping_id_fk, employeeNo_fk, customerNo_fk, salesLineItem_id_kf 
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
            int tempId, tempSalesLineItem, tempShipping, tempCustomer, tempEmployee;
            string tempStatus;
            decimal tempPayMentAmount;
            DateTime tempSalesDate;

            tempId = salesOrderReader.GetInt32(salesOrderReader.GetOrdinal("salesNo"));
            tempSalesDate = salesOrderReader.GetDateTime(salesOrderReader.GetOrdinal("salesDate"));
            tempPayMentAmount = salesOrderReader.GetDecimal(salesOrderReader.GetOrdinal("paymentAmount"));
            tempStatus = salesOrderReader.GetString(salesOrderReader.GetOrdinal("status"));
            //tempSalesLineItem = salesOrderReader.GetInt32(salesOrderReader.GetOrdinal("salesLineItem_id_kf"));
            //tempShipping = salesOrderReader.GetInt32(salesOrderReader.GetOrdinal("shipping_id_fk"));
            //if (tempShipping.Equals(null))
            //{
            //    int tempShip = 0;
            //    tempShipping = tempShip;
            //}            
            //tempEmployee = salesOrderReader.GetInt32(salesOrderReader.GetOrdinal("employeeNo_fk"));
            //if (tempEmployee.Equals(null))
            //{
            //    int tempEmp = 0;
            //    tempEmployee = tempEmp;
            //}
            //tempCustomer = salesOrderReader.GetInt32(salesOrderReader.GetOrdinal("customerNo_fk"));
            //if (tempCustomer.Equals(null))
            //{
            //    int tempCus = 0;
            //    tempCustomer = tempCus;
            //}

            foundSalesOrder = new SalesOrder(tempId, tempSalesDate, tempPayMentAmount, Enum.Parse<SalesOrderStatus>(tempStatus));           //, tempShipping, tempEmployee, tempCustomer, tempSalesLineItem, tempStatus

            return foundSalesOrder;
        }
    }

}
