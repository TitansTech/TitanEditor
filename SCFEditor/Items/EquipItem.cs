using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing ;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;

namespace TitanEditor
{
    public class EquipItem
    {
        public const string UNKNOW_ITEM = "unknownItem";

        public const int ITEM_SIZE = 16;

        int xnum = 1;
        int ynum = 1;
        string name = null; 
        int hand = 0;
        int profs = 0;
        byte[] codes = new byte[ITEM_SIZE] { 0x00, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
		Image img = null;


        static EquipItem unknownItem = createUnknownItem();

        public Int64 Serial
        {
            get
            {
                byte[] ser = {0,0,0,0, codes[3], codes[4], codes[5], codes[6] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(ser);

               // int sasa = BitConverter.ToUInt32 (ser, 0);

                return BitConverter.ToInt64(ser, 0);
            }
            set
            {
                byte[] bytes = BitConverter.GetBytes(value);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytes);
                for (int i = 0; i < 4; i++)
                    codes[i + 3] = bytes[i+4];
            }
        }

        public Int64 AutoSerialize()
        {
            try
            {
                Int64 tmpSerial = 0;
                DBLite.dbMu.Read("EXEC WZ_GetItemSerial");
                DBLite.dbMu.Fetch();
                tmpSerial = DBLite.dbMu.GetAsInteger64("");
                DBLite.dbMu.Close();
                return tmpSerial;
            }
            catch (Exception) 
            { 
                return 0; 
            }
        }

        public static EquipItem UnknownItem
        {
            get
            {
                return unknownItem; 
            }
        }

        protected static EquipItem createUnknownItem()
        {
            EquipItem item = new EquipItem();
            item.Name = EquipItem.UNKNOW_ITEM;
            item.hand = 1;
            item.profs = 0xFF;
            ResourceManager rmgr = new ResourceManager("TitanEditor.Properties.Resources", Assembly.GetExecutingAssembly());
            item.Img = (Image)rmgr.GetObject(UNKNOW_ITEM);

            return item;
        }



        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                }
            }
        }
        public string CodeType
        {
            get
            {
                return getItemCodeType(codes);
            }
        }
		public byte Type
		{
			get
			{
				return (byte)(codes[9] >> 4);
			}
			set
			{
                codes[9] = (byte)(codes[9] & 0x0F);  // clear
                codes[9] = (byte)(codes[9] | (value << 4));
			}
		}
		public byte Code
		{
			get
			{
				return codes[0];
			}
			set
			{
				if (codes[0] != value)
				{
					codes[0] = value;
				}
			}
		}
		public Image Img
		{
			get
			{
				return img;
			}
			set
			{
				if (img != value)
				{
					img = value;
				}
			}
		}
        public int Width
        {
            get
            {
                return xnum;
            }
        }
        public int Height
        {
            get
            {
                return ynum;
            }
        }

        public bool Hand
        {
            get
            {
                return hand == 1;
            }
        }


        public byte Level 
        {
            get
            {
                return (byte)((codes[1] & 0x78) >> 3);
            }
            set
            {
                modifyLevel(value);
            }
        }
        public byte Harmony 
        {
            get
            {
                return (byte)((codes[10]));
            }
            set
            {
                modifyHarmony(value);
            }
        }
        public byte Socket1 
        {
            get
            {
                return (byte)((codes[11]));
            }
            set
            {
                modifySocket1(value);
            }
        }
        public byte Socket2
        {
            get
            {
                return (byte)((codes[12]));
            }
            set
            {
                modifySocket2(value);
            }
        }
        public byte Socket3
        {
            get
            {
                return (byte)((codes[13]));
            }
            set
            {
                modifySocket3(value);
            }
        }
        public byte Socket4 
        {
            get
            {
                return (byte)((codes[14]));
            }
            set
            {
                modifySocket4(value);
            }
        }
        public byte Socket5
        {
            get
            {
                return (byte)((codes[15]));
            }
            set
            {
                modifySocket5(value);
            }
        }
        public int Ext
        {
            get
            {
                return ((codes[7] & 0x40) >> 4) + (codes[1] & 0x03);
            }
            set
            {
                modifyExt(value);
            }
        }
        public bool ZY1
        {
            get
            {
                return (codes[7] & 0x01) != 0;
            }
            set
            {
                modifyZY1(value);
            }
        }
        public bool ZY2
        {
            get
            {
                return (codes[7] & 0x02) != 0;
            }
            set
            {
                modifyZY2(value);
            }
        }
        public bool ZY3
        {
            get
            {
                return (codes[7] & 0x04) != 0;
            }
            set
            {
                modifyZY3(value);
            }
        }
        public bool ZY4
        {
            get
            {
                return (codes[7] & 0x08) != 0;
            }
            set
            {
                modifyZY4(value);
            }
        }
        public bool ZY5
        {
            get
            {
                return (codes[7] & 0x10) != 0;
            }
            set
            {
                modifyZY5(value);
            }
        }
        public bool ZY6
        {
            get
            {
                return (codes[7] & 0x20) != 0;
            }
            set
            {
                modifyZY6(value);
            }
        }
        public bool JN
        {
            get
            {
                return (codes[1] & 0x80) != 0;
            }
            set
            {
                modifyJN(value);
            }
        }
        public bool XY
        {
            get
            {
                return (codes[1] & 0x04) != 0;
            }
            set
            {
                modifyXY(value);
            }
        }
        public bool IsNoDurability
        {
            get
            {
                return codes[9] == 0xE0;
            }
        }
        public byte Durability
        {
            get
            {
                return codes[2];
            }
            set
            {
                codes[2] = value;
            }
        }

        //public bool Set
        //{
        //    //0100FF19B372AC000[97]0000000000000 - HYON
        //    //0100FF19B3721D000[A7]0000000000000 - VICIOUS

        //    get
        //    {
        //        return (codes[8] & 0x0C) != 0; // 1100
        //    }
        //    set
        //    {
        //        codes[8] = (byte)(codes[8] & 0xF0);
        //        if (value)
        //        {
        //            if (Type > 6)
        //                codes[8] = (byte)(codes[8] | 0x05);  // +5
        //            else
        //                codes[8] = (byte)(codes[8] | 0x09);  //+10
        //        }
        //    }
        //}


        public byte Set
        {
            //0100FF19B372AC000[97]0000000000000 - HYON
            //0100FF19B3721D000[A7]0000000000000 - VICIOUS

            get
            {
                if (codes[8] > 0)
                {
                    if (Type > 6)
                        return Convert.ToByte(codes[8] % 4);
                    else
                        return Convert.ToByte(codes[8] % 8);
                }
                else
                    return 0;
            }
            set
            {
                if (value > 0)
                {
                    codes[8] = value;
                    if (Type > 6)
                        codes[8] |= 4;
                    else
                        codes[8] |= 8;
                }
            }
        }

        public EquipItem()
        {
        }
        
        public EquipItem(EquipItem baseItem)
        {
            this.xnum = baseItem.xnum;
            this.ynum = baseItem.ynum;
            this.name = baseItem.name;
            this.hand = baseItem.hand;
            this.profs = baseItem.profs; // 1234 5678 1234 5678 1234 5678 1234  //

            this.img = baseItem.img;
        }

        public EquipItem(int code, string name, int hand, int type, int xnum, int ynum, int profs)
        {
            Code = (byte)code;
            Type = (byte)type;
            this.name = name;
            this.hand = hand;
            this.xnum = xnum;
            this.ynum = ynum;
            this.profs = profs;
        }

        public EquipItem(EquipItem baseItem, byte[] codes)
        {
            this.xnum = baseItem.xnum;
            this.ynum = baseItem.ynum;
            this.name = baseItem.name;
            this.hand = baseItem.hand;
            this.profs = baseItem.profs; // 1234 5678 1234 5678 1234 5678 1234  //
            this.img = baseItem.img;


            codes.CopyTo(this.codes, 0);

        }

        public EquipItem(EquipItem baseItem, byte[] codes, int offset, int len)
        {
            this.xnum = baseItem.xnum;
            this.ynum = baseItem.ynum;
            this.name = baseItem.name;
            this.hand = baseItem.hand;
            this.profs = baseItem.profs; // 1234 5678 1234 5678 1234 5678 1234  //
            this.img = baseItem.img;

            Array.Copy(codes, offset, this.codes, 0, len);
        }

        public EquipItem assign(EquipItem other)
        {

            other.codes.CopyTo(this.codes, 0);


            this.xnum = other.xnum;
            this.ynum = other.ynum;
            this.name = other.name;
            this.hand = other.hand;
            this.profs = other.profs; // 1 2 3 4 5 6 7
            this.img = other.img;

            return this;
        }

        public void modifyHarmony(int Value)
        {
            codes[10] = (byte)(Value);
        }
        public void modifySocket1(int Value)
        {
            codes[11] = (byte)(Value);
        }
        public void modifySocket2(int Value)
        {
            codes[12] = (byte)(Value);
        }
        public void modifySocket3(int Value)
        {
            codes[13] = (byte)(Value);
        }
        public void modifySocket4(int Value)
        {
            codes[14] = (byte)(Value);
        }
        public void modifySocket5(int Value)
        {
            codes[15] = (byte)(Value);
        }


        public void modifyLevel(int level)
        {

            codes[1] = (byte)(codes[1] & 0x87);

            codes[1] = (byte)(codes[1] | (level << 3));
        }
        public void modifyExt(int ext)
        {

            codes[1] = (byte)(codes[1] & 0xFC);
            codes[7] = (byte)(codes[7] & 0xBF);


            byte exth = (byte)(0x04 & ext);
            codes[7] = (byte)(codes[7] | (exth << 4));
            ext = 0x03 & ext;
            codes[1] = (byte)(codes[1] | ext);
        }
        public void modifyZY1(bool flag)
        {
            if (flag)
            {
                codes[7] = (byte)(codes[7] | 0x01);
            }
            else
            {
                codes[7] = (byte)(codes[7] & 0xFE);
            }
        }
        public void modifyZY2(bool flag)
        {
            if (flag)
            {
                codes[7] = (byte)(codes[7] | 0x02);
            }
            else
            {
                codes[7] = (byte)(codes[7] & 0xFD);
            }
        }
        public void modifyZY3(bool flag)
        {
            if (flag)
            {
                codes[7] = (byte)(codes[7] | 0x04);
            }
            else
            {
                codes[7] = (byte)(codes[7] & 0xFB);
            }
        }
        public void modifyZY4(bool flag)
        {
            if (flag)
            {
                codes[7] = (byte)(codes[7] | 0x08);
            }
            else
            {
                codes[7] = (byte)(codes[7] & 0xF7);
            }
        }
        public void modifyZY5(bool flag)
        {
            if (flag)
            {
                codes[7] = (byte)(codes[7] | 0x10);
            }
            else
            {
                codes[7] = (byte)(codes[7] & 0xEF);
            }
        }
        public void modifyZY6(bool flag)
        {
            if (flag)
            {
                codes[7] = (byte)(codes[7] | 0x20);
            }
            else
            {
                codes[7] = (byte)(codes[7] & 0xDF);
            }
        }
        public void modifyXY(bool flag)
        {
            if (flag)
            {
                codes[1] = (byte)(codes[1] | 0x04);
            }
            else
            {
                codes[1] = (byte)(codes[1] & 0xFB);
            }
        }
        public void modifyJN(bool flag)
        {
            if (flag)
            {
                codes[1] = (byte)(codes[1] | 0x80);
            }
            else
            {
                codes[1] = (byte)(codes[1] & 0x7F);
            }
        }

        public byte[] getCodes()
        {
            return codes;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ITEM_SIZE; i++)
            {
                sb.Append(codes[i].ToString("X2"));
            }
            return sb.ToString();
        }


        public static EquipItem createItem(string scodes)
        {
            //codes = fffffff....
            if (scodes.Length != ITEM_SIZE << 1)
            {
                return null;
            }
            scodes = scodes.ToUpper();
            if (scodes.StartsWith("FF"))
            {
                return null;
            }


            byte[] codes = new byte[ITEM_SIZE];
            try
            {
                for (int i = 0; i < ITEM_SIZE; i++)
                {
                    codes[i] = Convert.ToByte(scodes.Substring(i * 2, 2), 16);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return createItem(codes);
        }

        public static EquipItem createItem(byte[] codes)
        {
            return createItem(codes, 0, ITEM_SIZE);
        }

        public static EquipItem createItem(byte[] codes, int offset, int len)
        {
            if (offset < 0 || len <= 0 || (offset + len > codes.Length) || codes[offset] == 0xFF)
            {
                return null;
            }

            string codeType = getItemCodeType(codes, offset, len);
            EquipItem item = EquipImageCache.Instance.getItemByCodeType(codeType);
            return new EquipItem(item, codes, offset, len);
        }

        public static EquipItem createItem(byte code, byte type)
        {

            string codeType = getItemCodeType(code, type);
            EquipItem item = EquipImageCache.Instance.getItemByCodeType(codeType);
            return new EquipItem(item);
        }

        public static string getItemCodeType(byte[] codes)
        {
            if (codes.Length  < ITEM_SIZE)
                return null;
            return string.Format("{0:X2}{1:X2}", codes[0], codes[9]);
        }
        public static string getItemCodeType(byte[] codes, int offset, int len)
        {
            if (offset < 0 || len <= 0 || offset + len > codes.Length  || len < ITEM_SIZE)
                return UNKNOW_ITEM;
            return string.Format("{0:X2}{1:X2}", codes[offset], codes[offset + 9] >> 4);
        }
        public static string getItemCodeType(byte code, byte type)
        {
            return string.Format("{0:X2}{1:X2}", code, type);
        }

        public static byte getItemCode(string codeType)
        {
            if (codeType == null || codeType == null)
            {
                return 0xFF;  //FF
            }

            return Convert.ToByte(codeType.Substring(0, 2), 16);
        }

        public static byte getItemType(string codeType)
        {
            if (codeType == null || codeType == null)
            {
                return 0xF;  //FF
            }

            return Convert.ToByte(codeType.Substring(2, 2), 16);  //
        }

        public static string toHex(byte[] codes, int offset, int len)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                sb.Append(codes[offset + i].ToString("X2"));
            }
            return sb.ToString();
        }
    }


    public class EquipItemType
    {
        byte typeId;
        string name;
        IList itemNames = null;

        public EquipItemType()
        {
        }
        public EquipItemType(byte typeId, string name)
        {
            this.typeId = typeId;
            this.name = name;
        }
        public byte TypeId
        {
            get
            {
                return typeId;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public IList ItemNames
        {
            get
            {
                return itemNames;
            }
            set
            {
                itemNames = value;
            }
        }

        public override string ToString()
        {
            return name;
        }
    }


    public class EquipCustomSet
    {
        public const int MAX_ITEM_NUM = 13;

        string name = null;
        byte classType = 0;
        byte membLvl = 0;
        EquipItem[] items = new EquipItem[MAX_ITEM_NUM];

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public byte ClassType
        {
            get
            {
                return classType;
            }
            set
            {
                classType = value;
            }
        }
        public byte MembLvl
        {
            get
            {
                return membLvl;
            }
            set
            {
                membLvl = value;
            }
        }

        public EquipItem[] Items
        {
            get
            {
                return items;
            }
        }

        public EquipCustomSet()
        {
        }

        public bool setItem(int pos, string scodes)
        {
            if (pos < 0 || pos >= MAX_ITEM_NUM)
            {
                return false;
            }
            items[pos] = EquipItem.createItem(scodes);
            return items[pos] != null;
        }
        public bool setItems(IList items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                this.items[i] = (EquipItem)items[i];
            }
            return true;
        }

        public string[] getItemsCodes()
        {
            string[] scodes = new string[MAX_ITEM_NUM];
            for (int i = 0; i < MAX_ITEM_NUM; i++)
            {
                if (items[i] == null)
                {
                    scodes[i] = "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF";
                }
                else
                {
                    scodes[i] = items[i].ToString();
                }
            }
            return scodes;
        }


        public override string ToString()
        {
            return name;
        }
    }
}
