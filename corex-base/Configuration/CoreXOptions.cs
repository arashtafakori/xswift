using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreX.Base
{
	/// <summary>
	/// Coex runtime options
	/// </summary>
	public static class CoreXOptions
	{
		/// <summary>
		/// Global configuration for everything which needs to be configured.
		/// </summary>
		public static CoreXConfiguration Global { get; } = new CoreXConfiguration();
	}
}
