using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Data : MonoBehaviour
{
    protected class USER {
        int[] skills = new int[4];
        int[] needs = new int[4];
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
        public void setNeeds(int[] n)
        {
            needs = n;
        }
        public void setFieldStatus(string s)
        {
            forest.setFstatus(s);
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
        public int getForest(char who) {
            return forest.getSomething(who);
        }
        public int[] getSats()
        {
            return sat.getSat();
        }
        public int[] getNeeds()
        {
            return needs;
        }
        public string getFieldStatus()
        {
            return forest.getFstatus();
        }
    };
    private class FOREST
    {
        int farmer, tree, deer, wolf;
        string fieldStatus = "000000000000";
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
        public void setFstatus(string s)
        {
            fieldStatus = s;
        }
        public int getSomething(char who)
        {
            switch (who)
            {
                case 'f':
                    return farmer;
                case 't':
                    return tree;
                case 'd':
                    return deer;
                case 'w':
                    return wolf;
                default:
                    return 0;
            }
            
        }
        public string getFstatus()
        {
            return fieldStatus;
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
        public int[] getSat()
        {
            int[] s = { farmer, tree, deer, wolf };
            return s;
        }
    }

    private USER user = new USER();
    //List<string> goWorkScript, workSucScript, workFailScript;
    List<string>[] goWorkScript = new List<string>[4], workSucScript = new List<string>[4], workFailScript = new List<string>[4];

    // Start is called before the first frame update
    void Start()
    {
        userInit();
        scriptInit();
    }

    private void scriptInit()
    {
        for(int i = 0; i < 4; i++)
        {
            goWorkScript[i] = new List<string>();
            workSucScript[i] = new List<string>();
            workFailScript[i] = new List<string>();
        }

        string[] c = { "farmer", "wood", "deer", "wolf" };
        List<string> data = selectData(c, "workScript", "code='1'");
        for(int i = 0; i< data.Count; i++)
        {
            if (i % 4 == 0)
                goWorkScript[0].Add(data[i]);
            else if (i % 4 == 1)
                goWorkScript[1].Add(data[i]);
            else if (i % 4 == 2)
                goWorkScript[2].Add(data[i]);
            else
                goWorkScript[3].Add(data[i]);
        }


        data = selectData(c, "workScript", "code=2");
        for (int i = 0; i < data.Count; i++)
        {
            if (i % 4 == 0)
                workSucScript[0].Add(data[i]);
            else if (i % 4 == 1)
                workSucScript[1].Add(data[i]);
            else if (i % 4 == 2)
                workSucScript[2].Add(data[i]);
            else
                workSucScript[3].Add(data[i]);
        }

        data = selectData(c, "workScript", "code=3");
        for (int i = 0; i < data.Count; i++)
        {
            if (i % 4 == 0)
                workFailScript[0].Add(data[i]);
            else if (i % 4 == 1)
                workFailScript[1].Add(data[i]);
            else if (i % 4 == 2)
                workFailScript[2].Add(data[i]);
            else
                workFailScript[3].Add(data[i]);
        }
    }

    private void userInit()
    {
        string[] cols = { 
            "Filds", 
            "Skills", 
            "num_Tree", 
            "num_Deer", 
            "num_Wolf", 
            "sat_Farmer", 
            "sat_Tree", 
            "sat_Deer", 
            "sat_Wolf", 
            "Months", 
            "money", 
            "needs", 
            "FieldStatus" 
        };

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
        int[] tmp = new int[4];
        for (int i = 0; i < 4; i++)
            tmp[i] = Int32.Parse(d[11][i].ToString());
        user.setNeeds(tmp);
        user.setFieldStatus(d[12]);
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

    public string getRandomWorkScipt(int code, int idx)
    {
        string result = "";
        if (code == 1) result = goWorkScript[idx][UnityEngine.Random.Range(0, goWorkScript[idx].Count - 1)];
        else if (code == 2) result = workSucScript[idx][UnityEngine.Random.Range(0, workSucScript[idx].Count - 1)];
        else if (code == 3) result = workFailScript[idx][UnityEngine.Random.Range(0, workFailScript[idx].Count - 1)];
        return result;
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
    public List<string> getScript(int code, string who)
    {
        string[] c = { "script1", "answer", "script2", "result" };
        List<string> data;
        data = selectData(c, "dialog", "code'=" + code + "' AND group='" + who + "'");
        return data;
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
    public int[] getUserForestUnits()
    {
        int[] f = new int[4];
        f[0] = user.getForest('f'); 
        f[1] = user.getForest('t');
        f[2] = user.getForest('d');
        f[3] = user.getForest('w');
        return f;
    }
    public int[] getSats()
    {
        return user.getSats();
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
    public int[] getUserNeeds()
    {
        return user.getNeeds();
    }
    public string getFieldStatus()
    {
        return user.getFieldStatus();
    }
    internal void setSatisfy(int[] sat)
    {
        user.setSat('f', sat[0]);
        user.setSat('t', sat[1]);
        user.setSat('d', sat[2]);
        user.setSat('w', sat[3]);

        string[] c = { "sat_Farmer", "sat_Wood", "sat_Deer", "sat_Wolf" }, v = { sat[0].ToString(), sat[1].ToString(), sat[2].ToString(), sat[3].ToString()};
        updateData("Char_info", c, v);
    }

    internal void setForestUnits(int[] num)
    {
        user.setForest('f', num[0] / 100);
        user.setForest('t', num[1]);
        user.setForest('d', num[2]);
        user.setForest('w', num[3]);

        string[] c = {"Filds", "num_Tree", "num_Deer", "num_Wolf" }, v = { (num[0]/100).ToString(), num[1].ToString(), num[2].ToString(), num[3].ToString() };
        updateData("Char_info", c, v);
    }

    public void setFieldStatus(string s, int i)
    {
        user.setForest('f', i);
        user.setFieldStatus(s);
        string[] c = { "FieldStatus", "Filds" }, v = { s, i.ToString() };
        updateData("Char_info", c, v);
    }
}
