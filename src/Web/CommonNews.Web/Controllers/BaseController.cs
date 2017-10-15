namespace CommonNews.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Bytes2you.Validation;
    using Infrastructure.Mapping;

    public abstract class BaseController : Controller
    {
        private IMapper mapper;

        public BaseController(IMapper mapper)
        {
            Guard.WhenArgument(mapper, "IMapper").IsNull().Throw();

            this.Mapper = mapper;
        }

        public IMapper Mapper
        {
            get
            {
                return this.mapper;
            }

            private set
            {
                this.mapper = value;
            }
        }
    }
}
