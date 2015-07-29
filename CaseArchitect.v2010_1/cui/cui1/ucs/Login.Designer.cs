namespace cui1.ucs
{
    partial class Login
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1name = new System.Windows.Forms.TextBox();
            this.textBox2pwd = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1cancel = new System.Windows.Forms.Button();
            this.button2registry = new System.Windows.Forms.Button();
            this.button3login = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 46);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // textBox1name
            // 
            this.textBox1name.Location = new System.Drawing.Point(88, 67);
            this.textBox1name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1name.Name = "textBox1name";
            this.textBox1name.Size = new System.Drawing.Size(129, 21);
            this.textBox1name.TabIndex = 1;
            this.textBox1name.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2pwd
            // 
            this.textBox2pwd.Location = new System.Drawing.Point(88, 87);
            this.textBox2pwd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2pwd.Name = "textBox2pwd";
            this.textBox2pwd.Size = new System.Drawing.Size(129, 21);
            this.textBox2pwd.TabIndex = 2;
            this.textBox2pwd.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(46, 114);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "保存登录消息";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1cancel
            // 
            this.button1cancel.Location = new System.Drawing.Point(46, 138);
            this.button1cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1cancel.Name = "button1cancel";
            this.button1cancel.Size = new System.Drawing.Size(56, 18);
            this.button1cancel.TabIndex = 4;
            this.button1cancel.Text = "取消";
            this.button1cancel.UseVisualStyleBackColor = true;
            // 
            // button2registry
            // 
            this.button2registry.Location = new System.Drawing.Point(106, 138);
            this.button2registry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2registry.Name = "button2registry";
            this.button2registry.Size = new System.Drawing.Size(56, 18);
            this.button2registry.TabIndex = 4;
            this.button2registry.Text = "注册";
            this.button2registry.UseVisualStyleBackColor = true;
            // 
            // button3login
            // 
            this.button3login.Location = new System.Drawing.Point(167, 138);
            this.button3login.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3login.Name = "button3login";
            this.button3login.Size = new System.Drawing.Size(56, 18);
            this.button3login.TabIndex = 4;
            this.button3login.Text = "登录";
            this.button3login.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3login);
            this.Controls.Add(this.button2registry);
            this.Controls.Add(this.button1cancel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox2pwd);
            this.Controls.Add(this.textBox1name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Login";
            this.Size = new System.Drawing.Size(262, 216);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox textBox1name;
        internal System.Windows.Forms.TextBox textBox2pwd;
        internal System.Windows.Forms.CheckBox checkBox1;
        internal System.Windows.Forms.Button button1cancel;
        internal System.Windows.Forms.Button button2registry;
        internal System.Windows.Forms.Button button3login;
    }
}
