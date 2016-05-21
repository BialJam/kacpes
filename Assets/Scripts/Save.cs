using UnityEngine;
using System.Collections;
using System.IO;

public class Save : MonoBehaviour {

	string fileName = "Data";

	public void save(string bottle, int part)
	{
		string dataToSave = bottle + ";" + part;

		if (!File.Exists (fileName))
			File.Create (fileName);
		File.WriteAllText (fileName, dataToSave);
	}

	public string[] load()
	{
		string[] dataToReturn;
		if (!File.Exists (fileName))
			return new string[1];
		dataToReturn = File.ReadAllText (fileName).Split (';');

		return dataToReturn;
	}
}
