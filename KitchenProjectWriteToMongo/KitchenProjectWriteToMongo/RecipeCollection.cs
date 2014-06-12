// -----------------------------------------------------------------------
// <copyright file="RecipeCollection.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace KitchenProjectWriteToMongo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.Serialization;
    using System.Xml;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// 
    [DataContract]
    public class RecipeCollection
    {
        [DataMember]
        public List<Recipe> Recipe { get; set; }

        public void Serialize()
        {
            DataContractSerializer xmlSerializer = new DataContractSerializer(this.GetType());
            string path = "Data_local_stored.xml";
            var xmlW = XmlWriter.Create(path, new XmlWriterSettings() { Indent = true, IndentChars = "\t" });
            xmlSerializer.WriteObject(xmlW, this);
            xmlW.Close();
        }

        public void Deserialize()
        {
            string path = "final_may_be_3.xml";
            DataContractSerializer xmlDeserializer = new DataContractSerializer(this.GetType());
            XmlReader xmlR = XmlReader.Create(path);
            try
            {
                RecipeCollection serialize = (RecipeCollection)xmlDeserializer.ReadObject(xmlR);
                Recipe = serialize.Recipe;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
            finally
            {
                xmlR.Close();
            }

        }
    }
}
