using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;

namespace TitanEditor
{
	public class EquipImageCache
	{
		Hashtable cache = new Hashtable();

		EquipImageCache()
		{
		}
		//Singleton Object
		public static EquipImageCache Instance
		{
			get
			{
				return Nested.instance;
			}
		}
		class Nested
		{
			
			static Nested()
			{
			}

			internal static readonly EquipImageCache instance = new EquipImageCache();
		}

		public EquipItem getItem(string name)
		{
			EquipItem item = null;
            if ((item = (EquipItem)cache[name]) == null)
			{
				lock(cache)
				{
                    if ((item = (EquipItem)cache[name]) == null)
					{
                        string sql = string.Format("select UniQue, Name, Hand, Type, Wide, High, DW, DK, ELF, MG, DL, SU, RF, Pic from MuItem where Name = '{0}'", name);
                        item = getItemFromDb(sql);
                        if (item == null)
                        {
                            item = EquipItem.UnknownItem;
                        }
						cache[name] = item;
                        cache[item.CodeType] = item;
					}
				}
			}

			return item;
		}

        public EquipItem getItemByCodeType(string codeType)
        {
            EquipItem item = null;
            if ((item = (EquipItem)cache[codeType]) == null)
            {
                lock (cache)
                {
                    if ((item = (EquipItem)cache[codeType]) == null)
                    {
                        try
                        {
                            string sql = string.Format("select UniQue, Name, Hand, Type, Wide, High, DW, DK, ELF, MG, DL, SU, RF, Pic from MuItem where UniQue = {0} and Type = {1}", EquipItem.getItemCode(codeType), EquipItem.getItemType(codeType));
                            item = getItemFromDb(sql);
                            if (item == null)
                            {
                                item = item = EquipItem.UnknownItem;
                            }
                            cache[codeType] = item;
                            cache[item.Name] = item;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Item: [" + EquipItem.getItemType(codeType) + ", " + EquipItem.getItemCode(codeType) + "]. Doesnt exist in DB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            return item;
        }

		protected EquipItem getItemFromDb(string sql)
		{
			MemoryStream stream = null;
			Image img = null;
			EquipItem item = null;

			try 
			{
                DBLite.mdb.Read(sql);
                DBLite.mdb.Fetch();
				//
                int profs = DBLite.mdb.GetAsInteger("DW") + DBLite.mdb.GetAsInteger("DK") << 1 + DBLite.mdb.GetAsInteger("ELF") << 2 + DBLite.mdb.GetAsInteger("MG") << 3 + DBLite.mdb.GetAsInteger("DL") << 4 + DBLite.mdb.GetAsInteger("SU") << 5 + DBLite.mdb.GetAsInteger("RF") << 6;
				item = new EquipItem (DBLite.mdb.GetAsInteger("UniQue"), DBLite.mdb.GetAsString("Name"), DBLite.mdb.GetAsInteger("Hand"), DBLite.mdb.GetAsInteger("Type"), DBLite.mdb.GetAsInteger("Wide"), DBLite.mdb.GetAsInteger("High"), profs);
				Byte[] data = DBLite.mdb.GetAsBinary("Pic");
                if (data != null)
                {
                    stream = new MemoryStream(data);
                    img = Image.FromStream(stream);
                    stream.Close();
                    item.Img = img;
                }
                else
                {
                    ResourceManager rmgr = new ResourceManager("TitanEditor.Properties.Resources", Assembly.GetExecutingAssembly());
                    item.Img = (Image)rmgr.GetObject("unknownItem");
                }
                DBLite.mdb.Close();
			} 
			catch(Exception ex)
			{
                MessageBox.Show("MDB Query:" + sql + "\nError:" + ex.Message + "\nSource:" + ex.Source + "\nTrace:" + ex.StackTrace);
			}
			return item;
		}
	}
}
