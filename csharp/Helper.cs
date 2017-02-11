using System.Security.Principal;


static class Helper
	{
		public static bool IsAdministrator()
		{
			return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
					.IsInRole(WindowsBuiltInRole.Administrator);
		}   
	}
