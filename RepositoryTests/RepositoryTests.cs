using System.ComponentModel;

namespace Repository.Tests;

public class RepositoryTests
{
    private class FakeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    #region Create
    [Fact]
    [DisplayName("Create deve adicionar um novo objeto ao repositório")]
    public void Create_deve_adicionar_um_novo_objeto_ao_repositorio()
    {
        //Arrange
        var repository = new Repository<FakeEntity>();

        //Act
        var entity = new FakeEntity { Id = 1, Name = "Test" };
        repository.Create(entity);
        var retrievedEntity = repository.GetById(1);

        //Assert
        Assert.NotNull(retrievedEntity);
    }
    #endregion
    #region Read
    [Fact]
    [DisplayName("GetById deve retornar o objeto correto do repositório")]
    public void GetById_deve_retornar_o_objeto_correto_do_repositorio()
    {
        //Arrange
        var repository = new Repository<FakeEntity>();
        var entity = new FakeEntity { Id = 2, Name = "Test2" };
        repository.Create(entity);
        //Act
        var retrievedEntity = repository.GetById(2);
        //Assert
        Assert.NotNull(retrievedEntity);
        Assert.Equal(2, retrievedEntity!.Id);
        Assert.Equal("Test2", retrievedEntity.Name);
    }
    #endregion
    #region Update
    [Fact]
    [DisplayName("Update deve modificar o objeto existente no repositório")]
    public void Update_deve_modificar_o_objeto_existente_no_repositorio()
    {
        //Arrange
        var repository = new Repository<FakeEntity>();
        var entity = new FakeEntity { Id = 3, Name = "Test3" };
        repository.Create(entity);
        //Act
        var updatingEntity = new FakeEntity { Id = entity.Id, Name = "UpdatedTest3" };
        repository.Update(updatingEntity);
        //Assert
        var updatedEntity = repository.GetById(3);
        Assert.NotNull(updatedEntity);
        Assert.Equal("UpdatedTest3", updatedEntity!.Name);
    }
    #endregion
    #region Delete
    [Fact]
    [DisplayName("Delete deve remover o objeto existente do repositório")]
    public void Delete_deve_remover_o_objeto_existente_do_repositorio()
    {
        //Arrange
        var repository = new Repository<FakeEntity>();
        var entity = new FakeEntity { Id = 4, Name = "Test4" };
        repository.Create(entity);
        //Act
        repository.Delete(4);
        //Assert
        var deletedEntity = repository.GetById(4);
        Assert.Null(deletedEntity);
    }
    #endregion
}