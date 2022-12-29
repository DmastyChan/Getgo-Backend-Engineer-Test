using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TT.GetGo.Core.Domain;
using TT.GetGo.Services.Helper;
using TT.GetGo.Services.Records;
using TT.GetGo.Web.Controllers;
using TT.GetGo.Web.Models;
using TT.GetGo.Web.Validator;

namespace TT.GetGo.Web.Test
{
    public class RecordControllerTest
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

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public RecordControllerTest()
        {
            _userRequestValidator = new UserRequestValidator();
            _bookRequestValidator = new BookRequestValidator();
            _searchRequestValidator = new SearchRequestValidator();
            _reachCarRequestValidator = new ReachCarRequestValidator();
            _carServices = A.Fake<ICarServices>();
            _recordServices = A.Fake<IRecordServices>();
            _locationServices = A.Fake<ILocationServices>();
            _carWorkflow = A.Fake<ICarWorkflow>();
            _webHelper = A.Fake<IWebHelper>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void RecordController_GetAll_ReturnOk()
        {
            // Arrange 
            var cars = A.Fake<ICollection<CarInfo>>();
            var carList = A.Fake<List<CarModel>>();
            A.CallTo(() => _mapper.Map<List<CarModel>>(cars)).Returns(carList);
            var controller = new RecordController(_carServices, _recordServices, _locationServices, _webHelper, _mapper,
                _carWorkflow, _userRequestValidator, _bookRequestValidator, _searchRequestValidator,
                _reachCarRequestValidator);

            // Act
            var result = controller.GetAll();

            // Assert 
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void RecordController_Search_ReturnOk()
        {
            // Arrange 
            var request = new SearchRequest()
            {
                User = new UserRequest()
                {
                    X = 1,
                    Y = 2,
                }
            };

            var controller = new RecordController(_carServices, _recordServices, _locationServices, _webHelper, _mapper,
                _carWorkflow, _userRequestValidator, _bookRequestValidator, _searchRequestValidator,
                _reachCarRequestValidator);

            // Act
            var result = controller.Search(search: request);

            // Assert 
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void RecordController_Book_ReturnOK()
        {
            // Arrange 
            var request = new BookRequest()
            {
                CarId = 1,
                User = new UserRequest()
                {
                    X = 2,
                    Y = 3,
                }
            };

            var controller = new RecordController(_carServices, _recordServices, _locationServices, _webHelper, _mapper,
                _carWorkflow, _userRequestValidator, _bookRequestValidator, _searchRequestValidator,
                _reachCarRequestValidator);

            // Act
            var result = controller.BookAsync(book: request);

            // Assert 
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void RecordController_Book_ReturnBad()
        {
            // Arrange 
            // This car already been booked
            var request = new BookRequest()
            {
                CarId = 2,
                User = new UserRequest()
                {
                    X = 1,
                    Y = 2,
                }
            };

            var controller = new RecordController(_carServices, _recordServices, _locationServices, _webHelper, _mapper,
                _carWorkflow, _userRequestValidator, _bookRequestValidator, _searchRequestValidator,
                _reachCarRequestValidator);

            // Act
            var result = controller.BookAsync(book: request);
            var okResult = result as ObjectResult;

            // Assert 
            Assert.Equal(StatusCodes.Status400BadRequest, okResult.StatusCode);
        }

        [Fact]
        public void RecordController_ReachAsync_ReturnOK()
        {
            // Arrange 
            var request = new ReachCarRequest()
            {
                CarId = 2,
                User = new UserRequest()
                {
                    X = 2,
                    Y = 3,
                }
            };

            var controller = new RecordController(_carServices, _recordServices, _locationServices, _webHelper, _mapper,
                _carWorkflow, _userRequestValidator, _bookRequestValidator, _searchRequestValidator,
                _reachCarRequestValidator);

            // Act
            var result = controller.ReachAsync(user: request);

            // Assert 
             Assert.Equal(StatusCodes.Status200OK, ((ObjectResult)result).StatusCode);
        }

        

        [Fact]
        public void userRequestValidator_X_Y_Checking_ReturnTrue()
        {
            var result = _userRequestValidator.Validate(new UserRequest()
            {
                X = 1,
                Y = 1,
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void userRequestValidator_X_Y_Checking_ReturnFalse()
        {
            // Act
            var result = _userRequestValidator.Validate(new UserRequest()
            {
                X = 121312312312,
                Y = 1,
            });

            // Assert 
            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void userRequestValidator_X_Y_Checking_ReturnFalse_2()
        {
            // Act
            var result = _userRequestValidator.Validate(new UserRequest()
            {
                X = -121312312312,
                Y = 1,
            });
            
            // Assert 
            result.IsValid.Should().BeFalse();
        }

    }
}
