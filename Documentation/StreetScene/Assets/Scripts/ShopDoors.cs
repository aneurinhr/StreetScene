using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ShopDoors : MonoBehaviour {

    public AudioClip openSound;
    public AudioClip closeSound;
    public AudioClip lockPickSound;
    public GameObject interactUI;
    public GameObject person;

    public string doorTag = "";
    public float lockPickTime;

    public float rotateSpeed = 3.0f;

    private bool m_locked = true;
    private bool m_playable = false;
    private bool m_coolDown = false;
    private bool m_lockPicking = false;
    private bool m_open = false;
    private bool m_rotateMinus = false;
    private bool m_rotatePositive = false;

    private void OnTriggerEnter(Collider other)
    {
        m_playable = true;
        interactUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        m_playable = false;
        interactUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_locked == false)
        {
            if ((Input.GetButtonDown("Interact") == true) && (m_playable == true) && (m_coolDown == false))
            {
                if (m_open == true)
                {
                    StartCoroutine(Close());
                }
                else
                {
                    StartCoroutine(Open());
                }
            }
        }
        else
        {
            if ((Input.GetButtonDown("Interact") == true) && (m_lockPicking == false) && (m_playable == true))
            {
                StartCoroutine(Unlock());
            }
        }

        if ((m_rotateMinus == true) && (m_rotatePositive != true))
        {
            transform.Rotate(0, 0, - (rotateSpeed * Time.deltaTime));
        }
        else if ((m_rotatePositive == true) && (m_rotateMinus != true))
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }

    }

    IEnumerator Unlock()
    {
        GetComponent<AudioSource>().PlayOneShot(lockPickSound);
        person.GetComponent<FirstPersonController>().enabled = false;
        m_lockPicking = true;

        yield return new WaitForSeconds(lockPickTime);

        person.GetComponent<FirstPersonController>().enabled = true;
        m_locked = false;
        m_lockPicking = false;
    }

    IEnumerator Open()
    {
        m_coolDown = true;
        
        GetComponent<AudioSource>().PlayOneShot(openSound);

        yield return new WaitForSeconds(0.7f);

        m_rotateMinus = true;

        yield return new WaitForSeconds(1.0f);

        m_coolDown = false;
        m_open = true;
        m_rotateMinus = false;
    }

    IEnumerator Close()
    {
        m_coolDown = true;

        m_rotatePositive = true;

        GetComponent<AudioSource>().PlayOneShot(closeSound);

        yield return new WaitForSeconds(1);

        m_rotatePositive = false;

        yield return new WaitForSeconds(1);

        m_coolDown = false;
        m_open = false;
    }

}
