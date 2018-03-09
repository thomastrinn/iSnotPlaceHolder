using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRunner : MonoBehaviour {

	public UnityEngine.UI.Image imageComponent;

	// Use this for initialization
	void Start () {
		changeImage();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void changeImage() {
		Texture2D texture = Resources.Load("joy_v1") as Texture2D;
		Rect rect = new Rect(0.0f, 0.0f, texture.width, texture.height);
		Vector2 pivot = new Vector2(0.5f, 0.5f);
		Sprite sprite = Sprite.Create(texture, rect, pivot);
		Debug.Log(sprite);
		imageComponent.sprite = sprite;
	}
}