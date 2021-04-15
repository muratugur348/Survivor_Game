using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    private GameObject hedef;
    private float mesafe;
    private UnityEngine.UI.Image can;
    float sayaccan;
    private UnityEngine.UI.Text skor;
    private oyunKontrol oKontrol;
    // Start is called before the first frame update
    void Start()
    {
        oKontrol = GameObject.Find("_Scripts").GetComponent<oyunKontrol>();
        hedef = GameObject.Find("oyuncu");
        GameObject imageObject = GameObject.FindGameObjectWithTag("can");
        can = imageObject.GetComponent<Image>();
        GameObject textObject = GameObject.FindGameObjectWithTag("skor");
        skor = textObject.GetComponent<Text>();
        sayaccan = 0f;
    }
    float sayac = 0.5f;
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (gameObject.tag == "zombi")
        {
            Vector3 rotation = new Vector3(hedef.transform.position.x, transform.position.y,
               hedef.transform.position.z);

            transform.LookAt(rotation);
            mesafe = Vector3.Distance(transform.position, hedef.transform.position);
            if(mesafe>50f)
                transform.position = Vector3.Lerp(transform.position,
                hedef.transform.position, 0.008f);
            else
            transform.position = Vector3.Lerp(transform.position,
                hedef.transform.position, 0.03f);
           
            mesafe = Vector3.Distance(transform.position, hedef.transform.position);
            if (mesafe < 3.5f)
            {
                
                gameObject.GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
                sayac = 0.5f;
                sayaccan -= Time.deltaTime;
                if(sayaccan<0)
                {
                can.fillAmount -= 0.25f;
                    sayaccan = 1.6f;
                }
                if(can.fillAmount<=0)
                {
                    oKontrol.bittimi = true;
                        int highskor = PlayerPrefs.GetInt("skor");
                        if (int.Parse(skor.text) > highskor)
                        {
                            PlayerPrefs.SetInt("skor", int.Parse(skor.text));
                        }
                }
                
            }
            else if (mesafe > 3.5f)
            {
                sayaccan = 0f;
                sayac -= Time.deltaTime;
                if (sayac < 0)
                {
                    gameObject.GetComponentInChildren<Animation>().Play("Zombie_Walk_01");

                }
            }
        }
        
       
    }
}
