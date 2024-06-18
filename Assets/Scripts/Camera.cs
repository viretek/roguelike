using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    // Цель, к которой будет привязана камера (персонаж)
    public Vector3 offset;      // Смещение камеры относительно цели
    public float smoothSpeed = 0.125f; // Скорость сглаживания движения камеры

    void FixedUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target is not assigned in CameraFollow script.");
            return;
        }
        
        // Желаемая позиция камеры с учетом смещения
        Vector3 desiredPosition = target.position + offset;
        
        // Плавное перемещение камеры к желаемой позиции
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Обновление позиции камеры
        transform.position = smoothedPosition;
    }
}