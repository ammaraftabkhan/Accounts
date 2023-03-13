using Accounts.Common;
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
        private readonly IAccountProfileServices _IAccountProfileServices;
        private readonly IAccountContactServices _IAccountContactServices;
        private readonly IAddressTypeServices _IAddressTypeServices;
        private readonly ILanguageServices _ILanguageServices;
        private readonly ICurrencyServices _ICurrencyServices;
        private readonly ICivilEntitiesServices _ICivilEntitiesServices;
        private readonly ICivilLevelServices _ICivilLevelServices;
        private readonly ICivilEntitiesLanguageServices _ICivilEntitiesLanguageServices;
        private readonly ICivilEntitiesCurrencyServices _ICivilEntitiesCurrencyServices;
        private readonly IAddressServices _IAddressServices;
        private readonly IAccountTransTypeServices _IAccountTransTypeServices;
        private readonly IAccountFiscalYearServices _IAccountFiscalYearServices;
        public AccountController(
            IAccountHeadTypeServices _IAccountHeadTypeServices,
            IAccountHeadsServices _AccountHeadServices, 
            IAccountControlServices accountControlServices, 
            IAccountLedgerServices iAccountLedgerServices, 
            IAccountSubLedgerServices iAccountSubLedgerServices,
            IAccountProfileServices iAccountProfileServices,
            IAccountContactServices iAccountContactServices, 
            IAddressTypeServices iAddressTypeServices, 
            ILanguageServices iLanguageServices, 
            ICurrencyServices iCurrencyServices, 
            ICivilEntitiesServices iCivilEntitiesServices, 
            ICivilLevelServices iCivilLevelServices, 
            ICivilEntitiesLanguageServices iCivilEntitiesLanguageServices, 
            ICivilEntitiesCurrencyServices iCivilEntitiesCurrencyServices,
            IAddressServices iAddressServices,
            IAccountTransTypeServices iaccountTransTypeServices,
            IAccountFiscalYearServices iAccountFiscalYearServices
            )
        {
            this._IAccountHeadTypeServices = _IAccountHeadTypeServices;
            _accountHeadsServices = _AccountHeadServices;
            _IAccountControlServices = accountControlServices;
            _IAccountLedgerServices = iAccountLedgerServices;
            _IAccountSubLedgerServices = iAccountSubLedgerServices;
            _IAccountProfileServices = iAccountProfileServices;
            _IAccountContactServices = iAccountContactServices;
            _IAddressTypeServices = iAddressTypeServices;
            _ILanguageServices = iLanguageServices;
            _ICurrencyServices = iCurrencyServices;
            _ICivilEntitiesServices = iCivilEntitiesServices;
            _ICivilLevelServices = iCivilLevelServices;
            _ICivilEntitiesLanguageServices = iCivilEntitiesLanguageServices;
            _ICivilEntitiesCurrencyServices = iCivilEntitiesCurrencyServices;
            _IAddressServices = iAddressServices;
            _IAccountTransTypeServices = iaccountTransTypeServices;
            _IAccountFiscalYearServices = iAccountFiscalYearServices;
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

        [HttpGet("Get_All_AccountHeadtype")]
        public IActionResult Get_All_AccountHeadtype()
        {

            var get = _IAccountHeadTypeServices.GetAccountHeadType();

            if (get != null)
            {
                return Ok(new { list = get });
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

        [HttpGet("Get_All_AccountProfile")]
        public IActionResult Get_All_AccountProfile()
        {

            var get = _IAccountProfileServices.GetAllAccountProfile();

            if (get != null)
            {
                return Ok(new { list = get });
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

        [HttpGet("Get_All_AccountContact")]
        public IActionResult Get_All_AccountContact()
        {

            var get = _IAccountContactServices.GetAllAccountContact();

            if (get != null)
            {
                return Ok(new { list = get });
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

        [HttpGet("Get_All_AddressType")]
        public IActionResult Get_All_AddressType()
        {

            var get = _IAddressTypeServices.GetAllAddressType();

            if (get != null)
            {
                return Ok(new { list = get });
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

        // Language API Starting...
        [HttpPost("Add_Language")]
        public IActionResult Add_Language(VM_Language vM_Language)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _ILanguageServices.AddLanguage(vM_Language);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpGet("Get_All_Language")]
        public IActionResult Get_All_Language()
        {

            var get = _ILanguageServices.GetAllLanguage();

            if (get != null)
            {
                return Ok(new { list = get });
            }
            return NoContent();
        }

        [HttpGet("Find_Language")]
        public IActionResult Find_Language(int id)
        {
            if (id > 0)
            {

                var data = _ILanguageServices.FindLanguage(id);
                if (data.LanguageId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_Language")]
        public IActionResult Update_Language(VM_Language _VM_Language)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (_VM_Language.LanguageId > 0)
                {

                    flag = _ILanguageServices.UpdateLanguage(_VM_Language);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_Language")]
        public IActionResult Delete_Language(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _ILanguageServices.DeleteLanguage(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }
        // Account Contact API Starting...
        [HttpPost("Add_Currency")]
        public IActionResult AddCurrency(VM_Currency vM_Currency)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _ICurrencyServices.AddCurrency(vM_Currency);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpGet("Get_All_Currency")]
        public IActionResult Get_All_Currency()
        {

            var get = _ICurrencyServices.GetAllCurrency();

            if (get != null)
            {
                return Ok(new { list = get });
            }
            return NoContent();
        }

        [HttpGet("Find_currency")]
        public IActionResult Find_Currency(int id)
        {
            if (id > 0)
            {

                var data = _ICurrencyServices.FindCurrency(id);
                if (data.CurrencyId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_Currency")]
        public IActionResult Update_Currency(VM_Currency _VM_Currency)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (_VM_Currency.CurrencyId > 0)
                {

                    flag = _ICurrencyServices.UpdateCurrency(_VM_Currency);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_Currency")]
        public IActionResult Delete_Currency(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _ICurrencyServices.DeleteCurrency(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }
        //Civil Entity API Starting...
        [HttpPost("Add_CivilEntity")]
        public IActionResult Add_CivilEntity(VM_CivilEntity vM_CivilEntity)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _ICivilEntitiesServices.AddACivilEntity(vM_CivilEntity);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpGet("Get_All_CivilEntity")]
        public IActionResult Get_All_CivilEntity()
        {

            var get = _ICivilEntitiesServices.GetAllCivilEntity();

            if (get != null)
            {
                return Ok(new { list = get });
            }
            return NoContent();
        }

        [HttpGet("Find_CivilEntity")]
        public IActionResult Find_CivilEntity(long id)
        {
            if (id > 0)
            {

                var data = _ICivilEntitiesServices.FindCivilEntity(id);
                if (data.CivilEntityId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_CivilEntity")]
        public IActionResult Update_CvivlEntity(VM_CivilEntity _VM_CivilEntity)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (_VM_CivilEntity.CivilEntityId > 0)
                {

                    flag = _ICivilEntitiesServices.UpdateCivilEntity(_VM_CivilEntity);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_CivilEntity")]
        public IActionResult Delete_CivilEntity(long id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _ICivilEntitiesServices.DeleteCivilEntity(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }
        // Civil Language API Starting...
        [HttpPost("Add_CivilLevel")]
        public IActionResult Add_Civilevel(VM_CivilLevel vM_CivilLevel)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _ICivilLevelServices.AddCivilLevel(vM_CivilLevel);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpGet("Get_All_CivilLevel")]
        public IActionResult Get_All_CivilLevel()
        {

            var get = _ICivilLevelServices.GetAllCivilLevel();

            if (get != null)
            {
                return Ok(new { list = get });
            }
            return NoContent();
        }

        [HttpGet("Find_CivilLevel")]
        public IActionResult Find_CivilLevel(int id)
        {
            if (id > 0)
            {

                var data = _ICivilLevelServices.FindCivilLevel(id);
                if (data.CivilLevelId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_CivilLevel")]
        public IActionResult Update_CvilLevel(VM_CivilLevel _VM_CivilLevel)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (_VM_CivilLevel.CivilLevelId > 0)
                {

                    flag = _ICivilLevelServices.UpdateCivilLevel(_VM_CivilLevel);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_CivilLevel")]
        public IActionResult Delete_CivilLevel (int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _ICivilLevelServices.DeleteCivilLevel(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }


        //Civil Entity Language API Starting...
        [HttpPost("Add_CivilEntityLanguage")]
        public IActionResult Add_CivilEntityLanguage(VM_CivilEntitiesLanguage vM_CivilEntityLanguage)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _ICivilEntitiesLanguageServices.AddCivilEntitiesLanguage(vM_CivilEntityLanguage);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpGet("Get_All_CivilEntityLanguage")]
        public IActionResult Get_All_CivilEntityLanguge()
        {

            var get = _ICivilEntitiesLanguageServices.GetCivilEntitiesLanguage();

            if (get != null)
            {
                return Ok(new { list = get });
            }
            return NoContent();
        }

        [HttpGet("Find_CivilEntityLanguage")]
        public IActionResult Find_CivilEntityLanguage(int id)
        {
            if (id > 0)
            {

                var data = _ICivilEntitiesLanguageServices.FindCivilEntitiesLanguage(id);
                if (data.CivilEntitiessLanguagesId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });
            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_CivilEntityLanguage")]
        public IActionResult Update_CvivlEntityLanguage(VM_CivilEntitiesLanguage _VM_CivilEntityLanguage)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (_VM_CivilEntityLanguage.CivilEntitiessLanguagesId > 0)
                {

                    flag = _ICivilEntitiesLanguageServices.UpdateCivilEntitiesLanguage(_VM_CivilEntityLanguage);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_CivilEntityLanguage")]
        public IActionResult Delete_CivilEntityLanguage(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _ICivilEntitiesLanguageServices.DeleteCivilEntitiesLanguage(id);
                if (flag == true)
                {
                    return Ok(new { msg = "Successfully Deleted...!" });
                }
                return NotFound(new { msg = "Sorry, Required data not found in Database" });
            }
            return NotFound(new { msg = "Attention, Your ID is incorrect. Kindly Give id>0." });
        }

        //Civil Entity API Starting...
        [HttpPost("Add_CivilEntityCurrency")]
        public IActionResult Add_CivilEntityCurrency(VM_CivilEntitiesCurrency vM_CivilEntityCurrency)
        {
            bool Flag = false;
            if (ModelState.IsValid)
            {
                Flag = _ICivilEntitiesCurrencyServices.AddCivilEntitiesCurrency(vM_CivilEntityCurrency);

                if (Flag == true)
                {
                    return Ok(new { msg = "Data Saved...!" });
                }
                return BadRequest(new { msg = "Incomplete Data cannot be saved." });

            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
        }

        [HttpGet("Get_All_CivilEntityCurrency")]
        public IActionResult Get_All_CivilEntityCurrency()
        {

            var get = _ICivilEntitiesCurrencyServices.GetAllCivilEntitesCurrency();

            if (get != null)
            {
                return Ok(new { list = get });
            }
            return NoContent();
        }

        [HttpGet("Find_CivilEntityCurrency")]
        public IActionResult Find_CivilEntityCurrency(int id)
        {
            if (id > 0)
            {

                var data = _ICivilEntitiesCurrencyServices.FindCivilEntitesCurrency(id);
                if (data.CivilEntitiesCurrencyId != 0 && data != null && data.IsDeleted == false)
                {
                    return Ok(new { data = data });
                }
                return BadRequest(new { msg = "Your ID is not Found" });

            }

            return NotFound(new { msg = "Kindly Give ID > Zero" });
        }

        [HttpPost("Update_CivilEntityCurrency")]
        public IActionResult Update_CvivlEntityCurrency(VM_CivilEntitiesCurrency _VM_CivilEntityCurrency)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                if (_VM_CivilEntityCurrency.CivilEntitiesCurrencyId > 0)
                {

                    flag = _ICivilEntitiesCurrencyServices.UpdateCivilEntitiesCurrency(_VM_CivilEntityCurrency);
                    if (flag == true)
                    {
                        return Ok(new { msg = "Your data has been updated...!!!" });
                    }

                }
                return BadRequest(new { msg = "Your given ID not found in database." });
            }

            return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

        }

        [HttpDelete("Delete_CivilEntityCurrecny")]
        public IActionResult Delete_CivilEntityCurrency(int id)
        {
            if (id > 0)
            {
                bool flag = false;
                flag = _ICivilEntitiesCurrencyServices.DeleteCivilEntitiesCurrency(id);
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

        [HttpGet("Get_All_Addresses")]
        public IActionResult Get_AllAddresses()
        {

            var get = _IAddressServices.GetAllAddress();

            if (get != null)
            {
                return Ok(new { list = get });
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
