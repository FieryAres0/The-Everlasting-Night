using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public GameObject target;
    public Image fillImage;
    private Slider slider;

    [SerializeField] float current;
    [SerializeField] float max;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        current = target.GetComponent<Player_HP_Script>().getHealth();
        max = target.GetComponent<Player_HP_Script>().getMaxHealth();
        
        float fillValue = current / max;
        slider.value = fillValue;
    }
}
