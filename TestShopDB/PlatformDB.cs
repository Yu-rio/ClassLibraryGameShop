using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopDB
{
    private readonly IDataContext _dataContext;

    public PlatformRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Platform> GetAll()
    {
        return _dataContext.GetTable<Platform>().ToList();
    }

    public Platform GetById(string platformId)
    {
        return _dataContext.GetTable<Platform>().FirstOrDefault(p => p.PlatformId == platformId);
    }

    public void Insert(Platform platform)
    {
        _dataContext.Insert(platform);
    }

    public void Update(Platform platform)
    {
        _dataContext.Update(platform);
    }

    public void Delete(Platform platform)
    {
        _dataContext.Delete(platform);
    }
}
