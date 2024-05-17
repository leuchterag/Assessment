using Assessment.Controllers;
using Assessment.Models;

namespace UnitTest
{
  public class Tests
  {
    private TimelogTypesController _controller;

    [SetUp]
    public void Setup()
    {
      _controller = new TimelogTypesController();
    }

    [Test]
    public void GetTimelogTypes_ReturnsTimelogTypes()
    {
      var result = _controller.GetTimelogTypes();

      Assert.IsNotNull(result);
      Assert.IsInstanceOf<IEnumerable<TimelogTypeAPI>>(result);

      var timelogTypes = result as IEnumerable<TimelogTypeAPI>;
      Assert.IsTrue(timelogTypes.Any());
    }
  }
}
