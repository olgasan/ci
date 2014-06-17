using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public class CIGenericBuilder
{
	private static string[] SCENES = FindEnabledEditorScenes ();
	
	public static void DoBuild (BuildTarget target, string filepath, BuildOptions buildOptions)
	{
		if (target == BuildTarget.Android)
			SetKeystorePasswords ();
		
		GenericBuild (SCENES, filepath, target, buildOptions);
	}

	private static string[] FindEnabledEditorScenes ()
	{
		List<string> EditorScenes = new List<string> ();
		foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
		{
			if (!scene.enabled)
				continue;
			EditorScenes.Add (scene.path);
		}
		return EditorScenes.ToArray ();
	}
	
	private static void GenericBuild (string[] scenes, string target_dir, BuildTarget build_target, BuildOptions build_options)
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget (build_target);
		string res = BuildPipeline.BuildPlayer (scenes, target_dir, build_target, build_options);
		if (res.Length > 0)
		{
			throw new Exception ("BuildPlayer failure: " + res);
		}
	}

	public static void SetKeystorePasswords()
	{
		PlayerSettings.Android.keyaliasName = CISettings.KeystoreConfig.KeyaliasName;
		PlayerSettings.Android.keystorePass = CISettings.KeystoreConfig.KeystorePass;
		PlayerSettings.Android.keyaliasPass = CISettings.KeystoreConfig.KeyaliasPass;
	}
}
