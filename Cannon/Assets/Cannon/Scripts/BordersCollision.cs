using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordersCollision : MonoBehaviour
{
	[SerializeField]
	private GameManager _gameManager;

	private void OnCollisionEnter(Collision collision)
	{
		Destroy(collision.gameObject);
		_gameManager.AddScore(false);
	}
}
