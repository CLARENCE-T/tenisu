using FluentAssertions;
using Tenisu.Domain.Common;
using Tenisu.Domain.PlayerAggregate;
using Xunit;

namespace Tenisu.Domain.UnitTests;

public class PlayerTest
{
       [Fact]
        public void Player_ShouldInitializePropertiesCorrectly()
        {
            // Arrange & Act
            var player = new Player
            {
                Firstname = "Novak",
                Lastname = "Djokovic",
                Shortname = "N.DJO",
                Sex = "M",
                Country = new Country { Code = "SRB", Picture = "serbia.png" },
                CountryId = 1,
                InformationId = 2,
                Picture = "novak.png",
                Data = new PlayerInformation { Rank = 1, Points = 1500 }
            };

            // Assert
            player.Firstname.Should().Be("Novak");
            player.Lastname.Should().Be("Djokovic");
            player.Shortname.Should().Be("N.DJO");
            player.Sex.Should().Be("M");
            player.Country.Should().NotBeNull();
            player.Country.Code.Should().Be("SRB");
            player.CountryId.Should().Be(1);
            player.InformationId.Should().Be(2);
            player.Picture.Should().Be("novak.png");
            player.Data.Should().NotBeNull();
            player.Data.Rank.Should().Be(1);
        }

        [Fact]
        public void Player_ShouldAllowModificationOfSettableProperties()
        {
            // Arrange
            var player = new Player
            {
                Firstname = "Novak",
                Lastname = "Djokovic",
                Shortname = "N.DJO",
                Sex = "M",
                Picture = "novak.png"
            };

            // Act
            player.Firstname = "Rafael";
            player.Lastname = "Nadal";
            player.Shortname = "R.NAD";
            player.Sex = "M";
            player.Picture = "rafael.png";

            // Assert
            player.Firstname.Should().Be("Rafael");
            player.Lastname.Should().Be("Nadal");
            player.Shortname.Should().Be("R.NAD");
            player.Picture.Should().Be("rafael.png");
        }

        [Fact]
        public void Player_ShouldBeOfTypeEntity()
        {
            // Arrange & Act
            var player = new Player();

            // Assert
            player.Should().BeAssignableTo<Entity>();
        }
}