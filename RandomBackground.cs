using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomBackground : MonoBehaviour {

	public Image bg;
	public Sprite[] backgroundSprites;
	public static RandomBackground intance;

 // Use this for initialization
 
    void Awake()
    {
        intance = this;
    }
	
	public void setBackground() 
	{
		bg.sprite = backgroundSprites [Random.Range (0, backgroundSprites.Length)];
	}

}