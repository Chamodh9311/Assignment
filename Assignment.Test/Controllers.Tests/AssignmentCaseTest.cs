using Assignment.Controllers;
using Assignment.Service;
using AutoFixture;
using FluentAssertions;
using Moq;
using static Assignment.Model.AssignmentModel;

namespace Assignment_API_Test
{
    public class AssignmentCaseTest
    {

        private readonly IFixture _ifixer;
        private readonly Mock<IAssignmentService> _assignmentmock;
        private readonly AssignmentController _contol;

        public AssignmentCaseTest()
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
            var InvertText = _ifixer.Create<string>();
            _assignmentmock.Setup(x => x.StringReverser(Request))
                .ReturnsAsync(InvertText);
            //Act
            var Result = _contol
                .GetInvertedText(Request)
                .ConfigureAwait(false);

            //Assert
            Result.Should()
                .NotBeNull();

            _assignmentmock.Verify(x => x.StringReverser(Request), Times.Once());

        }
    }
}
