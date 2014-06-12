// -----------------------------------------------------------------------
// <copyright file="Recipe.cs" company="">
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

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// 
    [DataContract]
    public class Recipe
    {
        //[DataMember]
        //public int Id { get; set; }
        [DataMember]
        public string ARecept { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string DishType { get; set; }
        [DataMember]
        public string ICuisine { get; set; }
        //[DataMember]
        //public string Category1 { get; set; }
        //[DataMember]
        //public string Category2 { get; set; }
        //[DataMember]
        //public string Instrument { get; set; }
        //[DataMember]
        //public string Portions { get; set; }
        [DataMember]
        public string Minutes { get; set; }
        //[DataMember]
        //public string Notes { get; set; }
        //[DataMember]
        //public string Favorites { get; set; }
        //[DataMember]
        //public string Dead { get; set; }
        [DataMember]
        public string Picture { get; set; }
        //[DataMember]
        //public string Fast { get; set; }

        public Recipe()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            //Id = rand.Next();
            ARecept = rand.NextDouble().ToString();
            Content = rand.NextDouble().ToString();
            Description = rand.NextDouble().ToString();
            DishType = rand.NextDouble().ToString();
            ICuisine = rand.NextDouble().ToString();
            //Category1 = rand.NextDouble().ToString();
            //Category2 = rand.NextDouble().ToString();
            //Instrument = rand.NextDouble().ToString();
            //Portions = rand.NextDouble().ToString();
            Minutes = rand.NextDouble().ToString();
            //Notes = rand.NextDouble().ToString();
            //Favorites = rand.NextDouble().ToString();
            //Dead = rand.NextDouble().ToString();
            //DishPic = rand.NextDouble().ToString();
            //Fast = rand.NextDouble().ToString();
        }

        public Recipe(int id, string recept, string content, string receptDescription, string dishType, string cuisine, string category1,
            string category2, string instrument, string portions, string minutes, string notes, string favorites, string dead,
            string dishPic, string fast)
        {
            //Id = id;
            ARecept = recept;
            Content = content;
            Description = receptDescription;
            DishType = dishType;
            ICuisine = cuisine;
            //Category1 = category1;
            //Category2 = category2;
            //Instrument = instrument;
            //Portions = portions;
            Minutes = minutes;
            //Notes = notes;
            //Favorites = favorites;
            //Dead = dead;
            //DishPic = dishPic;
            //Fast = fast;
        }
    }
}
