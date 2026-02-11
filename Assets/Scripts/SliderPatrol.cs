using UnityEngine;

public class SliderPatrol : MonoBehaviour
{
    private SliderJoint2D slider;
    private JointMotor2D motor;

    void Start()
    {
        slider = GetComponent<SliderJoint2D>();
        motor = slider.motor;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ReverseMotor();
    }

    private void ReverseMotor()
    {
        motor.motorSpeed *= -1;
        slider.motor = motor;
    }
}