namespace allSpice.Interfaces;

public interface IRepository<T>
{

    List<T> GetAll();
    T GetById(int id);

    T Create(T createData);
    T Update(T updateData);
    void Delete(int id);

}