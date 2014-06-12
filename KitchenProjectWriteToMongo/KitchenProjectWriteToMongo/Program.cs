using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace KitchenProjectWriteToMongo
{
    class Program
    {
        public static void Serialize()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            RecipeCollection rc = new RecipeCollection();
            rc.Recipe = new List<Recipe>();
            rc.Recipe.Add(new Recipe(1, rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString()));
            rc.Recipe.Add(new Recipe(2, rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString()));
            rc.Recipe.Add(new Recipe(3, rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString(), rand.Next().ToString()));
            rc.Serialize();
        }
		
		public static void OlyasFunction()
		{

		Console.WriteLine("My new Change2");



		}

        public static RecipeCollection Deserialize()
        {
            RecipeCollection rc = new RecipeCollection();
            rc.Deserialize();
            return rc;
        }

        public static void Regulars()
        {
            string allText;
            using (StreamReader sr = new StreamReader("barada2_3.xml"))
            {
                allText = sr.ReadToEnd();
            }
            //string find = @"<ID>(.+)<\/ID>[.\n]+<Recept>(.+)<\/Recept>[.\n]+<Content>(.+)<\/Content>[.\n]+<ReceptDescription>([А-Яа-я.,\n ]+)<\/ReceptDescription>";//
            string find = @"<Content>(.+)<\/Content>";
            Regex regex = new Regex(find);
            MatchCollection matches = regex.Matches(allText);
            foreach (Match item in matches)
                Console.WriteLine(item.Groups[1].Value);
        }

        public static void MongoReading()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27001");
            var server = client.GetServer();
            var db = server.GetDatabase("Recipes");
            var collection = db.GetCollection("Kitchen");
            foreach (var document in collection.FindAll())
                Console.WriteLine(document["ingredients"]);
        }

        public static void MongoWriting(RecipeCollection rc)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27001");
            var server = client.GetServer();
            var db = server.GetDatabase("recipes");
            var collection = db.GetCollection("recipes");
            int i = 0, e = 0;
            string[] s, newS, spl;
            List<string> s_ = new List<string>();
            string str;
            foreach (Recipe r in rc.Recipe)
            {
                if (!string.IsNullOrEmpty(r.Content))
                {
                    str = Regex.Replace(r.Content, @" [\d-\/]+[ ]{0,3}", string.Empty);
                    str = Regex.Replace(str, @"[\-]", string.Empty);
                    str = Regex.Replace(str, @"шт", string.Empty);
                    str = Regex.Replace(str, @"  ", " ");
                    str = Regex.Replace(str, @"г", string.Empty);
                    str = Regex.Replace(str, @"  ", " ");
                    str = str.ToLower();
                    if (str[str.Length - 1] == ' ' || str[str.Length - 1] == '.')
                        str = str.Remove(str.Length - 1);
                    if (str[0] == ' ')
                        str = str.Remove(0, 1);
                    //s = str.Split(", ".ToCharArray());
                    s = str.Split(new string[] { ", ", "; ", ";", " и ", "., " }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in s)
                    {
                        spl = item.Split(' ');
                        if (spl.Length > 0)
                            for (int zz = 0; zz < spl.Length; zz++)
                            {
                                if (string.IsNullOrEmpty(spl[zz]))
                                    continue;
                                if (!char.IsDigit(spl[zz].First()) && spl[zz].First() != '.')
                                { e = zz; break; }
                            }
                        s_.Add(spl[e]);
                    }
                    //newS = new string[s.Length];
                    if (s != null && s.Length > 0)
                    {
                        //foreach (var item in s)
                        //    if (item[item.Length - 1] == ' ')
                        //        newS[i++] = item.Remove(item.Length - 1);
                        collection.Insert(new BsonDocument { 
                        { "name" , r.ARecept},
                        { "description" , r.Description},
                        { "ingredients" , new BsonArray(s_.ToArray())},
                        { "dishType" , r.DishType},
                        { "typeKitchen" , r.ICuisine},
                        { "minutes" , r.Minutes},
                        {"picture" , r.Picture}
                    });
                    }
                    s_.Clear();
                }

            }

        }

        static void Main(string[] args)
        {
            try
            {
                //Serialize();
                //Regulars();
                MongoWriting(Deserialize());
                //MongoReading();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
        }
    }
}
