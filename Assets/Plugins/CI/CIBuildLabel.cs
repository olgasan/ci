using UnityEngine;
using System.IO;
using System;
using System.Globalization;

public abstract class CIBuildLabel : MonoBehaviour
{
	private const int BRANCH_LINE = 0;
	private const int DATE_LINE = 1;

	private string fileName = "BuildInfo";
	private string branch;
	private string date;
	private string labelText;
	private Rect labelPosition;
	
	protected virtual string Text
	{
		get { return string.Format ("|{0}|{1}|", branch, date); }
	}

	protected abstract bool ShouldBeVisible
	{
		get;
	}
	
	private void Start ()
	{
		if (ShouldBeVisible)
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
			branch = lines [BRANCH_LINE];
			date = ConvertToDateTime (lines [DATE_LINE]);
		}
	}

	private string ConvertToDateTime (string value)
	{
		string ret = value;
		DateTime convertedDate;

		try
		{
			convertedDate = DateTime.ParseExact(value, "yyyy-MM-dd_HH-mm-ss", CultureInfo.InvariantCulture);
			ret = convertedDate.ToString ("HH:mm MM-dd/yy");
		}
		catch (FormatException)
		{
			Debug.Log (string.Format("'{0}' is not in the proper format.", value));
		}

		return ret;
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
