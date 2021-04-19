using Dapper;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.Customers;
using MedicalExamination.Domain.Responses.Customers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.DAL.Implement
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(IConfiguration config) : base(config)
        {

        }
        public async Task<CreateCustomerRes> CreateCustomer(CreateCustomerReq request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@FirstName", request.FirstName);
            parameters.Add(name: "@LastName", request.LastName);
            parameters.Add(name: "@DateOfBirth", request.DateOfBirth);
            parameters.Add(name: "@Adress", request.Adress);
            parameters.Add(name: "@PhoneNumber", request.PhoneNumber);
            parameters.Add(name: "@IdentityNumber", request.IdentityNumber);
            parameters.Add(name: "@Email", request.Email);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<CreateCustomerRes>(
                                                            cnn: connection,
                                                            sql: "[sp_CreateCustomer]",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception)
                {
                    return new CreateCustomerRes();
                }
            }
        }

        public async Task<UpdateCustomerRes> UpdateCustomer(UpdateCustomerReq request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@CustomerId", request.CustomerId);
            parameters.Add(name: "@FirstName", request.FirstName);
            parameters.Add(name: "@LastName", request.LastName);
            parameters.Add(name: "@DateOfBirth", request.DateOfBirth);
            parameters.Add(name: "@Adress", request.Adress);
            parameters.Add(name: "@PhoneNumber", request.PhoneNumber);
            parameters.Add(name: "@IdentityNumber", request.IdentityNumber);
            parameters.Add(name: "@Email", request.Email);
            parameters.Add(name: "@Message", "", DbType.String, ParameterDirection.Output);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<Customer>(
                                                            cnn: connection,
                                                            sql: "sp_UpdateCustomer",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure))
            {
                try
                {
                    UpdateCustomerRes editRes = new UpdateCustomerRes();
                    editRes.Customer = await result;
                    editRes.Message = parameters.Get<string>("@Message");
                    return editRes;
                }
                catch (Exception)
                {
                    return new UpdateCustomerRes();
                }
            }
        }

        public async Task<Customer> GetCustomerById(string customerId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<Customer>(
                                                cnn: connection,
                                                sql: "sp_GetCustomerById",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception ex)
                {
                    return new Customer();
                }
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            using (var result = SqlMapper.QueryAsync<Customer>(cnn: connection,
                                                       sql: "sp_GetAllCustomer",
                                                       commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception)
                {
                    return new List<Customer>();
                }
            }
        }

        public async Task<IEnumerable<Customer>> SearchByNameOrIdentityNumberAscByFirstName(string keyWord)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@SearchKey", keyWord);

            using (var result = SqlMapper.QueryAsync<Customer>(
                                              cnn: connection,
                                              sql: "sp_SearchByNameOrIdentityNumberAscByFirstName",
                                              param: parameters,
                                              commandType: CommandType.StoredProcedure))
                try
                {
                    return await result;
                }
                catch (Exception)
                {
                    return new List<Customer>();
                }
        }
    }
}

