using System.Collections;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject thirdCam;
    public GameObject firstCam;
    public int CamMode;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ViewSwitch"))
        {
            ChangeView();
        }
    }

    // There we change view
    void ChangeView()
    {
        if (CamMode == 1)
        {
            CamMode = 0;
        }
        else
        {
            CamMode += 1;
        }
        StartCoroutine(CanChange());
    }

    // Wait till we can change views then change them
    IEnumerator CanChange()
    {
        yield return new WaitForSeconds(0.1f);
        if (CamMode == 0)
        {
            thirdCam.SetActive(true);
            firstCam.SetActive(false);
        }
        if (CamMode == 1)
        {
            firstCam.SetActive(true);
            thirdCam.SetActive(false);
        }
    }
}
