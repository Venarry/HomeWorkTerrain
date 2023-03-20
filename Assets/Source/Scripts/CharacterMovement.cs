using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private const string VectorHorizontal = "Horizontal";
    private const string VectorVertical = "Vertical";

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private CharacterController _characterController;
    private Vector3 _moveDirection;

    public float Velocity => _characterController.velocity.magnitude;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        _moveDirection.x = Input.GetAxis(VectorHorizontal);
        _moveDirection.z = Input.GetAxis(VectorVertical);

        _characterController.Move(_moveDirection * _moveSpeed);
    }

    private void Rotate()
    {
        if (_characterController.velocity.magnitude == 0)
            return;

        Quaternion lookDirection = Quaternion.LookRotation(_moveDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookDirection, _rotationSpeed);
    }
}
