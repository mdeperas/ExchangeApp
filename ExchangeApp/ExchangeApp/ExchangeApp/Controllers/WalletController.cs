using ExchangeApp.API.Services.Interfaces;
using ExchangeApp.Repository.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Http;

namespace ExchangeApp.API.Controllers
{
    [RoutePrefix("api/wallet")]
    public class WalletController : ApiController
    {
        private IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [Authorize]
        public IHttpActionResult Get()
        {
            return Ok(_walletService.GetUserWallet(User.Identity.GetUserName()));
        }

        [Authorize]
        [HttpPost]
        public async Task<IHttpActionResult> Create(Wallet wallet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _walletService.CreateWallet(wallet, User.Identity.GetUserName());

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}