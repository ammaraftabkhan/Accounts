using Accounts.Common.Virtual_Models;
using Accounts.Repository.Repository;
using Accounts.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CivilEntitiesController : ControllerBase
    {
        private readonly ILanguageServices _ILanguageServices;
        private readonly ICurrencyServices _ICurrencyServices;
        private readonly ICivilEntitiesServices _ICivilEntitiesServices;
        private readonly ICivilLevelServices _ICivilLevelServices;
        private readonly ICivilEntitiesLanguageServices _ICivilEntitiesLanguageServices;
        private readonly ICivilEntitiesCurrencyServices _ICivilEntitiesCurrencyServices;

        public CivilEntitiesController(
            ILanguageServices iLanguageServices,
            ICurrencyServices iCurrencyServices,
            ICivilEntitiesServices iCivilEntitiesServices,
            ICivilLevelServices iCivilLevelServices,
            ICivilEntitiesLanguageServices iCivilEntitiesLanguageServices,
            ICivilEntitiesCurrencyServices iCivilEntitiesCurrencyServices
            )
        {


            _ILanguageServices = iLanguageServices;
            _ICurrencyServices = iCurrencyServices;
            _ICivilEntitiesServices = iCivilEntitiesServices;
            _ICivilLevelServices = iCivilLevelServices;
            _ICivilEntitiesLanguageServices = iCivilEntitiesLanguageServices;
            _ICivilEntitiesCurrencyServices = iCivilEntitiesCurrencyServices;
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
        public IActionResult Delete_CivilLevel(int id)
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
    }
}
