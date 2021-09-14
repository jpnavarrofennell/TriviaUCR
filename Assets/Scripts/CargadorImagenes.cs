using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public partial class Pregunta
{
    public Sprite imagenComplementaria;
}
public class CargadorImagenes : MonoBehaviour
{
    public Image imagenComplementaria;
    public Game game;

    //Declaración de variables
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
        preguntaActual = game.PreguntaActual();

        if (game.bancoDePreguntas[nivelPregunta].preguntas[preguntaActual].imagenComplementaria != null)
        {
            imagenComplementaria.gameObject.SetActive(true);
            imagenComplementaria.sprite = game.bancoDePreguntas[nivelPregunta].preguntas[preguntaActual].imagenComplementaria;
        }//Fin del if
        else
        {
            imagenComplementaria.gameObject.SetActive(false);
        }//Fin del else
    }//Fin de update
}//Final de clase cargado
