using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Text;

public class Files : MonoBehaviour {
	public static string ReadDataFile(string filename) {
		// try reading the data file from the build directory
		FileInfo theSourceFile = null;
		StreamReader reader = null;
		
		theSourceFile = new FileInfo (Application.dataPath + "/" + filename + ".txt");
		if (theSourceFile != null && theSourceFile.Exists) reader = theSourceFile.OpenText();
		
		StringBuilder sb = new StringBuilder();
		if (reader != null) {
			// Read each line from the file
			string line;
			while ((line = reader.ReadLine()) != null) {
				sb.Append(line);
				sb.Append("\n");
			}
			//			Debug.Log(filename + " loaded from external file");
			return sb.ToString();
		}
		else {
			TextAsset dataAsset = Resources.Load (filename, typeof(TextAsset)) as TextAsset;
			
			if (dataAsset == null) {
				throw new Exception("Couldn't load " + filename + " file.");
			}
			
			//			Debug.Log(filename + " loaded from Resources");
			return dataAsset.text;
		}
	}
}
