using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Resources ;
using System.Reflection;


namespace TitanEditor
{
    public partial class EquipPanel : UserControl
    {
        public const int pixels = 25;

        int xnum = 0;
        int ynum = 0;
        DrawingUnit[,] units = null;
        bool[,] flags = null;
        DrawingUnit curUnit = new DrawingUnit ();
        DrawingUnit selectedUnit = null;
        DrawingUnit activeUnit = null;
        DrawingUnit coveredUnit = null;
        int lastedX = 0, lastedY = 0;

        EquipEditor editor = null;
        public EquipEditor Editor
        {
            set
            {
                editor = value;
            }
        }

        public int XNum
        {
            get
            {
                return xnum;
            }
        }
        public int YNum
        {
            get
            {
                return ynum;
            }
        }
        public IList Items
        {
            get
            {
                return getItems();
            }
        }

        public EquipPanel()
        {
            InitializeComponent();
        }

        public EquipPanel(int xnum, int ynum, EquipEditor editor)
        {
            InitializeComponent();
            setSize(xnum, ynum);
            this.editor = editor;
            curUnit.Item = editor.EditItem;
        }
        public void setSize(int xnum, int ynum)
        {
            this.xnum = xnum;
            this.ynum = ynum;
            resizePanel();
            units = new DrawingUnit[xnum, ynum];
            flags = new bool[xnum, ynum];
            for (int i = 0; i < xnum; i++)
            {
                for (int j = 0; j < ynum; j++)
                {
                    units[i, j] = null;
                    flags[i, j] = false;
                }
            }
        }

        public void clearData()
        {
            activeUnit = null;
            selectedUnit = null;
            coveredUnit = null;
            lastedX = 0; lastedY = 0;
            
            for (int i = 0; i < xnum; i++)
            {
                for (int j = 0; j < ynum; j++)
                {
                    units[i, j] = null;
                    flags[i, j] = false;
                }
            }
        }
        
        protected void resizePanel()
        {
            this.Width = xnum * pixels;
            this.Height = ynum * pixels;
        }

        public bool loadItemsByCodes(byte[] codes, int offset, int len)
        {
            //
            if (offset < 0 || len < xnum * ynum * EquipItem.ITEM_SIZE || codes == null)
            {
                this.Invalidate();
                return false;
            }

            EquipItem item = null;
            for (int j = 0; j < ynum; j++)
            {
                for (int i = 0; i < xnum; i++)
                {

                    if ((item = EquipItem.createItem(codes, offset + (j * xnum + i) * EquipItem.ITEM_SIZE, EquipItem.ITEM_SIZE)) != null)
                    {
                        units[i, j] = new DrawingUnit(item, i, j);
                        putItem(units[i, j], false);
                    }
                }
            }
            this.Invalidate();
            return true;
        }

        public bool loadItemsByCodes(byte[] codes)
        {
            return loadItemsByCodes(codes, 0, codes.Length);
        }

        public bool putItems(EquipItem[] items)
        {
            bool isPut = true;
            if (canPutItems(items))
            {
                for (int i = 0; i < items.Length ; i ++)
                {
                    if (null == items[i])
                        continue;
                    isPut = isPut && putItem (items[i], true);
                }
                return isPut;
            }

            return false;
        }

        public bool canPutItems(EquipItem[] items)
        {
            bool[,] curflags = (bool[,])flags.Clone();

            foreach (EquipItem item in items)            
            {
                if (null == item)
                    continue;

                for (int j = 0; j < ynum; j++)
                {
                    for (int i = 0; i < xnum; i++)
                    {
                        if (!curflags[i, j] && canPutItem (item, i, j, curflags ) && tryPutItem(item, i, j, curflags))
                        {
                            goto NextItem;
                        }
                    }
                }
                return false;
            NextItem: ;
            }
            return true;
        }


