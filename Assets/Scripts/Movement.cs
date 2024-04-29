using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения персонажа
    public float gridSize = 1f; // Размер клетки сетки
    private Vector2 targetPosition; // Целевая позиция персонажа
    private bool isMoving; // Флаг, указывающий на то, двигается ли персонаж
    public AudioClip press;
    public AudioSource source;

    void Update()
    {
        if (isMoving)
        {
            // Двигаем персонажа к целевой позиции
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Проверяем, достиг ли персонаж целевой позиции
            if (Vector2.Distance(transform.position, targetPosition) < 0.05f)
            {
                transform.position = targetPosition; // Устанавливаем точную позицию
                isMoving = false;
            }
        }

        // Обработка нажатий клавиш и кнопок
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                TryMove(Vector2.up);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                TryMove(Vector2.down);
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                TryMove(Vector2.left);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                TryMove(Vector2.right);
            }
        }
    }

    // Методы для кнопок управления
    public void MoveUp()
    {
        if (!isMoving)
        {
            TryMove(Vector2.up);
        }
    }

    public void MoveDown()
    {
        if (!isMoving)
        {
            TryMove(Vector2.down);
        }
    }

    public void MoveLeft()
    {
        if (!isMoving)
        {
            TryMove(Vector2.left);
        }
    }

    public void MoveRight()
    {
        if (!isMoving)
        {
            TryMove(Vector2.right);
        }
    }

    void TryMove(Vector2 direction)
    {
        Vector2 nextPosition = (Vector2)transform.position + direction * gridSize;
        source.PlayOneShot(press);
        while (CanMoveTo(nextPosition))
        {
            targetPosition = nextPosition;
            isMoving = true;

            nextPosition += direction * gridSize;
        }
    }

    bool CanMoveTo(Vector2 position)
    {
        Collider2D collider = Physics2D.OverlapPoint(position);
        return collider == null || !collider.CompareTag("Wall");
    }
}
