using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class celebracionInicio : MonoBehaviour
{
    public GameObject celebracionNivel;
    public GameObject personaje;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 4 && SceneManager.GetActiveScene().buildIndex >= 2)
        {
            StartCoroutine(celebrarInicioNivel(2.0f));
        }
    }
    IEnumerator celebrarInicioNivel(float tiempo)
    {
        celebracionNivel.SetActive(true);
        personaje.SetActive(false);
        yield return new WaitForSeconds(tiempo);
        celebracionNivel.SetActive(false);
        personaje.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
