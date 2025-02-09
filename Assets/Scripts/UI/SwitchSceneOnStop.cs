using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchOnStop : MonoBehaviour
{
    public string sceneName = "NextScene"; // Název scény, na kterou se přepne
    public float checkTime = 2f; // Čas, po který musí být objekt nehybný
    public float startDelay = 2f; // Čas před začátkem kontroly pohybu
    private Vector3 lastPosition;
    private float timer;
    private float delayTimer;
    private bool canCheck = false;

    void Start()
    {
        lastPosition = transform.position;
        timer = 0f;
        delayTimer = 0f;
    }

    void Update()
    {
        if (!canCheck)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= startDelay)
            {
                canCheck = true;
            }
            return;
        }

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

