using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target; // ���� ��� ���������� (�����)
    public float smoothSpeed = 0.125f; // �������� ���������� ������. ��� ������ ��������, ��� ������� ����� ��������.
    public Vector3 offset; // �������� ������ ������������ ������

    void LateUpdate() // ���������� LateUpdate ��� ���������� ������ ����� ���� ������ ����������
    {
        Vector3 desiredPosition = target.position + offset; // �������� ������� ������
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime); // ���������� Lerp ��� �������� ����������

        transform.position = smoothedPosition; // ��������� ������� ������
    }
}
