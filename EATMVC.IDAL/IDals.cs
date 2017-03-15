 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EATMVC.Model;

namespace EATMVC.IDAL
{
	
	public partial interface IGP_LoginDal : IBaseDal<GP_Login>
    { 
    }   
	
	public partial interface IGP_LoginRoleInfoDal : IBaseDal<GP_LoginRoleInfo>
    { 
    }   
	
	public partial interface IRoleInfoDal : IBaseDal<RoleInfo>
    { 
    }   
}