using System;
using System.IO;
using System.Reflection;
using TaleWorlds.GauntletUI;
using ExampleMod.Util;

namespace ExampleMod.Configuretion
{
	internal class GameLoadConfiguration
	{
		public static float healAmount = 8f;
		public static HorizontalAlignment horizontalAlignment = HorizontalAlignment.Right;

		public static void loadConfig()
		{
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string path = Directory.GetParent(Directory.GetParent(directoryName).ToString()).ToString();
			PropertyOper po = new PropertyOper(path + "\\public.properties");
			String amount = po.getPropertie("healAmount");
			String horizontal = po.getPropertie("horizontalAlignment");
			if (null != amount) {
				GameLoadConfiguration.healAmount = float.Parse(amount);
			}
			if (null != horizontal && "Left".Equals(horizontal)) {
				GameLoadConfiguration.horizontalAlignment = HorizontalAlignment.Left;
			}
			


		}
	}
}
