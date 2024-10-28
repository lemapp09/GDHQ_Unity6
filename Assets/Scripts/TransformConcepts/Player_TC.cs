using UnityEngine;

// Don't allow duplicate scripts
[DisallowMultipleComponent]
public class Player_TC : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _rightBounds, _leftBounds, _frontBounds, _backBounds;
    [SerializeField] private float _floorLimits, _speed, _rotationSpeed = 1f;
    private bool _init;

    [SerializeField] private bool _smooth;
    
    void Start()
    {
        _init = false;
    }
    
    void Update()
    {
        // Rotate cube 30 degrees per second around the Y axis
        if (!_init)
        {
            transform.Rotate(0, 30 * Time.deltaTime * _rotationSpeed, 0);
        }
        else
        {
            if (!_smooth) {
                SmoothMovement();
            }  else   {
                SnapMovement();
            }
        }
        // stop rotating when Space key is pressed
        // then move cube to _startPosition
        if (Input.GetKeyDown(KeyCode.Space) && !_init)
        {
            transform.position = _startPosition;
            //  transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.localEulerAngles = new Vector3(0, 0, 0);
            _init = true;
        }
    }

    private void SmoothMovement()
    {
        // Smooth movement using transform.translate using time.deltaTime, using GetAxisRaw("Horizontal") and GetAxisRaw("Vertical")
        // GetAxis returns a value between -1 and 1
        // GetAxisRaw returns either -1, 0, or 1
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movement = _speed * Time.deltaTime * new Vector3(x, 0, z);
        transform.Translate(movement);

        // clamp the position between the floor bounds
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, _leftBounds, _rightBounds);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, _backBounds, _frontBounds);
    
        // Update the position of the cube
        transform.position = clampedPosition;
    }

    
    private void SnapMovement()
    {
        // Using WASD keys, move the cube along the floor, 1 unit at a time, in the XZ plane. 
        // Need to limit the cube between the floor limits -2 and 2
        if (Input.GetKeyDown(KeyCode.W))  
        {
            transform.position += Vector3.forward;
            if (transform.position.z > _frontBounds)
            {
                transform.position = new Vector3(transform.position.x, _floorLimits, _frontBounds);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += Vector3.back;
            if (transform.position.z < _backBounds)
            {
                transform.position = new Vector3(transform.position.x, _floorLimits, _backBounds);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left;
            if (transform.position.x < _leftBounds)
            {
                transform.position = new Vector3(_leftBounds, _floorLimits, transform.position.z);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right;
            if (transform.position.x > _rightBounds)
            {
                transform.position = new Vector3(_rightBounds, _floorLimits, transform.position.z);
            }
        }
    }

    public void ToggleSmooth()
    {
        _smooth = !_smooth;
    }
}
