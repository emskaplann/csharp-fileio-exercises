using System;

namespace FileExercise
{
    class Program
    {
        public struct User
        {
            public string firstName;
            public string lastName;
            public string profession;
            public Address address;
        }

        public struct Address
        {
            public string street;
            public string city;
            public string state;
            public string zipCode;
        }

        static void Main(string[] args)
        {
            string filePath = @"../../../example_text_file.txt";
            string text = System.IO.File.ReadAllText(filePath);
            Console.WriteLine(text);

            //string strToWrite = "Sena Saliha Kaplan";
            //System.IO.File.WriteAllText(@"../../../example_output_file.txt", strToWrite);

            string xmlPath = @"../../../example_xml_file.txt";
            System.Xml.XmlDocument xmlFile = new System.Xml.XmlDocument();
            xmlFile.Load(xmlPath);

            User[] users = new User[2];
            int index = 0;
            foreach (System.Xml.XmlNode node in xmlFile.DocumentElement.ChildNodes)
            {
                try
                {
                    //Console.WriteLine(node.Attributes["FirstName"].InnerText);
                    User newUser = new User()
                    {
                        firstName = node.Attributes["FirstName"].InnerText,
                        lastName = node.Attributes["LastName"].InnerText,
                        profession = node.Attributes["Profession"].InnerText,
                    };
                    foreach (System.Xml.XmlNode childNode in node.ChildNodes)
                    {
                        newUser.address = new Address()
                        {
                            street = childNode.Attributes["Street"].InnerText,
                            city = childNode.Attributes["City"].InnerText,
                            state = childNode.Attributes["State"].InnerText,
                            zipCode = childNode.Attributes["Zip"].InnerText
                        };
                    }
                    users.SetValue(newUser, index);
                    index++;
                }
                catch
                {
                    Console.WriteLine("Something went wrong, ups :/");
                }
            }

            Console.WriteLine(users[0].address.street);
        }
    }
}