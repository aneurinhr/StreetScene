using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Steal : MonoBehaviour {

    public GameObject stealUI;
    public GameObject scoreUI;

    public string stealTag;
    private bool m_seeStealable = false;
    private GameObject m_stealable;
    private int m_score = 0;
	
	// Update is called once per frame
	void Update () {

        LookForStealable();

    }

    private void OnTriggerStay(Collider other)
    {
        if ((m_seeStealable == true) && (Input.GetButtonDown("Steal")))
        {
            int temp = m_stealable.GetComponent<Lootable>().Looted();
            m_score = m_score + temp;

            m_stealable.SetActive(false);

            scoreUI.GetComponent<Text>().text = "Loot Score: " + m_score;
            m_seeStealable = false;
        }
    }

    private void LookForStealable()
    {

        Ray _ray = Camera.main.ViewportPointToRay(new Vector3(0.5f ,0.5f ,0));
        RaycastHit _hit;

        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.gameObject.tag == stealTag)
            {
                stealUI.SetActive(true);
                m_seeStealable = true;
                m_stealable = _hit.collider.gameObject;
            }
            else
            {
                stealUI.SetActive(false);
                m_seeStealable = false;
            }
        }

    }

}
