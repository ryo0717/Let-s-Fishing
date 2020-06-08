using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SqliteDatabase sqlDB = new SqliteDatabase("GameMaster.db");
        string query = "select name,attack from Weapon where id=2";
        DataTable dataTable = sqlDB.ExecuteQuery(query);
       
        string name = "";
        int attack = 0;
        foreach(DataRow dr in dataTable.Rows){
            name = (string)dr["name"];
            attack = (int)dr["attack"];
            Debug.Log ("name:" + name + " attack:" + attack);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
