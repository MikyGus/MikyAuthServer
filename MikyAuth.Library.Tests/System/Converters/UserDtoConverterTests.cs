using FluentAssertions;
using MikyAuth.Library.Converters;
using MikyAuth.Library.Entities;
using MikyAuth.Library.Gateway;
namespace MikyAuth.Library.Tests.System.Converters;
public class UserDtoConverterTests
{

    [Fact]
    public void ConvertToAuthUser_ShouldReturnAuthUserInstance_WhenCalledWithAUserCreateDto()
    {
        // Arrange
        UserCreateDto newUser = new("Testy");
        AuthUser authUserShouldBe = new()
        {
            UserName = "Testy",
            NormalizedUserName = "xxx"
        };
        // Act
        AuthUser result = newUser.ConvertToAuthUser();
        // Assert
        _ = result.Should().BeEquivalentTo(authUserShouldBe,
            options => options
            .Excluding(x => x.Id)
            .Excluding(x => x.NormalizedUserName)
            );
    }
}
