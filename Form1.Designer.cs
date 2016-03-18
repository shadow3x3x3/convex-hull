using System.Drawing;

namespace convex_hull_problem
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.graphPanel = new System.Windows.Forms.Panel();
            this.clearBtn = new System.Windows.Forms.Button();
            this.connectBtn = new System.Windows.Forms.Button();
            this.creatBtn = new System.Windows.Forms.Button();
            this.pointUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pointUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // graphPanel
            // 
            this.graphPanel.BackColor = System.Drawing.Color.White;
            this.graphPanel.Location = new System.Drawing.Point(23, 22);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(749, 682);
            this.graphPanel.TabIndex = 4;
            // 
            // clearBtn
            // 
            this.clearBtn.AutoSize = true;
            this.clearBtn.Location = new System.Drawing.Point(901, 656);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(79, 48);
            this.clearBtn.TabIndex = 3;
            this.clearBtn.Text = "清除";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // connectBtn
            // 
            this.connectBtn.AutoSize = true;
            this.connectBtn.Location = new System.Drawing.Point(792, 656);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(79, 48);
            this.connectBtn.TabIndex = 6;
            this.connectBtn.Text = "連接";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // creatBtn
            // 
            this.creatBtn.AutoSize = true;
            this.creatBtn.Location = new System.Drawing.Point(901, 592);
            this.creatBtn.Name = "creatBtn";
            this.creatBtn.Size = new System.Drawing.Size(79, 48);
            this.creatBtn.TabIndex = 7;
            this.creatBtn.Text = "產生";
            this.creatBtn.UseVisualStyleBackColor = true;
            this.creatBtn.Click += new System.EventHandler(this.creatBtn_Click);
            // 
            // pointUpDown
            // 
            this.pointUpDown.Location = new System.Drawing.Point(792, 592);
            this.pointUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.pointUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.pointUpDown.Name = "pointUpDown";
            this.pointUpDown.Size = new System.Drawing.Size(79, 26);
            this.pointUpDown.TabIndex = 8;
            this.pointUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Hiragino Sans GB W3", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(778, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "資訊三乙 D0029871 邱聖崴";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1014, 733);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pointUpDown);
            this.Controls.Add(this.creatBtn);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.clearBtn);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "Form1";
            this.Text = "Concex Hull Problem D0029871_邱聖崴";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pointUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button creatBtn;
        private System.Windows.Forms.NumericUpDown pointUpDown;
        
        //宣告點的陣列
        Point[] coords = new Point[100];

        //宣告角度的陣列
        float[] angle = new float[100];

        //宣告變數
        decimal pointNum;
        int angle_Num;
        int angle_Calc;
        bool first_Step;
        bool second_Step;
        private System.Windows.Forms.Label label1;

    }
}