        public bool tryPutItem(EquipItem item, int x, int y, bool[,] flags)
        {
            if (item.Width + x > xnum || item.Height + y > ynum || x < 0 || y < 0)
                return false;
            if (flags[x, y]) return false;

            for (int i = 0; i < item.Width; i++)
            {
                for (int j = 0; j < item.Height; j++)
                {
                    if (!flags[i + x, j + y])
                        flags[i + x, j + y] = true;
                    else
                        return false;
                }
            }
            return true;
        }
        public bool canPutItem(EquipItem item, int x, int y, bool[,] flags)
        {
            if (item.Width + x > xnum || item.Height + y > ynum || x < 0 || y < 0)
                return false;
            if (flags[x, y]) return false;

            for (int i = 0; i < item.Width; i++)
            {
                for (int j = 0; j < item.Height; j++)
                {
                    if (flags[i + x, j + y])
                        return false;
                }
            }
            return true;
        }

        public bool putItem(EquipItem item, bool add)
        {
            DrawingUnit unit = null;
            if (add)
            {
                unit = new DrawingUnit(new EquipItem(), 0, 0);
                unit.Item.assign(item);
            }
            else
            {
                unit = new DrawingUnit(item, 0, 0);
            }

            for (int j = 0; j < ynum; j++)
            {
                for (int i = 0; i < xnum; i++)
                {
                    if (!flags[i, j])
                    {
                        unit.X = i; unit.Y = j;
                        if (canPutItem(unit))
                        {
                            return putItem(unit, false);
                        }
                    }
                }
            }

            return false;
        }

