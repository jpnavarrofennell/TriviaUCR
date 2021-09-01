using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoaderJSON : MonoBehaviour
{
    public string nombreArchivo;
    public Game game;

    // Start is called before the first frame update
    void Start() 
    {
        //https://answers.unity.com/questions/1533905/reading-json-file-1.html

        // borrar todo el banco de preguntas
        game.bancoDePreguntas = null;

        // ubicacion del archivo
        string archivoPath = Application.streamingAssetsPath + "/" + nombreArchivo;

        string jsonString = File.ReadAllText(archivoPath);

        //Debug.Log(jsonString);

        // Serializar el archivo
        game.bancoDePreguntas = JsonUtility.FromJson<Dificultad[]>(jsonString);
        
        //Debug.Log(game.bancoDePreguntas);

    }
}
