using GymTestAPI.Controllers;
using GymTestBL.Models;
using GymTestBL.Interfaces;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using GymTestBL.Services;

namespace Tests
{
    public class RunningSessionControllerTests
    {
        private readonly Mock<IRunningSessionRepository> _mockRepo;
        private readonly RunningSessionService _runningSessionService;
        private readonly RunningSessionController _controller;

        public RunningSessionControllerTests()
        {
            _mockRepo = new Mock<IRunningSessionRepository>();
            _runningSessionService = new RunningSessionService(_mockRepo.Object);
            _controller = new RunningSessionController(_runningSessionService);
        }

        [Fact]
        public void Get_ExistingRunningSession_ReturnsRunningSession()
        {
            var sessionId = 1;
            var runningSession = new RunningSessionMain(
                runningSessionId: 1,
                date: DateTime.Now,
                memberId: 123,
                duration: TimeSpan.FromMinutes(30),
                avgSpeed: 10.5f,
                details: new RunningSessionDetail()
            );
            _mockRepo.Setup(repo => repo.GetRunningSession(sessionId)).Returns(runningSession);

            var result = _controller.Get(sessionId);

            Assert.NotNull(result);
            Assert.IsType<RunningSessionMain>(result);
            Assert.Equal(sessionId, result.RunningSessionId);
        }

        [Fact]
        public void Get_NonExistingRunningSession_ReturnsNull()
        {
            var sessionId = 999;
            _mockRepo.Setup(repo => repo.GetRunningSession(sessionId)).Returns((RunningSessionMain)null);

            var result = _controller.Get(sessionId);

            Assert.Null(result);
        }
    }
}
