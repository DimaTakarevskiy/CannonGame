using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float _timeToLive;
    [SerializeField]
    private TextMeshProUGUI _timeView;

    void Update()
    {
        _timeToLive -= Time.deltaTime;
        _timeView.text = "Time: " + (Math.Round(_timeToLive, 2)).ToString();

        if (_timeToLive <= 0f)
        {
            //˸��, � ���� � ��� ��� ������ ����� � �������� ����� �����? ������ ��� ������� ��� ���-�� �����������
            SceneManager.LoadScene(1);

			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
    }
}
