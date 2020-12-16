using MehmetEgitKurumsal.Activation;
using MehmetEgitKurumsal.BLL.Repository.Service;
using MehmetEgitKurumsal.StringOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsalWeb.UI.Controllers
{
    public class BaseController : Controller
    {
        protected EntityService service = new EntityService();

        protected Activation action = new Activation();

        protected StringOperations strOp = new StringOperations();

    }
}