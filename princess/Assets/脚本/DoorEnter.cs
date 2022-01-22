using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnter : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform backDoor;
    private Transform playerTransform;
    private Transform princessTransform;
    private bool isPriTouchDoor;
    private bool isPlayerStopDeliver = true;
    void Start()
    {
        InvokeRepeating("FindTransformLately",0.1f,1f);//死了后重新找主角
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FindTransformLately()
    {
        playerTransform = GameObject.FindWithTag("Tag_cha").GetComponent<Transform>();
        princessTransform = GameObject.FindWithTag("Tag_pri").GetComponent<Transform>();
    }
    void EnterDoor()
    {
        if (isPlayerStopDeliver == false)
        {
            playerTransform.position = backDoor.position;
        }
        if (isPriTouchDoor)
        {
            princessTransform.position = backDoor.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tag_cha")
            && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            Debug.Log("触碰到门了");
            isPlayerStopDeliver = false;
            Invoke("EnterDoor", 0.7f);
        }
        if (other.gameObject.CompareTag("Tag_pri")
            && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            Debug.Log("触碰到门了");
            isPriTouchDoor = true;
            Invoke("EnterDoor", 0.5f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        playerTransform = GameObject.FindWithTag("Tag_cha").GetComponent<Transform>();
        princessTransform = GameObject.FindWithTag("Tag_pri").GetComponent<Transform>();
        if (other.gameObject.CompareTag("Tag_cha")
            && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            isPlayerStopDeliver = true;
        }

        if (other.gameObject.CompareTag("Tag_pri")
            && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            isPriTouchDoor = false;
        }
    }
}
