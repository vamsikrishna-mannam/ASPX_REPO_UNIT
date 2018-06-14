using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.Database;

namespace DataLayer.Repositories
{
    public abstract class RepositoriesBaseClass<Data, Business> : IDisposable where Data : class, new() where Business : class, new()
    {
        protected Technology_SolutionsEntities dataContext;
        private IMapper mapper;
        private IConfigurationProvider mappingConfig;
        protected RepositoriesBaseClass()
        {
            dataContext = new Technology_SolutionsEntities();
            mappingConfig = CreateMappingConfiguration();
            mapper = mappingConfig.CreateMapper();
        }

        protected virtual IConfigurationProvider CreateMappingConfiguration()
        {
            return new MapperConfiguration(
                c =>
                {
                    c.CreateMap<Data, Business>();
                    c.CreateMap<Data, Business>().ReverseMap();
                });
        }

        protected List<Data> AsDataObjects(List<Business> business)
        {
            return business.ConvertAll(b => AsDataObject(b));
        }

        protected Data AsDataObject(Business b)
        {
            return mapper.Map<Data>(b);
        }

        protected List<Business> AsBusinessObjects(List<Data> data)
        {
            return data.AsQueryable().ProjectTo<Business>(mappingConfig).ToList();
        }

        protected Business AsBusinessObject(Data d)
        {
            return mapper.Map<Business>(d);
        }
        public void Dispose()
        {
            dataContext.Dispose();
        }
    }
}
