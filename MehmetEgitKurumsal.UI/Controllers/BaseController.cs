using MehmetEgitKurumsal.BLL.Repository.Service;
using MehmetEgitKurumsal.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsal.UI.Controllers
{
    public class BaseController : Controller
    {
       protected EntityService service = new EntityService();

       protected MehmetEgitKurumsal.StringOperations.StringOperations strOp = new StringOperations.StringOperations();
    }
}