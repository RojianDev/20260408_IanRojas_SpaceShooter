using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpecialBar : MonoBehaviour
{
    Slider slider;
    [SerializeField] Image Fill;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        slider.value = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Global.instance.specialBar;
        if (slider.value >= 1)
        {
            Fill.color = Color.yellow;
        }
        else
        {
            Fill.color = Color.greenYellow;
        }

    }
}
