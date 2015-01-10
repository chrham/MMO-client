using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class CharacterSelection : MonoBehaviour 
{
	List<object[]> characterList = new List<object[]>();

	void Start()
	{
		characterList = JsonConvert.DeserializeObject<List<object[]>>(Connection.characterList);
	}

	void OnGUI()
	{
		/*int characterIndex = 0;
		
		characterList.ForEach(delegate(object[] character)
		{
			if(GUI.Button(new Rect(Screen.width - 233, 10 + (characterIndex * 40), 100, 30), character[1].ToString()))
			{
				Connection.sendMessage(Messages.LOADCHARACTER, character[0]);
			}

			characterIndex++;
		});*/
	}
}
