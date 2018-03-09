using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRunner : MonoBehaviour {

	public UnityEngine.UI.Image imageComponent;
	public AudioSource audioSource;

	string[] emotions = {"joy", "fear", "disgust", "sadness", "anger", "surprise"};

	// Use this for initialization
	void Start () {
		generateQuestion();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void generateQuestion() {
		int nr = Random.Range(0,5);
		string emotion = emotions[nr];
		changeImage(emotion);
		playSound(emotion);
	}

	void changeImage(string emotion) {
		Texture2D texture = Resources.Load("Game/QuestionImages/" + emotion + "1") as Texture2D;
		Rect rect = new Rect(0.0f, 0.0f, texture.width, texture.height);
		Vector2 pivot = new Vector2(0.5f, 0.5f);
		Sprite sprite = Sprite.Create(texture, rect, pivot);
		Debug.Log(sprite);
		imageComponent.sprite = sprite;
	}

	void playSound(string emotion) {
		 AudioClip clip = Resources.Load<AudioClip>("Game/QuestionSounds/" + emotion + "1");
		 Debug.Log(clip);
		 audioSource.PlayOneShot(clip);
	}

}