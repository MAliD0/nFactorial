using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Switch : Stated
{
    [SerializeField]
    private GameObject switchRod;
    [SerializeField]
    private GameObject switchPad;

    private new HingeJoint2D hingeJoint;//joint which restricts rotation of "switchRod" accordingly to "switchPad" with allowed angle radius
    private void Start()
    {
        hingeJoint = switchPad.GetComponent<HingeJoint2D>();
    }
    void Update()
    {
        if (hingeJoint.limits.max - 2.5 < hingeJoint.jointAngle && hingeJoint.jointAngle < hingeJoint.limits.max + 2.5)//detecting tilt of levels' active part
        {
            if (!pressed) return; // avoiding multiple calls

            print("OnPress false");
            OnPress(false);
        }
        else if (switchRod.transform.rotation.eulerAngles.z < 90)
        {
            if (pressed) return;// avoiding multiple calls

            print("OnPress true");
            OnPress(true);
        }
    }
}
