﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Data : MonoBehaviour
{
    protected class USER {
        int[] skills = new int[4];
        int month, money;
        FOREST forest = new FOREST();
        SATISFY sat = new SATISFY();
        public void setSkills(int[] i)
        {
            skills = i;
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
        public int[] getSkills()
        {
            return skills;
        }
        public int getMonth()
        {
            return month;
        }
        public int getMoney()
        {
            return money;
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
        if (d.Count < 1)
        {
            string[] c = { "" };
            insertData(c, "Char_info", true);
            d = selectData(cols, "Char_info");
        }
        user.setForest('f', Int32.Parse(d[0]));
        int[] data = { 0, 0, 0, 0 };
        for (int i = 0; i < d[1].Length; i++)
        {
            int a = Int32.Parse(d[1][i].ToString());
            data[i] = a;
        } 
        user.setSkills(data);
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

    public List<string> selectData(string[] columns, string table, string where=null)
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
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        List<string> data = new List<string>();
        while (reader.Read())
            for (int i = 0; i < columns.Length; i++) { data.Add(reader.GetString(i)); }
        dbconn.Close();
        return data;
    }

    public List<string> getItemInfo(string itemName)
    {
        string[] cols = { "Name", "Info", "Effect_info", "soldout" };
        return selectData(cols, "asset_Item", "itemCode='" + itemName + "'");
    }

    public int getItemPrice(string itemName)
    {
        string[] cols = { "Price" };
        List<string> list = selectData(cols, "asset_Item", "itemCode='" + itemName + "'");
        Int32.TryParse(list[0], out int data);
        return data;
    }

    public void insertData(string[] columns, string table, bool def = false)
    {
        string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/fb_DB.db";
        IDbConnection dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO " + table + " ";
        if (def)
        {
            sqlQuery += "DEFAULT VALUES";
        }
        else
        {
            sqlQuery += "(";
            for (int i = 0; i < columns.Length; i++)
            {
                sqlQuery += columns[i];
                if (i < columns.Length - 1) sqlQuery += ", ";
            }
            sqlQuery += ")";
        }
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        dbconn.Close();
    }

    public void updateData(string table, string[] cols, string[] vals)
    {
        if(cols.Length != vals.Length)
        {
            Debug.LogError("sql error: cols and vals not matched");
            return;
        }
        string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/fb_DB.db";
        IDbConnection dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "UPDATE " + table + " SET ";
        for(int i =0; i < cols.Length; i++)
        {
            sqlQuery += cols[i] + "=" + vals[i];
            if (i < cols.Length - 1) sqlQuery += ", ";
        }
        dbcmd.CommandText = sqlQuery;
        dbconn.Close();
    }

    public int getUserMoney()
    {
        return user.getMoney();
    }
    public int[] getUserSkills()
    {
        return user.getSkills();
    }
    public int getUserMonth()
    {
        return user.getMonth();
    }
    public void setUserMoney(int m)
    {
        user.setMoney(m);
        string[] c = { "money" };
        string[] v = { m.ToString() };
        updateData("Char_info", c, v);
    }
    public void setUserSkills(int[] s)
    {
        user.setSkills(s);
        string d = "";
        for(int i = 0; i < s.Length; i++)
        {
            d += s[i].ToString();
        }
        string[] c = { "Skills" }, v = { d };
        updateData("Char_info", c, v);
    }
}
