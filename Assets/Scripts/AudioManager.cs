using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class Pregunta
{
    public AudioClip sonido;
}

public class AudioManager : MonoBehaviour
{
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
            //se carga el recurso
            audioSource.clip = game.bancoDePreguntas[nivelPregunta].preguntas[preguntaActual].sonido;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.clip = null;
        }
    }
}
