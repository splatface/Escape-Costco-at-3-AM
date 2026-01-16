using UnityEngine;
using System.IO;

public class LoadingLogic : MonoBehaviour
{

    string filePath1 = "save1.txt";
    string filePath2 = "save2.txt";

    void Load(string filePath)
    {
        File.ReadAllLines(filePath);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
