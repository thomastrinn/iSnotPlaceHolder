using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
	private bool camAvailable;
	private WebCamTexture frontCamera;
	private Texture defaultBackground;

	public RawImage bachground;
	public AspectRatioFitter fit;
	
	private void Start ()
	{
		defaultBackground = bachground.texture;
		WebCamDevice[] devices = WebCamTexture.devices;

		if (devices.Length == 0)
		{
			Debug.Log("No camera detected");
			camAvailable = false;
			return;
		}
		
		for (int i = 0; i < devices.Length; i++)
		{
			Debug.Log(devices[i].name);
			if (!devices[i].isFrontFacing)
			{
				frontCamera = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
				break;
			}
		}

		if (frontCamera == null)
		{
			Debug.Log("Unable to find front camera");
			camAvailable = false;
			return;
		}

		frontCamera.Play();
		bachground.texture = frontCamera;

		camAvailable = true;
	}
	
	private void Update () {
		if (!camAvailable)
		{
			return;
		}

		float ration = (float) frontCamera.width / (float) frontCamera.height;

		fit.aspectRatio = ration;

		float scaleY = frontCamera.videoVerticallyMirrored ? -1f : 1f;

		bachground.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

		int orient = -frontCamera.videoRotationAngle;
		bachground.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
	}
}
