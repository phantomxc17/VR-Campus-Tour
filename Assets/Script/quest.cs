using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class quest : MonoBehaviour
{
    public int quest_num = 1;
    public GameObject quest_shown;
    public TextMeshProUGUI txt;
    public GameObject txt_attend;
    public GameObject phone;
    public GameObject not_attend;
    public GameObject attend;
    public GameObject transisi;
    public GameObject target1;
    public GameObject target2;

    public GameObject directional;

    public Animator trans;
    public GameObject door;

    void to_slsc()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        trans.SetTrigger("start");

        yield return new WaitForSeconds(1);

        directional.SetActive(false);

        SceneManager.LoadScene(1);
    }
    void set_text()
    {
        if(quest_num <= 3)
        {
            txt.text = "Do Wifi Attendance";
        }
        else if(quest_num == 4)
        {
            txt.text = "Take a sit";
        }
        else
        {
            txt.text = "Leave the class";
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Target1" || col.gameObject.name == "Target2")
        {
            target1.SetActive(false);
            target2.SetActive(false);
            quest_num = 5;
            set_text();
            door.SetActive(true);
        }

        if(col.gameObject.name == "Target3")
        {
            // transisi
            txt.text = "Quest Complete";
            transisi.SetActive(true);
            to_slsc();
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
    
    public PlayerMovement speedy;
    void Start()
    {
        set_text();
        // phone.SetActive(false);
        not_attend.SetActive(false);
        attend.SetActive(false);
        speedy.moveSpeed = 0f;
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
        if(Input.GetKeyDown("f") || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            if(quest_num == 1)
            {
                phone.SetActive(true);
                not_attend.SetActive(true);
                quest_num = 2;
            }
            else if(quest_num == 2)
            {
                not_attend.SetActive(false);
                attend.SetActive(true);
                quest_num = 3;
            }
            else if(quest_num == 3)
            {
                phone.SetActive(false);
                attend.SetActive(false);
                quest_num = 4;
                txt_attend.SetActive(false);
                target1.SetActive(true);
                target2.SetActive(true);
                speedy.moveSpeed = 1.5f;
            }
            set_text();
        }
    }
}