        public bool putItem(DrawingUnit unit, bool add)
        {
            try
            {

                int x = unit.X, y = unit.Y;

                if (add)
                {
                    units[x, y] = new DrawingUnit(new EquipItem(), x, y);
                    units[x, y].Item.assign(unit.Item);
                }
                else
                {
                    units[x, y] = unit;
                }


                for (int i = 0; i < unit.Item.Width; i++)
                {
                    for (int j = 0; j < unit.Item.Height; j++)
                    {
                        flags[i + x, j + y] = true;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: On item:" + unit.Item.Name + ", X:" + unit.X + ", Y: " + unit.Y + " " + ex.Message);
                return false;
            }
        }

        public bool removeItem(DrawingUnit unit)
        {
            try
            {
                int x = unit.X, y = unit.Y;
                units[x, y] = null;                //remove


                for (int i = 0; i < unit.Item.Width; i++)
                {
                    for (int j = 0; j < unit.Item.Height; j++)
                    {
                        flags[i + x, j + y] = false;
                    }
                }
            }
            catch(Exception)
            {
            }

            return true;
        }

        public bool moveItem(DrawingUnit unit, int x, int y)
        {
            if (null == unit || unit.Item == null)
            {
                return false;
            }


            int oldX = unit.X, oldY = unit.Y;
            removeItem(unit);
            unit.X = x;  unit.Y = y;
            if (canPutItem(unit) && putItem(unit, false))
            {
                return true;
            }
            else
            {
                unit.X = oldX; unit.Y = oldY;
                putItem(unit, false); 
                return false;
            }
        }
        

        public bool canPutItem(DrawingUnit unit)
        {
            EquipItem item = unit.Item;
            int x = unit.X, y = unit.Y;

            if (item.Width + x > xnum || item.Height + y > ynum || x < 0 || y < 0)
                return false;
            if (flags[x, y]) return false;

            for (int i = 0; i < item.Width; i++) 
            {
                for (int j = 0; j < item.Height; j++)
                {
                    if (flags[i + x, j + y])
                        return false;
                }
            }
            return true;
        }
        public bool canPutItem(EquipItem item, int x, int y)
        {

            if (item.Width + x > xnum || item.Height + y > ynum || x < 0 || y < 0)
                return false;
            if (flags[x, y]) return false;

            for (int i = 0; i < item.Width; i++) 
            {
                for (int j = 0; j < item.Height; j++)
                {
                    if (flags[i + x, j + y])
                        return false;
                }
            }
            return true;
        }


        protected DrawingUnit findUnit(int x, int y)
        {
            DrawingUnit unit = null;
            if (flags[x, y])
                for (int i = 0; i < xnum; i++)
                {
                    for (int j = 0; j < ynum; j++)
                    {
                        if ((unit = units[i, j]) != null && unit.contains(x, y))
                        {
                            return unit;
                        }
                    }
                }
            return null;
        }

        private void EquipPanel_Paint(object sender, PaintEventArgs e)
        {
            if (units == null)
            {
                return;
            }
            //
            Graphics g = e.Graphics;

            DrawingUnit unit = null;
            EquipItem item = null;
            int x = 0, y = 0;

            for (int i = 0; i < xnum; i++)
            {
                for (int j = 0; j < ynum; j++)
                {
                    if ((unit = units[i, j]) != null && unit.Item != null)
                    {
                        drawUnit(g, units[i, j]);
                    }
                }
            }

            if (null != selectedUnit && null != selectedUnit.Item)
            {
                Brush brush = new SolidBrush(Color.FromArgb(60, 128, 128, 128));
                g.FillRectangle(brush, selectedUnit.X * pixels, selectedUnit.Y * pixels, selectedUnit.Item.Width * pixels, selectedUnit.Item.Height * pixels);
            }

            if (null != activeUnit && null != activeUnit.Item)
            {
                item = activeUnit.Item;
                x = activeUnit.X; y = activeUnit.Y;
                g.DrawImage(item.Img, x * pixels, y * pixels, item.Width * pixels, item.Height * pixels);
                if (canPutItem(activeUnit)) 
                {
                    g.DrawRectangle(Pens.Blue, x * pixels, y * pixels, item.Width * pixels, item.Height * pixels);
                }
                else
                {
                    g.DrawRectangle(Pens.Red, x * pixels, y * pixels, item.Width * pixels, item.Height * pixels);
                }
            }

            if (coveredUnit != null && coveredUnit.Item != null)
            {
                item = coveredUnit.Item;
                x = coveredUnit.X; y = coveredUnit.Y;
                g.DrawRectangle(Pens.Blue, x * pixels, y * pixels, item.Width * pixels, item.Height * pixels);
            }

            if (activeUnit == null && coveredUnit == null && selectedUnit == null && curUnit != null && curUnit.Item != null)
            {
                item = curUnit.Item;
                x = curUnit.X; y = curUnit.Y;
                g.DrawImage(item.Img, x * pixels, y * pixels, item.Width * pixels, item.Height * pixels);
                if (canPutItem(curUnit))
                {
                    g.DrawRectangle(Pens.Blue, x * pixels, y * pixels, item.Width * pixels, item.Height * pixels);
                }
                else
                {
                    g.DrawRectangle(Pens.Red, x * pixels, y * pixels, item.Width * pixels, item.Height * pixels);
                }
            }
        }


        private void drawUnit(Graphics g, DrawingUnit unit)
        {
            int x = unit.X, y = unit.Y;
            EquipItem item = unit.Item;
            g.DrawImage(item.Img, x * pixels, y * pixels, item.Width * pixels, item.Height * pixels);

            if (item.Level >= 1)
            {
                g.DrawString("+" + Convert.ToString(item.Level), new Font("Arial", 8), Brushes.White, x * pixels, y * pixels);
            } else if (item.IsNoDurability && item.Durability > 1)
            {
                g.DrawString (Convert.ToString(item.Durability), new Font("Arial", 6), Brushes.White, x * pixels, y * pixels);
            }
        }

        private bool addEditItem(int x, int y)
        {
            if (curUnit == null || curUnit.Item == null || curUnit.Item.Img == null)
                return false;


            curUnit.X = x;          
            curUnit.Y = y;
            editor.GenSerial();
            editor.updateData(curUnit.Item);
            if (canPutItem(curUnit) && putItem(curUnit, true)) 
            {
                return true;
            }
            else
            {
                MessageBox.Show("There is not enough space to put this item·[" + curUnit.Item.Name + "]");
            }
            return false;
        }

        private void setEquipProperty(DrawingUnit unit)
        {
            if (unit != null) //
            {
                EquipProperty prop = new EquipProperty(unit.Item);
                prop.ShowDialog();
                prop.Dispose();
            }
        }

        private void EquipPanel_MouseClick(object sender, MouseEventArgs e)
        {
            DrawingUnit unit = null;
            int x = e.X / pixels, y = e.Y / pixels;
            if (e.Button == MouseButtons.Right)
            {
                if (activeUnit != null)
                {
                    activeUnit.X = lastedX; activeUnit.Y = lastedY;
                    if (canPutItem(activeUnit) && putItem(activeUnit, false))         
                    {
                        selectedUnit = activeUnit;
                        activeUnit = null;
                    }
                }
                else if ((unit = findUnit(x, y)) != null)
                {
                    selectedUnit = unit;
                    popMenu.Show(this, e.X, e.Y);
                }else
                {
                    selectedUnit = null;
                }
            }
            else
            {
                if (activeUnit == null)
                {
                    if (!flags[x, y])
                    {
                        if (selectedUnit == null)
                        {
                            editor.currentName.Text = "None";
                            addEditItem(x, y);
                        }
                        else
                        {
                            selectedUnit = null;
                            editor.currentName.Text = "None";
                        }
                    }
                    else if ((unit = findUnit(x, y)) != null && unit == selectedUnit)
                    {
                        removeItem(selectedUnit);
                        activeUnit = selectedUnit;
                        lastedX = selectedUnit.X; lastedY = selectedUnit.Y ;
                        selectedUnit = null;
                    }
                    else
                    {
                        selectedUnit = unit;
                        editor.currentName.Text = selectedUnit.Item.Name;
                    }
                }
                else
                {
                    activeUnit .X = x; activeUnit .Y = y;
                    if (canPutItem(activeUnit) && putItem (activeUnit, false))
                    {
                        selectedUnit = activeUnit;
                        activeUnit = null;
                    }
                }
            }

            this.Invalidate();
        }


        private void EquipPanel_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X / pixels, y = e.Y / pixels;
            coveredUnit = null;

            if (activeUnit != null)
            {
                activeUnit.X = x; activeUnit.Y = y;
            }
            else if (flags[x, y])
            {
                this.Cursor = Cursors.Hand;
                coveredUnit = findUnit(x, y);
                editor.currentName.Text = coveredUnit.Item.Name;
                if (selectedUnit == coveredUnit)
                {
                    coveredUnit = null;
                }
            }
            else
            {
                this.Cursor = Cursors.Cross;
                curUnit.X = x; curUnit.Y = y;
                editor.currentName.Text = "None";
            }

            this.Invalidate();
        }

        private void EquipPanel_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                curUnit.Item = editor.EditItem;
            }
            catch (Exception) { }
        }

