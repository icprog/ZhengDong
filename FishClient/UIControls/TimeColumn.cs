using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIControls
{

        public class TimeColumn : DataGridViewColumn
        {
            /// <summary>  
            ///   
            /// </summary>  
            public TimeColumn()
                : base(new TimeCell())
            {
            }
            /// <summary>  
            ///   
            /// </summary>  
            public override DataGridViewCell CellTemplate
            {
                get
                {
                    return base.CellTemplate;
                }
                set
                {

                    if (value != null &&
                        !value.GetType().IsAssignableFrom(typeof(TimeCell)))
                    {
                        throw new InvalidCastException("Must be a TimeCell");
                    }
                    base.CellTemplate = value;
                }
            }
        }


        /// <summary>  
        /// DataGridView 添加日期列  
        /// </summary>  
        public class TimeCell : DataGridViewTextBoxCell
        {

            public TimeCell()
                : base()
            {

                this.Style.Format = "HH:mm";
            }

            public override void InitializeEditingControl(int rowIndex, object
                initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
            {

                base.InitializeEditingControl(rowIndex, initialFormattedValue,
                    dataGridViewCellStyle);
                TimeEditingControl ctl =
                    DataGridView.EditingControl as TimeEditingControl;

                if (this.Value == null)
                {
                    ctl.Value = (DateTime)this.DefaultNewRowValue;
                }
                else
                {
                    ctl.Value = (DateTime)this.Value;
                }
            }

            public override Type EditType
            {
                get
                {

                    return typeof(TimeEditingControl);
                }
            }

            public override Type ValueType
            {
                get
                {


                    return typeof(DateTime);
                }
            }

            public override object DefaultNewRowValue
            {
                get
                {

                    return DateTime.Now;
                }
            }
        }


        /// <summary>  
        ///DataGridView 添加日期列 
        /// </summary>  
        class TimeEditingControl : DateTimePicker, IDataGridViewEditingControl
        {
            DataGridView dataGridView;
            private bool valueChanged = false;
            int rowIndex;

            public TimeEditingControl()
            {
                this.Format = DateTimePickerFormat.Custom;
                this.CustomFormat = "HH:mm";
                this.ShowUpDown = true;
            }


            public object EditingControlFormattedValue
            {
                get
                {
                    //return this.Value.ToShortDateString();
                    return this.Value.ToString("HH:mm");
                }
                set
                {
                    if (value is String)
                    {
                        try
                        {

                            this.Value = DateTime.Parse((String)value);
                        }
                        catch
                        {

                            this.Value = DateTime.Now;
                        }
                    }
                }
            }


            public object GetEditingControlFormattedValue(
                DataGridViewDataErrorContexts context)
            {
                return EditingControlFormattedValue;
            }


            public void ApplyCellStyleToEditingControl(
                DataGridViewCellStyle dataGridViewCellStyle)
            {
                this.Font = dataGridViewCellStyle.Font;
                this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
                this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
            }


            public int EditingControlRowIndex
            {
                get
                {
                    return rowIndex;
                }
                set
                {
                    rowIndex = value;
                }
            }


            public bool EditingControlWantsInputKey(
                Keys key, bool dataGridViewWantsInputKey)
            {
                // Let the DateTimePicker handle the keys listed.  
                switch (key & Keys.KeyCode)
                {
                    case Keys.Left:
                    case Keys.Up:
                    case Keys.Down:
                    case Keys.Right:
                    case Keys.Home:
                    case Keys.End:
                    case Keys.PageDown:
                    case Keys.PageUp:
                        return true;
                    default:
                        return !dataGridViewWantsInputKey;
                }
            }


            public void PrepareEditingControlForEdit(bool selectAll)
            {
                // No preparation needs to be done.  
            }


            public bool RepositionEditingControlOnValueChange
            {
                get
                {
                    return false;
                }
            }


            public DataGridView EditingControlDataGridView
            {
                get
                {
                    return dataGridView;
                }
                set
                {
                    dataGridView = value;
                }
            }


            public bool EditingControlValueChanged
            {
                get
                {
                    return valueChanged;
                }
                set
                {
                    valueChanged = value;
                }
            }


            public Cursor EditingPanelCursor
            {
                get
                {
                    return base.Cursor;
                }
            }

            protected override void OnValueChanged(EventArgs eventargs)
            {

                valueChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnValueChanged(eventargs);
            }
        }
}
