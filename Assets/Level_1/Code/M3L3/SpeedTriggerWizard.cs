using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTriggerWizard : MonoBehaviour
{
    public float speedFactor = 2.5f;

    void OnTriggerEnter(Collider other)
    {
        //Увеличение скорости бега игрока
        other.GetComponent<ThirdPersonMovement>().runSpeed *= speedFactor;
        other.GetComponent<Jump>().jumpStrength *= speedFactor;
    }

    void OnTriggerExit(Collider other)
    {
        //Уменьшение скорости бега игрока
        other.GetComponent<ThirdPersonMovement>().runSpeed /= speedFactor;
        other.GetComponent<Jump>().jumpStrength /= speedFactor;
    }
}
