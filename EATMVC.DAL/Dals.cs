 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EATMVC.Model;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EATMVC.IDAL;

namespace EATMVC.DAL
{
   
		
	public partial class GP_LoginDal:BaseDal<GP_Login>,IGP_LoginDal
    {
	}
		
	public partial class GP_LoginRoleInfoDal:BaseDal<GP_LoginRoleInfo>,IGP_LoginRoleInfoDal
    {
	}
		
	public partial class RoleInfoDal:BaseDal<RoleInfo>,IRoleInfoDal
    {
	}


}