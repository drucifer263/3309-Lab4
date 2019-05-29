using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryMaintenance
{
    public partial class frmInvMaint : Form
	{
		public frmInvMaint()
		{
			InitializeComponent();
		}

        /*
        Drew Watson
        Jupin
        Component based
        Fall 17
        lab4
        13-1

            Edited code given to me. Mostly just modified the InvItem List class,
            Made a delegate, made an event, made an indexer, and overloaded the operators +  and -
        */

		private InvItemList invItems = new InvItemList();

        
		private void frmInvMaint_Load(object sender, EventArgs e)
		{
            //Wiring the delegate to the event
            invItems.Changed += new InvItemList.ChangeHandler(HandleChange);
            invItems.Fill();
			FillItemListBox();
		}

		private void FillItemListBox()
		{
            InvItem item;
			lstItems.Items.Clear();
            for (int i = 0; i < invItems.Count; i++)
            {
                item = invItems[i];
                lstItems.Items.Add(item.GetDisplayText());
            }
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			frmNewItem newItemForm = new frmNewItem();
			InvItem invItem = newItemForm.GetNewItem();
			if (invItem != null)
			{
				invItems += invItem;
				
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			int i = lstItems.SelectedIndex;
			if (i != -1)
			{
				InvItem invItem = invItems[i];
				string message = "Are you sure you want to delete "
					+ invItem.Description + "?";
				DialogResult button =
					MessageBox.Show(message, "Confirm Delete",
					MessageBoxButtons.YesNo);
				if (button == DialogResult.Yes)
				{
					invItems -= invItem;
					
				}
			}
		}

        private void HandleChange(InvItemList invItems)
        {
            invItems.Save();
            FillItemListBox();
        }

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}