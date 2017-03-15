 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EATMVC.DAL;
using EATMVC.IBLL;
using EATMVC.Model;

namespace EATMVC.BLL
{
	
	public partial class GP_LoginService:BaseService<GP_Login>,IGP_LoginService
    {	
		public override void SetCurrentDal()
        {
            CurrentDal = AbstractFactory.GetGP_LoginDal();
        }
	}
	
	public partial class GP_LoginRoleInfoService:BaseService<GP_LoginRoleInfo>,IGP_LoginRoleInfoService
    {	
		public override void SetCurrentDal()
        {
            CurrentDal = AbstractFactory.GetGP_LoginRoleInfoDal();
        }
	}
	
	public partial class RoleInfoService:BaseService<RoleInfo>,IRoleInfoService
    {	
		public override void SetCurrentDal()
        {
            CurrentDal = AbstractFactory.GetRoleInfoDal();
        }
	}
}