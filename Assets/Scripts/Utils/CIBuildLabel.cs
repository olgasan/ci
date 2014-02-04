using UnityEngine;
using System.IO;
using System;

public class CIBuildLabel : MonoBehaviour 
{
	private const int REVISION_LINE = 0;
	private const int DATE_LINE = 1;
	
	private string fileName = "BuildInfo";
	private string revision;
	private string date;
	private string labelText;
	private Rect labelPosition;
	
	private string Text
	{
		get { return string.Format ("|R{0}|{1}|{2}|", revision, date, ServerSettings.Instance.CurrentEnvironment); }
	}
	
	private void Start ()
	{
		if (Debug.isDebugBuild)
		{
			string[] lines = GetInformationFile ();
			ParseFileLines (lines);
			InitializeLabel ();
		}
		else
		{
			enabled = false;
		}
	}

	private void InitializeLabel ()
	{
		float width = 380F;
		float height = 20F;
		float x = Screen.width - width;
		float y = 0F;
		labelText = Text;
		labelPosition = new Rect (x, y, width, height);
	}

	private string[] GetInformationFile ()
	{
		string[] lines = null;
		try
		{
			TextAsset fileContents = (TextAsset)Resources.Load (fileName, typeof(TextAsset));
			string content = fileContents.text;
			lines = content.Split ("\n" [0]);
		}
		catch (Exception)
		{
			//..
		}
		
		return lines;
	}

	private void ParseFileLines (string[] lines)
	{
		if (lines != null && lines.Length >= 2)
		{
			revision = lines [REVISION_LINE];
			date = lines [DATE_LINE];
		}
	}
	
	private void OnGUI ()
	{
		if (Debug.isDebugBuild)
		{
			GUI.skin.label.alignment = TextAnchor.UpperRight;
			GUI.Label (labelPosition, labelText);
		}
	}
}
