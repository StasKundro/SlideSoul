using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamEff : MonoBehaviour
{
    public Camera mainCamera; // Ссылка на основную камеру
    public GameObject targetObject; // Ссылка на объект, который влияет на зум
    public float startZoom = 5f; // Начальный размер ортографической камеры
    public float zoomToTarget = 4f; // Размер камеры при активном объекте
    public float zoomToDefault = 3f; // Размер камеры при неактивном объекте
    public float zoomSpeed = 1f; // Скорость изменения зума

    void Start()
    {
        mainCamera.orthographicSize = startZoom; // Устанавливаем начальный зум
        StartCoroutine(ZoomCamera()); // Запускаем корутину для плавного изменения зума
    }

    IEnumerator ZoomCamera()
    {
        while (true)
        {
            if (targetObject != null && !targetObject.activeSelf)
            {
                // Плавно уменьшаем зум до zoomToDefault
                while (mainCamera.orthographicSize > zoomToDefault)
                {
                    mainCamera.orthographicSize -= zoomSpeed * Time.deltaTime;
                    yield return null;
                }
            }
            else
            {
                // Плавно уменьшаем зум до zoomToTarget
                while (mainCamera.orthographicSize > zoomToTarget)
                {
                    mainCamera.orthographicSize -= zoomSpeed * Time.deltaTime;
                    yield return null;
                }
            }

            yield return null;
        }
    }
}
