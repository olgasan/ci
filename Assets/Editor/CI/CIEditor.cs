using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System;

public class CIEditor
{
	[MenuItem ("Tools/CI/Perform iOS build")]
	private static void PerformIOSBuild ()
	{
		string filepath = CIBuilder.GetBuildFilepath (BuildTarget.iPhone);
		CIBuilder.DoBuild (BuildTarget.iPhone, filepath);
	}

	[MenuItem ("Tools/CI/Perform Android build")]
	private static void PerformAndroidBuild ()
	{
		string filepath = CIBuilder.GetBuildFilepath (BuildTarget.Android);
		CIBuilder.DoBuild (BuildTarget.Android, filepath);
	}
	
}
