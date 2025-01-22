using GymTestAPI.Controllers;
using GymTestBL.Interfaces;
using GymTestBL.Models;
using GymTestBL.Services;
using Moq;
using Xunit;

namespace Tests
{
    public class ProgramControllerTests
    {
        private readonly Mock<IProgramRepository> _mockRepository;
        private readonly ProgramService _programService;
        private readonly ProgramController _controller;

        public ProgramControllerTests()
        {
            _mockRepository = new Mock<IProgramRepository>();
            _programService = new ProgramService(_mockRepository.Object);
            _controller = new ProgramController(_programService);
        }

        [Fact]
        public void Add_ValidProgram_ReturnsAddedProgram()
        {
            var newProgram = new ProgramModel("P001", "Strength Training", "Fitness", DateTime.Now, 20);
            _mockRepository.Setup(repo => repo.AddProgram(It.IsAny<ProgramModel>()))
                .Returns(newProgram);

            var result = _controller.Add(newProgram);

            Assert.NotNull(result);
            Assert.Equal(newProgram.ProgramCode, result.ProgramCode);
            Assert.Equal(newProgram.Name, result.Name);
        }

        [Fact]
        public void Delete_ExistingProgram_ReturnsTrue()
        {
            var programCode = "P001";
            _mockRepository.Setup(repo => repo.DeleteProgram(programCode))
                .Returns(true);

            var result = _controller.Delete(programCode);

            Assert.True(result);
            _mockRepository.Verify(repo => repo.DeleteProgram(programCode), Times.Once);
        }

        [Fact]
        public void Update_ValidProgram_ReturnsUpdatedProgram()
        {
            var updatedProgram = new ProgramModel("P001", "Updated Name", "Fitness", DateTime.Now.AddDays(1), 25);
            _mockRepository.Setup(repo => repo.UpdateProgram(It.IsAny<ProgramModel>()))
                .Returns(updatedProgram);

            var result = _controller.Update(updatedProgram.ProgramCode, updatedProgram);

            Assert.NotNull(result);
            Assert.Equal(updatedProgram.Name, result.Name);
            Assert.Equal(updatedProgram.Target, result.Target);
        }
    }
}
