using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public bool PlayerDead = false;
    public bool PowerUP = false;
    private bool SecondLife = false;
    //public GameObject secondLife;
    public GameObject explosionParticulas;
    public GameObject mainCamera;
    public GameObject obsEnd;
    public GameObject MenuInteractivo;
    public GameObject Lava;
    public GameObject AnimWalk;
    public GameObject AnimJump;

    private bool saltoLargo = false;
    private bool saltoMedio = false;
    private bool saltoCorto = false;
    private bool terminoDeSaltar = false;

    public float varianteGravedadV;

    public float simuladorDeGravedad = 1;

    // Use this for initialization
    void Start ()
    {

	}
	// Update is called once per frame
	void Update ()
    {
        //transform.Translate(0, 10*Time.deltaTime, 0);
        if (Lava.GetComponent<Lava>().YaMurio == true)
        {
            if (PowerUP == false && SecondLife == false)
            {
                PlayerDead = true;
                obsEnd.GetComponent<BoxCollider>().enabled = true;
                //Instantiate(explosionParticulas, transform.position, transform.rotation);
                GetComponent<MeshRenderer>().enabled = false;
                MenuInteractivo.GetComponent<MenuInteractivoInGame>().IsPause = true;
                AnimWalk.SetActive(false);
                AnimJump.SetActive(false);
            }
        }
        if (MenuInteractivo.GetComponent<MenuInteractivoInGame>().IsPause == false)
        {
            MovimientoV();
        }
        Limites();
        //SecondLifeChange();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (PowerUP == false && SecondLife == false)
            {
                PlayerDead = true;
                obsEnd.GetComponent<BoxCollider>().enabled = true;
                GetComponent<MeshRenderer>().enabled = false;
                AnimWalk.SetActive(false);
                AnimJump.SetActive(false);
            }
            SecondLife = false;
            Instantiate(explosionParticulas, transform.position, transform.rotation);
        }
        if (collision.gameObject.tag == "Trampolin")
        {
            saltoLargo = true;
        }
        if (collision.gameObject.tag == "Trampolin2")
        {
            saltoMedio = true;
        }
        if (collision.gameObject.tag == "Trampolin 3")
        {
            saltoCorto = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            MenuInteractivo.GetComponent<score>()._miloNum = MenuInteractivo.GetComponent<score>()._miloNum + 1;
        }
        if (other.gameObject.tag == "Lava")
        {
            Lava.GetComponent<Lava>().TocoLava = true;
        }
        if (other.gameObject.tag == "Misil")
        {
            if (PowerUP == false && SecondLife == false)
            {
                PlayerDead = true;
                obsEnd.GetComponent<BoxCollider>().enabled = true;
                GetComponent<MeshRenderer>().enabled = false;
            }
            SecondLife = false;
            Instantiate(explosionParticulas, transform.position, transform.rotation);
        }
        if (other.gameObject.tag == "Bloqueo")
        {
            PlayerDead = true;
            obsEnd.GetComponent<BoxCollider>().enabled = true;
            Instantiate(explosionParticulas, transform.position, transform.rotation);
        }
        if (other.gameObject.tag == "PrimerSalto")
        {
            mainCamera.GetComponent<RotateCamera>().AllStop = true;
            saltoLargo = true;
            MenuInteractivo.GetComponent<MenuInteractivoInGame>().tePuedesMover = true;
            AnimWalk.SetActive(false);
            AnimJump.SetActive(true);
        }
        if (other.gameObject.tag == "secondLife")
        {
            SecondLife = true;
        }
        if (other.gameObject.tag == "Trampolin")
        {
            saltoLargo = true;
        }
        if (other.gameObject.tag == "Trampolin2")
        {
            saltoMedio = true;
        }
        if (other.gameObject.tag == "Trampolin 3")
        {
            saltoCorto = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {
            Lava.GetComponent<Lava>().TocoLava = false;
        }
    }
    public void Limites()
    {
        if (transform.localPosition.x > 4.5f)
        {
            this.gameObject.transform.localPosition = new Vector3(4.5f, transform.localPosition.y, transform.localPosition.z);
            if (mainCamera.GetComponent<RotateCamera>().currentRotationY >= 1.6f)
            {
                mainCamera.GetComponent<RotateCamera>().currentRotationY = 1.6f;
            }
        }
        if (transform.localPosition.x < -4.5f)
        {
            this.gameObject.transform.localPosition = new Vector3(-4.5f, transform.localPosition.y, transform.localPosition.z);
            if (mainCamera.GetComponent<RotateCamera>().currentRotationY <= -1.6f)
            {
                mainCamera.GetComponent<RotateCamera>().currentRotationY = -1.6f;
            }
        }
        if (transform.localPosition.y >= 15f)
        {
            this.gameObject.transform.localPosition = new Vector3(transform.localPosition.x, 15f, transform.localPosition.z);
            if (mainCamera.GetComponent<RotateCamera>().currentRotationX >= 8f)
            {
                mainCamera.GetComponent<RotateCamera>().currentRotationX = 8f;
            }
        }
        if(transform.localPosition.y < 3f)
        {
            this.gameObject.transform.localPosition = new Vector3(transform.localPosition.x, 3f, transform.localPosition.z);
            if (mainCamera.GetComponent<RotateCamera>().currentRotationX <= 0)
            {
                mainCamera.GetComponent<RotateCamera>().currentRotationX = 0;
            }
        }
    }
    /*void SecondLifeChange()
    {
        if (SecondLife && PlayerDead == false)
        {
            GetComponent<MeshRenderer>().enabled = false;
            secondLife.GetComponent<MeshRenderer>().enabled = true;
        }
        if(SecondLife == false && PlayerDead == false)
        {
            GetComponent<MeshRenderer>().enabled = true;
            secondLife.GetComponent<MeshRenderer>().enabled = false;
        }
    }*/
    void MovimientoV()
    {
        if (terminoDeSaltar)
        {
            simuladorDeGravedad += Time.deltaTime * varianteGravedadV;
            transform.Translate(0, -60f * simuladorDeGravedad * Time.deltaTime, 0);          //1.8f
            if (simuladorDeGravedad >= 0.4f)
            {
                simuladorDeGravedad = 0.4f;
            }
        }
        if (saltoLargo)
        {
            varianteGravedadV = 0.55f;      //original 0.55f         //cambio 1f
            terminoDeSaltar = false;
            simuladorDeGravedad -= Time.deltaTime * 0.4f;      //original 0.4f      //cambio 0.36f
            transform.Translate(0, 60f * simuladorDeGravedad * Time.deltaTime, 0);         //1.8f
            if (simuladorDeGravedad <= 0)
            {
                simuladorDeGravedad = 0;
                saltoLargo = false;
                terminoDeSaltar = true;
            }
        }
        if (saltoMedio)
        {
            varianteGravedadV = 0.9f;     //original 0.9f    //cambio 0.75f
            terminoDeSaltar = false;
            simuladorDeGravedad -= Time.deltaTime * 0.55f;      // original 0.55f      cambio 0.6f
            transform.Translate(0, 60f * simuladorDeGravedad * Time.deltaTime, 0);     //2f 
            if (simuladorDeGravedad <= 0)
            {
                simuladorDeGravedad = 0;
                saltoMedio = false;
                terminoDeSaltar = true;
            }
        }
        if (saltoCorto)
        {
            varianteGravedadV = 2f;     //original 2f       //cambio 3.9f
            terminoDeSaltar = false;
            simuladorDeGravedad -= Time.deltaTime * 1.3f;       //origina 1.3f      cambio 1.1f
            transform.Translate(0, 60f * simuladorDeGravedad * Time.deltaTime, 0);     //1.8f
            if (simuladorDeGravedad <= 0)
            {
                simuladorDeGravedad = 0;
                saltoCorto = false;
                terminoDeSaltar = true;
            }
        }
    }
}
