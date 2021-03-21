using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDongusu : MonoBehaviour
{
    public new Camera camera;
    public Light gunes,kirmiziisik;
    Color mavi, kirmizi;
    // Start is called before the first frame update
    void Start()
    {
        kirmiziisik = GameObject.Find("ayisigi1").GetComponent<Light>();
        mavi = new Color(177f/255, 205f/255, 225f/255);
        kirmizi = new Color(63f/255, 7f/255, 6f/255);
    }

    // Update is called once per frame
    void Update()
    {
        Color lerpedColor1 = Color.Lerp(camera.backgroundColor, mavi, 1/2000f);
        Color lerpedColor2 = Color.Lerp(camera.backgroundColor, kirmizi, 1/500f);

        if (gunes.transform.position.y<0)
        {
            camera.backgroundColor = lerpedColor2;
        }
        if(gunes.transform.position.y>0)
        {
            camera.backgroundColor = lerpedColor1;
        }
        /*if (gunes.transform.position.y>0)
            kirmiziisik.gameObject.SetActive(false);
        else
            kirmiziisik.gameObject.SetActive(true);
            */
        transform.RotateAround(new Vector3(250f, 0f, 250f), Vector3.right, 4f * Time.deltaTime);

    }
}
