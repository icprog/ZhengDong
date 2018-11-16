using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Text;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FromInquirySet :Form
    {
        public FromInquirySet ( string title ,FishEntity . InquiryEntity entity ,string fishId )
        {
            InitializeComponent ( );

            _model = entity;
            if ( _model != null )
            {
                texWeight . Text = _model . Weight . ToString ( );
                texNumber . Text = _model . Number . ToString ( );
                texRmb . Text = _model . Rmb . ToString ( );
                texExchangerate . Text = _model . Exchangerate . ToString ( );
                texDollarprice . Text = _model . Dollarprice . ToString ( );
                if ( _model . Datetime > DateTime . MinValue && _model . Datetime < DateTime . MaxValue )
                    dateTimeP . Value = _model . Datetime;
                richRemark . Text = _model . Remark;
            }
            texWeight . Tag = fishId;
            this . Text = title;
        }

        FishEntity.InquiryEntity _model=null;
        public event Action<EventArgs> RefreshEvent = null;
        
        private void FromInquirySet_Load ( object sender ,EventArgs e )
        {

        }

        private void butOk_Click ( object sender ,EventArgs e )
        {
            if ( Check ( ) == false )
            {
                this . DialogResult = System . Windows . Forms . DialogResult . None;
                return;
            }
            bool isAdd = false;
            if ( _model == null )
            {
                _model = new FishEntity . InquiryEntity ( );
                isAdd = true;
            }

            _model . Code = texWeight . Tag . ToString ( );
            _model . Weight = string . IsNullOrEmpty ( texWeight . Text ) == true ? 0 : Convert . ToDecimal ( texWeight . Text );
            _model . Number = string . IsNullOrEmpty ( texNumber . Text ) == true ? 0 : Convert . ToInt32 ( texNumber . Text );
            _model . Exchangerate = string . IsNullOrEmpty ( texExchangerate . Text ) == true ? 0 : Convert . ToDecimal ( texExchangerate . Text );
            _model . Rmb = string . IsNullOrEmpty ( texRmb . Text ) == true ? 0 : Convert . ToDecimal ( texRmb . Text );
            _model . Dollarprice = string . IsNullOrEmpty ( texDollarprice . Text ) == true ? 0 : Convert . ToDecimal ( texDollarprice . Text );
            _model . Datetime = dateTimeP . Value;
            _model . Remark = richRemark . Text;

            if ( isAdd )
            {
                FishBll . Bll . InquiryBll _bll = new FishBll . Bll . InquiryBll ( );
                int id = _bll . Add ( _model );
                if ( id > 0 )
                    OnRefresh ( );
            }
            else
            {
                FishBll . Bll . InquiryBll _bll = new FishBll . Bll . InquiryBll ( );
                bool isOk = _bll . Update ( _model );
                if ( isOk )
                    OnRefresh ( );
            }

            this . Close ( );
        }

        protected bool Check ( )
        {
            errorProvider1 . Clear ( );
            bool isOk = true;
            decimal temp = 0M;
            int tempOne = 0;
            if ( decimal . TryParse ( texWeight . Text ,out temp ) == false )
            {
                errorProvider1 . SetError ( texWeight ,"请输入正确数字" );
                isOk = false;
            }
            //if ( int . TryParse ( texNumber . Text ,out tempOne ) == false )
            //{
            //    errorProvider1 . SetError ( texNumber ,"请输入正确数字" );
            //    isOk = false;
            //}
            if ( decimal . TryParse ( texExchangerate . Text ,out temp ) == false )
            {
                errorProvider1 . SetError ( texExchangerate ,"请输入正确数字" );
                isOk = false;
            }
            if ( decimal . TryParse ( texRmb . Text ,out temp ) == false )
            {
                errorProvider1 . SetError ( texRmb ,"请输入正确数字" );
                isOk = false;
            }
            if ( decimal . TryParse ( texDollarprice . Text ,out temp ) == false )
            {
                errorProvider1 . SetError ( texDollarprice ,"请输入正确数字" );
                isOk = false;
            }

            return isOk;
        }

        protected void OnRefresh ( )
        {
            if ( RefreshEvent != null )
            {
                RefreshEvent ( EventArgs . Empty );
            }
        }

        private void butCancel_Click ( object sender ,EventArgs e )
        {
            this . Close ( );
        }
    }
}
