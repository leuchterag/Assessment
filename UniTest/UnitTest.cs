using Assessment.Controllers;

namespace UnitTest
{
  public class UnitTest
  {
    // Testet, ob die Methode GetTimelogType die richtige ID zurückgibt.
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
