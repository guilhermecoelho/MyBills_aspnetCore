using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBills.Domain.Services.Bills;
using AutoMapper;
using MongoDB.Bson;
using System.Text;
using MyBills.Domain.Entities;
using MyBills.API.Response;
using MyBills.API.VIewModels;
using MyBills.API.Helper;
using Microsoft.Extensions.Configuration;

namespace MyBills.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BillsController : Controller
    {
        private IConfiguration _configuration;

        private readonly IMapper _mapper;
        private readonly IBillService _billService;

        public BillsController(IBillService billService, IMapper mapper, IConfiguration configuration)
        {
            this._mapper = mapper;
            this._billService = billService;
            this._configuration = configuration;
        }

        // GET: api/Bills
        /// <summary>
        /// Get all bills
        /// </summary>
        /// <returns> list of bills</returns>
        [HttpGet]
        public async Task<BillResponse> GetAll()
        {
            BillResponse billResponse = new BillResponse();
            try
            {
                var retorno = await _billService.GetAll();

                if (retorno != null)
                {
                    billResponse.BillViewModelList = _mapper.Map<List<BillViewModel>>(retorno);
                    billResponse.Total = billResponse.BillViewModelList.Count;
                }

                billResponse.CodeStatus = (long)Constants.HttpStatusCode.Ok;

                return (billResponse);
            }
            catch (Exception ex)
            {
                billResponse.ErrorMessage = ex.Message;
                billResponse.CodeStatus = (long)Constants.HttpStatusCode.BadRequest;
                return (billResponse);
            }
        }

        /// <summary>
        /// Get a bill by ID
        /// </summary>
        /// <param name="id">Id String</param>
        /// <returns>a bill object</returns>
        [HttpGet("{id}", Name = "GetBills")]
        public async Task<BillResponse> GetById(string id)
        {
            BillResponse billResponse = new BillResponse();
            try
            {
                var retorno = await _billService.GetById(id);

                if (retorno != null)
                {
                    billResponse.BillViewModelList = _mapper.Map<List<BillViewModel>>(retorno);
                    billResponse.Total = billResponse.BillViewModelList.Count;
                }

                billResponse.CodeStatus = (long)Constants.HttpStatusCode.Ok;

                return billResponse;
            }
            catch (Exception ex)
            {
                billResponse.ErrorMessage = ex.Message;
                billResponse.CodeStatus = (long)Constants.HttpStatusCode.BadRequest;

                return billResponse;
            }
        }

        /// <summary>
        /// Add a bill
        /// </summary>
        /// <param name="billVM">bill object</param>
        /// <returns>simple response</returns>
        [HttpPost]
        public async Task<BillResponse> Add([FromBody] List<BillViewModel> billVM)
        {
            BillResponse billResponse = new BillResponse();

            try
            {
                var bill = _mapper.Map<List<Bill>>(billVM);

                var billResult = await _billService.Insert(bill);

                if (!billResult.IsValid)
                {
                    StringBuilder errors = new StringBuilder();
                    foreach (var error in billResult.Errors)
                    {
                        errors.AppendFormat("{0};", error.ErrorMessage);
                    }
                    billResponse.ErrorMessage = errors.ToString();
                }
                else
                {
                    billResponse.CodeStatus = (long)Constants.HttpStatusCode.Ok;
                }
            }
            catch (Exception ex)
            {
                billResponse.ErrorMessage = ex.Message;
                billResponse.CodeStatus = (long)Constants.HttpStatusCode.BadRequest;
            }

            return billResponse;

        }

        /// <summary>
        /// Update a Bill
        /// </summary>
        /// <param name="billVM">bill objct</param>
        /// <returns>simple response</returns>
        [HttpPut]
        public async Task<BillResponse> Update([FromBody] BillViewModel billVM)
        {
            BillResponse billResponse = new BillResponse();

            try
            {
                var bill = _mapper.Map<Bill>(billVM);

                var billResult = await _billService.UpdateBill(bill);

                if (!billResult.IsValid)
                {
                    billResponse.ValidationResult = billResult;
                }
                else
                {
                    billResponse.CodeStatus = (long)Constants.HttpStatusCode.Ok;
                }
            }
            catch (Exception ex)
            {
                billResponse.ErrorMessage = ex.Message;
                billResponse.CodeStatus = (long)Constants.HttpStatusCode.BadRequest;
            }

            return billResponse;
        }

        /// <summary>
        /// remove a bill
        /// </summary>
        /// <param name="Id">Bill Id</param>
        /// <returns>simple response</returns>
        [HttpDelete]
        public async Task<BillResponse> Remove(string Id)
        {
            BillResponse billResponse = new BillResponse();

            try
            {
                Bill bill = new Bill
                {
                    Id = ObjectId.Parse(Id)
                };

                var billResult = await _billService.Delete(bill);

                if (!billResult.IsValid)
                {
                    billResponse.ValidationResult = billResult;
                }
                else
                {
                    billResponse.CodeStatus = (long)Constants.HttpStatusCode.Ok;
                }
            }
            catch (Exception ex)
            {
                billResponse.ErrorMessage = ex.Message;
                billResponse.CodeStatus = (long)Constants.HttpStatusCode.BadRequest;
            }

            return billResponse;
        }
    }
}