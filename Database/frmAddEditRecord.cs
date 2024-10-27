using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    public partial class frmAddEditRecord : Form
    {

        private int mode; //0 = Add, 1 = Edit
        bool loaded;
        private string entity;
        private string autoFillEntity;
        private string[] fieldNames;
        private string[] record;
        private string[] autoFillFieldNames;
        private string inputAutoFillField;
        private List<string> inputControlNames = new List<string>();
        private List<bool> inputControlRequired = new List<bool>();
        private List<bool> inputAutoFill = new List<bool>();

        public frmAddEditRecord(string entity, string autoFillEntity, string[] fieldNames, string[] record)
        {
            InitializeComponent();
            loaded = false;
            this.MinimumSize = new Size(0, 0);
            this.Height = 70;
            this.entity = entity;
            this.autoFillEntity = autoFillEntity;
            this.fieldNames = fieldNames;
            this.record = record;
            autoFillFieldNames = DAL.GetSchemaInfo(autoFillEntity, "COLUMNS", "COLUMN_NAME");
            CheckType();
            ChooseLayout();
            SetByMode();
            loaded = true;
        }

        //Checks whether row data exists to determine if adding or editing a record
        private void CheckType()
        {
            mode = 0;
            if (record != null)
            {
                for (int i = 0; i < record.Count(); i++)
                {
                    if (record[i] != null)
                    {
                        mode = 1;
                        break;
                    }
                }
            }
        }

        //Calls the correct layout method.
        private void ChooseLayout()
        {
            xlblEnterDetails.Text = $"Enter {entity} details";
            if (entity == "Dog")
            {
                DogLayout();
            }
            else if (entity == "Customer")
            {
                CustomerLayout();
            }
            else if (entity == "Session")
            {
                SessionLayout();
            }
            else if (entity == "Class")
            {
                ClassLayout();
            }
            else if (entity == "Programme")
            {
                ProgrammeLayout();
            }
            ChooseButton();
        }

        //Sets the form properties and input control text
        private void SetByMode()
        {
            if (mode == 0)
            {
                this.Text = $"Add {entity}";
            }
            else if (mode == 1)
            {
                this.Text = $"Edit {entity}";
                /*int offset = 0;
                if (fieldNames[0] != null && fieldNames[0].Length > 1 && fieldNames[0].Substring(fieldNames[0].Length - 2, 2) == "Id")
                {
                    //Avoids setting the ID to a control
                    offset = 1;
                }*/
                for (int i = 0; i < inputControlNames.Count; i++)
                {
                    for (int j = 0; j < record.Count(); j++)
                    {
                        if (inputControlNames[i].Substring(4, inputControlNames[i].Length - 4) != fieldNames[j])
                        {
                            continue;
                        }
                        string recordString = record[j]; //i + offset
                        if (inputControlNames.ElementAtOrDefault(i).Substring(0, 4) == "xtbx")
                        {
                            this.Controls.Find(inputControlNames.ElementAtOrDefault(i), true)[0].Text = recordString;
                        }
                        else if (inputControlNames.ElementAtOrDefault(i).Substring(0, 4) == "xnup")
                        {
                            NumericUpDown numericUpDown = (NumericUpDown)this.Controls.Find(inputControlNames.ElementAtOrDefault(i), true)[0];
                            int value;
                            if (int.TryParse(recordString, out value) == false)
                            {
                                MessageBox.Show($"Unable to convert the attribute '{recordString}' to an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (numericUpDown.Value == numericUpDown.Minimum) //Ensures that numericUpDown will always show a value when the form opens
                            {
                                if (numericUpDown.Maximum < int.MaxValue)
                                {
                                    numericUpDown.Maximum += 1;
                                    numericUpDown.Value = numericUpDown.Maximum;
                                    numericUpDown.Maximum += -1;
                                    numericUpDown.Value = numericUpDown.Maximum;
                                }
                                else if (numericUpDown.Minimum > int.MinValue)
                                {
                                    numericUpDown.Minimum += -1;
                                    numericUpDown.Value = numericUpDown.Minimum;
                                    numericUpDown.Minimum += 1;
                                    numericUpDown.Value = numericUpDown.Minimum;
                                }
                            }
                            numericUpDown.Value = value;
                        }
                        else if (inputControlNames.ElementAtOrDefault(i).Substring(0, 4) == "xdtp")
                        {
                            DateTimePicker dateTimePicker = (DateTimePicker)this.Controls.Find(inputControlNames.ElementAtOrDefault(i), true)[0];
                            DateTime value;
                            if (DateTime.TryParse(recordString, out value) == false)
                            {
                                MessageBox.Show($"Unable to convert the attribute '{recordString}' to a date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (dateTimePicker.Value == dateTimePicker.MinDate) //Ensures that dateTimePicker will always show a value when the form opens
                            {
                                if (dateTimePicker.MaxDate < DateTime.MaxValue)
                                {
                                    DateTime temp = dateTimePicker.MaxDate;
                                    dateTimePicker.MaxDate = temp.AddDays(1);
                                    dateTimePicker.Value = dateTimePicker.MaxDate;
                                    dateTimePicker.MaxDate = temp.AddDays(-1);
                                    dateTimePicker.Value = dateTimePicker.MaxDate;
                                }
                                else if (dateTimePicker.MinDate > DateTime.MinValue)
                                {
                                    DateTime temp = dateTimePicker.MinDate;
                                    dateTimePicker.MinDate = temp.AddDays(-1);
                                    dateTimePicker.Value = dateTimePicker.MinDate;
                                    dateTimePicker.MinDate = temp.AddDays(1);
                                    dateTimePicker.Value = dateTimePicker.MinDate;
                                }
                            }
                            dateTimePicker.Value = value;
                        }
                        break;
                    }
                }
            }
        }

        //Adds a TextBox to TableLayoutPanel
        private void AddTextbox(string name, string labelText, bool autoFill, bool required)
        {
            Label label = new Label();
            TextBox textBox = new TextBox();
            label.Name = ($"xlbl{name}");
            textBox.Name = ($"xtbx{name}");
            inputControlNames.Add(textBox.Name);
            inputControlRequired.Add(required);
            inputAutoFill.Add(autoFill);
            label.Text = required ? labelText + "*" : labelText;
            label.TextAlign = ContentAlignment.BottomLeft;
            textBox.ContextMenu = new ContextMenu();
            label.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            textBox.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);

            xtlpDetails.RowCount += 1;
            xtlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            xtlpDetails.Controls.Add(label, 0, xtlpDetails.RowCount - 1);

            xtlpDetails.RowCount += 1;
            xtlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            xtlpDetails.Controls.Add(textBox, 0, xtlpDetails.RowCount - 1);

            textBox.KeyPress += new KeyPressEventHandler(xDetails_KeyPress);
            textBox.TextChanged += new EventHandler(xDetails_TextChanged);

            this.Height += 60;
            this.MinimumSize = this.Size;
        }

        //Adds a NumericUpDown to TableLayoutPanel
        private void AddNumericUpDown(string name, string labelText, int minimum, int maximum, bool autoFill, bool required)
        {
            Label label = new Label();
            NumericUpDown numericUpDown = new NumericUpDown();
            label.Name = ($"xlbl{name}");
            numericUpDown.Name = ($"xnup{name}");
            inputControlNames.Add(numericUpDown.Name);
            inputControlRequired.Add(required);
            inputAutoFill.Add(autoFill);
            label.Text = required ? labelText + "*" : labelText;
            label.TextAlign = ContentAlignment.BottomLeft;
            numericUpDown.Minimum = minimum == -1 ? int.MinValue : minimum;
            numericUpDown.Maximum = maximum == -1 ? int.MaxValue : maximum;
            numericUpDown.ResetText();
            numericUpDown.ContextMenu = new ContextMenu();
            label.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            numericUpDown.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);

            xtlpDetails.RowCount += 1;
            xtlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            xtlpDetails.Controls.Add(label, 0, xtlpDetails.RowCount - 1);

            xtlpDetails.RowCount += 1;
            xtlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            xtlpDetails.Controls.Add(numericUpDown, 0, xtlpDetails.RowCount - 1);

            numericUpDown.KeyPress += new KeyPressEventHandler(xDetails_KeyPress);
            numericUpDown.ValueChanged += new EventHandler(xDetails_TextChanged);

            this.Height += 60;
            this.MinimumSize = this.Size;
        }

        //Adds a DateTimePicker to TableLayoutPanel
        private void AddDateTimePicker(string name, string labelText, DateTime minimum, DateTime maximum, DateTimePickerFormat format, bool autoFill, bool required)
        {
            Label label = new Label();
            DateTimePicker dateTimePicker = new DateTimePicker();
            label.Name = ($"xlbl{name}");
            dateTimePicker.Name = ($"xdtp{name}");
            inputControlNames.Add(dateTimePicker.Name);
            inputControlRequired.Add(required);
            inputAutoFill.Add(autoFill);
            label.Text = required ? labelText + "*" : labelText;
            label.TextAlign = ContentAlignment.BottomLeft;
            dateTimePicker.MinDate = minimum;
            dateTimePicker.MaxDate = maximum;
            dateTimePicker.Format = format;
            dateTimePicker.ResetText(); //TODO: Prevent from reseting when editing records
            dateTimePicker.ContextMenu = new ContextMenu();
            label.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            dateTimePicker.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);

            xtlpDetails.RowCount += 1;
            xtlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            xtlpDetails.Controls.Add(label, 0, xtlpDetails.RowCount - 1);

            xtlpDetails.RowCount += 1;
            xtlpDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            xtlpDetails.Controls.Add(dateTimePicker, 0, xtlpDetails.RowCount - 1);

            dateTimePicker.KeyPress += new KeyPressEventHandler(xDetails_KeyPress);
            dateTimePicker.ValueChanged += new EventHandler(xDetails_TextChanged);

            this.Height += 60;
            this.MinimumSize = this.Size;
        }

        //Adds a Button to TableLayoutPanel
        private void AddAddEditButton(string buttonText)
        {
            Label label = new Label();
            Button button = new Button();
            button.Name = $"xbtnAddEdit";
            label.Name = ($"xlblMessage");
            label.Text = "Error";
            label.TextAlign = ContentAlignment.BottomLeft;
            label.ForeColor = Color.Red;
            label.Hide();
            button.Text = buttonText;
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.WhiteSmoke;
            label.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            button.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);

            xtlpDetails.RowCount += 1;
            xtlpDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            xtlpDetails.Controls.Add(label, 0, xtlpDetails.RowCount - 1);

            xtlpDetails.RowCount += 1;
            xtlpDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            xtlpDetails.Controls.Add(button, 0, xtlpDetails.RowCount - 1);

            button.Click += new EventHandler(xbtnAddEdit_Click);
            button.KeyPress += new KeyPressEventHandler(xbtnAddEdit_KeyPress);

            this.Height += 70;
            this.MinimumSize = this.Size;
        }

        //Checks if input data is valid
        private void AddEditCheck()
        {
            string[] fieldNames = DAL.GetSchemaInfo(entity, "COLUMNS", "COLUMN_NAME");
            for (int i = 0; i < inputControlNames.Count; i++)
            {
                if (inputControlRequired[i] == true && string.IsNullOrWhiteSpace(this.Controls.Find(inputControlNames.ElementAtOrDefault(i), true)[0].Text) == true)
                {
                    SetButtonLabelProperties("Fields marked with * are required", Color.Red);
                    return;
                }
                string controlText = this.Controls.Find(inputControlNames.ElementAtOrDefault(i), true)[0].Text;
                if (this.Controls.Find(inputControlNames.ElementAtOrDefault(i), true)[0] is NumericUpDown)
                {
                    for (int j = 0; j < controlText.Length; j++)
                    {
                        if (char.IsDigit(controlText[j]) == false)
                        {
                            if (controlText[j] == '-' && j == 0)
                            {
                                continue;
                            }
                            SetButtonLabelProperties($"{inputControlNames.ElementAtOrDefault(i).Substring(4, inputControlNames.ElementAtOrDefault(i).Length - 4)} must be an integer", Color.Red);
                            return;
                        }
                    }
                }
                else if (this.Controls.Find(inputControlNames.ElementAtOrDefault(i), true)[0] is DateTimePicker)
                {
                    DateTimePicker dateTimePicker = (DateTimePicker)this.Controls.Find(inputControlNames.ElementAtOrDefault(i), true)[0];
                    controlText = dateTimePicker.Value.Date.ToShortDateString();
                }
                string fieldName = inputControlNames.ElementAtOrDefault(i).Substring(4);
                if (record == null)
                {
                    record = new string[fieldNames.Count()];
                }
                for (int o = 0; o < fieldNames.Count(); o++)
                {
                    if (fieldName == fieldNames[o])
                    {
                        record[o] = !(string.IsNullOrWhiteSpace(controlText)) ? controlText : null;
                    }
                }
            }
            if (mode == 0)
            {
                Add();
            }
            else if (mode == 1)
            {
                Edit();
            }
        }

        //Adds a record
        private void Add()
        {
            int rowsAffected = 0;
            string[] fieldNames = DAL.GetSchemaInfo(entity, "COLUMNS", "COLUMN_NAME");
            try
            {
                rowsAffected = DAL.Add(entity, fieldNames, record, true);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 547)
                {
                    SetButtonLabelProperties("No record with that ID could be found", Color.Red);
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Failed to add record. Please try again.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Retry)
                {
                    Add();
                    return;
                }
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            if (rowsAffected == 1)
            {
                for (int i = 0; i < inputControlNames.Count; i++)
                {
                    this.Controls.Find(inputControlNames.ElementAtOrDefault(i), true)[0].ResetText();
                }
                this.ActiveControl = this.Controls.Find(inputControlNames.ElementAtOrDefault(0), true)[0];
                SetButtonLabelProperties("Added successfully", Color.Green);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Failed to add record. Please try again.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Retry)
                {
                    Add();
                    return;
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
        }

        //Edits a record
        private void Edit()
        {
            int rowsAffected = 0;
            string[] fieldNames = DAL.GetSchemaInfo(entity, "COLUMNS", "COLUMN_NAME");
            try
            {
                int id = int.Parse(record[0]);
                rowsAffected = DAL.Edit(entity, fieldNames, $"{entity}Id", id, record, true);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 547)
                {
                    SetButtonLabelProperties("No record with that ID could be found", Color.Red);
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Failed to edit record. Please try again.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Retry)
                {
                    Edit();
                    return;
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            if (rowsAffected == 1)
            {
                this.Close();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Failed to edit record. Please try again.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Retry)
                {
                    Edit();
                    return;
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
        }

        private void DogLayout()
        {
            AddTextbox("DogName", "Name", false, true);
            AddNumericUpDown("DogAge", "Age", 0, 30, false, true);
            AddTextbox("DogBreed", "Breed", false, true);
            AddNumericUpDown("CustomerId", "Customer ID", 0, -1, false, true);
        }

        private void CustomerLayout()
        {
            AddTextbox("CustomerForename", "Forename", false, true);
            AddTextbox("CustomerSurname", "Surname", false, true);
            AddTextbox("CustomerAddress", "Address", false, true);
            AddTextbox("CustomerContactNum", "Contact Number", false, true);
        }

        private void SessionLayout()
        {
            AddNumericUpDown("ClassId", "Class ID", 0, -1, false, true);
            AddTextbox("SessionDescription", "Description", false, false);
            AddDateTimePicker("SessionDate", "Date", DateTime.Today, DateTime.MaxValue, DateTimePickerFormat.Long, false, true);
            //AddTextbox("SessionDate", "Date", false, true);
            AddTextbox("SessionStartTime", "Time", false, true);
            AddNumericUpDown("SessionLength", "Length (minutes)", 1, 1440, false, true);
        }

        private void ClassLayout()
        {
            inputAutoFillField = "xnupProgrammeId";
            AddNumericUpDown("ProgrammeId", "Programme ID", 0, -1, false, false);
            AddTextbox("ClassName", "Name", true, true);
            AddTextbox("ClassDescription", "Description", true, false);
            AddNumericUpDown("ClassLength", "Length (weeks)", 1, -1, true, true);
            AddNumericUpDown("ClassNumSessions", "Number of sessions per week", 1, 7, true, true);
            AddNumericUpDown("ClassMinutesSession", "Minutes per session", 1, 1440, true, true);
            AddNumericUpDown("ClassCostSession", "Cost per session", 0, -1, true, true);
            AddNumericUpDown("ClassDogLimit", "Dog limit", 1, -1, true, true);
        }

        private void ProgrammeLayout()
        {
            AddTextbox("ProgrammeName", "Name", false, true);
            AddTextbox("ProgrammeDescription", "Description", false, false);
            AddNumericUpDown("ProgrammeLength", "Length (weeks)", 1, -1, false, true);
            AddNumericUpDown("ProgrammeNumSessions", "Number of sessions per week", 1, 7, false, true);
            AddNumericUpDown("ProgrammeMinutesSession", "Minutes per session", 1, 1440, false, true);
            AddNumericUpDown("ProgrammeCostSession", "Cost per session", 0, -1, true, true);
            AddNumericUpDown("ProgrammeDogLimit", "Dog limit", 1, -1, false, true);
        }

        //Sets the AddEdit button text
        private void ChooseButton()
        {
            if (mode == 0)
            {
                AddAddEditButton("Add");
            }
            else if (mode == 1)
            {
                AddAddEditButton("Edit");
            }
        }

        private void SetButtonLabelProperties(string text, Color color)
        {
            this.Controls.Find("xlblMessage", true)[0].ForeColor = color;
            this.Controls.Find("xlblMessage", true)[0].Text = text;
            this.Controls.Find("xlblMessage", true)[0].Show();
        }

        private void Check_KeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddEditCheck();
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }

        private void xbtnAddEdit_Click(object sender, EventArgs e)
        {
            AddEditCheck();
        }

        private void xDetails_TextChanged(object sender, EventArgs e)
        {
            this.Controls.Find("xlblMessage", true)[0].Hide();
            string senderName = null;
            if (sender is TextBox)
            {
                TextBox textbox = (TextBox)sender;
                senderName = textbox.Name;
            }
            else if (sender is NumericUpDown)
            {
                NumericUpDown numericUpDown = (NumericUpDown)sender;
                senderName = numericUpDown.Name;
            }
            else if (sender is DateTimePicker)
            {
                DateTimePicker dateTimePicker = (DateTimePicker)sender;
                senderName = dateTimePicker.Name;
            }
            if (loaded == true && senderName == inputAutoFillField)
            {
                string autoFillAttribute = null;
                if (inputAutoFillField.Substring(0, 4) == "xtbx")
                {
                    autoFillAttribute = this.Controls.Find(inputAutoFillField, true)[0].Text;
                }
                else if (inputAutoFillField.Substring(0, 4) == "xnup")
                {
                    NumericUpDown numericUpDown = (NumericUpDown)this.Controls.Find(inputAutoFillField, true)[0];
                    autoFillAttribute = Convert.ToString(numericUpDown.Value);
                }
                else if (inputAutoFillField.Substring(0, 4) == "xdtp")
                {
                    DateTimePicker dateTimePicker = (DateTimePicker)this.Controls.Find(inputAutoFillField, true)[0];
                    autoFillAttribute = Convert.ToString(dateTimePicker.Value);
                }
                DataTable dataTable = DAL.SearchRecords(autoFillEntity, null, null, autoFillAttribute, inputAutoFillField.Substring(4, inputAutoFillField.Length - 4), null, false, null, true, false, false, false);
                if (dataTable != null)
                {
                    string[,] records = DAL.DataTableToStringArray(dataTable);
                    if (records.Length > 1)
                    {
                        string[] autoFillRecord = new string[records.GetLength(1)];
                        for (int i = 0; i < autoFillRecord.Count(); i++)
                        {
                            autoFillRecord[i] = records[0, i];
                        }
                        for (int i = 0; i < inputControlNames.Count; i++)
                        {
                            if (inputAutoFill[i] == true)
                            {
                                string field = inputControlNames[i];
                                field = field.Substring(4 + entity.Length, field.Length - 4 - entity.Length);
                                field = $"{autoFillEntity}{field}";
                                for (int j = 0; j < autoFillRecord.Count(); j++)
                                {
                                    if (field == autoFillFieldNames[j])
                                    {
                                        if (inputControlNames.ElementAtOrDefault(i).Substring(0, 4) == "xtbx")
                                        {
                                            this.Controls.Find(inputControlNames.ElementAtOrDefault(i), true)[0].Text = autoFillRecord[j];
                                        }
                                        else if (inputControlNames.ElementAtOrDefault(i).Substring(0, 4) == "xnup")
                                        {
                                            NumericUpDown numericUpDown = (NumericUpDown)this.Controls.Find(inputControlNames.ElementAtOrDefault(i), true)[0];
                                            int value;
                                            if (int.TryParse(autoFillRecord[j], out value) == true)
                                            {
                                                if (numericUpDown.Value == numericUpDown.Minimum) //Ensures that numericUpDown will always show a value when auto filling
                                                {
                                                    if (numericUpDown.Maximum < int.MaxValue)
                                                    {
                                                        numericUpDown.Maximum += 1;
                                                        numericUpDown.Value = numericUpDown.Maximum;
                                                        numericUpDown.Maximum += -1;
                                                        numericUpDown.Value = numericUpDown.Maximum;
                                                    }
                                                    else if (numericUpDown.Minimum > int.MinValue)
                                                    {
                                                        numericUpDown.Minimum += -1;
                                                        numericUpDown.Value = numericUpDown.Minimum;
                                                        numericUpDown.Minimum += 1;
                                                        numericUpDown.Value = numericUpDown.Minimum;
                                                    }
                                                }
                                                numericUpDown.Value = value;
                                            }
                                        }
                                        else if (inputControlNames.ElementAtOrDefault(i).Substring(0, 4) == "xdtp")
                                        {
                                            DateTimePicker dateTimePicker = (DateTimePicker)this.Controls.Find(inputControlNames.ElementAtOrDefault(i), true)[0];
                                            DateTime value;
                                            if (DateTime.TryParse(autoFillRecord[j], out value) == false)
                                            {
                                                MessageBox.Show($"Unable to convert the attribute '{autoFillRecord[j]}' to a date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                            if (dateTimePicker.Value == dateTimePicker.MinDate) //Ensures that dateTimePicker will always show a value when the form opens
                                            {
                                                if (dateTimePicker.MaxDate < DateTime.MaxValue)
                                                {
                                                    DateTime temp = dateTimePicker.MaxDate;
                                                    dateTimePicker.MaxDate = temp.AddDays(1);
                                                    dateTimePicker.Value = dateTimePicker.MaxDate;
                                                    dateTimePicker.MaxDate = temp.AddDays(-1);
                                                    dateTimePicker.Value = dateTimePicker.MaxDate;
                                                }
                                                else if (dateTimePicker.MinDate > DateTime.MinValue)
                                                {
                                                    DateTime temp = dateTimePicker.MinDate;
                                                    dateTimePicker.MinDate = temp.AddDays(-1);
                                                    dateTimePicker.Value = dateTimePicker.MinDate;
                                                    dateTimePicker.MinDate = temp.AddDays(1);
                                                    dateTimePicker.Value = dateTimePicker.MinDate;
                                                }
                                            }
                                            dateTimePicker.Value = value;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void xDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_KeyPress(e);
        }

        private void xbtnAddEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_KeyPress(e);
        }
    }
}
