using Accounts.Common.Virtual_Models;
using Accounts.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Accounts.Services.Services;
using Accounts.Common.DataTable_Model;
using Accounts.Common.Response_Model;
using Accounts.Services.Implementation;
using Accounts.Common.Filter_Models;

namespace Accounts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase

    {

        private readonly IAccountTransTypeServices _IAccountTransTypeServices;
        private readonly IAccountFiscalYearServices _IAccountFiscalYearServices;
        private readonly IAccountTransMasterServices _IAccountTransMasterServices;
        private readonly IAccountTransDetailServices _IAccountTransDetailServices;
        private readonly DataResponse responseModel = new DataResponse();

        public TransactionController(

            IAccountTransTypeServices iaccountTransTypeServices,
            IAccountFiscalYearServices iAccountFiscalYearServices,
            IAccountTransMasterServices iAccountTransMasterServices,
            IAccountTransDetailServices iAccountTransDetailServices
            )
        {

            _IAccountTransTypeServices = iaccountTransTypeServices;
            _IAccountFiscalYearServices = iAccountFiscalYearServices;
            _IAccountTransMasterServices = iAccountTransMasterServices;
            _IAccountTransDetailServices = iAccountTransDetailServices;
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

        [HttpPost("Get_All_AccountTransType")]
        public IActionResult Get_AllAccountTransType(FilterModel filter)
        {
            responseModel.data = _IAccountTransTypeServices.GetAllAccountTranstype(filter);

            responseModel.PageRecords = responseModel.data.Count;

            if (responseModel.data != null)
            {
                return Ok(new { Response = responseModel });
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

        [HttpPost("Get_All_FiscalYears")]
        public IActionResult Get_All_FiscalYears(FilterModel filter)
        {

            responseModel.data = _IAccountFiscalYearServices.GetAllFiscalYear(filter);

            responseModel.PageRecords = responseModel.data.Count;

            if (responseModel.data != null)
            {
                return Ok(new { Response = responseModel });
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


        //Accont Tans Master Starting...
        [HttpPost("Add_AccountTransMaster")]
        public async Task<IActionResult> Add_AccountTransMaster(VM_AccountTransMaster vM_AccountTransMaster)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = await _IAccountTransMasterServices.AddAccountTransMaster(vM_AccountTransMaster);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpPost("Get_All_AccountTransMaster")]
        public IActionResult Get_AllAccountTransMaster(FilterModel filter)
        {

            responseModel.data = _IAccountTransMasterServices.GetAllAccountTransMaster(filter);

            responseModel.PageRecords = responseModel.data.Count;

            if (responseModel.data != null)
            {
                return Ok(new { Response = responseModel });
            }
            return NoContent();
        }

        [HttpGet("Find_AccountTransMaster")]
        public async Task<IActionResult> Find_AccountTransMaster(long id)
        {
            if (id > 0)
            {

                var data = await _IAccountTransMasterServices.FindAccountTransMaster(id);
                if (data.AcTransMasterId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_AccountTransMaster")]
        public IActionResult Update_AccountTrnasMaster(VM_AccountTransMaster vM_AccountTransMaster)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (vM_AccountTransMaster.AcTransMasterId > 0)
                {

                    flag = _IAccountTransMasterServices.UpdateAccountTransMaster(vM_AccountTransMaster);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_AccountTransMaster")]
        public async Task<IActionResult> Delete_AccountTransMaster(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = await _IAccountTransMasterServices.DeleteAccountTransMaster(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }
        [HttpPost("GetTransDtls")]

        public IActionResult Get_TransDtls(TransactionFilter tFilter)
        {
            responseModel.data = _IAccountTransMasterServices.GetTransDtls(tFilter);

            responseModel.PageRecords = responseModel.data.Count;

            if (responseModel.data != null)
            {
                return Ok(new { Response = responseModel });
            }
            return NoContent();
        }


        //Accont Tans Type API Starting...
        [HttpPost("Add_AccountTransDetails")]
        public IActionResult Add_AccountTransDetails(VM_AccountTransDetail vM_AccountTransDetail)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAccountTransDetailServices.AddAccountTransDetail(vM_AccountTransDetail);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpGet("Get_All_AccountTransDetail")]
        public IActionResult Get_AllAccountTransDetail(FilterModel filter)
        {

            responseModel.data = _IAccountTransDetailServices.GetAllAccountTransDetail(filter);

            responseModel.PageRecords = responseModel.data.Count;

            if (responseModel.data != null)
            {
                return Ok(new { Response = responseModel });
            }
            return NoContent();
        }

        [HttpGet("Find_AccountTransDetail")]
        public IActionResult Find_AccountTransDetail(long id)
        {
            if (id > 0)
            {

                var data = _IAccountTransDetailServices.FindAccountTransDetial(id);
                if (data.AcTransDetailId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_AccountTransDetail")]
        public IActionResult Update_AccountTrnasDetail(VM_AccountTransDetail vM_AccountTransDetail)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (vM_AccountTransDetail.AcTransMasterId > 0)
                {

                    flag = _IAccountTransDetailServices.UpdateAccountTransDetail(vM_AccountTransDetail);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_AccountTransDetail")]
        public IActionResult Delete_AccountTransDetail(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _IAccountTransDetailServices.DeleteAccountTransDetail(id);
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
