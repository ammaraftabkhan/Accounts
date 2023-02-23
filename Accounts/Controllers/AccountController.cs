using Accounts.Core.Context;
using Accounts.Core.Models;
using Accounts.Repository.Implementation;
using Accounts.Repository.Repository;
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
  
        private readonly IAccountHeadTypeServices _IAccountHeadTypeServices;
        public AccountController(IAccountHeadTypeServices _IAccountHeadTypeServices)
        {
            this._IAccountHeadTypeServices = _IAccountHeadTypeServices;
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


    }
}
