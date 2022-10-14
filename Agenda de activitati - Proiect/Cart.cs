using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agenda_de_activitati___Proiect
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
        }

        private int ItemIndexOf(int ID)
        {
            foreach (CartItem item in Items)
            {
                 if(item.ID == ID)
                {
                    return Items.IndexOf(item);
                }
            }
            return -1;
        }

        public void Insert(CartItem item)
        {
            int index = ItemIndexOf(item.ID);

            if(index==-1)
            {
                Items.Add(item);
            }
            else
            {
                Items[index].Cantitate++;
            }

        }

        public void Delete (int rowID)
        {
            Items.RemoveAt(rowID);
        }

        public void Update( int rowID, int cantitate)
        {
            if (cantitate>0)
            {
                Items[rowID].Cantitate = cantitate;
            }
            else
            {
                Delete(rowID);
            }
        }


        public Double Total
        {
            get
            {
                if (Items == null)
                {
                    return 0;
                }
                else
                {
                    Double total = 0;
                    foreach(CartItem item in Items )
                    {
                        total += item.Cantitate * item.Pret;
                    }

                    return total;
                }
            }
        }
    }
}