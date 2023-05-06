using UnityEngine;
using UnityEngine.UI;

public class FPSview : MonoBehaviour
{
    public Text fpsText;

    private float deltaTime;

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = string.Format("{0:0.} FPS", fps);
    }
}
