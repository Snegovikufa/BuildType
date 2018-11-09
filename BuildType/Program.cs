using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace BuildType
{
	internal class Program
	{
		#region Методы

		public static string GetBuildType(string assemblyName)
		{
			StringBuilder sb = new StringBuilder();
			Assembly assm = Assembly.LoadFrom(assemblyName);
			var attributes = assm.GetCustomAttributes(typeof(DebuggableAttribute), false);

			if (attributes.Length == 0)
			{
				sb.AppendLine($"{assemblyName} is a RELEASE Build....");
				return sb.ToString();
			}

			foreach (Attribute attr in attributes)
			{
				if (attr is DebuggableAttribute)
				{
					DebuggableAttribute d = attr as DebuggableAttribute;
					sb.AppendLine($"Run time Optimizer is enabled : {!d.IsJITOptimizerDisabled}");
					sb.AppendLine($"Run time Tracking is enabled : {d.IsJITTrackingEnabled}");
					if (d.IsJITOptimizerDisabled)
					{
						sb.AppendLine($"{assemblyName} is a DEBUG Build....");
						return sb.ToString();
					}

					sb.AppendLine($"{assemblyName} is a RELEASE Build....");
					return sb.ToString();
				}
			}

			return sb.ToString();
		}


		[STAThread]
		private static int Main(string[] args)
		{
			if (args.Length == 0)
			{
				MessageBox.Show("Usage:\n\nBuildType <assemblyName>");
				return 2;
			}

			try
			{
				string message = GetBuildType(args[0]);
				MessageBox.Show(message);
				return 0;
			}
			catch
			{
				return -1;
			}
		}

		#endregion
	}
}