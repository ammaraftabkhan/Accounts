﻿using Accounts.Common;
using Accounts.Common.DataTable_Model;
using Accounts.Common.User;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Context;
using Accounts.Core.Models;
using Accounts.Repository.Implementation;
using Accounts.Repository.Repository;
using Accounts.Services.Implementation;
using Accounts.Services.Services;
using MathNet.Numerics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace Accounts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountHeadsServices _accountHeadsServices;
        private readonly IAccountHeadTypeServices _IAccountHeadTypeServices;
        private readonly IAccountControlServices _IAccountControlServices;
        private readonly IAccountLedgerServices _IAccountLedgerServices;
        private readonly IAccountSubLedgerServices _IAccountSubLedgerServices;
        private readonly IJwtService _JwtService;
        public AccountsController(
            IAccountHeadTypeServices _IAccountHeadTypeServices,
            IAccountHeadsServices _AccountHeadServices, 
            IAccountControlServices accountControlServices, 
            IAccountLedgerServices iAccountLedgerServices, 
            IAccountSubLedgerServices iAccountSubLedgerServices,
            IJwtService jwtService
            )
        {
            this._IAccountHeadTypeServices = _IAccountHeadTypeServices;
            _accountHeadsServices = _AccountHeadServices;
            _IAccountControlServices = accountControlServices;
            _IAccountLedgerServices = iAccountLedgerServices;
            _IAccountSubLedgerServices = iAccountSubLedgerServices;
            _JwtService = jwtService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = _JwtService.Authenticate(userLogin);
            if (user != null)
            {
                var token = _JwtService.GenerateToken(user);
                return Ok(token);
            }
            return NotFound("user not found");
        }
        //[Authorize]
        [HttpPost("Add_AccountHeadType")]
        public IActionResult Add_AccountHeadType(VM_AccountHeadType _VM_AccountHeadType)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAccountHeadTypeServices.Add(_VM_AccountHeadType);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        //[Authorize]
        [HttpPost("Get_All_AccountHeadtype")]
        public IActionResult Get_All_AccountHeadtype([FromBody] FilterModel filter)
        {

            var get = _IAccountHeadTypeServices.GetAccountHeadType(filter).ToList();
            var cpoiu  = get.Count;
            if (get != null)
            {
                return Ok(new { list = get, count=cpoiu });
            }
            return NoContent();
        }

        [HttpPost("Update_AccountHeadType")]
        public IActionResult Update_AccountHeadType(VM_AccountHeadType _VM_AccountHeadType)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (_VM_AccountHeadType.AcHeadTypeId > 0)
                {

                    flag = _IAccountHeadTypeServices.Update(_VM_AccountHeadType);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        //[HttpPost("FindPost")]
        //public IActionResult FindPost()
        //{

        //}

        [HttpGet("Find_AccountHeadtype")]
        public IActionResult Find_AccountHeadtype(int id)
        {
            if (id > 0)
            {

                var data = _IAccountHeadTypeServices.Find(id);
                if (data.AcHeadTypeId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpDelete("Delete_AccountHeadType")]
        public IActionResult Delete_AccountHeadType(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _IAccountHeadTypeServices.Delete(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }




        // Account Head API Starting....

        [HttpPost("Add_AccountHead")]
        public IActionResult Add_AccountHead(VM_AccountHeads vM_AccountHeads)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _accountHeadsServices.AddAccountHead(vM_AccountHeads);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }
        [HttpDelete("Delete_AccountHead")]
        public IActionResult Delete_AccountHead(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _accountHeadsServices.DeleteAccountHead(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }
        [HttpPost("Get_All_AccountHead")]
        public IActionResult Get_All_AccountHead([FromBody]FilterModel filter)
        {

            var get = _accountHeadsServices.GetAccountHead(filter);

            if (get != null)
            {
                return Ok(new { list = get });
            }
            return NoContent();
        }
        [HttpGet("Find_AccountHead")]
        public IActionResult Find_AccountHead(long id)
        {
            if (id > 0)
            {

                var data = _accountHeadsServices.FindAccountHead(id);
                if (data.AcHeadId!=0&&data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                
                    return BadRequest(new { msg = "Your ID is not Found" });
                
                
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }
        [HttpPost("Update_AccountHead")]
        public IActionResult Update_AccountHead(VM_AccountHeads _VM_AccountHeads)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (_VM_AccountHeads.AcHeadId > 0)
                {

                    flag = _accountHeadsServices.UpdateAccountHead(_VM_AccountHeads);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }


        // Account Control API Starting...
        [HttpPost("Add_AccountControl")]
        public IActionResult Add_AccountControl(VM_AccountControl vM_AccountControl)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAccountControlServices.AddAccountControl(vM_AccountControl);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpPost("Get_All_AccountControl")]
        public IActionResult Get_All_AccountControl([FromBody]FilterModel filter)
        {

            var get = _IAccountControlServices.GetAllAccountControl(filter);

            if (get != null)
            {
                return Ok(new { list = get });
            }
            return NoContent();
        }

        [HttpGet("Find_AccountControl")]
        public IActionResult Find_AccountControl(long id)
        {
            if (id > 0)
            {

                var data = _IAccountControlServices.FindAccountControl(id);
                if (data.AcControlId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_AccountControl")]
        public IActionResult Update_AccountControl(VM_AccountControl _VM_AccountControl)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (_VM_AccountControl.AcControlId > 0)
                {

                    flag = _IAccountControlServices.UpdateAccountControl(_VM_AccountControl);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_AccountControl")]
        public IActionResult Delete_AccountControl(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _IAccountControlServices.DeleteAccountControl(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }


        // Account Ledger API Starting...
        [HttpPost("Add_AccountLedger")]
        public IActionResult Add_AccountLedger(VM_AccountLedger vM_AccountLedger)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAccountLedgerServices.AddAccountLedger(vM_AccountLedger);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpPost("Get_All_AccountLedger")]
        public IActionResult Get_All_AccountLedger([FromBody] FilterModel filter)
        {

            var get = _IAccountLedgerServices.GetAllAccountLedger(filter);

            if (get != null)
            {
                return Ok(new { list = get });
            }
            return NoContent();
        }

        [HttpGet("Find_AccountLegder")]
        public IActionResult Find_AccountLedger(long id)
        {
            if (id > 0)
            {

                var data = _IAccountLedgerServices.FindAccountLedger(id);
                if (data.AcLedgerId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_AccountLedger")]
        public IActionResult Update_AccountLedger(VM_AccountLedger _VM_AccountLedger)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (_VM_AccountLedger.AcLedgerId > 0)
                {

                    flag = _IAccountLedgerServices.UpdateAccountLegder(_VM_AccountLedger);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_AccountLedger")]
        public IActionResult Delete_AccountLedger(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _IAccountLedgerServices.DeleteAccountLedger(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }


        // Account Sub Ledger API Starting...
        [HttpPost("Add_AccountSubLedger")]
        public IActionResult Add_AccountSubLedger(VM_AccountSubLedger vM_AccountSubLedger)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAccountSubLedgerServices.AddAccountSubLedger(vM_AccountSubLedger);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpPost("Get_All_AccountSubLedger")]
        public IActionResult Get_All_AccountSubLedger([FromBody] FilterModel filter)
        {

            var get = _IAccountSubLedgerServices.GetAllAccountSubLedger(filter);

            if (get != null)
            {
                return Ok(new { list = get });
            }
            return NoContent();
        }

        [HttpGet("Find_AccountSubLegder")]
        public IActionResult Find_AccountSubLedger(long id)
        {
            if (id > 0)
            {

                var data = _IAccountSubLedgerServices.FindAccountSubLedger(id);
                if (data.AcSubLedgerId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_AccountSubLedger")]
        public IActionResult Update_AccountSubLedger(VM_AccountSubLedger _VM_AccountSubLedger)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (_VM_AccountSubLedger.AcSubLedgerId > 0)
                {

                    flag = _IAccountSubLedgerServices.UpdateAccountSubLedger(_VM_AccountSubLedger);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_AccountSubLedger")]
        public IActionResult Delete_AccountSubLedger(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _IAccountSubLedgerServices.DeleteAccountLSubLedger(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }

    }

}
