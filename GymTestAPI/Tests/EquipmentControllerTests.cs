using GymTestAPI.Controllers;
using GymTestBL.Interfaces;
using GymTestBL.Models;
using GymTestBL.Services;
using Moq;
using Xunit;

namespace Tests
{
    public class EquipmentControllerTests
    {
        private readonly Mock<IEquipmentRepository> _mockRepo;
        private readonly EquipmentController _controller;

        public EquipmentControllerTests()
        {
            _mockRepo = new Mock<IEquipmentRepository>();
            var service = new EquipmentService(_mockRepo.Object);
            _controller = new EquipmentController(service);
        }

        [Fact]
        public void GetEquipment_ReturnsListOfEquipment()
        {
            var equipmentList = new List<Equipment>
            {
                new Equipment(1, "Treadmill", true),
                new Equipment(2, "Dumbbells", false)
            };
            _mockRepo.Setup(repo => repo.GetAll()).Returns(equipmentList);

            var result = _controller.GetEquipment();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Treadmill", result[0].DeviceType);
        }

        [Fact]
        public void Add_ValidEquipment_ReturnsAddedEquipment()
        {
            var newEquipment = new Equipment(0, "Rowing Machine", true);
            _mockRepo
                .Setup(repo => repo.AddEquipment(It.IsAny<Equipment>()))
                .Returns((Equipment e) => e);

            var result = _controller.Add(newEquipment);

            Assert.NotNull(result);
            Assert.IsType<Equipment>(result);
            Assert.Equal(newEquipment.DeviceType, result.DeviceType); 
            Assert.Equal(newEquipment.IsInService, result.IsInService);
        }

        [Fact]
        public void Delete_ExistingEquipment_ReturnsTrue()
        {
            var equipmentId = 1;
            _mockRepo.Setup(repo => repo.DeleteEquipment(equipmentId)).Returns(true);

            var result = _controller.Delete(equipmentId);

            Assert.True(result);
            _mockRepo.Verify(repo => repo.DeleteEquipment(equipmentId), Times.Once);
        }

        [Fact]
        public void ToggleService_ExistingEquipment_ReturnsTrue()
        {
            var equipmentId = 1;
            _mockRepo.Setup(repo => repo.ToggleInService(equipmentId)).Returns(true);

            var result = _controller.ToggleService(equipmentId);

            Assert.True(result);
            _mockRepo.Verify(repo => repo.ToggleInService(equipmentId), Times.Once);
        }
    }
}
