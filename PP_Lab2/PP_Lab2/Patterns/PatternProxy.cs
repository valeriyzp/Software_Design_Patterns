using System;

namespace PP_Lab2.Patterns
{
    public interface IDataBase
    {
        public void set(string data);
        public string get();
    }

    public class DataBase : IDataBase
    {
        private string _Data {get; set;}

        public DataBase()
        {
            _Data = "Security data";
        }

        public void set(string data)
        {
            _Data = data;
        }

        public string get()
        {
            return _Data;
        }
    }

    public class DataBaseProxy : IDataBase
    {
        private DataBase _DataBase;
        string lastData = "";

        public DataBaseProxy() { ;}

        public DataBaseProxy(DataBase service)
        {
            _DataBase = service;
        }

        private void Init()
        {
            if (_DataBase == null)
            {
                _DataBase = new DataBase();
                Console.WriteLine("Init DataBase");
            }
        }

        public void set(string data)
        {
            Init();

            if (lastData == data)
                Console.WriteLine("Attempt to set the same data");
            else
            {
                _DataBase.set(data);
                lastData = data;
                Console.WriteLine("Update data in Database to {0}", lastData);
            }
        }

        public string get()
        {
            Init();

            lastData = _DataBase.get();
            return lastData;
        }
    }
}
