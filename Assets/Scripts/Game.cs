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

    public Button btn_Comodin5050;
    public Button [] btn_respuesta;

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

        //Desabilita comodin 50/50
        btn_Comodin5050.interactable = false;
        //fin

        //Recorro las respuestas en pantalla y desactivo 2 respuesta incorrectas
        int respuestaCorrecta = bancoDePreguntas[nivelPregunta].preguntas[preguntaAlAzar].respuestaCorrecta;
        ArrayList respuestasTemp = GenerarRandom(respuestaCorrecta);
        foreach (var r in respuestasTemp)
        {
            btn_respuesta[(int)r].gameObject.SetActive(false);
        }
    }


    //Generar Repuesta incorrecta ramdon para 50/50 

    public ArrayList GenerarRandom(int respuestaCorrecta)
    {
        ArrayList tempArray = new ArrayList();

        int r1 = Random.Range(0, 4);
        while (r1 == respuestaCorrecta)
            r1 = Random.Range(0, 4);


        int r2 = Random.Range(0, 4);
        while ((r2 == respuestaCorrecta) || (r2 == r1))
        {
            r2 = Random.Range(0, 4);
        }

        tempArray.Add(r1);
        tempArray.Add(r2);

        return tempArray;
    }



    //Fin de comodin 50/50.

    public void HabilitarRespuestas()
    {
       
        for (int i = 0; i < respuesta.Length; i++)
        {
            btn_respuesta[i].gameObject.SetActive(true);
        }

    }

}
