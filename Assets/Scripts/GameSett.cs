using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSett : MonoBehaviour
{
    private AudioSource[] allAudioSources;


    public int target = 120;

    void Awake()
    {
        Application.targetFrameRate = target;
    }

    void Update()
    {
        if (Application.targetFrameRate != target)
            Application.targetFrameRate = target;
    }

    void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            // ��������� ���� �� �����
            Time.timeScale = 0f;
            // ��������� ��� �����
            foreach (var audioSource in allAudioSources)
            {
                audioSource.Pause();
            }
        }
        else
        {
            // ����������� ����
            Time.timeScale = 1f;
            // �������� ��� �����
            foreach (var audioSource in allAudioSources)
            {
                audioSource.UnPause();
            }
        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            // ��������� ���� �� �����
            Time.timeScale = 0f;
            // ��������� ��� �����
            foreach (var audioSource in allAudioSources)
            {
                audioSource.Pause();
            }
        }
        else
        {
            // ����������� ����
            Time.timeScale = 1f;
            // �������� ��� �����
            foreach (var audioSource in allAudioSources)
            {
                audioSource.UnPause();
            }
        }
    }
}
