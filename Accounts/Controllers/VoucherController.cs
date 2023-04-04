using Accounts.Common.DataTable_Model;
using Accounts.Common.Response_Model;
using Accounts.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Accounts.Services.Services;
using Accounts.Common.Virtual_Models;

namespace Accounts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    { 
        private readonly IAccountVoucherMasterServices _IAccountVoucherMasterServices;
        private readonly IAccountVoucherTypeServices _IAccountVoucherTypeServices;
        private readonly IAccountVoucherDetailServices _IAccountVoucherDetailServices;
        private readonly DataResponse responseModel = new DataResponse();
        public VoucherController(IAccountVoucherMasterServices iAccountVoucherMasterServices, IAccountVoucherTypeServices iAccountVoucherTypeServices, IAccountVoucherDetailServices iAccountVoucherDetailServices)
        {
            _IAccountVoucherMasterServices = iAccountVoucherMasterServices;
            _IAccountVoucherTypeServices = iAccountVoucherTypeServices;
            _IAccountVoucherDetailServices = iAccountVoucherDetailServices;
        }


        //Accont Voucher Type API Starting...
        [HttpPost("Add_AccountVoucherType")]
        public IActionResult Add_AccountVoucherType(VM_AccountVoucherType vM_AccountVoucherType)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAccountVoucherTypeServices.AddAccountVoucherType(vM_AccountVoucherType);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpGet("Get_All_AccountVoucherType")]
        public IActionResult Get_AllAccountVouherType(FilterModel filter)
        {
            responseModel.data = _IAccountVoucherTypeServices.GetAllAccountVoucherType(filter);

            responseModel.PageRecords = responseModel.data.Count;

            if (responseModel.data != null)
            {
                return Ok(new { Response = responseModel });
            }
            return NoContent();
        }

        [HttpGet("Find_AccountVoucherType")]
        public IActionResult Find_AccountVoucherType(int id)
        {
            if (id > 0)
            {

                var data = _IAccountVoucherTypeServices.FindAccountVoucherType(id);
                if (data.AcVoucherTypeId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_AccountVoucherType")]
        public IActionResult Update_AccountVoucherType(VM_AccountVoucherType vM_AccountVoucherType)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (vM_AccountVoucherType.AcVoucherTypeId > 0)
                {

                    flag = _IAccountVoucherTypeServices.UpdateAccountVoucherType(vM_AccountVoucherType);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_AccountVoucherType")]
        public IActionResult Delete_AccountVoucherType(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _IAccountVoucherTypeServices.DeleteAccountVoucherType(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }

        //Accont Vocuher Master API Starting...
        [HttpPost("Add_AccountVoucherMaster")]
        public IActionResult Add_AccountVoucherMaster(VM_AccountVoucherMaster vM_AccountVoucherMaster)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAccountVoucherMasterServices.AddAccountVoucherMaster(vM_AccountVoucherMaster);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpGet("Get_All_AccountVoucherMaster")]
        public IActionResult Get_AllAccountVouherMaster(FilterModel filter)
        {
            responseModel.data = _IAccountVoucherMasterServices.GetAllAccountVoucherMaster(filter);

            responseModel.PageRecords = responseModel.data.Count;

            if (responseModel.data != null)
            {
                return Ok(new { Response = responseModel });
            }
            return NoContent();
        }

        [HttpGet("Find_AccountVoucherMaster")]
        public IActionResult Find_AccountVoucherMaster(int id)
        {
            if (id > 0)
            {

                var data = _IAccountVoucherMasterServices.FindAccountVoucherMaster(id);
                if (data.AcVoucherTypeId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_AccountVoucherMaster")]
        public IActionResult Update_AccountVoucherMaster(VM_AccountVoucherMaster vM_AccountVoucherMaster)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (vM_AccountVoucherMaster.AcVoucherMasterId > 0)
                {

                    flag = _IAccountVoucherMasterServices.UpdateAccountVoucherMaster(vM_AccountVoucherMaster);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_AccountVoucherMaster")]
        public IActionResult Delete_AccountVoucherMaster(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _IAccountVoucherMasterServices.DeleteAccountVoucherMaster(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }


        //Accont Vocuher Detail API Starting...
        [HttpPost("Add_AccountVoucherDetail")]
        public IActionResult Add_AccountVoucherDetail(VM_AccountVoucherDetail vM_AccountVoucherDetail)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAccountVoucherDetailServices.AddAccountVoucherDetail(vM_AccountVoucherDetail);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpGet("Get_All_AccountVoucherDetail")]
        public IActionResult Get_AllAccountVouherDetail(FilterModel filter)
        {
            responseModel.data = _IAccountVoucherDetailServices.GetAllAccountVoucherDetail(filter);

            responseModel.PageRecords = responseModel.data.Count;

            if (responseModel.data != null)
            {
                return Ok(new { Response = responseModel });
            }
            return NoContent();
        }

        [HttpGet("Find_AccountVoucherDetail")]
        public IActionResult Find_AccountVoucherDetial(int id)
        {
            if (id > 0)
            {

                var data = _IAccountVoucherDetailServices.FindAccountVoucherDetail(id);
                if (data.AcVoucherId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_AccountVoucherDetail")]
        public IActionResult Update_AccountVoucherDetail(VM_AccountVoucherDetail vM_AccountVoucherDetial)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (vM_AccountVoucherDetial.AcVoucherId > 0)
                {

                    flag = _IAccountVoucherDetailServices.UpdateAccountVoucherDetail(vM_AccountVoucherDetial);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_AccountVoucherDetail")]
        public IActionResult Delete_AccountVoucherDetail(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _IAccountVoucherDetailServices.DeleteAccountVoucherDetail(id);
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
