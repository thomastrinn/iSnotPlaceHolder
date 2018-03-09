using Affdex;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangulatKelto : ImageResultsListener {

	public AudioSource soundSource;
	public FeaturePoint[] featurePointsList;

	private float currentSurprise;
	private float currentContempt;
	private float currentAnger;
	private float currentFear;
	private float currentJoy;
	private float currentDisgust;
	private float currentSadness;
	private float currentValence;
	private float currentEngagement;

	private string biggestEmotion;
	private float biggestEmotionValue;

	private bool gotEmotion = false;

	private void Start()
	{
		updateValues();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void onFaceFound(float timestamp, int faceId)
	{
		
	}

	public override void onFaceLost(float timestamp, int faceId)
	{
		gotEmotion = false;
	}

	public override void onImageResults(Dictionary<int, Face> faces)
	{
		if (!gotEmotion) {
			foreach (KeyValuePair<int, Face> pair in faces) {
				int FaceId = pair.Key;  // The Face Unique Id.
				Face face = pair.Value;    // Instance of the face class containing emotions, and facial expression values.

				currentSurprise = 0;
				currentContempt = 0;
				currentAnger = 0;
				currentFear = 0;
				currentJoy = 0;
				currentDisgust = 0;
				currentSadness = 0;
				currentValence = 0;
				currentEngagement = 0;

				face.Emotions.TryGetValue (Emotions.Joy, out currentJoy);
				face.Emotions.TryGetValue (Emotions.Fear, out currentFear);
				face.Emotions.TryGetValue (Emotions.Contempt, out currentContempt);
				face.Emotions.TryGetValue (Emotions.Anger, out currentAnger);
				face.Emotions.TryGetValue (Emotions.Surprise, out currentSurprise);
				face.Emotions.TryGetValue (Emotions.Disgust, out currentDisgust);
				face.Emotions.TryGetValue (Emotions.Sadness, out currentSadness);
				face.Emotions.TryGetValue (Emotions.Valence, out currentValence);
				face.Emotions.TryGetValue (Emotions.Engagement, out currentEngagement);

				updateValues ();
			}
		}
	}

	private void updateValues() {
		
		biggestEmotion = "joy";
		biggestEmotionValue = currentJoy;
		if (currentFear > biggestEmotionValue) {
			biggestEmotion = "fear";
			biggestEmotionValue = currentFear;
		}
		if (currentContempt > biggestEmotionValue) {
			biggestEmotion = "contempt";
			biggestEmotionValue = currentContempt;
		}
		if (currentAnger > biggestEmotionValue) {
			biggestEmotion = "anger";
			biggestEmotionValue = currentAnger;
		}
		if (currentSurprise > biggestEmotionValue) {
			biggestEmotion = "surprise";
			biggestEmotionValue = currentSurprise;
		}
		if (currentDisgust > biggestEmotionValue) {
			biggestEmotion = "disgust";
			biggestEmotionValue = currentDisgust;
		}
		if (currentSadness > biggestEmotionValue) {
			biggestEmotion = "sadness";
			biggestEmotionValue = currentSadness;
		}

		if (biggestEmotionValue > 70) {
			gotEmotion = true;
			AudioClip clip = MoodLoader.getClip(biggestEmotion);
			soundSource.PlayOneShot(clip);
		}


	}

}
	