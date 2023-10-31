using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSwift.Base
{
	/// <summary>
	/// Coex runtime options
	/// </summary>
	public static class OptionsX
	{
		/// <summary>
		/// Global configuration for everything which needs to be configured.
		/// </summary>
		public static ConfigurationX Global { get; } = new ConfigurationX();
	}
}