        private void EquipPanel_MouseLeave(object sender, EventArgs e)
        {
            curUnit.Item = null;
            coveredUnit = null;

            if (activeUnit != null)
            {
                activeUnit.X = lastedX; activeUnit.Y = lastedY;
                if (canPutItem(activeUnit) && putItem(activeUnit, false))
                {
                    selectedUnit = activeUnit;
                    activeUnit = null;
                }
            }
            this.Invalidate();
        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            popMenu.Close ();
        }

        public IList getItems()
        {
            IList items = new ArrayList();

            for (int j = 0; j < ynum; j++)
            {
                for (int i = 0; i < xnum; i++)
                {
                    if (units[i, j] != null && units[i, j].Item != null)
                    {
                        items.Add(units[i, j].Item);
                    }
                }
            }
            return items;
        }

        public string getEquipCodes()
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < ynum; j++)
            {
                for (int i = 0; i < xnum; i++)
                {
                    if (units[i, j] == null || units[i, j].Item == null)
                    {
                        sb.Append("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
                    }
                    else
                    {
                        sb.Append(units[i, j].Item.ToString());
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        ///
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EquipPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (selectedUnit != null)
            {
                switch ((int)e.KeyCode)
                {
                    case 46:
                        removeItem(selectedUnit); selectedUnit = null; Invalidate(); break;
                }
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeItem(selectedUnit);
            selectedUnit = null;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setEquipProperty(selectedUnit);
        }
    }

    public class DrawingUnit
    {
        public const int STATUS_DOWN = 0; 
        public const int STATUS_COVER = 1;
        public const int STATUS_HOVER = 2;

        EquipItem item = null;
        int x, y;

        int status = 0;
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        public EquipItem Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
            }
        }
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public DrawingUnit()
        {
        }

        public DrawingUnit(EquipItem item)
        {
            this.item = item;
        }
        public DrawingUnit(EquipItem item, int x, int y)
        {
            this.item = item;
            this.x = x;
            this.y = y;
        }
        public void assign(DrawingUnit unit)
        {
            x = unit.X;
            y = unit.Y;
            item = unit.Item;
        }

        public bool contains(int xx, int yy)
        {
            return (x <= xx && y <= yy && x + item.Width > xx && y + item.Height > yy);
        }
    }

}
