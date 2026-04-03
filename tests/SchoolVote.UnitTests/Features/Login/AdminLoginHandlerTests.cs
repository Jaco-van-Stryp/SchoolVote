// ╔══════════════════════════════════════════════════════════════════════╗
// ║              LESSON 1 — UNIT TESTS                                  ║
// ║                                                                      ║
// ║  A UNIT test checks ONE class/method in complete ISOLATION.          ║
// ║  "Isolation" = we FAKE every dependency so we only test OUR logic.   ║
// ║                                                                      ║
// ║  AdminLoginHandler has two dependencies:                             ║
// ║    1. ApplicationDbContext  → we use an IN-MEMORY database           ║
// ║    2. IJwtService           → we use Moq to create a fake version    ║
// ║                                                                      ║
// ║  Test naming convention:  Given_[state]_When_[action]_Then_[result]  ║
// ║  This is called "Given / When / Then" (GWT).                         ║
// ╚══════════════════════════════════════════════════════════════════════╝

using System.Data.Common;
using SchoolVote.API.Features.Login.AdminLogin;

namespace SchoolVote.UnitTests.Features.Login;

public class AdminLoginHandlerTests
{
    // ─────────────────────────────────────────────────────────────────────
    // HELPER: Creates a fresh in-memory database for each test.
    //
    // WHY a new database per test?
    //   Tests must be INDEPENDENT. If Test A adds data and Test B runs
    //   after it, Test B would see Test A's data and produce wrong results.
    //   A unique database name (Guid) guarantees each test starts clean.
    // ─────────────────────────────────────────────────────────────────────
    private static ApplicationDbContext CreateFreshDatabase()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // unique per test
            .Options;

