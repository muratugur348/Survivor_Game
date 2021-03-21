using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class oyunKontrol : MonoBehaviour
{
    public GameObject zombi;
    private float mesafe;
    private GameObject hedef;
    public UnityEngine.UI.Text highskor,skor1,skor2;
    public bool bittimi = false,tekrar=false;
    float animasyonsayaci = 20f;
    public Canvas canvas1,canvas2;
    public oyuncuKontrol oyuncuKontrol;
    GameObject parent;
    bool again = true;
    // Start is called before the first frame update
    void Start()
    {
        hedef = GameObject.Find("oyuncu");
        parent = hedef.transform.parent.gameObject;

        if (PlayerPrefs.HasKey("skor"))
        {
            highskor.text = "High Score:"+PlayerPrefs.GetInt("skor").ToString();
        }
    }
    float sayac = 4f;
    // Update is called once per frame
    void Update()
    {
        sayac -= Time.deltaTime;
        if(sayac<0 && bittimi==false)
        {
            
            Vector3 konum = new Vector3(Random.Range(152, 323), 10, Random.Range(198, 346));

            mesafe = Vector3.Distance(transform.position, hedef.transform.position);
            if (mesafe > 6f)
            {
                Instantiate(zombi, konum, Quaternion.identity);
                sayac = 4f;
            }
            else
            {
                sayac = 0f;
            }
        }
        animasyonsayaci -= Time.deltaTime;
        if(bittimi==false)
        {
            animasyonsayaci = 20f;
        }
        GameObject ChildGameObject1 = hedef.gameObject.transform.GetChild(0).gameObject;
        Quaternion startRotation = hedef.transform.rotation;
        Vector3 startPosition = hedef.transform.position;
        if (bittimi&&tekrar==false)
        {
           // parent.GetComponent<Animation>().Play("oyunbitisi");
            
            GameObject keles = ChildGameObject1.transform.GetChild(0).gameObject;
            GameObject pos= ChildGameObject1.transform.GetChild(1).gameObject;
            keles.SetActive(false);
            pos.SetActive(false);
            tekrar = true;
            GameObject camera = GameObject.Find("Camera");
            camera.SetActive(false);
            canvas1.enabled=false;
            canvas2.enabled = true;
            skor2.text = skor1.text;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("zombi");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy);
            oyuncuKontrol.scriptkapat();

             
            
            
        }
        
        if (hedef.transform.position.y > 70 && again)
        {
            again = false;
        }
        if (bittimi && hedef.transform.position.y<40 && again)
        {
            
            hedef.transform.position += Vector3.Lerp(startPosition, new Vector3(0,0.6f, -0.2f), 1f);
            hedef.transform.rotation = Quaternion.Lerp(startRotation, new Quaternion(0.30f, 0, 0, startRotation.w), 0.1f);
        /*    if (hedef.transform.rotation.x < 0)
                hedef.transform.rotation = new Quaternion(0 - hedef.transform.rotation.x, 0, 0, hedef.transform.rotation.w);*/
            print(hedef.transform.rotation.x);

            ChildGameObject1.transform.localRotation =Quaternion.identity;
        }
        startRotation = hedef.transform.rotation;
        startPosition = hedef.transform.position;
        
        if (bittimi && hedef.transform.position.y>40 && hedef.transform.position.y<71 && again)
        {
            hedef.transform.position = Vector3.Lerp(startPosition, new Vector3(249, 71f, 117f), 0.1f);
        }
        if (bittimi && hedef.transform.position.y>40 && !again)
        {
            hedef.transform.position = Vector3.Lerp(startPosition, new Vector3(249, 40f, 96f), 0.03f);
            hedef.transform.rotation = Quaternion.Lerp(startRotation, new Quaternion(0.10f, 0, 0, startRotation.w), 0.01f);
            print(hedef.transform.rotation.x);  
        }
        if (animasyonsayaci <= 0)
        {
            
           // parent.GetComponent<Animation>().Play("otohareket");
        }
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
