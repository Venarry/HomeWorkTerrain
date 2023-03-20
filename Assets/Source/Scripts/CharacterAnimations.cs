using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(Animator))]
public class CharacterAnimations : MonoBehaviour
{
    private CharacterController _characterMovement;
    private Animator _animator;

    private void Awake()
    {
        _characterMovement = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _animator.SetFloat("Speed", _characterMovement.velocity.magnitude);
    }
}
