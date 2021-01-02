namespace PrincessHelper
{
    partial class PrincessHelper
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincessHelper));
            this.Search_btn = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ShowResult_txt = new System.Windows.Forms.TextBox();
            this.Input_btn = new System.Windows.Forms.Button();
            this.NewMember_txt = new System.Windows.Forms.TextBox();
            this.NewMember_lbl = new System.Windows.Forms.Label();
            this.Hour_Role_txt = new System.Windows.Forms.TextBox();
            this.Hour_Role_lbl = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // Search_btn
            // 
            this.Search_btn.Location = new System.Drawing.Point(12, 58);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(102, 36);
            this.Search_btn.TabIndex = 0;
            this.Search_btn.Text = "查詢";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_ClickAsync);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 31);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // ShowResult_txt
            // 
            this.ShowResult_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowResult_txt.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ShowResult_txt.Location = new System.Drawing.Point(237, 12);
            this.ShowResult_txt.Multiline = true;
            this.ShowResult_txt.Name = "ShowResult_txt";
            this.ShowResult_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ShowResult_txt.Size = new System.Drawing.Size(317, 289);
            this.ShowResult_txt.TabIndex = 2;
            // 
            // Input_btn
            // 
            this.Input_btn.Location = new System.Drawing.Point(12, 250);
            this.Input_btn.Name = "Input_btn";
            this.Input_btn.Size = new System.Drawing.Size(102, 36);
            this.Input_btn.TabIndex = 3;
            this.Input_btn.Text = "加入";
            this.Input_btn.UseVisualStyleBackColor = true;
            this.Input_btn.Click += new System.EventHandler(this.Input_btn_Click);
            // 
            // NewMember_txt
            // 
            this.NewMember_txt.Location = new System.Drawing.Point(12, 219);
            this.NewMember_txt.Name = "NewMember_txt";
            this.NewMember_txt.Size = new System.Drawing.Size(200, 25);
            this.NewMember_txt.TabIndex = 4;
            // 
            // NewMember_lbl
            // 
            this.NewMember_lbl.AutoSize = true;
            this.NewMember_lbl.Location = new System.Drawing.Point(12, 201);
            this.NewMember_lbl.Name = "NewMember_lbl";
            this.NewMember_lbl.Size = new System.Drawing.Size(56, 15);
            this.NewMember_lbl.TabIndex = 5;
            this.NewMember_lbl.Text = "新成員:";
            // 
            // Hour_Role_txt
            // 
            this.Hour_Role_txt.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Hour_Role_txt.Location = new System.Drawing.Point(12, 136);
            this.Hour_Role_txt.Name = "Hour_Role_txt";
            this.Hour_Role_txt.Size = new System.Drawing.Size(200, 30);
            this.Hour_Role_txt.TabIndex = 6;
            // 
            // Hour_Role_lbl
            // 
            this.Hour_Role_lbl.AutoSize = true;
            this.Hour_Role_lbl.Location = new System.Drawing.Point(12, 114);
            this.Hour_Role_lbl.Name = "Hour_Role_lbl";
            this.Hour_Role_lbl.Size = new System.Drawing.Size(101, 15);
            this.Hour_Role_lbl.TabIndex = 7;
            this.Hour_Role_lbl.Text = "現在現實精靈:";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "騎士公主";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // PrincessHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 307);
            this.Controls.Add(this.Hour_Role_lbl);
            this.Controls.Add(this.Hour_Role_txt);
            this.Controls.Add(this.NewMember_lbl);
            this.Controls.Add(this.NewMember_txt);
            this.Controls.Add(this.Input_btn);
            this.Controls.Add(this.ShowResult_txt);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Search_btn);
            this.Name = "PrincessHelper";
            this.Text = "PrincessHelper";
            this.TopMost = true;
            this.Resize += new System.EventHandler(this.PrincessHelper_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox ShowResult_txt;
        private System.Windows.Forms.Button Input_btn;
        private System.Windows.Forms.TextBox NewMember_txt;
        private System.Windows.Forms.Label NewMember_lbl;
        private System.Windows.Forms.TextBox Hour_Role_txt;
        private System.Windows.Forms.Label Hour_Role_lbl;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

