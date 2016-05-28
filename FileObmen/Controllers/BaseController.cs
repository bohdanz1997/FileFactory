using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileObmen.Mappers;
using FileObmen.Models;

namespace FileObmen.Controllers
{
    public class BaseController : Controller
    {
        protected UnitOfWork UnitOfWork;
        protected IMapper ModelMapper;

        public BaseController(UnitOfWork unit, IMapper mapper)
        {
            UnitOfWork = unit;
            ModelMapper = mapper;
        }

    }
}
