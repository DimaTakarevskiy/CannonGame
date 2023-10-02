using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textResult;
	[SerializeField]
	private Canvas _menu;
	[SerializeField]
	private GameObject _targetPrefab;
	[SerializeField]
	private AudioSource _backgroundMusic;
	private int _score;
	private bool _gameActive = true;

	//Creating start targets
	private void Start()
	{
		for (int i = 0; i < 3; i++)
		{
			Vector3 newPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(0.5f, 10f), 13);
			var target = Instantiate(_targetPrefab, newPosition, Quaternion.identity);
		}
	}
	//Hear and in Pause mathod we process Pause and Resume
	private void Update()
	{
		_textResult.text = _score.ToString();

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			_gameActive = !_gameActive;
			Pause();
		}
	}

	private void Pause()
	{
		if (!_gameActive)
		{
			_menu.gameObject.SetActive(true);
			Time.timeScale = 0f;
			_backgroundMusic.Pause();
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		if (_gameActive)
		{
			_menu.gameObject.SetActive(false);
			Time.timeScale = 1f;
			_backgroundMusic.Play();
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}

	}

	public void AddScore(bool hit)
	{
		if (hit)
			_score += 10;
		else
			_score -= 10;
	}
}
