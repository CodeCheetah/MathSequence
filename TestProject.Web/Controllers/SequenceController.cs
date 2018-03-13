using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MathSequence.Logic.Interfaces;
using MathSequence.Web.Interfaces;

namespace MathSequence.Web.Controllers
{
    /// <summary>
    /// Sequence Controller
    /// </summary>
    [RoutePrefix("api/sequence")]
    public class SequenceController : BaseController
    {
        protected readonly ICalculationFactory _calculationFactory;

        public SequenceController(ICalculationFactory calculationFactory)
        {
            _calculationFactory = calculationFactory;
        }

        /// <summary>
        /// Get calculations.
        /// </summary>
        /// <returns>Get calculations.</returns>
        [Route("calculate")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<int>))]
        public IHttpActionResult GetCalculations()
        {
            var results = _calculationFactory.Calculate();
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, results));
        }

        /// <summary>
        /// Get total.
        /// </summary>
        /// <returns>Get total.</returns>
        [Route("sum")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<int>))]
        public IHttpActionResult GetSum(string limit)
        {
            int.TryParse(limit, out int max);
            var results = _calculationFactory.Sum(max);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, results));
        }
    }
}