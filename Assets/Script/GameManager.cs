using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


public class GameManager : MonoBehaviour
{
    public  string category;
    public  string name_object;
    public  float score_object;
    dataEntry dE = new dataEntry();
    
    
    
    
    void FixedUpdate()
    {
        
        dE.category = category;
        dE.object_name = name_object;
        dE.object_score = score_object;
    }
    public ItemDatabase itemDB;
    // save function
    // create and open xml file 
    // save category, name, score data into xml file
    // close xml file
    public void saveItem()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/RowData/XmlData/itemData.xml", FileMode.Create);
        serializer.Serialize(stream, itemDB);
        stream.Close();
    }

    //load dunction
    public void loadItem()
    {

    }


        //Get the datas from every script like e-watse, wet-waste and others....
        //set score, name, category data to dataEntry class
    public void E_WasteScore(float score, string name, string cat)
    {
        saveItem();
        Debug.Log(dE.category);
        category = cat;
        name_object = name;
        score_object = score;
        Debug.Log(cat + " __ " + name + " __ " + score);
    }
    public void WWasteScore(float score, string name, string cat)
    {
        saveItem();
        Debug.Log(dE.category);
        category = cat;
        name_object = name;
        score_object = score;
        Debug.Log(cat + " __ " + name + " __ " + score);
    }
    public void DWasteScore(float score, string name, string cat)
    {
        saveItem();
        Debug.Log(dE.category);
        category = cat;
        name_object = name;
        score_object = score;
        Debug.Log(cat + " __ " + name + " __ " + score);
    }
    public void SNWasteScore(float score, string name, string cat)
    {
        saveItem();
        Debug.Log(dE.category);
        category = cat;
        name_object = name;
        score_object = score;
        Debug.Log(cat + " __ " + name + " __ " + score);
    }

    

}
[System.Serializable]
public class dataEntry {

    public string category;
    public string object_name;
    public float object_score;

}


[System.Serializable]
public class ItemDatabase {
    public List<dataEntry> list = new List<dataEntry>();
}
