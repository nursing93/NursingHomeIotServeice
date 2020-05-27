using LogingWindow.ToolClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogingWindow
{
    public partial class AreaSetWindow : Form
    {
        private Boolean ISMIN = true;        // 标志位，判断人员列表是否处于收缩（最小）状态，用以实现窗口布局变化而设置
        private Boolean ISPUTAREA = false;    //标志位，用于判断用户是否设置了多边形区域
        public AreaSetWindow()
        {
            InitializeComponent();
        }

        private void AreaSetWindow_Load(object sender, EventArgs e)
        {
            HandMap.ShowBaseMap(this.setAreaWebBrowser);      //调用页面刷新方法，将该窗口的webbroser加载成地图首页
        }

        /************************************************
         * 自定义方法
         * *************************************************/
        /// <summary>
        /// 控制主页面的布局，即人员列表的伸拉状态
        /// </summary>
        private void LayoutControl()
        {
            if (ISMIN)
            {
                this.panel1.Height = 256;
                this.layoutControlBtn.Text = "-";
                this.ISMIN = false;
            }
            else
            {
                this.panel1.Height = 36;
                this.layoutControlBtn.Text = "+";
                this.ISMIN = true;
            }
        }




        /********************************************************
         * 事件处理代码块
         * ********************************************************/

        private void putAreaBtn_Click(object sender, EventArgs e)
        {
            HandMap.SetBaseArea(this.setAreaWebBrowser);    //调用放置基本图形的方法，向地图中添加基本图形（三角形）
            this.ISPUTAREA = true;      //基本图形已经设置
        }

        private void saveAreaBtn_Click(object sender, EventArgs e)
        {
            if (ISPUTAREA)
            {
                //调用保存活动区域的静态方法,并将返回值传给ElderManageForm对象的AREASTRING属性
                 ElderManageForm.elderManageForm.AREASTRING= HandMap.SaveManArea(this.setAreaWebBrowser);
                 //this.Close();
            }
            else 
            {
                MessageBox.Show("您尚未进行设置安全活动区域\n请完成该操作后进行保存", "操作未完成");
            }
        }

        private void putAreaBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                //调用一个静态方法，实现将历时图形显示在地图上
                string areaStr = ElderManageForm.elderManageForm.AREASTRING;
                //将标志位置为所调用方法的返回值，以便顺利实现ManPointsWindow的数据保存和关闭
               this.ISPUTAREA = HandMap.SetHistoryArea(this.setAreaWebBrowser,areaStr);
            }
        }

        private void layoutControlBtn_Click(object sender, EventArgs e)
        {
            LayoutControl();
        }



    }
}
