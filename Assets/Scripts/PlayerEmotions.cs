using Affdex;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEmotions : ImageResultsListener
{
    public Text JoyValue;
    public Text FearValue;
    public Text DisgustValue;
    public Text SadnessValue;
    public Text AngerValue;
    public Text SurpriseValue;
    public Text ContemptValue;
    public Text ValenceValue;
    public Text EngagementValue;

    private float currentSurprise;
    private float currentContempt;
    private float currentAnger;
    private float currentFear;
    private float currentJoy;
    private float currentDisgust;
    private float currentSadness;
    private float currentValence;
    private float currentEngagement;
    
    public FeaturePoint[] featurePointsList;

    private void Start()
    {
        updateValues();
    }

    public override void onFaceFound(float timestamp, int faceId)
    {
        Debug.Log("Found the face");
    }

    public override void onFaceLost(float timestamp, int faceId)
    {
        Debug.Log("Lost the face");
    }

    public override void onImageResults(Dictionary<int, Face> faces)
    {
        foreach (KeyValuePair<int, Face> pair in faces)
        {
            int FaceId = pair.Key;  // The Face Unique Id.
            Face face = pair.Value;    // Instance of the face class containing emotions, and facial expression values.

            Debug.Log("Got face results: " + FaceId);

            currentSurprise = 0;
            currentContempt = 0;
            currentAnger = 0;
            currentFear = 0;
            currentJoy = 0;
            currentDisgust = 0;
            currentSadness = 0;
            currentValence = 0;
            currentEngagement = 0;

            face.Emotions.TryGetValue(Emotions.Joy, out currentJoy);
            face.Emotions.TryGetValue(Emotions.Fear, out currentFear);
            face.Emotions.TryGetValue(Emotions.Contempt, out currentContempt);
            face.Emotions.TryGetValue(Emotions.Anger, out currentAnger);
            face.Emotions.TryGetValue(Emotions.Surprise, out currentSurprise);
            face.Emotions.TryGetValue(Emotions.Disgust, out currentDisgust);
            face.Emotions.TryGetValue(Emotions.Sadness, out currentSadness);
            face.Emotions.TryGetValue(Emotions.Valence, out currentValence);
            face.Emotions.TryGetValue(Emotions.Engagement, out currentEngagement);
            
            updateValues();
        }
    }

    private void updateValues() {
        JoyValue.text = "Joy: " + (int) currentJoy + "/100";
        FearValue.text = "Fear: " + (int) currentFear + "/100";;
        ContemptValue.text = "Contempt: " + (int) currentContempt + "/100";
        AngerValue.text = "Anger: " + (int) currentAnger + "/100";
        SurpriseValue.text = "Surprise: " + (int) currentSurprise + "/100";
        DisgustValue.text = "Disgust: " + (int) currentDisgust + "/100";
        SadnessValue.text = "Sadness: " + (int) currentSadness + "/100";
        ValenceValue.text = "Valence: " + (int) currentValence + "/100";
        EngagementValue.text = "Engagement: " + (int) currentEngagement + "/100";
    }

}
