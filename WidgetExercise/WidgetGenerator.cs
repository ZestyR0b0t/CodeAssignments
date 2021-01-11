using System;
using System.Collections.Generic;

namespace WidgetExercise
{
    public static class WidgetGenerator
    {
        public static List<Widget> GetRandomWidgets()
        {
            List<Widget> genList = new List<Widget>();

			string[] adjs = {"red", "blue", "green", "yellow", "white", "black", "big", "small", "slimy", "loud", "soft", "ugly", "pretty"};
			string[] objs = {"button", "door", "lever", "key", "fruit", "ghost", "developer", "book", "horn", "crystal"};

			Random rand = new Random();

			int listSize = rand.Next(10, 20);

			while (genList.Count < listSize)
			{
                string adj = adjs[rand.Next(adjs.Length)];
                string obj = objs[rand.Next(objs.Length)];

				string desc = adj + " " + obj;

				bool alreadyExists = false;
				for (int i = 0; i < genList.Count; i++)
				{
					if (genList[i].GetDescription().Equals(desc))
					{
						alreadyExists = true;
						break;
					}
				}

				if (!alreadyExists)
				{
					genList.Add(new Widget(adj, obj));
				}
			}

			return genList; 
        }
    }
}