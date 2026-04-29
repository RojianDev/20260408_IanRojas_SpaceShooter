using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject Hearth1;
    public GameObject Hearth2;
    public GameObject Hearth3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Global.instance.lifes >=3)
        {
            Hearth1.SetActive(true);
            Hearth2.SetActive(true);
            Hearth3.SetActive(true);
        }
        else if (Global.instance.lifes ==2)
        {
            Hearth1.SetActive(true);
            Hearth2.SetActive(true);
            Hearth3.SetActive(false);
        }
        else if (Global.instance.lifes ==1)
        {
            Hearth1.SetActive(true);
            Hearth2.SetActive(false);
            Hearth3.SetActive(false);
        }
        else if (Global.instance.lifes <=0)
        {
            Hearth1.SetActive(false);
            Hearth2.SetActive(false);
            Hearth3.SetActive(false);
        }
    }
}
