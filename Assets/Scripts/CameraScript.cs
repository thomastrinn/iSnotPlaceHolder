using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Affdex;

public class CameraScript : MonoBehaviour, IDetectorInput
{
	private bool camAvailable;
	private WebCamTexture camTexture;
	private Texture defaultBackground;

	public RawImage bachground;
	public AspectRatioFitter fit;
	
	public Detector detector
	{
		get; private set;
	}
	
	/// <summary>
	/// The texture that is being modified for processing
	/// </summary>
	public Texture Texture
	{
		get
		{
			return camTexture;
		}
	}
	
	void OnEnable()
	{

		StartCoroutine(SampleRoutine());
	}
	
	/// <summary>
	/// Coroutine to sample frames from the camera
	/// </summary>
	/// <returns></returns>
	private IEnumerator SampleRoutine()
	{
		while (enabled)
		{
			yield return new WaitForSeconds(1 / 20);
			ProcessFrame();
		}
	}
	
	private void Start ()
	{
		defaultBackground = bachground.texture;
		
		detector = GetComponent<Detector>();
		
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
			if (devices[i].isFrontFacing)
			{
				camTexture = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
				break;
			}
		}

		if (camTexture == null)
		{
			Debug.Log("Unable to find front camera");
			camAvailable = false;
			return;
		}

		camTexture.Play();
		bachground.texture = camTexture;

		camAvailable = true;
	}
	
	private void Update () {
		if (!camAvailable)
		{
			return;
		}

		float ration = (float) camTexture.width / (float) camTexture.height;

		fit.aspectRatio = ration;

		float scaleY = camTexture.videoVerticallyMirrored ? -1f : 1f;

		bachground.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

		int orient = -camTexture.videoRotationAngle;
		bachground.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
	}

	/// <summary>
	/// Sample an individual frame from the webcam and send to detector for processing.
	/// </summary>
	public void ProcessFrame()
	{

		if (camTexture == null)
		{
			return;
		}

		if (!detector.IsRunning)
		{
			return;
		}

		if (!camTexture.isPlaying)
		{
			return;
		}
		
		Frame.Orientation orientation = Frame.Orientation.Upright;
		// account for camera rotation on mobile devices
		switch (camTexture.videoRotationAngle)
		{
			case 90:
				orientation = Frame.Orientation.CW_90;
				break;
			case 180:
				orientation = Frame.Orientation.CW_180;
				break;
			case 270:
				orientation = Frame.Orientation.CW_270;
				break;
		}

		Frame frame = new Frame(camTexture.GetPixels32(), camTexture.width, camTexture.height, orientation,
			Time.realtimeSinceStartup);
		detector.ProcessFrame(frame);
	}
}
