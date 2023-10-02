using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    private Ball _ballPrefab;
    [SerializeField] 
    private Transform _shootPoint;
    [SerializeField]
    private float _shootPower;
    [SerializeField]
    private AudioSource _hitSound;
    [SerializeField]
    private float _mouseSensitivity;
	private bool _isShooting;


	private void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

    //Creating a cannon controller 
	private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
		var mouseY = Input.GetAxis("Mouse Y");

		transform.Rotate(-mouseY * _mouseSensitivity * Time.deltaTime, mouseX * _mouseSensitivity * Time.deltaTime, 0f);

        if(transform.rotation.x >= 30f)
        {
            Debug.Log("low");
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _hitSound.Play();
            _isShooting = true;
        }
    }
    //Creating a ball and giving it force
	private void FixedUpdate()
	{
		if(_isShooting)
        {
			var ball = Instantiate(_ballPrefab, _shootPoint.position, Quaternion.identity);

            if(ball.TryGetComponent(out Rigidbody ballRigidbody))
            {
				ballRigidbody.AddForce(_shootPower * _shootPoint.forward, ForceMode.Impulse);
			}

            _isShooting = false;
		}
	}
}
