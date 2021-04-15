using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuKontrol : MonoBehaviour
{
    public GameObject silah;
    public GameObject mermi;
    public Transform mermiPos;
    public GameObject atesefekt;
    float sayac;
    bool isClicked = false;
    public UnityEngine.UI.Image can;
    // Start is called before the first frame update
    void Start()
    {
        sayac = 0f;
        silah.GetComponent<Animator>().enabled = false;
    }
    
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            silah.GetComponent<Animator>().enabled = true;
            silah.GetComponent<Animator>().Play(0);
            
            
            isClicked = true;
            
           
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isClicked = false;
            sayac = 0f;
            silah.GetComponent<Animator>().enabled = false;
            silah.transform.localPosition= new Vector3(0.8000031f, -1.35f, 0.9100037f);
            silah.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
           
        }
        if(isClicked==true)
        {
            sayac -= Time.deltaTime;
            if (sayac < 0)
            {
                GameObject mermiClone = Instantiate(mermi, mermiPos.position, mermiPos.rotation) as GameObject;
                GameObject ates = Instantiate(atesefekt, mermiPos.position, mermiPos.rotation) as GameObject;

                mermiClone.GetComponent<Rigidbody>().velocity = mermiPos.transform.up * 100f;
                sayac = 0.2f;
                
                Destroy(mermiClone, 1f);
                Destroy(ates, 1f);
            }
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.Equals("kalp"))
        {
            if (can.fillAmount < 1) { 
            Destroy(other.gameObject);

            can.fillAmount += 0.15f;
        }
            
        }
    }
    public void scriptkapat()
    {
        foreach (Behaviour childCompnent in GetComponentsInChildren<Behaviour>())
        {
            if(childCompnent is Animation)
            { }
            else if(childCompnent is AudioSource)
            {

            }
            else if(childCompnent is Camera)
            { }
            else if(childCompnent is AudioListener)
            { }
            else
            childCompnent.enabled = false;
        }

    }


}
