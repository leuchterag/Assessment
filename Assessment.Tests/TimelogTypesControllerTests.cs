using Xunit;
using Assessment.Controllers;
using Assessment.Models;
using Microsoft.AspNetCore.Mvc;


namespace Assessment.Tests
{
    public class TimelogTypesControllerTests
    {
        [Fact]
        public void GetTimelogTypes_ReturnsAllItems()
        {
            // Arrange: Controller-Instanz wird erstellt.
            var controller = new TimelogTypesController();

            // Act: Die GetTimelogTypes-Methode wird aufgerufen.
            var result = controller.GetTimelogTypes();

            // Assert: Überprüfe, ob das Ergebnis vom korrekten Typ ist und die erwartete Anzahl an Elementen enthält.// Assert
            var viewResult = Assert.IsType<ActionResult<List<TimelogTypeResponse>>>(result);
            var model = Assert.IsAssignableFrom<List<TimelogTypeResponse>>(viewResult.Value);
            Assert.Equal(6, model.Count()); // Es werden 5 Elemente erwartet plus das eine Element was im CreateTimelogType_Validation_Fails_ForInvalidData() erstellt wird.
        }
        [Fact]
        public void GetTimelogType_WithInvalidId_ReturnsNotFound()
        {
            // Arrange: Controller-Instanz wird erstellt.
            var controller = new TimelogTypesController();

            // Act: Die GetTimelogType-Methode wird mit einer ungültigen ID aufgerufen.
            var result = controller.GetTimelogType(9999); // 999 annehmen, dass diese ID nicht existiert

            // Assert: Überprüfe, ob das Ergebnis ein NotFoundResult ist.
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateTimelogType_Validation_Fails_ForInvalidData()
        {
            // Arrange: Controller initialisieren und ungültige Testdaten erstellen
            var controller = new TimelogTypesController();
            var invalidTimelogType = new TimelogTypeRequest
            {
            timelogTypeId = 4,
            timelogType = "Valid Timelog Type",
            budget = -1 // Negativer Wert
            };

            // Act: Versuche, einen neuen TimelogType mit ungültigen Daten zu erstellen
            var result = controller.CreateTimelogType(invalidTimelogType);

            //Todo: Assert: Überprüfe, ob das Ergebnis ein BadRequestObjectResult ist und die Fehlermeldung enthält
        }
    }
}
