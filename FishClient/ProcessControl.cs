using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FishEntity;


namespace FishClient
{
    public class ProcessControl
    {
        FishBll.Bll.PersonBll user = new FishBll.Bll.PersonBll();


        public bool ProcessControText(string Text)
        {
            bool Num = user.ExistsUser(FishEntity.Variable.User.id,Text);
            if (Num == false)
            {
                MessageBox.Show("请设置权限");
            }
            return Num;
        }
    }
}

