using Moq;
using AutoFixture;
using Assignment.Service;
using Assignment.Controllers;
using static Assignment.Model.AssignmentModel;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_API_Test.Test_Case
{
    public class DataProcessTest
    {
        private readonly IFixture _ifixer;
        private readonly Mock<IAssignmentService> _assignmentmock;
        private readonly AssignmentController _contol;

        public DataProcessTest()
        {
            _ifixer = new Fixture();
            _assignmentmock = _ifixer.Freeze<Mock<IAssignmentService>>();
            _contol = new AssignmentController(_assignmentmock.Object);
        }
        [Fact]
        public async Task GetData_ShouldReturnOkResponse_WhenDataFound()
        {
            //Arramge
   
            var DataProcess = _ifixer.Create<List<int>>();
            _assignmentmock.Setup(x => x.FunctionA())
                .Returns(DataProcess);
            //Act
            var Result = _contol
                .GetDataProcess();

            //Assert
            Result.Should()
                .NotBeNull();

            _assignmentmock.Verify(x => x.FunctionA(), Times.Once());

        }
    }
}
