using UnityEngine;
using UnityEditor;
using System;

public class CIBackendEditor 
{
	private static void DoBuildWithParameters (BuildTarget platform, ServerEnvironment environment, Action<BuildTarget> preBuildOperations)
	{
		if (preBuildOperations != null)
			preBuildOperations (platform);

		ServerSettingsEditor.SwitchTo (environment);
		string filepath = CIBuilder.GetBuildFilepath (platform, environment.ToString());
		CIBuilder.DoBuild (platform, filepath);
	}

	public static void DoBuildWithParameters (BuildTarget platform, ServerEnvironment environment)
	{
		DoBuildWithParameters (platform, environment, null);
	}

	private static void PerformBuild ()
	{
		BuildTarget platform = ParseEnum <BuildTarget> (CommandLineReader.GetCustomArgument("Platform"));
		ServerEnvironment environment = ParseEnum <ServerEnvironment> (CommandLineReader.GetCustomArgument("Environment"));
		DoBuildWithParameters (platform, environment, CheckVersionNumber);
	}

	private static void CheckVersionNumber (BuildTarget platform)
	{
		string versionNumber = CommandLineReader.GetCustomArgument("Version");

		if (!string.IsNullOrEmpty (versionNumber))
		{
			PlayerSettings.bundleVersion = versionNumber;
		}
	}

	private static T ParseEnum <T> (string str)
	{
		T value = default (T);

		try
		{
			value = (T) Enum.Parse(typeof(T), str);
		}
		catch (ArgumentException)
		{
			Debug.Log (string.Format ("ERROR: {0} is not an underlying value of the enumeration.", str));
		}

		return value;
	}
}