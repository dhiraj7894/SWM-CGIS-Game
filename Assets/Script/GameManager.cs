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
    public ItemDatabase itemDB = new ItemDatabase();



     void Awake()
    {
        ////////////////////////////////////////////////////////////////////////////////
        /*TextAsset asset = Resources.Load("save") as TextAsset;
        if (asset != null)
        {
            itemDB = JsonUtility.FromJson<ItemDatabase>(asset.text);
            foreach (dataEntry data in itemDB.list)
            {
                Debug.Log(data.DECategory);
                Debug.Log(data.DEobjectName);
                Debug.Log(data.DEobjectScore);
            }
        }
        else
        {
            Debug.LogWarning("Asset not found !");
        }*/
        //////////////////////////////////////////////////////////////////////////////////
    }
   

    // save function
    // create and open xml or json file 
    // save category, name, score data into xml or json file
    // close xml file
    public void saveItem()
    {
        /*XmlSerializer serializer = new XmlSerializer(typeof(dataEntry));
        FileStream stream = new FileStream(Application.dataPath + "/RowData/XmlData/itemData.xml", FileMode.Create);
        serializer.Serialize(stream, itemDB);
        stream.Close();*/
        
        //saving data into dataentry Class
        dataEntry data = new dataEntry
        {
            DECategory = category,
            DEobjectName = name_object,
            DEobjectScore = score_object,
        };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/RowData/Database/json.txt", json);
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
        category = cat;
        name_object = name;
        score_object = score;

        ///////////////////////////////////////////////////////////
/*        dataEntry data = new dataEntry
        {
            DECategory = category,
            DEobjectName = name_object,
            DEobjectScore = score_object,
        };
        string json = JsonUtility.ToJson(data);*/
        ///////////////////////////////////////////////////////////
    }
    public void WWasteScore(float score, string name, string cat)
    {
        saveItem();
        category = cat;
        name_object = name;
        score_object = score;

    }
    public void DWasteScore(float score, string name, string cat)
    {

        category = cat;
        name_object = name;
        score_object = score;

    }
    public void SNWasteScore(float score, string name, string cat)
    {
        category = cat;
        name_object = name;
        score_object = score;
    }

    

}


//serialized field for data entry which is coming from 4 other script
[System.Serializable]
public class dataEntry {

    public string DECategory;
    public string DEobjectName;
    public float DEobjectScore;

}


//List of dataEntry
[System.Serializable]
public class ItemDatabase {
    public List<dataEntry> list = new List<dataEntry>();
}
