using Accounts.Common.Virtual_Models;
using Accounts.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Accounts.Services.Services;

namespace Accounts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly IAccountTransTypeServices _IAccountTransTypeServices;
        private readonly IAccountFiscalYearServices _IAccountFiscalYearServices;
        
        public TransactionController(

            IAccountTransTypeServices iaccountTransTypeServices,
            IAccountFiscalYearServices iAccountFiscalYearServices
            )
        {

            _IAccountTransTypeServices = iaccountTransTypeServices;
            _IAccountFiscalYearServices = iAccountFiscalYearServices;
        }


        //Accont Tans Type API Starting...
        [HttpPost("Add_AccountTransType")]
        public IActionResult Add_AccountTransType(VM_AccountTransType vM_AccountTransType)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAccountTransTypeServices.AddAccountTransType(vM_AccountTransType);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpGet("Get_All_AccountTransType")]
        public IActionResult Get_AllAccountTransType()
        {

            var get = _IAccountTransTypeServices.GetAllAccountTranstype();

            if (get != null)
            {
                return Ok(new { list = get });
            }
            return NoContent();
        }

        [HttpGet("Find_AccountTransType")]
        public IActionResult Find_AccountTransType(int id)
        {
            if (id > 0)
            {

                var data = _IAccountTransTypeServices.FindAccountTransType(id);
                if (data.AcTransTypeId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_AccountTransType")]
        public IActionResult Update_AccountTrnasType(VM_AccountTransType vM_AccountTransType)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (vM_AccountTransType.AcTransTypeId > 0)
                {

                    flag = _IAccountTransTypeServices.UpdateAccountTransType(vM_AccountTransType);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_AccountTransType")]
        public IActionResult Delete_AccountTransType(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _IAccountTransTypeServices.DeleteAccountTransType(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }


        //FiscalYear API Starting...
        [HttpPost("Add_FiscalYear")]
        public IActionResult Add_FiscalYear(VM_AccountFiscalYear vM_AccountFiscalYear)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAccountFiscalYearServices.AddFiscalYear(vM_AccountFiscalYear);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpGet("Get_All_FiscalYears")]
        public IActionResult Get_All_FiscalYears()
        {

            var get = _IAccountFiscalYearServices.GetAllFiscalYear();

            if (get != null)
            {
                return Ok(new { list = get });
            }
            return NoContent();
        }

        [HttpGet("Find_FiscalYear")]
        public IActionResult Find_FiscalYear(long id)
        {
            if (id > 0)
            {

                var data = _IAccountFiscalYearServices.FindFiscalYear(id)
;
                if (data.FiscalYearId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_FiscalYear")]
        public IActionResult Update_FiscalYear(VM_AccountFiscalYear vM_AccountFiscalYear)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (vM_AccountFiscalYear.FiscalYearId > 0)
                {

                    flag = _IAccountFiscalYearServices.UpdateFiscalYear(vM_AccountFiscalYear);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_FiscalYear")]
        public IActionResult Delete_FiscalYear(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _IAccountFiscalYearServices.DeleteFiscalYear(id)
;
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
