using UnityEditor;
using UnityEngine;

public class CIEditorWindow : EditorWindow
{
	CIBuildDescriptor descriptor = new CIBuildDescriptor ();
	bool developmentGroup = true;
	bool prevDevelopmentGroup;

	[MenuItem("Tools/CI/Generate Build", false, -100)]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(CIEditorWindow));
	}

	private BuildTargetGroup SelectedBuildTarget
	{
		get { return EditorUserBuildSettings.selectedBuildTargetGroup; }
	}

	private string ButtonLabel
	{
		get 
		{ 
			string label = "Generate {0} Build";

			if (descriptor.IsReleaseBuild)
				return string.Format (label, "Release");
			else
				return string.Format (label, "");
		}
	}
	
	private void OnGUI()
	{
		developmentGroup = EditorGUILayout.BeginToggleGroup ("This build is for development purposes", developmentGroup);
		{
			GUILayout.Label ("Server Environment", EditorStyles.boldLabel);
			descriptor.serverEnvironment = (ServerEnvironment)EditorGUILayout.EnumPopup (descriptor.serverEnvironment);

			descriptor.isDebugBuild = EditorGUILayout.Toggle ("Is debug build", descriptor.isDebugBuild);
		}

		EditorGUILayout.EndToggleGroup ();

		descriptor.acceptExternalModifications = EditorGUILayout.Toggle ("With external modifications", descriptor.acceptExternalModifications);
		descriptor.version = EditorGUILayout.TextField ("Version", descriptor.version);

		if (GUILayout.Button (ButtonLabel))
		{
			TryToGenerateBuild ();
		}
	}

	private void Update() 
	{
		if (developmentGroup != prevDevelopmentGroup)
		{
			SetUpPlatform ();
			descriptor.IsReleaseBuild = !developmentGroup;
		}

		prevDevelopmentGroup = developmentGroup;
	}

	private void SetUpPlatform ()
	{
		if (SelectedBuildTarget == BuildTargetGroup.Android)
		{
			descriptor.platform = RuntimePlatform.Android;
		}
		else if (SelectedBuildTarget == BuildTargetGroup.iPhone)
		{
			descriptor.platform = RuntimePlatform.IPhonePlayer;
		}
	}
	
	private void TryToGenerateBuild ()
	{
		SetUpPlatform ();

		CIValidator validator = new CIValidator (true);
		bool isValid = validator.IsValidConfiguration (descriptor);

		if (isValid)
		{
			Debug.Log (descriptor.ToString ());
			CIBuilder.DoBuildWithParameters (descriptor);
		}
	}
}
