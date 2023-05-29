using Accounts.Common.DataTable_Model;
using Accounts.Common.Response_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IAccountProfileServices _IAccountProfileServices;
        private readonly IAccountContactServices _IAccountContactServices;
        private readonly IAddressTypeServices _IAddressTypeServices;
        private readonly IAddressServices _IAddressServices;
        private readonly DataResponse responseModel = new DataResponse();
        public ContactController(
            IAccountProfileServices iAccountProfileServices,
            IAccountContactServices iAccountContactServices,
            IAddressTypeServices iAddressTypeServices, 
            IAddressServices iAddressServices
            )
        {
            _IAccountProfileServices = iAccountProfileServices;
            _IAccountContactServices = iAccountContactServices;
            _IAddressTypeServices = iAddressTypeServices;
            _IAddressServices = iAddressServices;
        }

        // Account Profile API Starting...
        [HttpPost("Add_AccountProfile")]
        public IActionResult Add_AccountProfile(VM_AccountProfile vM_AccountProfile)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAccountProfileServices.AddAccountProfile(vM_AccountProfile);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpPost("Get_All_AccountProfile")]
        public IActionResult Get_All_AccountProfile(FilterModel filter)
        {

            responseModel.data = _IAccountProfileServices.GetAllAccountProfile(filter);

            responseModel.PageRecords = responseModel.data.Count;
            //responseModel.TotalRecords = responseModel.data[0].TotalRows;
            if (responseModel.data != null)
            {
                return Ok(new { Response = responseModel });
            }
            return NoContent();
        }

        [HttpGet("Find_AccountProfile")]
        public IActionResult Find_AccountProfile(long id)
        {
            if (id > 0)
            {

                var data = _IAccountProfileServices.FindAccountProfile(id);
                if (data.AcProfileId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_AccountProfile")]
        public IActionResult Update_AccountProfile(VM_AccountProfile _VM_AccountProfile)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (_VM_AccountProfile.AcProfileId > 0)
                {

                    flag = _IAccountProfileServices.UpdateAccountProfile(_VM_AccountProfile);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_AccountProfile")]
        public IActionResult Delete_AccountProfile(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _IAccountProfileServices.DeleteAccountProfile(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }



        // Account Contact API Starting...
        [HttpPost("Add_AccountContact")]
        public IActionResult Add_AccountContact(VM_AccountContact vM_AccountContact)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAccountContactServices.AddAccountContact(vM_AccountContact);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpPost("Get_All_AccountContact")]
        public IActionResult Get_All_AccountContact(FilterModel filter)
        {

            responseModel.data = _IAccountContactServices.GetAllAccountContact(filter);

            responseModel.PageRecords = responseModel.data.Count;
            //responseModel.TotalRecords = responseModel.data[0].TotalRows;
            if (responseModel.data != null)
            {
                return Ok(new { Response = responseModel });
            }
            return NoContent();
        }

        [HttpGet("Find_AccountContact")]
        public IActionResult Find_AccountContact(long id)
        {
            if (id > 0)
            {

                var data = _IAccountContactServices.FindAccountContact(id);
                if (data.AcContactId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_AccountContact")]
        public IActionResult Update_AccountContact(VM_AccountContact _VM_AccountContact)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (_VM_AccountContact.AcContactId > 0)
                {

                    flag = _IAccountContactServices.UpdateAccountContact(_VM_AccountContact);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_AccountContact")]
        public IActionResult Delete_AccountContact(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _IAccountContactServices.DeleteAccountContact(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }


        // Account Contact API Starting...
        [HttpPost("Add_AddressType")]
        public IActionResult Add_AddressType(VM_AddressType vM_AddressType)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAddressTypeServices.AddAddressType(vM_AddressType);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpPost("Get_All_AddressType")]
        public IActionResult Get_All_AddressType(FilterModel filter) 
        {

            responseModel.data = _IAddressTypeServices.GetAllAddressType(filter);

            responseModel.PageRecords = responseModel.data.Count;
            //responseModel.TotalRecords = responseModel.data[0].TotalRows;
            if (responseModel.data != null)
            {
                return Ok(new { Response = responseModel });
            }
            return NoContent();
        }

        [HttpGet("Find_AddressType")]
        public IActionResult Find_AddressType(int id)
        {
            if (id > 0)
            {

                var data = _IAddressTypeServices.FindAddressType(id);
                if (data.AddressTypeId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_AddressType")]
        public IActionResult Update_AddressType(VM_AddressType _VM_AddressType)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (_VM_AddressType.AddressTypeId > 0)
                {

                    flag = _IAddressTypeServices.UpdateAddressType(_VM_AddressType);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_AddressType")]
        public IActionResult Delete_AddressType(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _IAddressTypeServices.DeleteAddressType(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }


        //Addresses API Starting...
        [HttpPost("Add_Address")]
        public IActionResult Add_Address(VM_Address vM_Address)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _IAddressServices.AddAddress(vM_Address);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpPost("Get_All_Addresses")]
        public IActionResult Get_AllAddresses(FilterModel filter)
        {

            responseModel.data = _IAddressServices.GetAllAddress(filter);

            responseModel.PageRecords = responseModel.data.Count;
            //responseModel.TotalRecords = responseModel.data[0].TotalRows;
            if (responseModel.data != null)
            {
                return Ok(new { Response = responseModel });
            }
            return NoContent();
        }

        [HttpGet("Find_Address")]
        public IActionResult Find_Address(int id)
        {
            if (id > 0)
            {

                var data = _IAddressServices.FindAddress(id);
                if (data.AddressId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_Address")]
        public IActionResult Update_Address(VM_Address vM_Address)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (vM_Address.AddressId > 0)
                {

                    flag = _IAddressServices.UpdateAddress(vM_Address);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_Address")]
        public IActionResult Delete_Address(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _IAddressServices.DeleteAddress(id);
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
