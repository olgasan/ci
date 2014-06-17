using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class CIBuilder 
{
	private static string BASE_PATH = Environment.GetFolderPath (System.Environment.SpecialFolder.Desktop) + "/builds/" + CISettings.AppName;
	
	public static void DoBuildWithParameters (CIBuildDescriptor descriptor)
	{
		PreBuildOperations (descriptor);

		string basepath = GetBasePath (descriptor);
		string buildpath = GetBuildFileDir (descriptor);
		string filepath = basepath + "/" + buildpath;
		BuildTarget platform = descriptor.platform == RuntimePlatform.IPhonePlayer ? BuildTarget.iPhone : BuildTarget.Android;
		BuildOptions options = GetBuildOptions (descriptor);
		Debug.Log ("INFO: generate build at " + filepath);

		CIGenericBuilder.DoBuild (platform, filepath, options);
	}

	private static void PreBuildOperations (CIBuildDescriptor descriptor)
	{
		CIPreBuildOperations preBuildOperations = new CIPreBuildOperations ();

		preBuildOperations.SetUpServerEnvironment (descriptor.serverEnvironment);
		preBuildOperations.SetUpVersion (descriptor.version);
	}

	private static BuildOptions GetBuildOptions (CIBuildDescriptor descriptor)
	{
		if (descriptor.isDebugBuild)
		{
			if (descriptor.acceptExternalModifications)
				return BuildOptions.Development | BuildOptions.AcceptExternalModificationsToPlayer;
			else
				return BuildOptions.Development;
		}
		else
		{
			if (descriptor.acceptExternalModifications)
				return BuildOptions.AcceptExternalModificationsToPlayer;
			else
				return BuildOptions.None;
		}
	}

	private static string GetBasePath (CIBuildDescriptor descriptor)
	{
		string basepath = BASE_PATH + "/" + descriptor.platform.ToString ();
		
		if (!Directory.Exists (basepath))
			Directory.CreateDirectory (basepath);
		
		return basepath;
	}

	private static string GetBuildFileDir (CIBuildDescriptor descriptor)
	{
		string baseDir = string.Format ("{0}_{1}_{2}", CISettings.AppName, descriptor.serverEnvironment, PlayerSettings.bundleVersion);

		if (descriptor.platform == RuntimePlatform.Android && !descriptor.acceptExternalModifications)
			baseDir += ".apk";

		return baseDir;
	}
}