﻿using ArmysalgDataAccess.ModelLayer;
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

        public SalesOrder GetSalesOrderById(int salesOrderId)
        {
            throw new NotImplementedException();
        }
    }

}
