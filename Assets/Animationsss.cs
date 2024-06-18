using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator animator;
    private Vector3 movementDirection;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Получаем направление движения персонажа
        movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        // Определяем угол направления движения
        float angle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;

        // Выбираем анимацию, основываясь на угле направления
        if (angle >= -22.5f && angle < 22.5f)
        {
            animator.SetTrigger("Right");
        }
        else if (angle >= 22.5f && angle < 67.5f)
        {
            animator.SetTrigger("Up");
        }
        else if (angle >= 67.5f && angle < 112.5f)
        {
            animator.SetTrigger("Up");
        }
        else if (angle >= 112.5f && angle < 157.5f)
        {
            animator.SetTrigger("Up");
        }
        else if (angle >= 157.5f || angle < -157.5f)
        {
            animator.SetTrigger("LeftMovement");
        }
        else if (angle >= -157.5f && angle < -112.5f)
        {
            animator.SetTrigger("Down");
        }
        else if (angle >= -112.5f && angle < -67.5f)
        {
            animator.SetTrigger("Down");
        }
        else if (angle >= -67.5f && angle < -22.5f)
        {
            animator.SetTrigger("Down");
        }
    }
}
