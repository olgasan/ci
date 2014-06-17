using UnityEngine;

public class CIBuildDescriptor
{
	public RuntimePlatform platform;
	public ServerEnvironment serverEnvironment;
	public string version = "1.0.0";
	public bool isDebugBuild;
	public bool acceptExternalModifications;

	private bool _isReleaseBuild;

	public bool IsReleaseBuild
	{
		get { return _isReleaseBuild; }
		set
		{
			if (value)
			{
				SetReleaseParameters ();
			}

			_isReleaseBuild = value;
		}
	}

	private void SetReleaseParameters ()
	{
		isDebugBuild = false;
		serverEnvironment = ServerEnvironment.Live;
	}

	public override string ToString ()
	{
		return string.Format ("BuildDescriptor:\n[serverEnvironment={0}, version={1}, isDebugBuild={2}]",
		                      serverEnvironment,
		                      version,
		                      isDebugBuild);
	}
}
