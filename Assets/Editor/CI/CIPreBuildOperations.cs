using UnityEngine;
using UnityEditor;

public class CIPreBuildOperations
{
	public void SetUpVersion (string version)
	{
		if (!string.IsNullOrEmpty (version))
		{
			PlayerSettings.bundleVersion = version;
			Debug.Log ("INFO: Set Version to " + version);
		}
	}

	public void SetUpServerEnvironment (ServerEnvironment environment)
	{
		ServerSettings.Instance.CurrentEnvironment = environment;
		EditorUtility.SetDirty(ServerSettings.Instance);

		Debug.Log ("INFO: Set Server to " + ServerSettings.Instance.CurrentEnvironment);
	}
}
