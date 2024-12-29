using System;

namespace ConMySqlTest
{
    class Person
    {
        static Random rnd = new Random(DateTime.Now.Millisecond);
        
        public Person(string name, string vorname, string ort)
        {
            Name = name;
            Vorname = vorname;
            Ort = ort;
        }
        public string Vorname { get; set; }
        public string Name { get; set; }
        public string Ort { get; set; }
        
        public int Faktor
        {
            get { return rnd.Next(1, 10); }
        }

        public string DataStr
        {
            get { return string.Format("'{0}','{1}','{2}',{3}", Name, Vorname, Ort, Faktor); }
        }
    }
}
