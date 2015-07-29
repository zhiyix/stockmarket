namespace cui1.ucs
{
    partial class Registry
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1cfm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2pwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3repwd = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3repwd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2pwd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "baseinfo";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(16, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 191);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "detail";
            // 
            // button1cfm
            // 
            this.button1cfm.Location = new System.Drawing.Point(188, 376);
            this.button1cfm.Name = "button1cfm";
            this.button1cfm.Size = new System.Drawing.Size(75, 23);
            this.button1cfm.TabIndex = 1;
            this.button1cfm.Text = "confirm";
            this.button1cfm.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "name";
            // 
            // textBox1name
            // 
            this.textBox1name.Location = new System.Drawing.Point(91, 29);
            this.textBox1name.Name = "textBox1name";
            this.textBox1name.Size = new System.Drawing.Size(120, 21);
            this.textBox1name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "password";
            // 
            // textBox2pwd
            // 
            this.textBox2pwd.Location = new System.Drawing.Point(91, 56);
            this.textBox2pwd.Name = "textBox2pwd";
            this.textBox2pwd.Size = new System.Drawing.Size(120, 21);
            this.textBox2pwd.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "re-password";
            // 
            // textBox3repwd
            // 
            this.textBox3repwd.Location = new System.Drawing.Point(91, 83);
            this.textBox3repwd.Name = "textBox3repwd";
            this.textBox3repwd.Size = new System.Drawing.Size(120, 21);
            this.textBox3repwd.TabIndex = 1;
            // 
            // Registry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1cfm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Registry";
            this.Size = new System.Drawing.Size(285, 445);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox textBox3repwd;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox textBox2pwd;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox textBox1name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button button1cfm;
    }
}
