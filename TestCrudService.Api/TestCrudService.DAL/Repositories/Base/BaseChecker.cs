using System.Collections;

namespace TestCrudService.DAL.Repositories.Base;

internal class BaseChecker
{
    protected void CheckDtoNull<T>(T dto)
    {
        CheckNull(dto);
    }
    
    protected void CheckDtoCollectionNullAndEmpty<T>(ICollection<T> dtoList)
    {
        CheckNull(dtoList);
        CheckEmptyCollection(dtoList);
    }
    
    protected void CheckNull<T>(T obj)
    {
        if (obj is null) throw new NullReferenceException();
    }
    
    protected void CheckEmptyCollection<T>(ICollection<T> list)
    {
        if (list.Count == 0) throw new InvalidOperationException("Collection is empty");
    } 
}