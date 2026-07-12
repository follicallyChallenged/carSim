using UnityEngine;
using System.Collections;

public class WebcamManager : MonoBehaviour
{
    public Renderer targetRenderer;

    private WebCamTexture webcamTexture;

    private void Start()
    {
        if (WebCamTexture.devices.Length == 0)
        {
            Debug.LogError("No webcam found.");
            return;
        }

        string webcamName = WebCamTexture.devices[0].name;
        webcamTexture = new WebCamTexture(webcamName);

        if (targetRenderer != null)
        {
            targetRenderer.material.mainTexture = webcamTexture;
        }

        webcamTexture.Play();

        StartCoroutine(ApplyCameraOrientation());

        Debug.Log("Webcam started: " + webcamName);
    }

    private IEnumerator ApplyCameraOrientation()
    {
        yield return new WaitUntil(() => webcamTexture.width > 100);

        if (targetRenderer != null)
        {
            Vector3 scale = targetRenderer.transform.localScale;

            // Flip horizontally
            scale.x *= -1;
            targetRenderer.transform.localScale = scale;
        }
    }

    private void OnDisable()
    {
        if (webcamTexture != null && webcamTexture.isPlaying)
        {
            webcamTexture.Stop();
        }
    }

    public WebCamTexture GetWebcamTexture()
    {
        return webcamTexture;
    }
}