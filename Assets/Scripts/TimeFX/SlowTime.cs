using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController controller;

    public float timeScale = 0.5f;
    public float slowDownLength = 5.0f;

    void Update()
    {
        Time.timeScale += (1.0f / slowDownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0.0f, 1.0f);

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            Time.timeScale = timeScale;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
    }
}
