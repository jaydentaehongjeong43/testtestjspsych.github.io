using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaKaoTalkParser
{
    public partial class Form1 : Form
    {
        private string[] result;

        public Form1()
        {
            InitializeComponent();
        }

        private void updateUI(string str)
        {
            Func<int> del = delegate ()
            {
                txt_parsing.AppendText(str + Environment.NewLine);
                return 0;
            };
            Invoke(del);
        }


        private void btn_start_Click(object sender, EventArgs e)
        {
            txt_parsing.Text = null;
            if(txt_original.Text == null)
            {
                txt_parsing.Text = "Error!!! No Text in original";
                return;
            }
            textParsing();
        }

        private void textParsing()
        {
            KaKaoParsing kakao = new KaKaoParsing(txt_original.Text);
            //string[] result;
            string count;
            if (radioButton1.Checked == true)
            {
                result = kakao.parseText(1);
                
            }
            else if (radioButton2.Checked == true)
            {
                result = kakao.parseText(2);
            }
            else if (radioButton3.Checked == true)
            {
                result = kakao.parseText(3);
            }
            
            for (int i = 0; i < result.Length; i++)
            {
                //result[i] = result[i].Replace("<사진>", "");
                //result[i] = result[i].Replace("<동영상>", "");
                //result[i] = result[i].Replace("<이모티콘>", "");
                updateUI(result[i]);
            }
            count = Convert.ToString(kakao.countWord(result));
            txt_nword.Text = count;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