        return new ApplicationDbContext(options);
    }


    // ═════════════════════════════════════════════════════════════════════
    // ✅  TEST 1 — FULLY WRITTEN FOR YOU  (read it, understand it, run it)
    // ═════════════════════════════════════════════════════════════════════
    //
    // Scenario: A valid admin username + password is provided.
    // Expected: The handler returns a response containing a JWT token.
    //
    [Fact]  // <-- [Fact] marks a method as a test. xUnit will find and run it.
    public async Task Given_ValidCredentials_When_AdminLogsIn_Then_ReturnsJwtToken()
    {
        // ── GIVEN ──────────────────────────────────────────────────────
        // "Given" = set up the world before the action happens.

        // 1. Create a fresh in-memory database
        using var context = CreateFreshDatabase();

        // 2. Seed one administrator into the database
        var admin = new Administrators
        {
            Id = Guid.NewGuid(),
            Username = "teacher",
            Password = "correct-password"
        };
        context.Administrators.Add(admin);
        await context.SaveChangesAsync();

        // 3. Create a FAKE IJwtService using Moq.
        //    We tell Moq: "when GenerateToken is called with ANY arguments,
        //    return the string "fake-jwt-token"."
        //    This means we are NOT testing JWT generation — only login logic.
        var mockJwtService = new Mock<IJwtService>();
        mockJwtService
            .Setup(service => service.GenerateToken(
                It.IsAny<Guid>(),               // match any Guid
                It.IsAny<IEnumerable<string>>() // match any roles array
            ))
            .Returns("fake-jwt-token");

        // 4. Create the handler, injecting the real DB and the fake JWT service
        var handler = new AdminLoginHandler(context, mockJwtService.Object);

        // 5. Build the command (the input to the handler)
        var command = new AdminLoginCommand("teacher", "correct-password");

        // ── WHEN ────────────────────────────────────────────────────────
        // "When" = perform the action being tested.

        var result = await handler.Handle(command, CancellationToken.None);

        // ── THEN ────────────────────────────────────────────────────────
        // "Then" = assert the outcome is what we expected.
        //
        // FluentAssertions reads like English:
        //   result.Jwt  .Should()  .Be("fake-jwt-token")
        //   ──────────  ─────────  ──────────────────────
        //   the value   fluent     the expected value

        result.Jwt.Should().Be("fake-jwt-token");

        // Bonus assertion: verify the JWT service was actually called once.
        // This guards against a bug where the handler returns a hardcoded token
        // and never calls the service at all.
        mockJwtService.Verify(
            service => service.GenerateToken(admin.Id, It.IsAny<IEnumerable<string>>()),
            Times.Once
        );
    }


    // ═════════════════════════════════════════════════════════════════════
    // 📝  TEST 2 — YOUR TURN  (fill in the blanks)
    // ═════════════════════════════════════════════════════════════════════
    //
    // Scenario: The correct username is given, but the WRONG password.
    // Expected: The handler throws an UnauthorizedAccessException.
    //
    // HINT: Use  Func<Task> act = () => handler.Handle(command, CancellationToken.None);
    //       Then: await act.Should().ThrowAsync<UnauthorizedAccessException>();
    //
    [Fact]
    public async Task Given_WrongPassword_When_AdminLogsIn_Then_ThrowsUnauthorizedException()
    {
        // ── GIVEN ──────────────────────────────────────────────────────
        using var context = CreateFreshDatabase();

        // TODO: Seed an administrator with any username and password
        var admin = new Administrators
        {
            Id = Guid.NewGuid(),
            Username = "teacher",
            Password = "correct-password"
        };
        context.Administrators.Add(admin);
        await context.SaveChangesAsync();
        // TODO: Create a mock IJwtService (you still need it even though it won't be called)
        var mockJwtService = new Mock<IJwtService>();
        mockJwtService.Setup(service => service.GenerateToken(
            It.IsAny<Guid>(),
            It.IsAny<IEnumerable<string>>()
        )).Returns("valid-jwt-token");
        // TODO: Create the handler
        var handler = new AdminLoginHandler(context, mockJwtService.Object);
        // TODO: Build a command using the correct username but the WRONG password
        var command = new AdminLoginCommand("teacher", "incorrect-password");
        // ── WHEN ────────────────────────────────────────────────────────

        // TODO: Wrap the handler call in a Func<Task> called "act"
        //       Func<Task> act = () => handler.Handle(???, CancellationToken.None);
        Func<Task> act = () => handler.Handle(command, CancellationToken.None);
        // ── THEN ────────────────────────────────────────────────────────

        // TODO: Assert that "act" throws an UnauthorizedAccessException
        //       await act.Should().ThrowAsync<???>();
        await act.Should().ThrowAsync<UnauthorizedAccessException>();
    }


    // ═════════════════════════════════════════════════════════════════════
    // 📝  TEST 3 — YOUR TURN  (fill in the blanks)
    // ═════════════════════════════════════════════════════════════════════
    //
    // Scenario: A username is provided that does NOT exist in the database.
    // Expected: The handler throws a UserNotFoundException.
    //
    // HINT: You don't need to seed any administrator this time —
    //       an empty database already represents "user not found".
    //
    [Fact]
    public async Task Given_NonExistentUser_When_AdminLogsIn_Then_ThrowsUserNotFoundException()
    {
        // ── GIVEN ──────────────────────────────────────────────────────
        using var context = CreateFreshDatabase();

        // NOTE: No administrator is seeded — the database is intentionally empty.

        // TODO: Create a mock IJwtService
        var mockJwtService = new Mock<IJwtService>();
        mockJwtService.Setup(service => service.GenerateToken(
            It.IsAny<Guid>(),
            It.IsAny<IEnumerable<string>>()
        )).Returns("valid-jwt-token");
        // TODO: Create the handler
        var handler = new AdminLoginHandler(context, mockJwtService.Object);
        // TODO: Build a command with a username that doesn't exist
        var command = new AdminLoginCommand("non-existent-user", "non-existent-password");
        // ── WHEN ────────────────────────────────────────────────────────

        // TODO: Wrap the handler call in a Func<Task> called "act"
        Func<Task> act = () => handler.Handle(command, CancellationToken.None);
        // ── THEN ────────────────────────────────────────────────────────

        // TODO: Assert that "act" throws a UserNotFoundException
        await act.Should().ThrowAsync<UserNotFoundException>();
    }
}
