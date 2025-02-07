using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchOnStop : MonoBehaviour
{
    public string sceneName = "GUI_Scene";
    public float checkTime = 2f;
    private Vector3 lastPosition;
    private float timer;

    void Start()
    {
        lastPosition = transform.position;
        timer = 0f;
    }

    void Update()
    {
        if (transform.position == lastPosition)
        {
            timer += Time.deltaTime;
            if (timer >= checkTime)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            timer = 0f;
            lastPosition = transform.position;
        }
    }
}
