using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Social_Drink
{
    public class GravaIS
    {


        public static class IsolatedStorageCacheManager<T>
        {
            public static void Store(string filename, T obj)
            {
                IsolatedStorageFile appStore = IsolatedStorageFile.GetUserStoreForApplication();
                using (IsolatedStorageFileStream fileStream = appStore.OpenFile(filename, FileMode.Create))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                    serializer.WriteObject(fileStream, obj);
                }
            }
            public static T Retrieve(string filename)
            {
                T obj = default(T);
                IsolatedStorageFile appStore = IsolatedStorageFile.GetUserStoreForApplication();
                if (appStore.FileExists(filename))
                {
                    using (IsolatedStorageFileStream fileStream = appStore.OpenFile(filename, FileMode.Open))
                    {
                        DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                        obj = (T)serializer.ReadObject(fileStream);
                    }
                }
                return obj;
            }
        }




         public static void SaveToIs(String fileName, Object saved)
    {
        try
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isf.FileExists(fileName))
                {
                    isf.DeleteFile(fileName);
                }


                using (IsolatedStorageFileStream fs = isf.CreateFile(fileName))
                {

                    XmlSerializer ser = new XmlSerializer(saved.GetType());
                    ser.Serialize(fs, saved);
                }
            }
        }
        catch (IsolatedStorageException ex)
        {
            MessageBox.Show(ex.Message);
        }


    }

    public static Object loadFromIS(String fileName, Type t)
    {
        Object result = null;
        try
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isf.FileExists(fileName))
                {

                    using (StreamReader sr = new StreamReader(isf.OpenFile(fileName, FileMode.Open)))
                    {
                        XmlSerializer ser = new XmlSerializer(t);
                        result = ser.Deserialize(sr);
                    }
                }
            }
        }
        catch (IsolatedStorageException ex)
        {
            MessageBox.Show(ex.Message);
        }
        catch (InvalidOperationException e)
        {
            MessageBox.Show(e.Message);
        }
        return result;
    }



    }
}

