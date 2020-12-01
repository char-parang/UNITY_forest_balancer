using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Data : MonoBehaviour
{
    protected class USER {
        string skills;
        int month, money;
        FOREST forest = new FOREST();
        SATISFY sat = new SATISFY();
        public void setSkills(string s)
        {
            skills = s;
        }
        public void setMonth(int i)
        {
            month = i;
        }
        public void setMoney(int m)
        {
            money = m;
        }
        public void setForest(char who, int i)
        {
            forest.setSomething(who, i);
        }
        public void setSat(char who, int i)
        {
            sat.setSomething(who, i);
        }
    };

    private class FOREST
    {
        int farmer, tree, deer, wolf;
        public void setSomething(char who, int i)
        {
            switch (who)
            {
                case 'f':
                    farmer = i;
                    break;
                case 't':
                    tree = i;
                    break;
                case 'd':
                    deer = i;
                    break;
                case 'w':
                    wolf = i;
                    break;
            }
        }
    }
    private class SATISFY
    {
        int farmer, tree, deer, wolf;
        public void setSomething(char who, int i)
        {
            switch (who)
            {
                case 'f':
                    farmer = i;
                    break;
                case 't':
                    tree = i;
                    break;
                case 'd':
                    deer = i;
                    break;
                case 'w':
                    wolf = i;
                    break;
            }
        }
    }

    private USER user = new USER();

    // Start is called before the first frame update
    void Start()
    {
        string[] cols = { "Filds", "Skills", "num_Tree", "num_Deer", "num_Wolf", "sat_Farmer", "sat_Tree", "sat_Deer", "sat_Wolf", "Months", "money" };
        List<string> d = selectData(cols, "Char_info");
        user.setForest('f', Int32.Parse(d[0]));
        user.setSkills(d[1]);
        user.setForest('t', Int32.Parse(d[2]));
        user.setForest('d', Int32.Parse(d[3]));
        user.setForest('w', Int32.Parse(d[4]));
        user.setSat('f', Int32.Parse(d[5]));
        user.setSat('t', Int32.Parse(d[6]));
        user.setSat('d', Int32.Parse(d[7]));
        user.setSat('w', Int32.Parse(d[8]));
        user.setMonth(Int32.Parse(d[9]));
        user.setMoney(Int32.Parse(d[10]));
    }

    private List<string> selectData(string[] columns, string table, string where=null)
    {
        string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/fb_DB.db";
        IDbConnection dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT ";
        for (int i = 0; i < columns.Length; i++)
        {
            sqlQuery += columns[i];
            if (i < columns.Length - 1) sqlQuery += ", ";
        }
        sqlQuery += " FROM " + table;
        if (where != null) sqlQuery += " WHERE " + where;
        Debug.Log(sqlQuery);
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        List<string> data = new List<string>();
        while (reader.Read())
            for (int i = 0; i < columns.Length; i++) data.Add(reader.GetString(i));

        dbconn.Close();
        return data;
    }

    public List<string> getItemInfo(string itemName)
    {
        string[] cols = { "Name", "Info", "Effect_info" };
        return selectData(cols, "asset_Item", "itemCode='" + itemName + "'");
    }

    public int getItemPrice(string itemName)
    {
        string[] cols = { "Price" };
        List<string> list = selectData(cols, "asset_Item", "itemCode='" + itemName + "'");
        Int32.TryParse(list[0], out int data);
        return data;
    }
}
