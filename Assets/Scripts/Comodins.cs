using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Comodins : MonoBehaviour
{

    public Button btn_Comodin5050;
    public Game game;
    public int nivelPregunta;
    public int preguntaActual;



   


    //Metodo para seleccionar el tipo de comodin
    public void SeleccionarComodin(int comodin)
    {
        switch(comodin)
        {
            case 0:
                Comodin5050();
                break;

            case 1:
                //comodinCambioPregunta()
                break;

            default:
                Debug.Log("Error: " + comodin + "invalido");//imprime en la consola si se selecciona un número de comodín no válido
                break;
        }
    }


   //Metodo para el comodin de 50/50
    public void Comodin5050()
    {
        nivelPregunta = game.nivelPregunta;
        preguntaActual = game.preguntaAlAzar;

        //Desabilita el boton comodin 50/50
        btn_Comodin5050.interactable = false;
        //fin

        //Obtiene la respuesta correcta de la pregunta actual dentro del pool y la asigna en una variable
        int respuestaCorrecta = RespuestaCorrecta(nivelPregunta, preguntaActual); 
        ArrayList respuestasTemp = GenerarRandom(respuestaCorrecta); //Genera dos posiciones random y las agrega a un ArrayList
        foreach (var r in respuestasTemp) //Desabilita las opciones agregadas al ArrayList con un ciclo
        {
            game.btn_respuesta[(int)r].interactable = false;
        }
    }

    //Meto para seleccionar 2 posiciones random en las respuestas
    public ArrayList GenerarRandom(int respuestaCorrecta)
    {
        ArrayList tempArray = new ArrayList();

        //genera el primer numero
        int r1 = Random.Range(0, 4);
        while (r1 == respuestaCorrecta)
            r1 = Random.Range(0, 4);

        //genera el segundo numero
        int r2 = Random.Range(0, 4);
        while ((r2 == respuestaCorrecta) || (r2 == r1))
            r2 = Random.Range(0, 4);
        

        tempArray.Add(r1);
        tempArray.Add(r2);

        return tempArray;
    }
    public int RespuestaCorrecta(int nivelPreguntaParametro, int preguntaActualParametro)//Metodo para returnar la respuesta correcta, con el fin de hacer el codigo más corto 
    {
        int respuestaCorrecta = game.bancoDePreguntas[nivelPreguntaParametro].preguntas[preguntaActualParametro].respuestaCorrecta;// que tome la respuesta correcta del bando de preguntas del nivel y la pregunta correspondiente que amerite
        return respuestaCorrecta;// retorno de la respuesta correcta
    }

}
