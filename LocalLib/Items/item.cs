using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;


namespace LocalLib.Casting
{
    public class Item
    {

        private Dictionary<string, Attribute> attributes;
        public string ItemKey;

        /// <summary>
        /// Constructs a new instance of Actor using the given ID.
        /// </summary>
        /// <param name="ID">The given actor type.</param>
        public Item(string ItemKey)
        {
            attributes = new Dictionary<string, Attribute>();
            this.ItemKey = ItemKey;
            // this.ID = ID;
        }

        /// <summary>
        /// Gets the Actor's ID value.
        /// </summary>
        /// <returns>The ID value.</returns>
        public Attribute GetActorAttribute(string key)
        {
            if(attributes.ContainsKey(key))
            {
                return attributes[key];
            }

            return null;
        }

        /// <summary>
        /// sets the Actor's type value.
        /// </summary>
        public void AddAttribute(Attribute action)
        {
            string key = action.GetAttributeKey();
            if (!attributes.ContainsKey(key))
            {
                attributes.Add(key, action);
            }else 
            {
                System.Console.WriteLine("attribute : " + key + " is alredy apllyed to Actor");
            }
        }

        /// <summary>
        /// sets the Actor's type value.
        /// </summary>
        public void RemoveActorAttribute(string key)
        {
            if (!attributes.ContainsKey(key))
            {
                System.Console.WriteLine("attribute : " + key + " is not applyed to Actor");
                
            }else 
            {
                attributes.Remove(key);
            }
        }

        /// <summary>
        /// Gets the Actor's ID value.
        /// </summary>
        /// <returns>The ID value.</returns>
        public bool HasAttribute(string key)
        {
            if(attributes.ContainsKey(key))
            {
                return true;
            }

            return false;
        }


    }
}
