﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Castle.MonoRail.Framework;

namespace DemoCastleSite.Controllers
{
	[Layout("Default")]
	public class HomeController : SmartDispatcherController
	{		
		public void Index()
		{
			
		}
		public void Apply(string name, string address)
		{
			RenderView("index");
		}
	}
}