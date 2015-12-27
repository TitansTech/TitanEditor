using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TitanEditor
{
    public partial class CharPanel : UserControl
    {
        public const int EquipNum = 12;

        Rectangle[] positions = new Rectangle[EquipNum] { new Rectangle(2, 56, 47, 72), new Rectangle(150, 56, 47, 72),
            new Rectangle(78, 3, 46, 46), new Rectangle(78, 56, 46, 72), new Rectangle(78, 136, 46, 45),
            new Rectangle(2, 136, 46, 46), new Rectangle(152, 136, 48, 46),
            new Rectangle(128, 3, 71, 46),
            new Rectangle(2, 3, 46, 46),
            new Rectangle(52, 58, 20, 20), new Rectangle(52, 136, 20, 20), new Rectangle(128, 136, 20, 20)};

        DrawingUnit[] units = new DrawingUnit[EquipNum];

        DrawingUnit curUnit = new DrawingUnit();
        DrawingUnit selectedUnit = null; 
        DrawingUnit coveredUnit = null;


        int prof = -1;
        public int Prof
        {
            get
            {
                return prof;
            }
            set
            {
                prof = value;
            }
        }

        EquipEditor editor = null;
        public EquipEditor Editor
        {
            set
            {
                editor = value;
            }
        }

        public CharPanel()
        {
            InitializeComponent();
        }

        public CharPanel(EquipEditor editor)
        {
            InitializeComponent();
            this.editor = editor;
        }

        public void clearData()
        {
            selectedUnit = null;
            coveredUnit = null;

            for (int i = 0; i < EquipNum; i++)
            {
                units[i] = null;
            }
        }

        public bool loadItemsByCodes(byte[] codes)
        {
            return loadItemsByCodes(codes, 0, codes.Length);
        }

        public bool loadItemsByCodes(byte[] codes, int offset, int len)
        {
            //
            if (offset < 0 || len < EquipItem.ITEM_SIZE * EquipNum || codes == null)
            {
                this.Invalidate();
                return false;
            }

            EquipItem item = null;
            for (int i = 0; i < EquipNum; i++)
            {
                if ((item = EquipItem.createItem(codes, offset + i * EquipItem.ITEM_SIZE, EquipItem.ITEM_SIZE)) != null)
                {
                    units[i] = new DrawingUnit(item, i, 0);
                }
            }
            this.Invalidate();
            return true;
        }


        public bool putItem(DrawingUnit unit, bool add)
        {
            int x = unit.X, y = unit.Y;

            if (add)
            {
                units[x] = new DrawingUnit(new EquipItem(), x, y);
                units[x].Item.assign(unit.Item); 
            }
            else
            {
                units[x] = unit;
            }

            return true;
        }

        public bool removeItem(DrawingUnit unit)
        {
            int x = unit.X;
            units[x] = null;                //remove

            return true;
        }

        public bool canPutItem(DrawingUnit unit)
        {
            EquipItem item = unit.Item;
            int x = unit.X, y = unit.Y;

            if (x < 0 && x >= EquipNum && units[x] != null)
                return false;
            


            return true;
        }

        public int findRectangle(int x, int y)
        {
            for (int i = 0; i < EquipNum; i++)
            {
                if (positions[i].Contains(x, y))
                {
                    return i;
                }
            }
            return -1;
        }

        private bool addEditItem(int index)
        {
            if (curUnit == null || curUnit.Item == null || curUnit.Item.Img == null)
                return false;

            curUnit.X = index;
            curUnit.Y = 0;
            editor.updateData(curUnit.Item);
            if (canPutItem(curUnit) && putItem(curUnit, true))
            {
                return true;
            }
            else
            {
                MessageBox.Show("[" + curUnit.Item.Name + "]");
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

        private void CharPanel_MouseClick(object sender, MouseEventArgs e)
        {
            int index = findRectangle(e.X, e.Y);

            if (e.Button == MouseButtons.Right)
            {
                if (index >= 0)
                {
                    if (units[index] != null)
                    {
                        selectedUnit = units[index];
                        popMenu.Show(this, e.X, e.Y);
                    }
                    else 
                    {
                        selectedUnit = null;
                    }
                }
                else
                {
                    selectedUnit = null;
                }
            }
            else
            {
                if (index >= 0)
                {
                    if (units[index] != null)
                    {
                        selectedUnit = units[index];
                        editor.currentName.Text = selectedUnit.Item.Name;
                    }
                    else if (selectedUnit != null)
                    {
                        selectedUnit = null;
                        editor.currentName.Text = "None";
                    }
                    else
                    {
                        addEditItem(index);
                        editor.currentName.Text = "None";
                    }
                }
                else
                {
                    selectedUnit = null;
                }
            }
        }


        private void CharPanel_MouseEnter(object sender, EventArgs e)
        {
            curUnit.Item = editor.EditItem;
        }

        private void CharPanel_MouseLeave(object sender, EventArgs e)
        {
            curUnit.Item = null;
            coveredUnit = null;

            this.Invalidate();
        }

        private void CharPanel_MouseMove(object sender, MouseEventArgs e)
        {
            coveredUnit = null;

            int index = findRectangle (e.X, e.Y);
            if (index >= 0) 
            {
                if (units[index] != null)
                {
                    this.Cursor = Cursors.Hand;
                    coveredUnit = units[index];
                    editor.currentName.Text = coveredUnit.Item.Name;
                }
                else
                {
                    editor.currentName.Text = "None";
                    this.Cursor = Cursors.Cross;
                    curUnit.X = index;
                    curUnit.Y = 1;
                }
            }
            else
            {
                curUnit.Y = -1;
                editor.currentName.Text = "None";
            }

            this.Invalidate();
        }

        private void CharPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics ;

            for (int i = 0; i < EquipNum; i++)
            {
                if (units[i] != null)
                {
                    drawUnit (g, units[i]);
                }
            }


            EquipItem item = null;
            if (null != selectedUnit && null != selectedUnit.Item)
            {
                Brush brush = new SolidBrush(Color.FromArgb(60, 128, 128, 128));
                g.FillRectangle(brush, positions[selectedUnit.X]);
            }

            if (coveredUnit != null && coveredUnit.Item != null)
            {
                item = coveredUnit.Item;
                g.DrawRectangle(Pens.Blue, positions[coveredUnit.X]);
            }

            if (coveredUnit == null && selectedUnit == null && curUnit != null && curUnit.Item != null)
            {
                item = curUnit.Item;
                drawUnit(g, curUnit);
                if (canPutItem(curUnit))
                {
                    g.DrawRectangle(Pens.Blue, positions [curUnit.X]);
                }
                else
                {
                    g.DrawRectangle(Pens.Red, positions [curUnit.X]);
                }
            }
        }

        private void drawUnit(Graphics g, DrawingUnit unit)
        {

            int x = unit.X, y = unit.Y;
            EquipItem item = unit.Item;

            int xOffset = Math.Max((positions[x].Width - item.Width * EquipPanel.pixels) >> 1, 0);
            int yOffset = Math.Max((positions[x].Height - item.Height * EquipPanel.pixels) >> 1, 0);
            int width = Math.Min(item.Width * EquipPanel.pixels, positions[x].Width);
            int height = Math.Min(item.Height * EquipPanel.pixels, positions[x].Height);
            g.DrawImage(item.Img, positions[x].X + xOffset, positions[x].Y + yOffset, width, height);

        }

        public string getEquipCodes()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < EquipNum; i++)
            {
                if (units[i] == null || units[i].Item == null)
                {
                    sb.Append("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
                }
                else
                {
                    sb.Append(units[i].Item.ToString());
                }
            }
            return sb.ToString();
        }

        private void CharPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (selectedUnit != null)
            {
                switch ((int)e.KeyCode)
                {
                    case 46: // Delete
                        removeItem(selectedUnit); selectedUnit = null; break;
                }
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeItem(selectedUnit);
            selectedUnit = null;
        }

        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setEquipProperty(selectedUnit);
        }
    }
}
