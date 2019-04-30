using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;

namespace Lab09
{
    class Program
    {
        /* Burada binary olarak objeleri serilize etmeye yaran örnek methodlar vardır. 
         * 
         * Binary dosya yerine XML dosyasına serileştirme için kullanılabilecek örnek bir kod aşağıdadır. Ancak XML serileştirmenin bazı limitleri vardır. Öncelikle 
         * sınıfınızın parametresiz bir oluşturcu metoda ihtiyaçı olacaktır. Ayrıca serileştirilmesini istediğiniz tüm özelliklerin ya public erişimi olmalı veya public erişimli
         * get ve set metodları olmalıdır.
          XmlSerializer xsSubmit = new XmlSerializer(typeof(MyObject));
         var subReq = new MyObject();
         var xml = "";

         using(var sww = new StringWriter())
        {
            using(XmlWriter writer = XmlWriter.Create(sww))
            {
                xsSubmit.Serialize(writer, subReq);
                xml = sww.ToString(); // Your XML
            }
         }
         */
        static void Main(string[] args)
        {

            University deu = null;
            try
            {
                // Deserilizasyon burada yapılacak.
                deu = Deserialize();
            }
            catch (Exception e)
            {

                string name = "deu";
                deu = new University(name);
                deu.AddStudent(new BSc("Ahmet", "Mehmet", 1));
                deu.AddStudent(new MSc("Ali", "Veli", 2));
                deu.AddStudent(new PhD("Ali", "Mehmet", 3));
            }
            finally
            {
                if (deu != null)
                {
                    foreach (Student a in deu.Students)
                    {
                        Console.WriteLine(a.ToString());
                        SerializeXML(a, a.Name + ".xml");
                    }
                    //Serilizasyon burada yapılacak
                    Console.WriteLine();
                }
            }


            NoyaGoreArama(deu);
            // exceptionları nerede çalıştıracağımı anlamadım. XML olarak nesneleri yazdırıyor.
	    // exception constructor'larını oluşturdum

            

            Console.ReadKey();
        }

        static void NoyaGoreArama(University deu)
        {
            try
            {
                //Student s = deu.SearchStudent(3);
                //Console.WriteLine(s.ToString());
                Student s = deu.SearchStudent(4);
                Console.WriteLine("varmi ? " + s.ToString());

                if (s == null)
                {
                    Console.WriteLine("yok");
                    throw new StudentNotFound(s.No);
                }
            }
            catch (StudentNotFound e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {

            }
        }

        static void IsmeGoreArama(University deu)
        {
            try
            {
                Student s = deu.SearchStudent("Ali");
                Console.WriteLine(s.ToString());
                s = deu.SearchStudent("Hasan");
                Console.WriteLine(s.ToString());

                if (s == null)
                {
                    throw new StudentNotFound(s.Name);
                }
            }
            catch (StudentNotFound e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {

            }
        }

        static void SerializeXML(Student student, string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {

                var XML = new XmlSerializer(typeof(Student));
                XML.Serialize(stream, student);
            }

            //XmlSerializer xsSubmit = new XmlSerializer(typeof(Student));
            //var subReq = new BSc();
            //var xml = "";

            //using (var sww = new StringWriter())
            //{
            //    using (XmlWriter writer = XmlWriter.Create(sww))
            //    {
            //        xsSubmit.Serialize(writer, subReq);
            //        xml = sww.ToString(); // Your XML
            //        Console.WriteLine(xml);
            //    }
            //}


        }

        static void Serialize(University deu)
        {
            using (FileStream fs = new FileStream("university.dat", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fs, deu);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    throw;
                }
            }
        }
        static University Deserialize()
        {
            University deu;
            using (FileStream fs = new FileStream("university.dat", FileMode.Open))
            {

                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    deu = (University)formatter.Deserialize(fs);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                    throw;
                }

            }
            return deu;
        }
    }
}

