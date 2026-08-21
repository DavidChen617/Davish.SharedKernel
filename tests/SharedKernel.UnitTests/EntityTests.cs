using Davish.SharedKernel;

namespace SharedKernel.UnitTests;

public class EntityTests
{
    private sealed class TestEntity : Entity<Guid>;

    [Fact]
    public void GivenANewlyCreatedEntity_WhenNoIdHasBeenAssigned_ThenItsIdIsTheDefaultValue()
    {
        // Given / When
        var entity = new TestEntity();

        // Then
        Assert.Equal(Guid.Empty, entity.Id);
    }

    [Fact]
    public void GivenAnEntity_WhenAssigningAnId_ThenTheEntityExposesThatId()
    {
        // Given
        var entity = new TestEntity();
        var id = Guid.NewGuid();

        // When
        entity.Id = id;

        // Then
        Assert.Equal(id, entity.Id);
    }
}
