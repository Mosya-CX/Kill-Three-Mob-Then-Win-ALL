using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Excel;
using System.Data;


public static class ExcelEditor
{
    [MenuItem("����/Excelתtxt")]
    public static void ExportExcelToTxt()
    {
        // ��ô��Excel���ļ���·�������л��excel�ļ�
        string excelPath = Application.dataPath + "/Excel";
        string[] Files = Directory.GetFiles(excelPath, "*.xlsx");
        
        for (int i = 0; i < Files.Length; i++)
        {
            // ����1
            Debug.Log(Files[i]);
            Files[i] = Files[i].Replace('\\', '/');
            // ����2
            Debug.Log(Files[i]);

            // ͨ���ļ�����ȡ�ļ�(��������ֻ֪����)
            using (FileStream fs = File.Open(Files[i], FileMode.Open, FileAccess.Read))
            {
                // ���ļ���ת��Excel����
                var excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                // ��ȡexcel�е�����
                DataSet dataSet = excelDataReader.AsDataSet();
                // �������ݱ�
                DataTable dataTable = dataSet.Tables[0];
                // �����ݱ�����ݴ浽��Ӧ��txt��
                readTableToTxt(Files[i], dataTable);
            }
        }
        
        // ˢ�±༭��
        AssetDatabase.Refresh();
    }

    static void readTableToTxt(string filePath, DataTable dataTable)
    {
        // ����ļ�������ȥ�ļ���׺
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        // ����txt�ļ��洢·��
        string txtPath = Application.dataPath + "/Resources/Data/" + fileName + ".txt";
        // �ж��Ƿ���ڸ�·���������ھ�ɾ��
        if (File.Exists(txtPath))
        {
            File.Delete(txtPath);
        }
        // ͨ���ļ�������txt(�ļ�����д����������һ�㣬����)
        using (FileStream fs = new FileStream(txtPath, FileMode.Create) )
        {
            // �ļ���תд���� д���ַ���
            using (StreamWriter sw = new StreamWriter(fs))
            {
                // i ���У�j����
                for (int i = 0;i < dataTable.Rows.Count;i++)
                {
                    DataRow dataRow = dataTable.Rows[i];
                    string str = "";
                    for (int j = 0;j < dataTable.Columns.Count;j++)
                    {
                        string val = dataRow[j].ToString();
                        str = str + val + "\t";
                    }
                    // д��
                    sw.Write(str);
                    // �ж��Ƿ����һ�У���������
                    if (i != dataTable.Rows.Count - 1)
                    {
                        sw.WriteLine();
                    }
                }
            }
        }

    }
}
