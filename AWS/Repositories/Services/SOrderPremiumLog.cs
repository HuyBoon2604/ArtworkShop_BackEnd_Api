﻿using AWS.Models;
using AWS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AWS.Repositories.Services
{
    public class SOrderPremiumLog : IOrderPremiumLog
    {
        private readonly ARTWORKPLATFORMContext cxt;

        public SOrderPremiumLog(ARTWORKPLATFORMContext cxt)
        {
            this.cxt = cxt;
        }

        public async Task<OrderPremiumLog> createPayment(string OrderPremiumId)
        {
            try
            {
                var payment = new OrderPremiumLog();
                var order = await this.cxt.OrderPremia
                              .Where(x => x.OrderPremiumId.Equals(OrderPremiumId))
                              .FirstOrDefaultAsync();
                if (order != null)
                {
                    payment.OrderPremiumLogId = "OPL" + Guid.NewGuid().ToString().Substring(0, 8);
                    payment.OrderPremiumId = order.OrderPremiumId;
                    payment.LogDate = DateTime.Now;
                    payment.Total = order.Total;
                    payment.Status = false;

                    await this.cxt.OrderPremiumLogs.AddAsync(payment);
                    await this.cxt.SaveChangesAsync();
                    return payment;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<OrderPremiumLog>> GetPaymentList()
        {
            try
            {
                var log = await this.cxt.OrderPremiumLogs.ToListAsync();
                if (log != null)
                {
                    return log;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderPremiumLog> GetPaymentLogByOrderPreId(string OrPreId)
        {
            try
            {
                var log = await this.cxt.OrderPremiumLogs.Where(x => x.OrderPremiumId == OrPreId).FirstOrDefaultAsync();
                if (log != null)
                {
                    return log;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderPremiumLog> UpdateStatusSuccess(string LogId)
        {
            try
            {
                var log = await this.cxt.OrderPremiumLogs.Where(x => x.OrderPremiumLogId == LogId).FirstOrDefaultAsync();
                log.Status = true;
                return log;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}