using UnityEngine;

public class ShowInfo : MonoBehaviour
{
    public GameObject infoScreen;
    public GameObject gameUI;
    public GameObject playerPointer;
    public GameObject exitPointer;
    public GameObject player;

    public void ShowInfoScreen()
    {
        infoScreen.SetActive(true);
        gameUI.SetActive(false);
        //player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Time.timeScale = 0;
        playerPointer.SetActive(false);
    }

    public void HideInforScreen()
    {
        infoScreen.SetActive(false);
        gameUI.SetActive(true);
        //player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Time.timeScale = 1;
        playerPointer.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ShowInfoScreen();
        }
    }

}
