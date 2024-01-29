using FlashCards.Desktop.Models;

namespace FlashCards.Desktop.RepositoryContracts
{
	public interface IRepository<T> where T : IEntity
	{
		Task Create(T entity);

		Task Delete(Guid id);

		Task Update(Guid id, T entity);

		Task<T> GetById(Guid id);
	}
}
