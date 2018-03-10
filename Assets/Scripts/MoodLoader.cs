using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoodLoader {

	public static AudioClip getClip(string emotion) {
		int nr = Random.Range(1,6);
		return Resources.Load<AudioClip>("Mood/" + emotion + "/" + emotion + nr);
	}
}
