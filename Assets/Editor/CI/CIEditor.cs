using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System;

public class CIEditor
{
	[MenuItem ("Tools/CI/Perform iOS - Dev")]
	private static void PerformIOSBuildDev ()
	{
		ServerSettingsEditor.SwitchTo (ServerEnvironment.Dev);
		string filepath = CIBuilder.GetBuildFilepath (BuildTarget.iPhone, ServerEnvironment.Dev.ToString());
		CIBuilder.DoBuild (BuildTarget.iPhone, filepath);
	}
	
	[MenuItem ("Tools/CI/Perform - iOS Test")]
	private static void PerformIOSBuildTest ()
	{
		ServerSettingsEditor.SwitchTo (ServerEnvironment.Test);
		string filepath = CIBuilder.GetBuildFilepath (BuildTarget.iPhone, ServerEnvironment.Test.ToString());
		CIBuilder.DoBuild (BuildTarget.iPhone, filepath);
	}
	
	[MenuItem ("Tools/CI/Perform Android - Dev")]
	private static void PerformAndroidBuildDev ()
	{
		ServerSettingsEditor.SwitchTo (ServerEnvironment.Dev);
		string filepath = CIBuilder.GetBuildFilepath (BuildTarget.Android, ServerEnvironment.Dev.ToString());
		CIBuilder.DoBuild (BuildTarget.Android, filepath);
	}
	
	[MenuItem ("Tools/CI/Perform Android - Test")]
	private static void PerformAndroidBuildTest ()
	{
		ServerSettingsEditor.SwitchTo (ServerEnvironment.Test);
		string filepath = CIBuilder.GetBuildFilepath (BuildTarget.Android, ServerEnvironment.Test.ToString());
		CIBuilder.DoBuild (BuildTarget.Android, filepath);
	}
}
