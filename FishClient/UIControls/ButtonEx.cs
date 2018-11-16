using System;
using System.Collections.Generic;
using System.Text;
using FishEntity;

namespace FishClient.UIControls
{
    public  class ButtonEx:UILibrary.SkinButtom
    {
        protected FormMenuBase _form = null;

        protected Type _formType = null;

        protected string _functionCode = "";


        public Type FormType
        {
            get
            {
                return _formType;
            }
            set
            {
                _formType = value;
            }
        }

        public string FunctionCode
        {
            get { return _functionCode; }
            set { _functionCode = value; }
        }

        public FormMenuBase Form
        {
            get
            {
                if (_form == null && _formType !=null )
                {
                    _form = Activator.CreateInstance(_formType, null) as FormMenuBase;
                   
                }
                if (_form != null)
                {
                    _form.ClosingEvent += _form_ClosingEvent;
                    _form.MenuCode = _functionCode;
                }

                return _form;
            }

        }

        void _form_ClosingEvent(EventArgs obj)
        {
            _form = null;
        }
    }
}
