using Xunit;
using Assessment.Controllers;
using System.Linq;

namespace TimelogTypesControllerTests
{
  public class TimelogTypesControllerTests
  {
    [Fact]
    public void GetTimelogType_ReturnsCorrectId()
    {
      // Arrange
      var controller = new TimelogTypesController();
      int expectedId = 1;

      // Act
      var result = controller.GetTimelogType(expectedId);

      // Assert
      Assert.Equal(expectedId, result.Value.TimelogTypeId);
    }
  }
}
