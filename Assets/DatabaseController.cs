using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DatabaseController : MonoBehaviour {
    
	public void saveCharacter(CharacterModel model)
    {
        string json = JsonUtility.ToJson(model);
        PlayerPrefs.SetString("Character", json);
    }
    public void saveCharacterColors(CharacterColorModel model)
    {
        string json = JsonUtility.ToJson(model);
        PlayerPrefs.SetString("CharacterColor", json);
    }
    public CharacterModel getCharacter()
    {
        CharacterModel result = JsonUtility.FromJson<CharacterModel>(PlayerPrefs.GetString("Character"));        
        return result;
    }
    public CharacterColorModel getCharacterColors()
    {
        CharacterColorModel result = JsonUtility.FromJson<CharacterColorModel>(PlayerPrefs.GetString("CharacterColor"));
        return result;
    }
}
