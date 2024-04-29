using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target; // Цель для следования (игрок)
    public float smoothSpeed = 0.125f; // Скорость следования камеры. Чем меньше значение, тем плавнее будет движение.
    public Vector3 offset; // Смещение камеры относительно игрока

    void LateUpdate() // Используем LateUpdate для обновления камеры после всех других обновлений
    {
        Vector3 desiredPosition = target.position + offset; // Желаемая позиция камеры
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime); // Используем Lerp для плавного следования

        transform.position = smoothedPosition; // Обновляем позицию камеры
    }
}
