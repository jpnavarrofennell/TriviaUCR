using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    public Dificultad[] bancoDePreguntas;
    public Text enunciado;
    public Text[] respuesta;
    public int nivelPregunta;
    protected int preguntaAlAzar;
    public Button btn_respuesta0;
    public Button btn_respuesta1;
    public Button btn_respuesta2;
    public Button btn_respuesta3;

    // Start is called before the first frame update
    void Start()
    {
        nivelPregunta = 0; 
        SelecionarPregunta();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Este método recibe la respuesta del jugador
    /// </summary>
    /// <param name="respuestaJugador"></param>
    public void Respuesta(int respuestaJugador)
    {
        Debug.Log("Ha selecionado la opción " + respuestaJugador.ToString() );
      
        EvaluarPregunta(respuestaJugador);
    }

    public void SelecionarPregunta()
    {
       
        // se elige un indice del arreglo al azar
        preguntaAlAzar = Random.Range( 0, bancoDePreguntas[nivelPregunta].preguntas.Length );

        // sacamos el texto del banco de preguntas y lo ponemos en el UI donde se depliega el enunciado.
        enunciado.text = bancoDePreguntas[nivelPregunta].preguntas[preguntaAlAzar].enunciado;

        // cargar los textos de cada boton del UI
        for(int i = 0; i < respuesta.Length; i++)
        {
            respuesta[i].text = bancoDePreguntas[nivelPregunta].preguntas[preguntaAlAzar].respuestas[i].texto;
        }
    }

    public bool EvaluarPregunta(int respuestaJugador)
    {
        if(respuestaJugador == bancoDePreguntas[nivelPregunta].preguntas[preguntaAlAzar].respuestaCorrecta)
        {
            // reinicio del problema con mayor dificultad
            nivelPregunta++;
            if (nivelPregunta == bancoDePreguntas.Length)
            {
                // deplegar la pantalla de fin de juego ganado!
                SceneManager.LoadScene("Gane");
            }
            else
            {
                // subir de nivel
                HabilitarRespuestas();
                SelecionarPregunta();
            }

            return true;
        }
        else
        {
            SceneManager.LoadScene("Perder");
            return false;
        }
    }



    //Inicio Seleccionar comodin.
    public void SeleccionarComodin(int comodin)
    {
        if(comodin==0){
            Comodin5050();
        }
       
    }

    //Fin Seleccionar comodin.



    //Comodins.

        //Inicio comodin 50/50.
    public void Comodin5050()
    {
        //Recorro las respuestas en pantalla y desactivo 2 respuesta incorrectas
        for (int i = 0; i < (respuesta.Length-1); i++)
        {
            if (i == bancoDePreguntas[nivelPregunta].preguntas[preguntaAlAzar].respuestaCorrecta)
            {
           
                     
                Debug.Log("Opcion correcta " + bancoDePreguntas[nivelPregunta].preguntas[preguntaAlAzar].respuestaCorrecta.ToString());
                
            }
            else
            {
                if (i == 0)
                {
                    btn_respuesta0.gameObject.SetActive(false);
                   
                }
                else if (i == 1)
                {
                    btn_respuesta1.gameObject.SetActive(false);
                 
                }
                else if (i == 2)
                {
                    btn_respuesta2.gameObject.SetActive(false);
               
                }
                else if (i == 3)
                {
                    btn_respuesta3.gameObject.SetActive(false);
                }
            }

        }
    }
    //Fin de comodin 50/50.

    public void HabilitarRespuestas()
    {           
            btn_respuesta0.gameObject.SetActive(true);
            btn_respuesta1.gameObject.SetActive(true);
            btn_respuesta2.gameObject.SetActive(true);
            btn_respuesta3.gameObject.SetActive(true);
    }

}
