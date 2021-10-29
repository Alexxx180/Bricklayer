using UnityEngine;

public class Punches : MonoBehaviour
{
    public GameObject zone;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !zone.activeSelf)
            Punch();
    }

    // There we are activating fight zone - it will damage foes
    private async void Punch()
    {
        animator.SetBool("isHit", true);
        zone.SetActive(true);
        await System.Threading.Tasks.Task.Delay(1200);
        animator.SetBool("isHit", false);
        zone.SetActive(false);
    }
}
