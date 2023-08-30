using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalaryManagement.Authorize;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using SalaryManagement.Responses;
using SalaryManagement.Services.FormulaService;
using SalaryManagement.Utility.Validation;
using System;
using System.Threading.Tasks;

namespace SalaryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class FormulaController : ControllerBase
    {
        private readonly ILogger<FormulaController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFormulaService _formulaService;

        public FormulaController(IUnitOfWork unitOfWork, ILogger<FormulaController> logger)
        {
            _formulaService = new FormulaService(unitOfWork);
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region GET api/Formula/GroupAttributes

        /// <summary>
        /// Lấy danh sách tất cả các GroupAttribute
        /// </summary>
        [HttpGet("GroupAttributes")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetGroupAttributes()
        {
            try
            {
                var data = _formulaService.GetGroupAttributes();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found GroupAttribute" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Formula/GroupAttributes

        #region GET api/Formula/GroupAttribute/GetFormulaAttrFunction

        /// <summary>
        /// Lấy danh sách tất cả các FormulaAttribute THUỘC Group Function
        /// </summary>
        [HttpGet("GroupAttribute/GetFormulaAttrFunction")]
        [AuthorizeRoles(UserInfo.ROLE_HR, UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetFormulaAttrFunction()
        {
            try
            {
                var data = _formulaService.GetFormulaAttrFunction();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found GroupAttribute Function" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Formula/GroupAttribute/GetFormulaAttrFunction

        #region GET api/Formula/GroupAttribute/GetFormulaAttrNotFunction

        /// <summary>
        /// Lấy danh sách tất cả các FormulaAttribute KHÔNG THUỘC Group Function
        /// </summary>
        [HttpGet("GroupAttribute/GetFormulaAttrNotFunction")]
        [AuthorizeRoles(UserInfo.ROLE_HR, UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetFormulaAttrNotFunction()
        {
            try
            {
                var data = _formulaService.GetFormulaAttrNotFunction();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found GroupAttribute Not Function" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Formula/GroupAttribute/GetFormulaAttrNotFunction

        #region GET api/Formula/GroupAttributes/FormulaAttributes

        /// <summary>
        /// Lấy danh sách tất cả các GroupAttribute và các FormulaAttribute của GroupAttribute đó
        /// </summary>
        [HttpGet("GroupAttributes/FormulaAttributes")]
        [AuthorizeRoles(UserInfo.ROLE_HR, UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetFormulaAttrsOfGroupAttrs()
        {
            try
            {
                var data = _formulaService.GetFormulaAttrsOfGroupAttrs();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found GroupAttribute" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Formula/GroupAttributes/FormulaAttributes

        #region GET api/Formula/GroupAttributes/FormulaAttribute

        /// <summary>
        /// Lấy danh sách tất cả các FormulaAttribute trong GroupAttribute theo GroupAttributeId
        /// </summary>
        [HttpGet("GroupAttributes/FormulaAttribute")]
        [AuthorizeRoles(UserInfo.ROLE_HR, UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetFormulaAttrInGroupAttr(string groupAttributeId)
        {
            try
            {
                var data = _formulaService.GetFormulaAttrInGroupAttr(groupAttributeId);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found GroupAttribute" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Formula/GroupAttributes/FormulaAttribute

        #region GET api/Formula/GroupAttribute/{id}

        /// <summary>
        /// Lấy một GroupAttribute theo Id
        /// </summary>
        [HttpGet("GroupAttribute/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetGroupAttribute(string id)
        {
            try
            {
                var groupAttribute = _formulaService.GetGroupAttribute(id);

                return groupAttribute != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, groupAttribute))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found GroupAttribute" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Formula/GroupAttribute/{id}

        #region POST api​/Formula/GroupAttribute

        /// <summary>
        /// Thêm mới một GroupAttribute
        /// </summary>
        [HttpPost("GroupAttribute")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PostGroupAttribute([FromBody] GroupAttributeRequest groupAttributeRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string groupAttributeId = Guid.NewGuid().ToString();

                    int created = _formulaService.CreateGroupAttribute(groupAttributeId, groupAttributeRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();

                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { groupAttributeId, groupAttributeRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add GroupAttribute fail" }));
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/Formula/GroupAttribute

        #region PUT api​/Formula/GroupAttribute​/{id}

        /// <summary>
        /// Cập nhật một GroupAttribute theo Id
        /// </summary>
        [HttpPut("GroupAttribute​/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutGroupAttribute(string id, [FromBody] GroupAttributeRequest groupAttributeRequest)
        {
            try
            {
                int update = _formulaService.UpdateGroupAttribute(id, groupAttributeRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, groupAttributeRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found GroupAttribute" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api​/Formula/GroupAttribute​/{id}

        #region PUT api/Formula/GroupAttribute​/{id}/{status}

        /// <summary>
        /// Update trạng thái (IsDisable) của GroupAttribute với Id
        /// </summary>
        [HttpPut("GroupAttribute​/{id}/{status}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutStatusGroupAttribute(string id, bool status)
        {
            try
            {
                int update = _formulaService.DisableGroupAttribute(id, status);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found GroupAttribute" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/Formula/GroupAttribute​{id}/{status}

        #region GET api/Formula/PayPolicies

        /// <summary>
        /// Lấy danh sách tất cả các PayPolicy
        /// </summary>
        [HttpGet("PayPolicies")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetPayPolicies()
        {
            try
            {
                var data = _formulaService.GetPayPolicies();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PayPolicy" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Formula/PayPolicies

        #region GET api/Formula/PayPolicy/{id}

        /// <summary>
        /// Lấy một PayPolicy theo Id
        /// </summary>
        [HttpGet("PayPolicy/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetPayPolicy(string id)
        {
            try
            {
                var salaryBasic = _formulaService.GetPayPolicy(id);

                return salaryBasic != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, salaryBasic))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found FormulaType" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Formula/PayPolicy/{id}

        #region POST api​/Formula/PayPolicy

        /// <summary>
        /// Thêm mới một PayPolicy
        /// </summary>
        [HttpPost("PayPolicy")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PostPayPolicy([FromBody] PayPolicyRequest payPolicyRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string payPolicyId = Guid.NewGuid().ToString();

                    int created = _formulaService.CreatePayPolicy(payPolicyId, payPolicyRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();

                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { payPolicyId, payPolicyRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add PayPolicy fail" }));
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/Formula/PayPolicy

        #region PUT api​/Formula/PayPolicy​/{id}

        /// <summary>
        /// Cập nhật một PayPolicy theo Id
        /// </summary>
        [HttpPut("PayPolicy/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutPayPolicy(string id, [FromBody] PayPolicyRequest payPolicyRequest)
        {
            try
            {
                int update = _formulaService.UpdatePayPolicy(id, payPolicyRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, payPolicyRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PayPolicy" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api​/Formula/PayPolicy​/{id}

        #region GET api/Formula/FormulaAttributes

        /// <summary>
        /// Lấy danh sách tất cả các FormulaAttributes
        /// </summary>
        [HttpGet("FormulaAttributes")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetFormulaAttributes()
        {
            try
            {
                var data = _formulaService.GetFormulaAttributes();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found FormulaAttributes" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Formula/FormulaAttributes

        #region GET api/Formula/FormulaAttribute/search

        /// <summary>
        /// Tìm các FormulaAttribute (theo Attribute)
        /// </summary>
        [HttpGet("search")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetFormulaAttributesByAttribute(string attribute)
        {
            try
            {
                var data = _formulaService.GetFormulaAttributesByAttribute(attribute);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found FormulaAttributes" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Formula/FormulaAttribute/search

        #region GET api/Formula/FormulaAttribute/{id}

        /// <summary>
        /// Lấy một FormulaAttribute theo Id
        /// </summary>
        [HttpGet("FormulaAttribute/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetFormulaAttribute(string id)
        {
            try
            {
                var groupAttribute = _formulaService.GetFormulaAttribute(id);

                return groupAttribute != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, groupAttribute))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found FormulaAttribute" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Formula/FormulaAttribute/{id}

        #region POST api​/Formula/FormulaAttribute

        /// <summary>
        /// Thêm mới một FormulaAttribute
        /// </summary>
        [HttpPost("FormulaAttribute")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PostFormulaAttribute([FromBody] FormulaAttributeRequest formulaAttributeRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string formulaAttributeId = Guid.NewGuid().ToString();

                    int created = _formulaService.CreateFormulaAttribute(formulaAttributeId, formulaAttributeRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();

                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { formulaAttributeId, formulaAttributeRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add GroupAttribute fail" }));
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/Formula/FormulaAttribute

        #region PUT api​/Formula/FormulaAttribute​/{id}

        /// <summary>
        /// Cập nhật một FormulaAttribute theo Id
        /// </summary>
        [HttpPut("FormulaAttribute​/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutFormulaAttribute(string id, [FromBody] FormulaAttributeRequest formulaAttributeRequest)
        {
            try
            {
                int update = _formulaService.UpdateFormulaAttribute(id, formulaAttributeRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, formulaAttributeRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found FormulaAttribute" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api​/Formula/FormulaAttribute​/{id}

        #region PUT api​/Formula/FormulaAttribute​/GroupAttribute

        /// <summary>
        /// Thêm một FormulaAttribute vào một GroupAttribute theo Id
        /// </summary>
        [HttpPut("FormulaAttribute​​/GroupAttribute")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutFormulaAttributeToGroup([FromBody] FormulaAttrGroupRequest formulaAttrGroup)
        {
            try
            {
                int update = _formulaService.AddFormulaAttributeToGroup(formulaAttrGroup);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { formulaAttrGroup } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found FormulaAttribute" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api​/Formula/FormulaAttribute​/GroupAttribute

        #region PUT api/Formula/FormulaAttribute​/{id}/{status}

        /// <summary>
        /// Update trạng thái (IsDisable) của FormulaAttribute với Id
        /// </summary>
        [HttpPut("FormulaAttribute​/{id}/{status}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutStatusFormulaAttribute(string id, bool status)
        {
            try
            {
                int update = _formulaService.DisableFormulaAttribute(id, status);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found FormulaAttribute" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/Formula/FormulaAttribute/​{id}/{status}

        #region GET api/Formula/FormulaAttributeList

        /// <summary>
        /// Lấy danh sách tất cả các FormulaAttribute (Phân trang)
        /// </summary>
        [HttpGet("FormulaAttributeList")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetFormulaAttributeList([FromQuery] Pagination pagination, bool? isDisable)
        {
            try
            {
                var data = _formulaService.GetFormulaAttributeList(pagination, isDisable);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found BasicSalarys" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Formula/FormulaAttributeList

        #region GET api/Formula/Formulas

        /// <summary>
        /// Lấy danh sách tất cả các Formulas
        /// </summary>
        [HttpGet("Formulas")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetFormulas()
        {
            try
            {
                var data = _formulaService.GetFormulas();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found GetFormulas" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Formula/Formulas

        #region GET api/Formula/{id}

        /// <summary>
        /// Lấy một Formula theo Id
        /// </summary>
        [HttpGet("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetFormula(string id)
        {
            try
            {
                var data = _formulaService.GetFormula(id);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Formula" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Formula/{id}

        #region POST api​/Formula

        /// <summary>
        /// Cách 1: Thêm mới một Formula (Cái này quan trọng nhất)
        /// </summary>
        [HttpPost()]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PostFormula([FromBody] FormulaRequest formulaRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string formulaId = Guid.NewGuid().ToString();

                    int created = _formulaService.CreateFormula(formulaId, formulaRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();

                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { formulaId, formulaRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add Formula fail" }));
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Data = ex.Data, Message = ex.Message }));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/Formula

        #region POST api​/Formula/FormulaNotAttribute

        /// <summary>
        /// Cách 2: Thêm mới một Formula KHÔNG CẦN mảng Formula Attribute đính kèm (Nên dùng thay cho Cách 1)
        /// </summary>
        [HttpPost("FormulaNotAttribute")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PostFormulaNotAttribute([FromBody] FormulaNotAttrRequest formulaRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string formulaId = Guid.NewGuid().ToString();

                    int created = _formulaService.CreateFormulaNotAttribute(formulaId, formulaRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();

                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { formulaId, formulaRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add Formula fail" }));
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Data = ex.Data, Message = ex.Message }));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/Formula/FormulaNotAttribute

        #region PUT api/Formula/LecturerType

        /// <summary>
        /// Thêm một Formula vào một LecturerType theo Id
        /// </summary>
        [HttpPut("LecturerType")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutFormulaToLecType([FromBody] FormulaLecTypeRequest formulaLecType)
        {
            try
            {
                int update = _formulaService.AddFormulaToLecType(formulaLecType);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Formula" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/Formula/LecturerType

        #region PUT api​/Formula​/{id}

        /// <summary>
        /// Cách 1: Cập nhật một Formula theo Id
        /// </summary>
        [HttpPut("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutFormula(string id, [FromBody] FormulaRequest formulaRequest)
        {
            try
            {
                int update = _formulaService.UpdateFormula(id, formulaRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, formulaRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Formula" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Data = ex.Data }));
            }
        }

        #endregion PUT api​/Formula​/{id}

        #region PUT api​/Formula/FormulaNotAttribute/{id}

        /// <summary>
        /// Cách 2: Cập nhật một Formula theo Id KHÔNG CẦN mảng Formula Attribute đính kèm (Nên dùng thay cho Cách 1)
        /// </summary>
        [HttpPut("FormulaNotAttribute/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutFormulaNotAttribute(string id, [FromBody] FormulaNotAttrRequest formulaRequest)
        {
            try
            {
                int update = _formulaService.UpdateFormulaNotAttribute(id, formulaRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, formulaRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Formula" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Data = ex.Data, Message = ex.Message }));
            }
        }

        #endregion PUT api​/Formula/FormulaNotAttribute/{id}

        #region PUT api/Formula/{id}/{status}

        /// <summary>
        /// Update trạng thái (IsDisable) của Formula với Id
        /// </summary>
        [HttpPut("{id}/{status}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutStatusFormula(string id, bool status)
        {
            try
            {
                int update = _formulaService.DisableFormula(id, status);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Formula" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/Formula/{id}/{status}

        #region POST api​/Formula/CheckFormula

        /// <summary>
        /// Cách 1: Check một Formula (dùng để check lúc tạo Formula)
        /// </summary>
        [HttpPost("CheckFormula")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> CheckFormula([FromBody] FormulaCheckRequest formulaCheckRequest)
        {
            try
            {
                var data = _formulaService.CheckFormula(formulaCheckRequest);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new { result = data }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Check Formula fail" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Data = ex.Data, Message = ex.Message }));
            }
        }

        #endregion POST api​/Formula/CheckFormula

        #region POST api​/Formula/CheckFormulaNotAttribute

        /// <summary>
        /// Cách 2: Check một Formula KHÔNG CẦN mảng Formula Attribute đính kèm (dùng để check lúc tạo Formula, Khuyến khích dùng thay cho cách 1)
        /// </summary>
        [HttpPost("CheckFormulaNotAttribute")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> CheckFormulaNotAttribute([FromBody] FormulaCheckNotAttrRequest formulaCheckRequest)
        {
            try
            {
                var data = _formulaService.CheckFormulaNotAttribute(formulaCheckRequest);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new { result = data }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Check Formula fail" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Data = ex.Data, Message = ex.Message }));
            }
        }

        #endregion POST api​/Formula/CheckFormulaNotAttribute

        #region GET api/Formula/FormulaAttributeTypes

        /// <summary>
        /// Lấy danh sách tất cả các FormulaAttributeType
        /// </summary>
        [HttpGet("FormulaAttributeTypes")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetFormulaAttributeTypes()
        {
            try
            {
                var data = _formulaService.GetFormulaAttributeTypes();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found FormulaAttributeType" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Formula/FormulaAttributeTypes
    }
}
