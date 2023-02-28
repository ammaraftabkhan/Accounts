using Accounts.Common.Virtual_Models;
using Accounts.Core.Context;
using Accounts.Core.Models;
using Accounts.Repository.Implementation;
using Accounts.Repository.Repository;
using Accounts.Services.Implementation;
using Accounts.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace Accounts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountHeadsServices _accountHeadsServices;
  
        private readonly IAccountHeadTypeServices _IAccountHeadTypeServices;
        private readonly IAccountControlServices _IAccountControlServices;
        private readonly IAccountLedgerServices _IAccountLedgerServices;
        private readonly IAccountSubLedgerServices _IAccountSubLedgerServices;
        public AccountController(IAccountHeadTypeServices _IAccountHeadTypeServices, IAccountHeadsServices _AccountHeadServices,IAccountControlServices accountControlServices, IAccountLedgerServices iAccountLedgerServices, IAccountSubLedgerServices iAccountSubLedgerServices)
        {
            this._IAccountHeadTypeServices = _IAccountHeadTypeServices;
            _accountHeadsServices = _AccountHeadServices;
            _IAccountControlServices = accountControlServices;
            _IAccountLedgerServices = iAccountLedgerServices;
            _IAccountSubLedgerServices = iAccountSubLedgerServices;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            
            return Ok();
        }

        [HttpPost("Add_AccountHeadType")]
        public IActionResult Add_AccountHeadType(VM_AccountHeadType _VM_AccountHeadType)
        {
            bool Flag = false;
            if(ModelState.IsValid) 
            {
                Flag= _IAccountHeadTypeServices.Add(_VM_AccountHeadType);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });
                
            }
            return BadRequest(ModelState.Values.SelectMany(x=>x.Errors));
            
        }

        [HttpGet("Get_All_AccountHeadtype")]
        public IActionResult Get_All_AccountHeadtype()
        {
            
           var get = _IAccountHeadTypeServices.GetAccountHeadType();
            
            if(get!=null)
            {
                return Ok(new { list = get });
            }
            return NoContent();
        }

        [HttpPost("Update_AccountHeadType")]
        public IActionResult Update_AccountHeadType(VM_AccountHeadType _VM_AccountHeadType ) 
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (_VM_AccountHeadType.AcHeadTypeId > 0)
                {
                    
                     flag =  _IAccountHeadTypeServices.Update(_VM_AccountHeadType);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }
                    
                }
                return BadRequest(new {msg = "Your given ID not found in database." });
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
            if (id>0)
            {

                var data = _IAccountHeadTypeServices.Find(id);
                if (data != null)
                {
                    return Ok(new { data = data });
                }
            }
            
            return NotFound(new {msg = "No Content found against your ID"});
        }

        [HttpDelete("Delete_AccountHeadType")]
        public IActionResult Delete_AccountHeadType(int id) 
        {
            if(id > 0)
            {
                bool flag = false;
                flag = _IAccountHeadTypeServices.Delete(id);
                if (flag == true)
                {
                    return Ok(new { msg="Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }




        // Account Head API Starting....

        [HttpPost("Add_AccountHead")]
        public IActionResult Add_AccountHead(int id, VM_AccountHeads vM_AccountHeads)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _accountHeadsServices.AddAccountHead(id, vM_AccountHeads);

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
        [HttpGet("Get_All_AccountHead")]
        public IActionResult Get_All_AccountHead()
        {

            var get = _accountHeadsServices.GetAccountHead();

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
                if (data != null)
                {
                    return Ok(new { data = data });
                }
            }

            return NotFound(new { msg = "No Content found against your ID" });
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
        public IActionResult Add_AccountControl(int id, VM_AccountControl vM_AccountControl)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAccountControlServices.AddAccountControl(id, vM_AccountControl);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpGet("Get_All_AccountControl")]
        public IActionResult Get_All_AccountControl()
        {

            var get = _IAccountControlServices.GetAllAccountControl();

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
                if (data != null)
                {
                    return Ok(new { data = data });
                }
            }

            return NotFound(new { msg = "No Content found against your ID" });
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
        public IActionResult Add_AccountLedger(int id, VM_AccountLedger vM_AccountLedger)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAccountLedgerServices.AddAccountLedger(id, vM_AccountLedger);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpGet("Get_All_AccountLedger")]
        public IActionResult Get_All_AccountLedger()
        {

            var get = _IAccountLedgerServices.GetAllAccountLedger();

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
                if (data != null)
                {
                    return Ok(new { data = data });
                }
            }

            return NotFound(new { msg = "No Content found against your ID" });
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
        public IActionResult Add_AccountSubLedger(int id, VM_AccountSubLedger vM_AccountSubLedger)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAccountSubLedgerServices.AddAccountSubLedger(id, vM_AccountSubLedger);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpGet("Get_All_AccountSubLedger")]
        public IActionResult Get_All_AccountSubLedger()
        {

            var get = _IAccountSubLedgerServices.GetAllAccountSubLedger();

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
                if (data != null)
                {
                    return Ok(new { data = data });
                }
            }

            return NotFound(new { msg = "No Content found against your ID" });
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
