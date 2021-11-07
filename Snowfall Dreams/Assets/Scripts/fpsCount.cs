using UnityEngine;
using TMPro;

public class fpsCount : MonoBehaviour 
{
    public float timer, refresh = .5f, avgFramerate;
    public TextMeshProUGUI fpsCounter;

    // Functions
    private void Start() 
    {
        fpsCounter.text = "{0} fps";
    }

    private void Update() 
    {
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if (timer <= 0)
        {
            avgFramerate = (int) (1f / timelapse);
        }

        fpsCounter.text = string.Format("FPS: {0}", avgFramerate.ToString());
    }
}