using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    public partial class frmViewTables : Form
    {
        //TODO: Make selection stay with the correct cells when inverting a field
        //TODO: Make selection remain the same on opposite DGV when selecting different records if linked records is enabled
        //TODO: Advanced search in frmSearch
        //TODO: Save settings such as linked records and resolution between launches
        private BindingSource bindingSourceEntity0 = new BindingSource();
        private BindingSource bindingSourceEntity1 = new BindingSource();

        private readonly ToolTip toolTip = new ToolTip();
        private int[][,] selectedCells = new int[2][,]; //[Entity][PerCell,RowIndex(0)ColumnIndex(1)]
        private int[][] selectedRows = new int[2][]; //[Entity][RowIndex] Entire row using DGV left select box
        private List<int> selectedIdsEntity0 = new List<int>();
        private List<int> selectedIdsEntity1 = new List<int>();
        private float[] tlpEntitiesColumnWidth;
        private string entity0;
        private string entity1;
        private string linkingEntity;
        private string entity0LinkingField;
        private string entity1LinkingField;
        private string selectedEntity;
        private string linkingFieldName;
        private int selectedDataGridView = 0;
        private bool entity0Shown;
        private bool entity1Shown;
        private bool entity1UserShow = true;
        public bool loaded = false;

        private readonly Bitmap leftArrow = Properties.Resources.leftArrow2;
        private readonly Bitmap leftArrowHover = Properties.Resources.leftArrow2Hover;
        private readonly Bitmap leftArrowClick = Properties.Resources.leftArrow2Click;
        private readonly Bitmap eye = Properties.Resources.Eye;
        private readonly Bitmap eyeHover = Properties.Resources.EyeHover;
        private readonly Bitmap eyeClick = Properties.Resources.EyeClick;
        private readonly Bitmap eyeCross = Properties.Resources.EyeCross;
        private readonly Bitmap eyeCrossHover = Properties.Resources.EyeCrossHover;
        private readonly Bitmap eyeCrossClick = Properties.Resources.EyeCrossClick;

        public frmViewTables(string entity0, string entity1)
        {
            try
            {
                InitializeComponent();
                this.entity0 = entity0;
                this.entity1 = entity1;
                xlblEntityName0.Text = entity0;
                xlblEntityName1.Text = entity1;
                SetToolTip();
                SetLinkingEntity();
                SetLinkingFieldName();
                AddMenuAndItems();
                GetTableLayoutPanelColumnWidth();
                SetDataSource();
                ShowHideEntity(entity0 == null ? false : true, entity1 == null ? false : true);
                RefreshDataGrid(0, true, entity1Shown);
                xcbxLinkedRecordsEntity0.Checked = false;
                xcbxLinkedRecordsEntity1.Checked = true;
                xpbxBack.Image = leftArrow;
                xpbxBack.SizeMode = PictureBoxSizeMode.Zoom;
                xpbxHideEntity1.Image = eye;
                xpbxHideEntity1.SizeMode = PictureBoxSizeMode.Zoom;
                loaded = true;
            }
            catch (ObjectDisposedException ex) when (ex.ObjectName == this.Name)
            {
                return;
            }
        }

        //  Sets up the tooltips
        private void SetToolTip()
        {
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(xbtnLinkLeft, "Link two selected records from each table");
            toolTip.SetToolTip(xcbxLinkedRecordsEntity0, "Shows only records which are linked to selected ones on the opposite table");
            toolTip.SetToolTip(xcbxLinkedRecordsEntity1, toolTip.GetToolTip(xcbxLinkedRecordsEntity0));
            toolTip.SetToolTip(xcbxAllLinkedEntity0, "Shows only records which are linked to any record on the opposite table");
            toolTip.SetToolTip(xcbxAllLinkedEntity1, toolTip.GetToolTip(xcbxAllLinkedEntity0));
            toolTip.SetToolTip(xpbxHideEntity1, "Shows/hides the secondary table");
        }

        // Adds xmsMenu ToolStripMenuItem items.
        private void AddMenuAndItems()
        {
            //(xmsMenu.Items[0] as ToolStripMenuItem).DropDownItems.Add("Search");
            (xmsMenu.Items[0] as ToolStripMenuItem).DropDownItems.Add("Refresh");
            (xmsMenu.Items[0] as ToolStripMenuItem).DropDownItems.Add("Report");
            if (linkingEntity == "ClassDog")
            {
                (xmsMenu.Items[0] as ToolStripMenuItem).DropDownItems.Add("Certificate");
            }
        }

        // Calls the correct method when a ToolStripMenuItem is clicked.
        private void xmsMenu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Search")
            {
                //SearchSpecies();
            }
            else if (e.ClickedItem.Text == "Refresh")
            {
                RefreshDataGrid(1, true, entity1Shown);
            }
            else if (e.ClickedItem.Text == "Report")
            {
                OpenReport(entity0);
            }
            else if (e.ClickedItem.Text == "Certificate")
            {
                OpenCertificate();
            }
        }

        //Sets the DataGridView to the specified table(s)
        private void SetDataSource()
        {
            xdgvEntity0.DataSource = bindingSourceEntity0;
            xdgvEntity_SelectionChanged(xdgvEntity0, null);

            xdgvEntity1.DataSource = bindingSourceEntity1;
            xdgvEntity_SelectionChanged(xdgvEntity1, null);
        }

        private void SetLinkingEntity()
        {
            xbtnLinkLeft.Show();
            if ((entity0 == "Dog" && entity1 == "Class") || (entity0 == "Class" && entity1 == "Dog"))
            {
                linkingEntity = "ClassDog";
                entity0LinkingField = "ClassId"; //DogId
                entity1LinkingField = "DogId"; //ClassId
            }
            else
            {
                linkingEntity = null;
                xbtnLinkLeft.Hide();
            }
        }

        private void SetLinkingFieldName()
        {
            if (entity1 != null)
            {
                string[] entity0FieldNames = null;
                string[] entity1FieldNames = null;
                try
                {
                    entity0FieldNames = DAL.GetSchemaInfo(entity0, "COLUMNS", "COLUMN_NAME");
                    entity1FieldNames = linkingEntity == null ? DAL.GetSchemaInfo(entity1, "COLUMNS", "COLUMN_NAME") : DAL.GetSchemaInfo(linkingEntity, "COLUMNS", "COLUMN_NAME");
                }
                catch (SqlException ex)
                {
                    DatabaseOpenException(ex);
                    return;
                }
                bool found = false;
                for (int i = 0; i < entity0FieldNames.Count(); i++)
                {
                    for (int j = 0; j < entity1FieldNames.Count(); j++)
                    {
                        if (entity0FieldNames[i] == entity1FieldNames[j])
                        {
                            linkingFieldName = entity0FieldNames[i];
                            found = true;
                            break;
                        }
                    }
                    if (found == true)
                    {
                        break;
                    }
                }
            }
        }

        private void DatabaseOpenException(SqlException ex)
        {
            if (ex.Number == 15350 || ex == null)
            {
                MessageBox.Show("Failed to open the database. Please ensure that database.mdf is in the program directory and that you have read/write privileges to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ObjectDisposedException(this.Name);
            }
        }

        // Adds a new record.
        private void AddRecord()
        {
            string[] fieldNames = null;
            try
            {
                fieldNames = DAL.GetSchemaInfo(selectedEntity, "COLUMNS", "COLUMN_NAME");
            }
            catch (SqlException ex)
            {
                DatabaseOpenException(ex);
                return;
            }
            string autoFillEntity = null;
            if (selectedEntity == "Class")
            {
                autoFillEntity = "Programme";
            }
            using (frmAddEditRecord addRecord = new frmAddEditRecord(selectedEntity, autoFillEntity, fieldNames, null))
            {
                addRecord.ShowDialog();
            }
            RefreshDataGrid(1, true, entity1Shown);
        }

        // Edits the selected record.
        private void EditRecord()
        {
            List<int> recordIds = GetIdOfSelectedCells();
            string autoFillEntity = null;
            if (selectedEntity == "Class")
            {
                autoFillEntity = "Programme";
            }
            if (recordIds.Count == 1)
            {
                string[] fieldNames = null;
                DataTable dataTable = null;
                try
                {
                    fieldNames = DAL.GetSchemaInfo(selectedEntity, "COLUMNS", "COLUMN_NAME");
                    dataTable = DAL.SearchRecords(selectedEntity, null, null, Convert.ToString(recordIds.ElementAtOrDefault(0)), selectedEntity + "Id", null, false, null, true, false, false, false);
                }
                catch (SqlException ex)
                {
                    DatabaseOpenException(ex);
                    return;
                }
                string[,] records = DAL.DataTableToStringArray(dataTable);
                string[] record = new string[records.GetLength(1)];
                for (int o = 0; o < records.GetLength(1); o++)
                {
                    record[o] = records[0, o];
                }
                using (frmAddEditRecord editRecord = new frmAddEditRecord(selectedEntity, autoFillEntity, fieldNames, record))
                {
                    editRecord.ShowDialog();
                }
            }
            RefreshDataGrid(1, true, entity1Shown);
        }

        // Deletes selected records.
        private void DeleteRecord(bool askPrompt)
        {
            DialogResult dialogResult = new DialogResult();
            if (askPrompt == true)
            {
                dialogResult = MessageBox.Show("Are you sure that you want to delete the selected record(s)? References to this record must be removed before deletion.", "Information", MessageBoxButtons.YesNo);
            }
            if (dialogResult == DialogResult.Yes || askPrompt == false)
            {
                List<int> recordIds = GetIdOfSelectedCells();
                if (recordIds != null)
                {
                    string[] fields = { selectedEntity + "Id" };
                    try
                    {
                        for (int i = 0; i < recordIds.Count; i++)
                        {
                            List<int> ids = new List<int>();
                            ids.Add(recordIds.ElementAtOrDefault(i));
                            DAL.Delete(selectedEntity, fields, ids, false);
                        }
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 547)
                        {
                            MessageBox.Show("This record has been referenced elsewhere in the database. Please remove the reference(s) first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            DialogResult dialogResultError = MessageBox.Show("An error occured when deleting the selected item(s). Would you like to try again?", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            if (dialogResultError == DialogResult.Retry)
                            {
                                DeleteRecord(false);
                                return;
                            }
                        }
                    }
                    RefreshDataGrid(0, true, entity1Shown);
                }
            }
        }

        // Gets the ID of all selected cells and rows. It ensures that each ID is unique to prevent errors.
        private List<int> GetIdOfSelectedCells()
        {
            List<int> recordIds = new List<int>();
            DataGridView dataGridView = (DataGridView)this.Controls.Find($"xdgvEntity{selectedDataGridView}", true)[0];
            int selectedCells = dataGridView.SelectedCells.Count;
            int selectedRows = dataGridView.SelectedRows.Count;
            if (selectedCells > 0 || selectedRows > 0)
            {
                for (int i = 0; i < selectedCells; i++)
                {
                    int id;
                    int row = dataGridView.SelectedCells[i].RowIndex;
                    string idString = Convert.ToString(dataGridView[0, row].Value);
                    id = CheckId(idString, recordIds);
                    if (id != -1)
                    {
                        recordIds.Add(id);
                    }
                }
            }
            if (selectedDataGridView == 0)
            {
                selectedIdsEntity0 = recordIds;
            }
            else if (selectedDataGridView == 1)
            {
                selectedIdsEntity1 = recordIds;
            }
            return recordIds;
        }

        private List<int> GetSelectedLinkingIds(int entity)
        {
            GetIdOfSelectedCells();
            List<int> selectedLinkingIds = new List<int>();
            DataGridView dataGridView = (DataGridView)this.Controls.Find($"xdgvEntity{entity}", true)[0];
            int linkingColumn = 0;
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                if (dataGridView.Columns[i].Name == linkingFieldName)
                {
                    linkingColumn = i;
                }
            }
            List<int> selectedIds = entity == 0 ? selectedIdsEntity0 : selectedIdsEntity1;
            for (int i = 0; i < selectedIds.Count; i++)
            {
                int rowIndex = 0;
                for (int j = 0; j < dataGridView.RowCount; j++)
                {
                    if (Convert.ToString(dataGridView[0, j].Value) == Convert.ToString(selectedIds[i])) //TODO: Optimise - only one Convert.To...()?
                    {
                        rowIndex = j;
                        break;
                    }
                }
                string linkingAttribute = Convert.ToString(dataGridView[linkingColumn, rowIndex].Value);
                int linkingId = 0;
                if (int.TryParse(linkingAttribute, out linkingId) == true)
                {
                    selectedLinkingIds.Add(linkingId);
                }
            }
            return selectedLinkingIds;
        }

        private int CheckId(string idString, List<int> recordIds)
        {
            int id;
            if (int.TryParse(idString, out id) == false)
            {
                DialogResult dialogResult = MessageBox.Show($"Id [{idString}] is not in the correct format of int.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                {
                    if (dialogResult == DialogResult.Retry)
                    {
                        GetIdOfSelectedCells();
                    }
                    return -1;
                }
            }
            bool found = false;
            foreach (int o in recordIds)
            {
                if (id == o)
                {
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                return id;
            }
            return -1;
        }

        // Stores all currently selected cells and rows
        private void GetSelectedCellsRows(bool loadEntity0, bool loadEntity1)
        {
            int start = loadEntity0 == true ? 0 : 1;
            int end = loadEntity1 == true ? 2 : 1;
            for (int i = start; i < end; i++)
            {
                DataGridView dataGridView = (DataGridView)this.Controls.Find($"xdgvEntity{i}", true)[0];
                int selectedCellCount = dataGridView.SelectedCells.Count;
                int selectedRowCount = dataGridView.SelectedRows.Count;
                if (selectedCellCount > 0 || selectedRowCount > 0)
                {
                    selectedCells[i] = new int[selectedCellCount, 2];
                    selectedRows[i] = new int[selectedRowCount];
                    for (int o = 0; o < selectedCellCount; o++)
                    {
                        int rowIndex = dataGridView.SelectedCells[o].RowIndex;
                        selectedCells[i][o, 0] = Convert.ToInt16(dataGridView.Rows[rowIndex].Cells[0].Value);
                        selectedCells[i][o, 1] = dataGridView.SelectedCells[o].ColumnIndex;
                    }
                    for (int o = 0; o < selectedRowCount; o++)
                    {
                        int rowIndex = dataGridView.SelectedRows[o].Index;
                        selectedRows[i][o] = Convert.ToInt16(dataGridView.Rows[rowIndex].Cells[0].Value);
                    }
                }
            }
        }

        // Selects previously seleted cells and rows after a change in the DataGridView
        private void SetSelectedCellsRows(bool loadEntity0, bool loadEntity1)
        {
            int start = loadEntity0 == true ? 0 : 1;
            int end = loadEntity1 == true ? 2 : 1;
            for (int i = start; i < end; i++)
            {
                DataGridView dataGridView = (DataGridView)this.Controls.Find($"xdgvEntity{i}", true)[0];
                if (!(selectedCells[i] == null) && selectedCells[i].GetLength(0) > 0)
                {
                    dataGridView.ClearSelection();
                    for (int o = 0; o < selectedCells[i].GetLength(0); o++)
                    {
                        for (int p = 0; p < dataGridView.Rows.Count; p++)
                        {
                            if (selectedCells[i][o, 0] == Convert.ToInt16(dataGridView.Rows[p].Cells[0].Value))
                            {
                                dataGridView.Rows[p].Cells[selectedCells[i][o, 1]].Selected = true;
                            }
                        }
                    }
                }
                if (!(selectedRows[i] == null) && selectedRows[i].GetLength(0) > 0)
                {
                    for (int o = 0; o < selectedRows[i].GetLength(0); o++)
                    {
                        for (int p = 0; p < dataGridView.Rows.Count; p++)
                        {
                            if (selectedRows[i][o] == Convert.ToInt16(dataGridView.Rows[p].Cells[0].Value))
                            {
                                dataGridView.Rows[p].Selected = true;
                            }
                        }
                    }
                }
            }
        }

        // Begins the process of loading/refreshing the DataGridView
        private void RefreshDataGrid(int mode, bool loadEntity0, bool loadEntity1)
        {
            loaded = false;
            // Use mode '0' if loading form or deleting records to prevent selecting non-existant cells, otherwise use mode '1'
            if (mode == 0)
            {
                DatabaseLoad(loadEntity0, loadEntity1);
            }
            else if (mode == 1)
            {
                GetSelectedCellsRows(loadEntity0, loadEntity1);
                DatabaseLoad(loadEntity0, loadEntity1);
                SetSelectedCellsRows(loadEntity0, loadEntity1);
            }
            loaded = true;
        }

        // Loads the database data into the DataGridView. Only call from RefreshDataGrid()
        private void DatabaseLoad(bool loadEntity0, bool loadEntity1)
        {
            int start = loadEntity0 == true ? 0 : 1;
            int end = loadEntity1 == true ? 2 : 1;
            for (int i = start; i < end; i++)
            {
                int oppositeEntity = i == 0 ? 1 : 0;
                List<int> selectedLinkedIds = GetSelectedLinkingIds(oppositeEntity); //For opposite entity
                TextBox textBoxQuickSearch = (TextBox)this.Controls.Find($"xtbxQuickSearchEntity{i}", true)[0];
                CheckBox checkBoxLinkedRecords = (CheckBox)this.Controls.Find($"xcbxLinkedRecordsEntity{i}", true)[0];
                CheckBox checkBoxAllLinked = (CheckBox)this.Controls.Find($"xcbxAllLinkedEntity{i}", true)[0];
                DataGridView dataGridView = (DataGridView)this.Controls.Find($"xdgvEntity{i}", true)[0];
                dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                dataGridView.RowHeadersVisible = false;
                try
                {
                    DataTable empty = new DataTable();
                    bool allLinkedRecords = checkBoxAllLinked.Checked == true && checkBoxAllLinked.Enabled == true ? true : false;
                    bool manyToMany = linkingEntity != null ? true : false;
                    string entity0Field = manyToMany == false ? linkingFieldName : entity0LinkingField;
                    string entity1Field = manyToMany == false ? linkingFieldName : entity1LinkingField;
                    if (textBoxQuickSearch.ForeColor == Color.Black && !string.IsNullOrWhiteSpace(textBoxQuickSearch.Text)) // Search
                    {
                        if (checkBoxLinkedRecords.Checked == true) // Search and linked
                        {
                            if (i == 0)
                            {
                                DataTable dataTable = DAL.SearchRecords(entity0, entity1, linkingEntity, textBoxQuickSearch.Text, entity0Field, entity1Field, true, selectedLinkedIds, false, true, allLinkedRecords, manyToMany); //selectedIdsEntity1
                                bindingSourceEntity0.DataSource = dataTable == null ? empty : dataTable;
                            }
                            else if (i == 1)
                            {
                                DataTable dataTable = DAL.SearchRecords(entity1, entity0, linkingEntity, textBoxQuickSearch.Text, entity0Field, entity1Field, true, selectedLinkedIds, false, true, allLinkedRecords, manyToMany); //selectedIdsEntity0
                                bindingSourceEntity1.DataSource = dataTable == null ? empty : dataTable;
                            }
                        }
                        else // Search and non-linked
                        {
                            if (i == 0)
                            {
                                DataTable dataTable = DAL.SearchRecords(entity0, null, linkingEntity, textBoxQuickSearch.Text, entity0Field, entity1Field, true, null, false, false, allLinkedRecords, manyToMany); //selectedIdsEntity1
                                bindingSourceEntity0.DataSource = dataTable == null ? empty : dataTable;
                            }
                            else if (i == 1)
                            {
                                DataTable dataTable = DAL.SearchRecords(entity1, null, linkingEntity, textBoxQuickSearch.Text, entity0Field, entity1Field, true, null, false, false, allLinkedRecords, manyToMany); //selectedIdsEntity0
                                bindingSourceEntity1.DataSource = dataTable == null ? empty : dataTable;
                            }
                        }
                    }
                    else if (checkBoxLinkedRecords.Checked == true) // Non-search and linked //TODO: [Potentially] Remove else and handle links and searches simultanously
                    {
                        if (i == 0)
                        {
                            DataTable dataTable = DAL.SearchRecords(entity0, entity1, linkingEntity, null, entity0Field, entity1Field, false, selectedLinkedIds, true, true, allLinkedRecords, manyToMany); //selectedIdsEntity1
                            bindingSourceEntity0.DataSource = dataTable == null ? empty : dataTable;
                        }
                        else if (i == 1)
                        {
                            DataTable dataTable = DAL.SearchRecords(entity1, entity0, linkingEntity, null, entity0Field, entity1Field, false, selectedLinkedIds, true, true, allLinkedRecords, manyToMany); //selectedIdsEntity0
                            bindingSourceEntity1.DataSource = dataTable == null ? empty : dataTable;
                        }
                    }
                    else // Non-search and non-linked
                    {
                        if (i == 0)
                        {
                            bindingSourceEntity0.DataSource = DAL.LoadEntireEntity(entity0);
                        }
                        else if (i == 1)
                        {
                            bindingSourceEntity1.DataSource = DAL.LoadEntireEntity(entity1);
                        }
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show($"{ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxQuickSearch.Text = textBoxQuickSearch.Text.Substring(0, textBoxQuickSearch.Text.Length - 1);
                }
                catch (SqlException ex) when (ex.Number == 15350)
                {
                    DatabaseOpenException(ex);
                    return;
                }
                catch (Exception ex)
                {
                    bool showEntity0 = i == 0 ? false : entity0Shown;
                    bool showEntity1 = i == 1 ? false : entity1Shown;
                    ShowHideEntity(showEntity0, showEntity1);
                    string entity = i == 0 ? entity0 : entity1;
                    xcbxLinkedRecordsEntity0.Visible = i == 0 ? false : true;
                    xcbxLinkedRecordsEntity1.Visible = i == 1 ? false : true;
                    DialogResult dialogResult = MessageBox.Show($"An error occured while loading the {entity} table. Please try again.", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Abort)
                    {
                        frmMainMenu frmMainMenu = new frmMainMenu
                        {
                            MdiParent = this.ParentForm,
                            Dock = DockStyle.Fill
                        };
                        frmMainMenu.Show();
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.Retry)
                    {
                        RefreshDataGrid(0, loadEntity0, (loadEntity1 && entity1Shown));
                    }
                }
                finally
                {
                    if (i == 0)
                    {
                        xdgvEntity0_DataBindingComplete(null, null);
                    }
                    else if (i == 1)
                    {
                        xdgvEntity1_DataBindingComplete(null, null);
                    }
                }
                dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dataGridView.RowHeadersVisible = true;
            }
        }

        //Shows or hides the specified entity
        private void ShowHideEntity(bool showEntity0, bool showEntity1)
        {
            int startHide = showEntity0 == false ? 0 : 3;
            int endHide = showEntity1 == true && entity1UserShow == true ? 3 : 7;
            int startShow = showEntity0 == true ? 0 : 3;
            int endShow = showEntity1 == false || entity1UserShow == false ? 3 : 7;
            entity0Shown = showEntity0;
            entity1Shown = showEntity1;
            for (int i = startHide; i < endHide; i++)
            {
                xtlpEntities.ColumnStyles[i].Width = 0f;
            }
            for (int i = startShow; i < endShow; i++)
            {
                xtlpEntities.ColumnStyles[i].Width = tlpEntitiesColumnWidth[i];
            }
            for (int i = 0; i < 2; i++)
            {
                if ((i == 0 && showEntity0 == false) || (i == 1 && (showEntity1 == false || entity1UserShow == false)))
                {
                    this.Controls.Find($"xtbxQuickSearchEntity{i}", true)[0].Hide();
                    this.Controls.Find($"xdgvEntity{i}", true)[0].Hide();
                    this.Controls.Find($"xbtnAddEntity{i}", true)[0].Hide();
                    this.Controls.Find($"xbtnEditEntity{i}", true)[0].Hide();
                    this.Controls.Find($"xbtnDeleteEntity{i}", true)[0].Hide();
                    this.Controls.Find($"xlblEntityName{i}", true)[0].Hide();
                    xcbxLinkedRecordsEntity0.Hide();
                    xcbxLinkedRecordsEntity1.Hide();
                    xcbxAllLinkedEntity0.Hide();
                    xcbxAllLinkedEntity1.Hide();
                    if (linkingEntity != null)
                    {
                        xbtnLinkLeft.Hide();
                    }
                }
                else if ((i == 0 && showEntity0 == true) || (i == 1 && showEntity1 == true && entity1UserShow == true))
                {
                    this.Controls.Find($"xtbxQuickSearchEntity{i}", true)[0].Show();
                    this.Controls.Find($"xdgvEntity{i}", true)[0].Show();
                    this.Controls.Find($"xbtnAddEntity{i}", true)[0].Show();
                    this.Controls.Find($"xbtnEditEntity{i}", true)[0].Show();
                    this.Controls.Find($"xbtnDeleteEntity{i}", true)[0].Show();
                    this.Controls.Find($"xlblEntityName{i}", true)[0].Show();
                    if (entity0Shown == true && entity1Shown == true)
                    {
                        xcbxLinkedRecordsEntity0.Show();
                        xcbxLinkedRecordsEntity1.Show();
                        xcbxAllLinkedEntity0.Show();
                        xcbxAllLinkedEntity1.Show();
                        if (linkingEntity != null)
                        {
                            xbtnLinkLeft.Show();
                        }
                    }
                }
            }
        }

        //Gets the width of each column in the table layout panel
        private void GetTableLayoutPanelColumnWidth()
        {
            int columnCount = xtlpEntities.ColumnCount;
            if (columnCount > 0)
            {
                tlpEntitiesColumnWidth = new float[columnCount];
                for (int i = 0; i < columnCount; i++)
                {
                    tlpEntitiesColumnWidth[i] = xtlpEntities.ColumnStyles[i].Width;
                }
            }
        }

        //Opens the main menu
        private void OpenMainMenu()
        {
            frmMainMenu frmMainMenu = new frmMainMenu()
            {
                MdiParent = this.ParentForm,
                Dock = DockStyle.Fill,
            };
            frmMainMenu.Show();
            this.Close();
        }

        private void OpenReport(string entity)
        {
            frmReportView frmReportView = new frmReportView(entity)
            {
                MdiParent = this.ParentForm,
                Dock = DockStyle.Fill,
            };
            frmReportView.Show();
            //this.Close();
        }

        private void OpenCertificate()
        {
            int classDGV = entity0 == "Class" && entity1 == "Dog" ? 0 : 1;
            int dogDGV = entity0 == "Dog" && entity1 == "Class" ? 0 : 1;
            DataGridView dataGridView0 = (DataGridView)this.Controls.Find($"xdgvEntity{classDGV}", true)[0];
            DataGridView dataGridView1 = (DataGridView)this.Controls.Find($"xdgvEntity{dogDGV}", true)[0];
            if (selectedIdsEntity0.Count == 1 && selectedIdsEntity1.Count == 1)
            {
                int classRow = 0;
                int dogRow = 0;
                for (int i = 0; i < dataGridView0.Rows.Count; i++) // Class
                {
                    if (Convert.ToInt16(dataGridView0[0, i].Value) == selectedIdsEntity0[0])
                    {
                        dogRow = i;
                    }
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++) // Dog
                {
                    if (Convert.ToInt16(dataGridView1[0, i].Value) == selectedIdsEntity1[0])
                    {
                        classRow = i;
                    }
                }
                string className = Convert.ToString(dataGridView0[1, classRow].Value);
                string dogName = Convert.ToString(dataGridView1[1, dogRow].Value);
                frmCertificate frmCertificate = new frmCertificate(dogName, className)
                {
                    MdiParent = this.ParentForm,
                    Dock = DockStyle.Fill,
                };
                frmCertificate.Show();
                //this.Close();
            }
            else
            {
                MessageBox.Show("One record must be selected in each table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void xbtnLinkLeft_Click(object sender, EventArgs e)
        {
            Link();
        }

        private void Link()
        {
            int entity0Id = 0;
            int entity1Id = 0;
            try
            {
                selectedDataGridView = 0;
                entity0Id = GetIdOfSelectedCells()[0];
                selectedDataGridView = 1;
                entity1Id = GetIdOfSelectedCells()[0];
            }
            catch
            {
                MessageBox.Show("One record must be selected in each table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string[] linkingFieldNames = null;
            string entity0IdName = null;
            string entity1IdName = null;
            try
            {
                linkingFieldNames = DAL.GetSchemaInfo(linkingEntity, "COLUMNS", "COLUMN_NAME");
                entity0IdName = DAL.GetSchemaInfo(entity0, "COLUMNS", "COLUMN_NAME")[0];
                entity1IdName = DAL.GetSchemaInfo(entity1, "COLUMNS", "COLUMN_NAME")[0];
            }
            catch (SqlException ex)
            {
                DatabaseOpenException(ex);
                return;
            }
            string[] ids = { Convert.ToString(entity0Id), Convert.ToString(entity1Id) };
            if (entity0IdName == linkingFieldNames[1] && entity1IdName == linkingFieldNames[0])
            {
                string temp0 = ids[0];
                string temp1 = ids[1];
                ids[0] = temp1;
                ids[1] = temp0;
            }
            if (linkingEntity == "ClassDog")
            {
                DataTable dataTable = DAL.SearchRecords("Class", null, null, ids[0], "ClassId", null, false, null, true, false, false, false);
                string[] dataTableFieldNames = DAL.GetSchemaInfo("Class", "COLUMNS", "COLUMN_NAME");
                int columnIndex = 0;
                for (int i = 0; i < dataTableFieldNames.Count(); i++)
                {
                    if (dataTableFieldNames[i] == "ClassDogLimit")
                    {
                        columnIndex = i;
                    }
                }
                if (DAL.Count(linkingEntity, linkingFieldNames, ids, false) == 0) //DAL.Count(linkingEntity, linkingFieldNames, ids, false) == 0
                {
                    int o = DAL.Count(linkingEntity, null, null, true);
                    int p = Convert.ToInt32(Convert.ToString(dataTable.Rows[0][columnIndex]));
                    if (DAL.Count(linkingEntity, null, null, true) < Convert.ToInt32(Convert.ToString(dataTable.Rows[0][columnIndex]))) //DAL.Count(linkingEntity, null, null, true) <= Convert.ToInt32(dataTable.Rows[0][columnIndex])
                    {
                        try
                        {
                            if (DAL.Add(linkingEntity, linkingFieldNames, ids, false) == 1)
                            {
                                MessageBox.Show("Linked succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DialogResult dialogResult = MessageBox.Show($"An error occured during linking. Please try again.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                                if (dialogResult == DialogResult.Retry)
                                {
                                    xbtnLinkLeft_Click(null, null);
                                }
                            }
                        }
                        catch
                        {
                            DialogResult dialogResult = MessageBox.Show("An error occured during linking. Please try again.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            if (dialogResult == DialogResult.Retry)
                            {
                                xbtnLinkLeft_Click(null, null);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dog limit reached. Please remove a dog or create a new class.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("These two records are already linked. Do you want to unlink them?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        List<int> idsInt = new List<int>();
                        idsInt.Add(entity0Id);
                        idsInt.Add(entity1Id);
                        if (DAL.Delete(linkingEntity, linkingFieldNames, idsInt, true) == 1)
                        {
                            MessageBox.Show("Unlinked succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DialogResult dialogResultError = MessageBox.Show($"An error occured during unlinking. Please try again.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            if (dialogResultError == DialogResult.Retry)
                            {
                                xbtnLinkLeft_Click(null, null);
                            }
                        }
                    }
                }
                RefreshDataGrid(0, true, entity1Shown);
            }
        }

        private void xcbxLinkedRecords_CheckedChanged(object sender, EventArgs e)
        {
            if (entity0 == null || entity1 == null)
            {
                return;
            }
            CheckBox checkbox = (CheckBox)sender;
            if (sender == xcbxLinkedRecordsEntity0 || sender == xcbxAllLinkedEntity0)
            {
                selectedDataGridView = 0;
                selectedEntity = entity0;
            }
            else if (sender == xcbxLinkedRecordsEntity1 || sender == xcbxAllLinkedEntity1)
            {
                selectedDataGridView = 1;
                selectedEntity = entity1;
            }
            xcbxAllLinkedEntity0.Enabled = xcbxLinkedRecordsEntity0.Checked == true ? true : false;
            xcbxAllLinkedEntity1.Enabled = xcbxLinkedRecordsEntity1.Checked == true ? true : false;
            SetLinkingFieldName();
            GetIdOfSelectedCells();
            bool loadEntity0 = selectedDataGridView == 0 ? true : false;
            bool loadEntity1 = selectedDataGridView == 1 ? true : false;
            RefreshDataGrid(1, loadEntity0, (loadEntity1 && entity1Shown));
        }

        private void xdgvEntity_SelectionChanged(object sender, EventArgs e)
        {
            if (sender == xdgvEntity0)
            {
                selectedDataGridView = 0;
                selectedEntity = entity0;
                selectedIdsEntity0 = GetIdOfSelectedCells();
                if (selectedIdsEntity0.Count != 1)
                {
                    xbtnEditEntity0.Enabled = false;
                    xbtnLinkLeft.Enabled = false;
                }
                else
                {
                    xbtnEditEntity0.Enabled = true;
                    xbtnLinkLeft.Enabled = true;
                }
                if (loaded == true && xcbxLinkedRecordsEntity1.Checked == true)
                {
                    //xcbxLinkedRecords_CheckedChanged(xcbxLinkedRecordsEntity0, e);
                    bool loadEntity0 = selectedEntity == entity0 ? false : true;
                    bool loadEntity1 = selectedEntity == entity1 ? false : true;
                    RefreshDataGrid(1, loadEntity0, (loadEntity1 && entity1Shown));
                    GetIdOfSelectedCells();
                }
            }
            else if (sender == xdgvEntity1)
            {
                selectedDataGridView = 1;
                selectedEntity = entity1;
                selectedIdsEntity1 = GetIdOfSelectedCells();
                if (selectedIdsEntity1.Count != 1)
                {
                    xbtnEditEntity1.Enabled = false;
                    xbtnLinkLeft.Enabled = false;
                }
                else
                {
                    xbtnEditEntity1.Enabled = true;
                    xbtnLinkLeft.Enabled = true;
                }
                if (loaded == true && xcbxLinkedRecordsEntity0.Checked == true)
                {
                    //xcbxLinkedRecords_CheckedChanged(xcbxLinkedRecordsEntity1, e);
                    bool loadEntity0 = selectedEntity == entity0 ? false : true;
                    bool loadEntity1 = selectedEntity == entity1 ? false : true;
                    RefreshDataGrid(1, loadEntity0, (loadEntity1 && entity1Shown));
                    GetIdOfSelectedCells();
                }
            }
        }

        private void xdgvEntity0_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (xdgvEntity0.Columns.Count == 0)
            {
                ShowHideEntity(false, entity1Shown);
            }
            else
            {
                ShowHideEntity(true, entity1Shown);
            }
        }

        private void xdgvEntity1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (xdgvEntity1.Columns.Count == 0)
            {
                ShowHideEntity(entity0Shown, false);
            }
            else
            {
                ShowHideEntity(entity0Shown, true);
            }
        }

        private void xbtnAddEntity0_Click(object sender, EventArgs e)
        {
            selectedDataGridView = 0;
            selectedEntity = entity0;
            AddRecord();
        }

        private void xbtnEditEntity0_Click(object sender, EventArgs e)
        {
            selectedDataGridView = 0;
            selectedEntity = entity0;
            EditRecord();
        }

        private void xbtnDeleteEntity0_Click(object sender, EventArgs e)
        {
            selectedDataGridView = 0;
            selectedEntity = entity0;
            DeleteRecord(true);
        }

        private void xbtnAddEntity1_Click(object sender, EventArgs e)
        {
            selectedDataGridView = 1;
            selectedEntity = entity1;
            AddRecord();
        }

        private void xbtnEditEntity1_Click(object sender, EventArgs e)
        {
            selectedDataGridView = 1;
            selectedEntity = entity1;
            EditRecord();
        }

        private void xbtnDeleteEntity1_Click(object sender, EventArgs e)
        {
            selectedDataGridView = 1;
            selectedEntity = entity1;
            DeleteRecord(true);
        }

        private void xtbxQuickSearch_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            selectedEntity = sender == xtbxQuickSearchEntity0 ? entity0 : entity1;
            selectedDataGridView = sender == xtbxQuickSearchEntity0 ? 0 : 1;
            bool loadEntity0 = selectedEntity == entity0 ? true : false;
            bool loadEntity1 = selectedEntity == entity1 ? true : false;
            RefreshDataGrid(1, loadEntity0, (loadEntity1 && entity1Shown));
        }

        private void xtbxQuickSearch_Enter(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.ForeColor == Color.Gray)
            {
                textbox.ForeColor = Color.Black;
                textbox.Clear();
            }
        }

        private void xtbxQuickSearch_Leave(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textbox.Text))
            {
                textbox.ForeColor = Color.Gray;
                textbox.Text = "Quick search...";
            }
        }

        private void xpbxBack_Click(object sender, EventArgs e)
        {
            OpenMainMenu();
        }

        private void xpbxBack_MouseDown(object sender, MouseEventArgs e)
        {
            xpbxBack.Image = leftArrowClick;
        }

        private void xpbxBack_MouseEnter(object sender, EventArgs e)
        {
            xpbxBack.Image = leftArrowHover;
        }

        private void xpbxBack_MouseLeave(object sender, EventArgs e)
        {
            xpbxBack.Image = leftArrow;
        }

        private void xpbxBack_MouseUp(object sender, MouseEventArgs e)
        {
            xpbxBack.Image = leftArrow;
        }

        private void xpbxHideEntity1_Click(object sender, EventArgs e)
        {
            if (entity1UserShow == true)
            {
                entity1UserShow = false;
                //xbtnHideEntity1.Text = "Show";
                xpbxHideEntity1.Image = eyeCrossClick;
                xtlpEntities.SetColumn(xpbxHideEntity1, 2);
            }
            else
            {
                entity1UserShow = true;
                //xbtnHideEntity1.Text = "Hide";
                xpbxHideEntity1.Image = eyeClick;
                xtlpEntities.SetColumn(xpbxHideEntity1, 6);
            }
            ShowHideEntity(entity0Shown, entity1UserShow);
        }

        private void xpbxHideEntity1_MouseDown(object sender, MouseEventArgs e)
        {
            if (entity1UserShow == true)
            {
                xpbxHideEntity1.Image = eyeClick;
            }
            else
            {
                xpbxHideEntity1.Image = eyeCrossClick;
            }
        }

        private void xpbxHideEntity1_MouseEnter(object sender, EventArgs e)
        {
            if (entity1UserShow == true)
            {
                xpbxHideEntity1.Image = eyeHover;
            }
            else
            {
                xpbxHideEntity1.Image = eyeCrossHover;
            }
        }

        private void xpbxHideEntity1_MouseLeave(object sender, EventArgs e)
        {
            if (entity1UserShow == true)
            {
                xpbxHideEntity1.Image = eye;
            }
            else
            {
                xpbxHideEntity1.Image = eyeCross;
            }
        }

        private void xpbxHideEntity1_MouseUp(object sender, MouseEventArgs e)
        {
            if (entity1UserShow == true)
            {
                xpbxHideEntity1.Image = eye;
            }
            else
            {
                xpbxHideEntity1.Image = eyeCross;
            }
        }

        private void xbtnHideEntity1_Click(object sender, EventArgs e)
        {
            /*if (entity1UserShow == true)
            {
                entity1UserShow = false;
                xbtnHideEntity1.Text = "Show";
                xtlpEntities.SetColumn(xbtnHideEntity1, 2);
            }
            else
            {
                entity1UserShow = true;
                xbtnHideEntity1.Text = "Hide";
                xtlpEntities.SetColumn(xbtnHideEntity1, 6);
            }
            ShowHideEntity(entity0Shown, entity1UserShow);*/
        }
    }
}
