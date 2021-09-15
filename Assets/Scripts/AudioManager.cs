using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class Pregunta
{
    public AudioClip sonido;
}//Fin de la clase parcial pregunta

public class AudioManager : MonoBehaviour
{
    //Definicion de variables
    public GameObject btn_Sonido;
    public AudioSource audioSource;
    public Game game;

    private int nivelPregunta;
    private int preguntaActual;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nivelPregunta = game.nivelPregunta;
        preguntaActual = game.preguntaAlAzar;

        //Si la pregunta elegida al azar tiene un sonido asignado...
        if (game.bancoDePreguntas[nivelPregunta].preguntas[preguntaActual].sonido != null)
        {
            btn_Sonido.SetActive(true);
            //se carga el recurso
            audioSource.clip = game.bancoDePreguntas[nivelPregunta].preguntas[preguntaActual].sonido;
            if (!audioSource.isPlaying)
            {
                //audioSource.Play();
            }
        }//Fin del if
        else
        {
            audioSource.clip = null;
            btn_Sonido.SetActive(false);
        }//Fin del else
    }//Fin del metodo update
}//Fin de la clase AudioManager
