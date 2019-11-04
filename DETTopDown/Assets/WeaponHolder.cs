using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;

    int currentIndex;

    private void Update()
    {
        if (Input.GetButtonDown("WeaponUp"))
        {
            weapons[currentIndex].SetActive(false);
            currentIndex = (currentIndex + 1) % weapons.Length;
            weapons[currentIndex].SetActive(true);
        }

        if (Input.GetButtonDown("WeaponDown"))
        {
            weapons[currentIndex].SetActive(false);
            currentIndex = (currentIndex - 1) % weapons.Length;
            weapons[currentIndex].SetActive(true);
        }
    }
}
