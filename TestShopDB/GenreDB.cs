using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopDB
{
    private readonly IDataContext _dataContext;

    public GenreRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Genre> GetAll()
    {
        return _dataContext.GetTable<Genre>().ToList();
    }

    public Genre GetById(string genreId)
    {
        return _dataContext.GetTable<Genre>().FirstOrDefault(g => g.GenreId == genreId);
    }

    public void Insert(Genre genre)
    {
        _dataContext.Insert(genre);
    }

    public void Update(Genre genre)
    {
        _dataContext.Update(genre);
    }

    public void Delete(Genre genre)
    {
        _dataContext.Delete(genre);
    }
}
