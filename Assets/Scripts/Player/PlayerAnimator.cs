using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("isRun", KD(KeyCode.W) || KD(KeyCode.A) || KD(KeyCode.S) || KD(KeyCode.D));
        _animator.SetBool("isAttack", Input.GetButtonDown("Fire1"));
    }
    private bool KD(KeyCode code)
    {
        return Input.GetKeyDown(code);
    }
}
