using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class quest_slsc_pc : MonoBehaviour
{
    public int quest_num = 1;
    public GameObject quest_shown;
    public TextMeshProUGUI txt;
    public GameObject txt_attend;
    public GameObject phone;
    public GameObject not_attend;
    public GameObject target1;
    public GameObject target2;

    void set_text()
    {
        if(quest_num == 1)
        {
            txt.text = "Check Your Attendance";
        }
        else if(quest_num == 2)
        {
            txt.text = "Get SSC queue number";
        }
        else if(quest_num == 3)
        {
            txt.text = "Go to the SSC counter";
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Target1")
        {
            target1.SetActive(false);
            target2.SetActive(true);
            quest_num = 3;
            set_text();
        }
    }
    void show_quest()
    {
        if(quest_shown.activeInHierarchy)
        {
            quest_shown.SetActive(false);
        }
        else
        {
            quest_shown.SetActive(true);
        }
    }
    
    void Start()
    {
        set_text();
        phone.SetActive(false);
    }
    void Update()
    {
        // Quest
        if(Input.GetKeyDown("q"))
        {
            set_text();
            show_quest();
        }

        // interact
        if(Input.GetKeyDown("f"))
        {
            if(quest_num == 1)
            {
                quest_num = 2;
                txt_attend.SetActive(false);
                target1.SetActive(true);
            }

            if(phone.activeInHierarchy)
            {
                phone.SetActive(false);
            }
            else
            {
                phone.SetActive(true);
            }
            set_text();
        }
    }
}
