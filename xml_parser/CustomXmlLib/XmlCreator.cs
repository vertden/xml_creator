using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CustomXmlLib
{
    public class Phone
    {
        public String manufactured { get; set; }
        public String model { get; set; }
        public String year { get; set; }
    }
    public static class XmlCreator
    {

        public static void createXml(List<Phone> phonesList)
        {
            try
            {
                XDocument xdoc = new XDocument();
                // создаем корневой элемент
                XElement phones = new XElement("phones");

                foreach (Phone phone in phonesList)
                {

                    // создаем первый элемент
                    XElement xml_phone = new XElement("phone");
                    // создаем атрибут

                    XElement manufacturedElem = new XElement("manufactured", phone.manufactured);
                    XElement modelElem = new XElement("model", phone.model);
                    XElement yearElem = new XElement("year", phone.year);
                    // добавляем атрибут и элементы в первый элемент
                    xml_phone.Add(manufacturedElem);
                    xml_phone.Add(modelElem);
                    xml_phone.Add(yearElem);

                    // добавляем в корневой элемент
                    phones.Add(xml_phone);
                }
                // добавляем корневой элемент в документ
                xdoc.Add(phones);
                //сохраняем документ
                xdoc.Save("phones.xml");
                Console.WriteLine("XML file was successfully created");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
