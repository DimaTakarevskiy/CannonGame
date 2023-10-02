using UnityEngine;

public class Target : MonoBehaviour
{
	[SerializeField]
	private GameManager _gameManager;
	[SerializeField]
	private AudioSource _hitSound;

	private void OnCollisionEnter(Collision collision)
	{
		_hitSound.Play();

		Vector3 newPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(1f, 10f), 13);

		var ball = Instantiate(gameObject, newPosition, Quaternion.identity);

		Destroy(collision.gameObject);

		Destroy(gameObject);

		_gameManager.AddScore(true);
	}
}
