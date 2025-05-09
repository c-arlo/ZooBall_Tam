using UnityEngine;
using UnityEngine.UI;

public class RotationBtn : MonoBehaviour
{   
    public GameObject stage;
    public float rotationSpeed = 1f;
    private float targetRotationZ = 0f;
    public float pointRot = 20f;
    private float lastPress;
    public float btnDelay = 1f;
    public AudioClip spinSound;

    void Update()
    {
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetRotationZ);
        stage.transform.rotation = Quaternion.Lerp(stage.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    public void RotateLeft()
    {
        if (Time.time < lastPress + btnDelay) {return;}
        targetRotationZ += pointRot;
        lastPress = Time.time;
        SoundManager.instance.PlaySound(spinSound, transform, 1f, false);
    }
    
    public void RotateRight()
    {
        if (Time.time < lastPress + btnDelay) {return;}
        targetRotationZ -= pointRot;
        lastPress = Time.time;
        SoundManager.instance.PlaySound(spinSound, transform, 1f, false);
    }
}
