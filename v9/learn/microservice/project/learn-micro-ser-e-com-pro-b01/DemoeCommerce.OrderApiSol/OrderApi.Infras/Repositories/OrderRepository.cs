using eCommerce.SharedLibrary.Logs;
using eCommerce.SharedLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using OrderApi.Infras.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Infras.Repositories
{
    public class OrderRepository(OrderDbContext _dbContext) : IOrder
    {
        public async Task<Response> CreateAsync(Order entity)
        {
            try
            {
                var order = _dbContext.Orders.Add(entity).Entity;
                await _dbContext.SaveChangesAsync();
                return order.Id > 0 ? new Response(true, "Order placed successfully!") : new Response(false, "Error occurred while placing order.");
            }
            catch (Exception ex)
            {
                // Log the original exception
                LogException.LogExceptions(ex);

                // display scary-free message to the client
                return new Response(false, "Error occurred while placing order.");
            }
        }

        public async Task<Response> DeleteAsync(Order entity)
        {
            try
            {
                var order = await GetByIdAsync(entity.Id);
                if (order is null)
                {
                    return new Response(false, "Order not found!");
                }

                _dbContext.Orders.Remove(entity);
                await _dbContext.SaveChangesAsync();

                return new Response(true, "Order successfully deleted!");
            }
            catch (Exception ex)
            {
                // Log the original exception
                LogException.LogExceptions(ex);

                // display scary-free message to the client
                return new Response(false, "Error occurred deleting order.");
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            try
            {
                var orders = await _dbContext.Orders.AsNoTracking().ToListAsync();
                return orders is not null ? orders : null!;
            }
            catch (Exception ex)
            {
                // Log the original exception
                LogException.LogExceptions(ex);

                // display scary-free message to the client
                throw new Exception("Error occurred get all order.");
            }
        }

        public async Task<Order> GetByAsync(Expression<Func<Order, bool>> predicate)
        {
            try
            {
                var order = await _dbContext.Orders.Where(predicate).FirstOrDefaultAsync();

                return order is not null ? order : null!;
            }
            catch (Exception ex)
            {
                // Log the original exception
                LogException.LogExceptions(ex);

                // display scary-free message to the client
                throw new Exception("Error occurred get order by.");
            }
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            try
            {
                var order = await _dbContext.Orders!.FindAsync(id);
                return order is not null ? order : null!;
            }
            catch (Exception ex)
            {
                // Log the original exception
                LogException.LogExceptions(ex);

                // display scary-free message to the client
                throw new Exception("Error occurred getting order by Id.");
            }
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(Expression<Func<Order, bool>> predicate)
        {
            try
            {
                var orders = await _dbContext.Orders.Where(predicate).ToListAsync();
                return orders is not null ? orders : null!;
            }
            catch (Exception ex)
            {
                // Log the original exception
                LogException.LogExceptions(ex);

                // display scary-free message to the client
                throw new Exception("Error occurred getting order.");
            }
        }

        public async Task<Response> UpdateAsync(Order entity)
        {
            try
            {
                var order = await GetByIdAsync(entity.Id);
                if (order is null)
                {
                    return new Response(false, $"Order not found");
                }
                _dbContext.Entry(order).State = EntityState.Detached;
                _dbContext.Orders.Update(order);
                await _dbContext.SaveChangesAsync();

                return new Response(true, "Update Order is successfully!");
            }
            catch (Exception ex)
            {
                // Log the original exception
                LogException.LogExceptions(ex);

                // display scary-free message to the client
                return new Response(false, "Error occurred updating order.");
            }
        }
    }
}
