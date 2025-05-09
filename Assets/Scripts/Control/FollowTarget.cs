using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 100f;
    public Vector3 offset = new Vector3(-0.4f, 8.4f, 30f);

    void OnEnable()
    {
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(5);
        transform.gameObject.SetActive(false);
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            transform.LookAt(target);
        }
    }
}
