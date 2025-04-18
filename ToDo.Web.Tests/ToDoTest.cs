using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using ToDo.Web.Components.Pages;

namespace ToDo.Web.Tests
{
    public class ToDoTest
    {
        [Fact]
        public void AddTest()
        {
            // Arrange
            var mockTodoApi = new Mock<TodoApi>();
            using var context = new TestContext();
            context.Services.AddSingleton<TodoApi>(mockTodoApi.Object);
            var cut = context.RenderComponent<Home>();
            var element = cut.Find("p");

            // Act
            cut.Find("input").Change("Test");
            cut.Find("button").Click();

            // Assert
            var result = element.TextContent;
            result.MarkupMatches("<p>Test</p>");
        }
    }
}
