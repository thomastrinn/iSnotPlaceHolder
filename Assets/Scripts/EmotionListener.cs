using Affdex;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class EmotionListener : ImageResultsListener {

	public Text emotionValue;
	public GameObject winText;
	private Boolean finished = false;

	public override void onFaceFound(float timestamp, int faceId)
    {
    }

    public override void onFaceLost(float timestamp, int faceId)
    {
    }

    public override void onImageResults(Dictionary<int, Face> faces)
    {
    	if (finished) {
    		return;
    	}

        foreach (KeyValuePair<int, Face> pair in faces)
        {
            Face face = pair.Value;

            Emotions emotion = Emotions.Joy;

            switch(GameVariables.currentEmotion) {
				case "joy":
					emotion = Emotions.Joy;
					break;
				case "fear":
					emotion = Emotions.Fear;
					break;
				case "disgust":
					emotion = Emotions.Disgust;
					break;
				case "sadness":
					emotion = Emotions.Sadness;
					break;
				case "anger":
					emotion = Emotions.Anger;
					break;
				case "surprise":
					emotion = Emotions.Surprise;
					break;
			}

           	float currentEmotion = 0;

            face.Emotions.TryGetValue(emotion, out currentEmotion);

        	emotionValue.text = "" + (int) currentEmotion + "/100";

			if (currentEmotion > 70) {
				winText.SetActive(true);
				finished = true;

				StartCoroutine(OpenJatekScene());
			}
        }
    }

    public IEnumerator OpenJatekScene() {
    	yield return new WaitForSeconds(5);
    	SceneManager.LoadScene("Jatek", LoadSceneMode.Single);
    }
}
