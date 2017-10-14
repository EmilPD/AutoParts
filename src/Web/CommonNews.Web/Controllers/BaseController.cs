namespace CommonNews.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Infrastructure.Mapping;

    public abstract class BaseController : Controller
    {
        private IMapper mapper;

        public BaseController(IMapper mapper)
        {
            this.Mapper = mapper;
        }

        public IMapper Mapper
        {
            get
            {
                if (this.mapper == null)
                {
                    this.mapper = AutoMapperConfig.Configuration.CreateMapper();
                }

                return this.mapper;
            }

            set
            {
                this.mapper = value;
            }
        }
    }
}
