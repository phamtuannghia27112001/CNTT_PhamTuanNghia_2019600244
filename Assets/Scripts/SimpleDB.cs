using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class SimpleDB : MonoBehaviour
{
    private string dbName = "URI=file:CSDL.db";
    public Text dtb;
    public InputField idInput;
    public InputField khoaInput;
    // Start is called before the first frame update
    void Start()
    {
        CreateDB();
    }

    public void DisplayHV()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var commmand = connection.CreateCommand())
            {
                commmand.CommandText = "SELECT * FROM CSDL ORDER BY khoa;";
                using (IDataReader reader = commmand.ExecuteReader())
                {
                    while (reader.Read())
                        dtb.text += reader["id"] + "\t\t" + reader["khoa"] + "\n";
                    connection.Close();
                }
            }
        }
    }
    public void Login()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                if(idInput.text==""||khoaInput.text=="")
                {
                    Debug.Log("Vui long nhap thong tin");
                }
                else
                {
                    command.CommandText = "SELECT * FROM CSDL WHERE id='" + idInput.text + "' AND khoa='" + khoaInput.text + "';";
                    command.ExecuteNonQuery();
                    SqliteDataReader reader = command.ExecuteReader();
                    int count = 0;
                    while (reader.Read())
                    {
                        count++;
                    }
                    if (count == 1)
                    {
                        SceneManager.LoadScene(1);
                    }
                    if(count<1)
                    {
                        Debug.Log("Dang nhap khong thanh cong");
                    }
                }      
            }
            connection.Close();
        }
    }

    public void AddHV()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO CSDL (id,khoa) VALUES ('" + idInput.text + "','" + khoaInput.text + "');";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        DisplayHV();
    }

    private void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS CSDL (id string, khoa varchar(30));";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}