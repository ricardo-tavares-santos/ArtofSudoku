using UnityEngine;
using UnityEngine.UI;

public class LocalisedText : MonoBehaviour {

    public string key;

	void Start () {
        GetComponent<Text>().text = GameObject.Find("GameManager").GetComponent<LocalisationTexts>().GetLocalisedText(key);
	}
}