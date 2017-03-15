 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EATMVC.Model;

namespace EATMVC.IBLL
{
	
    public partial interface IGP_LoginService:IBaseService<GP_Login>
    {
    }
	
    public partial interface IGP_LoginRoleInfoService:IBaseService<GP_LoginRoleInfo>
    {
    }
	
    public partial interface IRoleInfoService:IBaseService<RoleInfo>
    {
    }
}