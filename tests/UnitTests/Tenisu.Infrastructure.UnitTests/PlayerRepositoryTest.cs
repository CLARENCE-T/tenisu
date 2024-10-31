using FluentAssertions;
using NSubstitute;
using Tenisu.Application.Common.Interfaces;
using Tenisu.Domain;
using Tenisu.Domain.PlayerAggregate;
using Xunit;

namespace Tenisu.Infrastructure.UnitTests;

public class PlayerRepositoryTest
{
    [Fact]
    public async Task ListAllAsync_ShouldReturnListOfPlayers()
    {
        // Arrange
        var mockRepository = Substitute.For<IPlayersRepository>();
        var samplePlayers = new List<Player>
        {
            new Player { Id = 1, Firstname = "Novak", Lastname = "Djokovic" },
            new Player { Id = 2, Firstname = "Rafael", Lastname = "Nadal" }
        };
            
        mockRepository.ListAllAsync().Returns(Task.FromResult(samplePlayers));

        // Act
        var result = await mockRepository.ListAllAsync();

        // Assert
        result.Should().BeOfType<List<Player>>()
            .And.HaveCount(2);
    }
    
    [Fact]
    public async Task GetByIdAsync_ShouldReturnPlayer_WhenPlayerExists()
    {
        // Arrange
        var mockRepository = Substitute.For<IPlayersRepository>();
        var playerId = 1;
        var samplePlayer = new Player 
        { 
            Id = playerId, 
            Firstname = "Novak", 
            Lastname = "Djokovic",
            Country = new Country { Code = "SRB", Picture = "serbia.png" },
            Data = new PlayerInformation { Rank = 1, Points = 1200, Age = 34 }
        };

        mockRepository.GetByIdAsync(playerId).Returns(Task.FromResult<Player?>(samplePlayer));

        // Act
        var result = await mockRepository.GetByIdAsync(playerId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Player>();
        result?.Id.Should().Be(playerId);
        result?.Country.Should().NotBeNull();
        result?.Data.Should().NotBeNull();
    }
    
    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenPlayerDoesNotExist()
    {
        // Arrange
        var mockRepository = Substitute.For<IPlayersRepository>();
        var playerId = 99;

        mockRepository.GetByIdAsync(playerId).Returns(Task.FromResult<Player?>(null));

        // Act
        var result = await mockRepository.GetByIdAsync(playerId);

        // Assert
        result.Should().BeNull();
    }
}