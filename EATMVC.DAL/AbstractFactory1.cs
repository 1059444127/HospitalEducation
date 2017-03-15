 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EATMVC.DAL
{
	public partial class AbstractFactory
	{
				
			public static GP_LoginDal GetGP_LoginDal()
			{
			  return Assembly.Load(AssemblyPath).CreateInstance(NameSpacePath + ".GP_LoginDal") as GP_LoginDal;
			}
	 		
			public static GP_LoginRoleInfoDal GetGP_LoginRoleInfoDal()
			{
			  return Assembly.Load(AssemblyPath).CreateInstance(NameSpacePath + ".GP_LoginRoleInfoDal") as GP_LoginRoleInfoDal;
			}
	 		
			public static RoleInfoDal GetRoleInfoDal()
			{
			  return Assembly.Load(AssemblyPath).CreateInstance(NameSpacePath + ".RoleInfoDal") as RoleInfoDal;
			}
	 	 }
}