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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    //Inicio Seleccionar comodin.
    public void SeleccionarComodin(int comodin)
    {
        if (comodin == 0)
        {
            Comodin5050();
        }

    }

    //Fin Seleccionar comodin.


    //Comodins.

    //Inicio comodin 50/50.
    public void Comodin5050()
    {
        nivelPregunta = game.nivelPregunta;
        preguntaActual = game.preguntaAlAzar;

        //Desabilita comodin 50/50
        btn_Comodin5050.interactable = false;
        //fin

        //Recorro las respuestas en pantalla y desactivo 2 respuesta incorrectas
        int respuestaCorrecta = RespuestaCorrecta(nivelPregunta, preguntaActual);//aquí utilizo el metodo Respuesta correcta con los paramentros necesarios para que me retorne la respuesta correcta 
        ArrayList respuestasTemp = GenerarRandom(respuestaCorrecta);
        foreach (var r in respuestasTemp)
        {
            game.btn_respuesta[(int)r].gameObject.SetActive(false);
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
    public int RespuestaCorrecta(int nivelPreguntaParametro, int preguntaActualParametro)//Metodo para returnar la respuesta correcta, con el fin de hacer el codigo más corto 
    {
        int respuestaCorrecta = game.bancoDePreguntas[nivelPreguntaParametro].preguntas[preguntaActualParametro].respuestaCorrecta;// que tome la respuesta correcta del bando de preguntas del nivel y la pregunta correspondiente que amerite
        return respuestaCorrecta;// retorno de la respuesta correcta
    }

}
