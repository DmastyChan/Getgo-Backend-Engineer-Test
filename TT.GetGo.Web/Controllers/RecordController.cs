using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TT.GetGo.Core.Domain;
using TT.GetGo.Services.Helper;
using TT.GetGo.Services.Records;
using TT.GetGo.Web.Extensions;
using TT.GetGo.Web.Models;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace TT.GetGo.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecordController : ControllerBase
    {
        private readonly ICarServices _carServices;
        private readonly IRecordServices _recordServices;
        private readonly ILocationServices _locationServices;
        private readonly ICarWorkflow _carWorkflow;
        private readonly IWebHelper _webHelper;
        private readonly IMapper _mapper;
        private readonly IValidator<UserRequest> _userRequestValidator;
        private readonly IValidator<BookRequest> _bookRequestValidator;
        private readonly IValidator<SearchRequest> _searchRequestValidator;
        private readonly IValidator<ReachCarRequest> _reachCarRequestValidator;

        public RecordController(
            ICarServices carServices, 
            IRecordServices recordServices, 
            ILocationServices locationServices, 
            IWebHelper webHelper, 
            IMapper mapper, 
            ICarWorkflow carWorkflow, 
            IValidator<UserRequest> userRequestValidator, 
            IValidator<BookRequest> bookRequestValidator, 
            IValidator<SearchRequest> searchRequestValidator, 
            IValidator<ReachCarRequest> reachCarRequestValidator)
        {
            _carServices = carServices;
            _recordServices = recordServices;
            _locationServices = locationServices;
            _webHelper = webHelper;
            _mapper = mapper;
            _carWorkflow = carWorkflow;
            _userRequestValidator = userRequestValidator;
            _bookRequestValidator = bookRequestValidator;
            _searchRequestValidator = searchRequestValidator;
            _reachCarRequestValidator = reachCarRequestValidator;
        }

        /// <summary>
        /// Retrieve all the cars records
        /// </summary>
        /// <returns></returns>
        [HttpGet(template: "all",Name = "GetAll")]
        public IActionResult GetAll()
        {
            var returnList = new List<CarModel>();
            var caList = _carWorkflow.GetAll();

            if (caList.Any())
                returnList = _mapper.Map<List<CarModel>>(caList);

            return Ok(returnList);
        }
        
        /// <summary>
        /// Search the car with the logic
        /// </summary>
        /// <returns></returns>
        [HttpPost(template: "search",Name = "Search")]
        public IActionResult Search(SearchRequest search)
        {
            ValidationResult result = _searchRequestValidator.Validate(search);

            if (!result.IsValid)
                return ValidationProblem(new ValidationProblemDetails(errors: result.ToErrorDictionary()));

            var returnList = new List<CarModel>();
            var caList = _carWorkflow.GetAll(filterCar: search.SearchKeyWords, x: (int)search.User.X, y: (int)search.User.Y, filterStatus: new []
                {
                    CarStatus.None
                });

            if (caList.Any())
                returnList = _mapper.Map<List<CarModel>>(caList);

            return Ok(returnList);
        }

        /// <summary>
        /// Book Car
        /// </summary>
        /// <param name="book">Book Car Request</param>
        /// <returns></returns>
        [HttpPost(template: "book", Name = "Book")]
        public IActionResult BookAsync(BookRequest book)
        {
            ValidationResult result =  _bookRequestValidator.Validate(book);

            if (!result.IsValid)
                return ValidationProblem(new ValidationProblemDetails(errors: result.ToErrorDictionary()));

            switch (_carWorkflow.Book(car: book.CarId, x: (int)book.User.X, y: (int)book.User.Y).Result)
            {
                case BookingReturnStatus.Complete:
                    return Ok("Successfully");
                case BookingReturnStatus.FatalError:
                    return StatusCode(500, "System error");
                case BookingReturnStatus.InvalidCar:
                    return BadRequest( "Invalid car");
                case BookingReturnStatus.InvalidDistance:
                    return BadRequest("Invalid user and car's home lot distance.");
                case BookingReturnStatus.InvalidCarStatus:
                    return BadRequest( "Car already been booked.");
                default:
                    return StatusCode(500, "System error");
            }
        }

        /// <summary>
        /// Reach / Navigate to home lot 
        /// </summary>
        /// <param name="user">Reach Car Request</param>
        /// <returns></returns>
        [HttpPost(template: "reach", Name = "Reach")]
        public IActionResult ReachAsync(ReachCarRequest user)
        {
            ValidationResult result = _reachCarRequestValidator.Validate(user);

            if (!result.IsValid)
                return ValidationProblem(new ValidationProblemDetails(errors: result.ToErrorDictionary()));

            var returnStatus = _carWorkflow.Reach(car: user.CarId, x: (int)user.User.X, y: (int)user.User.Y);

            switch (returnStatus.Status)
            {
                case ReachReturnStatus.Complete:
                    return Ok(returnStatus.Direction);
                case ReachReturnStatus.FatalError:
                    return StatusCode(500, "System error");
                case ReachReturnStatus.InvalidCar:
                    return BadRequest( "Invalid car");
                case ReachReturnStatus.InvalidCarStatus:
                    return BadRequest( "Invalid car status ( the car is not book yet )");
                default:
                    return StatusCode(500, "System error");
            }
        }



    }
}
