using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(Animator))]
public class CharacterAnimations : MonoBehaviour
{
    private int AnimatorValueSpeed = Animator.StringToHash("Speed");

    private CharacterController _characterMovement;
    private Animator _animator;

    private void Awake()
    {
        _characterMovement = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _animator.SetFloat(AnimatorValueSpeed, _characterMovement.velocity.magnitude);
    }
}
