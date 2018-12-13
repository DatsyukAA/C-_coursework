using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Travel.Data;
using Travel.Models.Entites.OrderModels;
using Travel.Models.Entites.UserModels.OperatorModels;
using Travel.Models.ViewModels;

namespace Travel.Controllers
{
    [Authorize(Policy = "operator_access")]
    [Route("api/[controller]/[action]")]
    public class OperatorsController : Controller
    {
        private readonly TravelDbContext dbContext;
        private readonly ClaimsPrincipal user;

        public OperatorsController(TravelDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.user = httpContextAccessor.HttpContext.User;
        }

        [HttpGet]
        public IActionResult getVoucherData()
        {
            var vouchers = dbContext.Vouchers.Include(x => x.Tour).ToArray();
            ArrayList vouchersvm = new ArrayList();
            foreach (Voucher voucher in vouchers)
            {
                vouchersvm.Add(new VouchersVM
                {
                    Id = voucher.Id,
                    TourId = voucher.Tour.Id,
                    Status = voucher.Status,
                    BeginDate = voucher.EnableFrom.ToShortDateString(),
                    EndDate = voucher.EnableTo.ToShortDateString(),
                    InCurrentList = voucher.InCurrentList
                });
            }
            return new OkObjectResult(vouchersvm);
        }

        [HttpPut]
        public IActionResult changeVoucherStatus([FromBody]int id)
        {
            var local_voucher = dbContext.Vouchers.SingleOrDefault(x => x.Id == id);
            local_voucher.InCurrentList = !local_voucher.InCurrentList;
            dbContext.Vouchers.Update(local_voucher);
            dbContext.SaveChanges();
            return getVoucherData();
        }

        
        public List<Voucher> getCurrentList()
        {
            var current_list = dbContext.Vouchers.Include(x => x.Tour).Where(x => x.InCurrentList == true).ToList();
            return current_list;
        }

        [HttpPut]
        public IActionResult sendReport([FromBody]string report)
        {
            Report local_report = new Report
            {
                Operator = dbContext.Operators.Include(x => x.User).SingleOrDefault(x => x.User.Id.ToString() == user.Claims.SingleOrDefault(c => c.Type == "id").Value),
                ReportText = report,
                VoucherList = getCurrentList(),
                SendTime = DateTime.Now
            };

            dbContext.Reports.Add(local_report);
            var test = dbContext.Reports.Include(x => x.VoucherList).LastOrDefault(x => x.ReportText == report);
            dbContext.SaveChanges();
            return new OkResult();
        }
    }
}