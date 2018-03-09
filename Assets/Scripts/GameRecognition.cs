using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRecognition : MonoBehaviour {

	public GameObject winText;
	public UnityEngine.UI.Image imageComponent;
	public Sprite joySprite;
	public Sprite fearSprite;
	public Sprite disgustSprite;
	public Sprite sadnessSprite;
	public Sprite angerSprite;
	public Sprite surpriseSprite;
	

	// Use this for initialization
	void Start () {
		winText.SetActive(false);

		switch(GameVariables.currentEmotion) {
			case "joy":
				imageComponent.sprite = joySprite;
				break;
			case "fear":
				imageComponent.sprite = fearSprite;
				break;
			case "disgust":
				imageComponent.sprite = disgustSprite;
				break;
			case "sadness":
				imageComponent.sprite = sadnessSprite;
				break;
			case "anger":
				imageComponent.sprite = angerSprite;
				break;
			case "surprise":
				imageComponent.sprite = surpriseSprite;
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}