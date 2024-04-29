using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamEff : MonoBehaviour
{
    public Camera mainCamera; // ������ �� �������� ������
    public GameObject targetObject; // ������ �� ������, ������� ������ �� ���
    public float startZoom = 5f; // ��������� ������ ��������������� ������
    public float zoomToTarget = 4f; // ������ ������ ��� �������� �������
    public float zoomToDefault = 3f; // ������ ������ ��� ���������� �������
    public float zoomSpeed = 1f; // �������� ��������� ����

    void Start()
    {
        mainCamera.orthographicSize = startZoom; // ������������� ��������� ���
        StartCoroutine(ZoomCamera()); // ��������� �������� ��� �������� ��������� ����
    }

    IEnumerator ZoomCamera()
    {
        while (true)
        {
            if (targetObject != null && !targetObject.activeSelf)
            {
                // ������ ��������� ��� �� zoomToDefault
                while (mainCamera.orthographicSize > zoomToDefault)
                {
                    mainCamera.orthographicSize -= zoomSpeed * Time.deltaTime;
                    yield return null;
                }
            }
            else
            {
                // ������ ��������� ��� �� zoomToTarget
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
