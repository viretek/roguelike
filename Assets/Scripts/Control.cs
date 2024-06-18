using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения персонажа
    public Animator anim;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isInvisible = false;
    private float invisibilityDuration = 3f; // Время невидимости в секундах
    private float invisibilityCooldown = 0f; // Время до следующей возможности стать невидимым

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Получение ввода от пользователя
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        anim.SetBool("IsMovingRight", movement.x > 0);
        anim.SetBool("IsMovingLeft", movement.x < 0);
        anim.SetBool("IsMovingUp", movement.y > 0);
        anim.SetBool("IsMovingDown", movement.y < 0);

        // Проверка на нажатие клавиши Q
        if (Input.GetKey(KeyCode.Q))
        {
            if (isInvisible == false)
            {
                StartCoroutine(BecomeInvisible());
            }
        }
    }

    void FixedUpdate()
    {
        // Перемещение персонажа
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private IEnumerator BecomeInvisible()
    {
        isInvisible = true;
        anim.SetBool("IsInvisible", true); // Проигрывание анимации невидимости
        GetComponent<Collider2D>().enabled = false; // Отключение хитбокса
        GetComponent<SpriteRenderer>().enabled = false; // Отключение спрайта

        while (Input.GetKey(KeyCode.Q))
        {
            yield return null;
            invisibilityCooldown = 3f; // Начинается перезарядка способности
        }

        isInvisible = false;
        anim.SetBool("IsInvisible", false);
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;

    }
}