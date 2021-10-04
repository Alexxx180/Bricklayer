using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("isRun", Input.GetKey(KeyCode.W));
        _animator.SetBool("isAttack", Input.GetButtonDown("Fire1"));
    }
}
