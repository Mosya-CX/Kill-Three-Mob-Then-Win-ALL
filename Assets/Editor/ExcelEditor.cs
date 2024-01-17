using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Excel;
using System.Data;


public static class ExcelEditor
{
    [MenuItem("调试/Excel转txt")]
    public static void ExportExcelToTxt()
    {
        // 获得存放Excel的文件夹路径并从中获得excel文件
        string excelPath = Application.dataPath + "/Excel";
        string[] Files = Directory.GetFiles(excelPath, "*.xlsx");
        
        for (int i = 0; i < Files.Length; i++)
        {
            // 测试1
            Debug.Log(Files[i]);
            Files[i] = Files[i].Replace('\\', '/');
            // 测试2
            Debug.Log(Files[i]);

            // 通过文件流读取文件(看不懂，只知道用)
            using (FileStream fs = File.Open(Files[i], FileMode.Open, FileAccess.Read))
            {
                // 将文件流转成Excel对象
                var excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                // 读取excel中的数据
                DataSet dataSet = excelDataReader.AsDataSet();
                // 建立数据表
                DataTable dataTable = dataSet.Tables[0];
                // 将数据表的内容存到对应的txt中
                readTableToTxt(Files[i], dataTable);
            }
        }
        
        // 刷新编辑器
        AssetDatabase.Refresh();
    }

    static void readTableToTxt(string filePath, DataTable dataTable)
    {
        // 获得文件名并出去文件后缀
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        // 设置txt文件存储路径
        string txtPath = Application.dataPath + "/Resources/Data/" + fileName + ".txt";
        // 判断是否存在该路径，若存在就删掉
        if (File.Exists(txtPath))
        {
            File.Delete(txtPath);
        }
        // 通过文件流创建txt(文件流和写入流看不懂一点，纯超)
        using (FileStream fs = new FileStream(txtPath, FileMode.Create) )
        {
            // 文件流转写入流 写入字符串
            using (StreamWriter sw = new StreamWriter(fs))
            {
                // i 是行，j是列
                for (int i = 0;i < dataTable.Rows.Count;i++)
                {
                    DataRow dataRow = dataTable.Rows[i];
                    string str = "";
                    for (int j = 0;j < dataTable.Columns.Count;j++)
                    {
                        string val = dataRow[j].ToString();
                        str = str + val + "\t";
                    }
                    // 写入
                    sw.Write(str);
                    // 判断是否最后一行，若否则换行
                    if (i != dataTable.Rows.Count - 1)
                    {
                        sw.WriteLine();
                    }
                }
            }
        }

    }
}
