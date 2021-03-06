using System;
using Modding;

namespace $safeprojectname$
{
	public class $safeitemname$: Mod
	{
		$if$ ($usenullableannotations$ == enable)private static $safeitemname$? _instance;
		$else$private static $safeitemname$ _instance;
	    $endif$
		internal static $safeitemname$ Instance
		{
			get
			{
				if (_instance == null)
				{
					throw new InvalidOperationException($"{nameof($safeitemname$)} was never initialized");
				}
				return _instance;
			}
		}

		public override string GetVersion() => GetType().Assembly.GetName().Version.ToString();
		
		public $safeitemname$() : base()
		{
			_instance = this;
		}

		// if you need preloads, you will need to implement GetPreloadNames and use the other signature of Initialize.
		public override void Initialize()
		{
			Log("Initializing");

			// put additional initialization logic here

			Log("Initialized");
		}
	}
}
