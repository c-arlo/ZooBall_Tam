using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip itemSound;
    public AudioClip winSound;
    void OnTriggerEnter(Collider Item)
    {
        if(Item.gameObject.CompareTag("Item"))
        {
            Item.gameObject.SetActive(false);
            SoundManager.instance.PlaySound(itemSound, transform, 1f, false);
            MenuController.instance.AddScore();
        }

        if(Item.gameObject.CompareTag("Exit"))
        {
            //Item.gameObject.SetActive(false);
            SoundManager.instance.PlaySound(winSound, transform, 1f, false);
            MenuController.instance.GameWon();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Stage"))
        {
            Rigidbody rb = transform.parent.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = new Vector3(0.1f, 0.1f, 0f);
            }
        }
    }
}
