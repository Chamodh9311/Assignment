using Assignment.Controllers;
using Assignment.Service;
using AutoFixture;
using FluentAssertions;
using Moq;
using static Assignment.Model.AssignmentModel;

namespace Assignment_API_Test.Test_Case
{
    public class CryptoBlockAPICaseTest
    {
        private readonly IFixture _ifixer;
        private readonly Mock<IAssignmentService> _assignmentmock;
        private readonly AssignmentController _contol;

        public CryptoBlockAPICaseTest()
        {
            _ifixer = new Fixture();
            _assignmentmock = _ifixer.Freeze<Mock<IAssignmentService>>();
            _contol = new AssignmentController(_assignmentmock.Object);
        }

        [Fact]
        public async Task GetData_ShouldReturnOkResponse_WhenDataFound()
        {
            //Arramge
            InverseText Request = new InverseText();
            Request.Text = "This is Just Test Case";
            var MarketData = _ifixer.Create<Task<List<Market>>>();
            _assignmentmock.Setup(x => x.PageAssets())
                .Returns(MarketData);
            //Act
            var Result = _contol
                .GetDataFromThirdParty();

            //Assert
            Result.Should()
                .NotBeNull();

            _assignmentmock.Verify(x => x.PageAssets(), Times.Once());

        }
    }
}
