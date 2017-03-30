using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float maxHp;
    public float curHp;
    private float hpBarLength;
    private float hpPercentage;

    private void Start()
    {
        curHp = maxHp;
        slider.maxValue = maxHp;
        slider.minValue = 0;
    }

    void Update()
    {
        //clamp values
        curHp = Mathf.Clamp(curHp, 0, maxHp);

        hpPercentage = curHp / maxHp;
        hpBarLength = hpPercentage * maxHp;

        slider.value = hpBarLength;
    }
}