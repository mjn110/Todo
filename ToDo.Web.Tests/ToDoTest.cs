using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using ToDo.Shared.Wrappers;
using ToDo.Web.Components.Pages;
using ToDo.Web.MockApis;

namespace ToDo.Web.Tests
{
    public class ToDoTest : TestContext // Ensure the test class inherits from TestContext
    {
        [Fact]
        public void AddTest()
        {
            // Arrange
            Services.AddSingleton<TodoApi>(new MockTodoApi());

            var cut = RenderComponent<Home>(); // RenderComponent is available in TestContext

            // Find the input and button
            var input = cut.Find("input");
            var button = cut.Find("button");
            var pElement = cut.Find("label").TextContent;

            // Act: Simulate entering text and clicking the button
            input.Change("New Test Task");
            button.Click();

            // Assert: Check if the new task appears in the component
            pElement.Contains("New Test Task");
        }
    }
}
