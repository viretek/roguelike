using UnityEngine;
using System.Collections.Generic;

public class RoomController : MonoBehaviour
{
    private GameObject player;
    private GameObject door1;
    private GameObject door2;
    private GameObject door3;
    private GameObject door4;
    public bool LeftDoor;
    public bool RightDoor;
    public bool UpDoor;
    public bool DownDoor; 
    public bool PlayerHere;
    private int Counter;

    void Start()
    {
        PlayerHere = false;

        // Получаем ссылку на игрока
        player = GameObject.FindGameObjectWithTag("Player");

        door1 = transform.Find("DoorDown").gameObject;
        door2 = transform.Find("DoorLeft").gameObject;
        door3 = transform.Find("DoorUp").gameObject;
        door4 = transform.Find("DoorRight").gameObject;


    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        Counter++;
        Debug.Log("Кто то где то");
        if (other.CompareTag("Player"))
        {
            PlayerHere = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Counter--;
    }

    void Update()
    {


        if (!PlayerHere)
        {
            if (!PlayerHere)
            {
                // Отключаем двери, у которых нет соответствующего флага равного false
                if (LeftDoor)
                {
                    door2.SetActive(false);
                }
                if (RightDoor)
                {
                    door4.SetActive(false);
                }
                if (UpDoor)
                {
                    door3.SetActive(false);
                }
                if (DownDoor)
                {
                    door1.SetActive(false);
                }
                Debug.Log("Я есть");
            }

            Debug.Log("Я есть");
        }


        if (PlayerHere)
        {
            if (PlayerHere)
        {
            Debug.Log("ОН СЗДЕСЬ ААААА");
            if (LeftDoor)
            {
                door2.SetActive(true);
            }
            if (RightDoor)
            {
                door4.SetActive(true);
            }
            if (UpDoor)
            {
                door3.SetActive(true);
            }
            if (DownDoor)
            {
                door1.SetActive(true);
            }
        }

        }
        
        if (Counter == 1)
        {
            PlayerHere = false;
        }

    }

}
