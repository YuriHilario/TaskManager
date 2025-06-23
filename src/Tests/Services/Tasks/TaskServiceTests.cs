using API.Interfaces.Repositories;
using API.Models;
using API.Services.Tasks;
using Moq;
using Xunit;

namespace Tests.Services.Tasks
{
    public class TaskServiceTests
    {
        private readonly Mock<ITaskRepository> _mockRepository;
        private readonly TaskService _taskService;

        public TaskServiceTests()
        {
            _mockRepository = new Mock<ITaskRepository>();
            _taskService = new TaskService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllTasksAsync_ShouldReturnTaskList()
        {
            // Arrange
            var tasks = new List<TaskItem>
            {
                new TaskItem { Id = 1, Title = "Task 1", Priority = API.Enums.Priority.High, Status = API.Enums.Status.Pending },
                new TaskItem { Id = 2, Title = "Task 2", Priority = API.Enums.Priority.Medium, Status = API.Enums.Status.Completed }
            };

            _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(tasks);

            // Act
            var result = await _taskService.GetAllTasksAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, t => t.Title == "Task 1");
        }

        [Fact]
        public async Task GetTaskByIdAsync_ShouldReturnNull_WhenTaskNotFound()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((TaskItem)null);

            // Act
            var result = await _taskService.GetTaskByIdAsync(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateTaskAsync_ShouldCallRepositoryAddAsync()
        {
            // Arrange
            var newTask = new TaskItem { Title = "New Task", Priority = API.Enums.Priority.Low, Status = API.Enums.Status.Pending };

            _mockRepository.Setup(r => r.AddAsync(It.IsAny<TaskItem>())).Returns(Task.CompletedTask);

            // Act
            await _taskService.CreateTaskAsync(newTask);

            // Assert
            _mockRepository.Verify(r => r.AddAsync(newTask), Times.Once);
        }
    }
}
