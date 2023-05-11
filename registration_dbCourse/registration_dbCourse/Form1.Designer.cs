
namespace registration_dbCourse
{
    partial class Start_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start_Form));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.exit_BUT3 = new System.Windows.Forms.Button();
            this.registr_BUT2 = new System.Windows.Forms.Button();
            this.entry_BUT1 = new System.Windows.Forms.Button();
            this.pass_TB2 = new System.Windows.Forms.TextBox();
            this.log_TB1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.exit_BUT4 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(621, 358);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = global::registration_dbCourse.Properties.Resources._Form1_norm;
            this.tabPage1.Controls.Add(this.exit_BUT3);
            this.tabPage1.Controls.Add(this.registr_BUT2);
            this.tabPage1.Controls.Add(this.entry_BUT1);
            this.tabPage1.Controls.Add(this.pass_TB2);
            this.tabPage1.Controls.Add(this.log_TB1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(613, 332);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Вход";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // exit_BUT3
            // 
            this.exit_BUT3.BackgroundImage = global::registration_dbCourse.Properties.Resources._exitBTN;
            this.exit_BUT3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exit_BUT3.Location = new System.Drawing.Point(501, 279);
            this.exit_BUT3.Name = "exit_BUT3";
            this.exit_BUT3.Size = new System.Drawing.Size(104, 45);
            this.exit_BUT3.TabIndex = 4;
            this.exit_BUT3.UseVisualStyleBackColor = true;
            this.exit_BUT3.Click += new System.EventHandler(this.exit_BUT3_Click);
            // 
            // registr_BUT2
            // 
            this.registr_BUT2.BackgroundImage = global::registration_dbCourse.Properties.Resources._RegistrBTN;
            this.registr_BUT2.Location = new System.Drawing.Point(309, 224);
            this.registr_BUT2.Name = "registr_BUT2";
            this.registr_BUT2.Size = new System.Drawing.Size(150, 50);
            this.registr_BUT2.TabIndex = 3;
            this.registr_BUT2.UseVisualStyleBackColor = true;
            this.registr_BUT2.Click += new System.EventHandler(this.registr_BUT2_Click);
            // 
            // entry_BUT1
            // 
            this.entry_BUT1.BackgroundImage = global::registration_dbCourse.Properties.Resources._enterBTN;
            this.entry_BUT1.Location = new System.Drawing.Point(153, 224);
            this.entry_BUT1.Name = "entry_BUT1";
            this.entry_BUT1.Size = new System.Drawing.Size(150, 50);
            this.entry_BUT1.TabIndex = 2;
            this.entry_BUT1.UseVisualStyleBackColor = true;
            this.entry_BUT1.Click += new System.EventHandler(this.entry_BUT1_Click);
            // 
            // pass_TB2
            // 
            this.pass_TB2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pass_TB2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pass_TB2.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.pass_TB2.Location = new System.Drawing.Point(249, 173);
            this.pass_TB2.Name = "pass_TB2";
            this.pass_TB2.Size = new System.Drawing.Size(210, 27);
            this.pass_TB2.TabIndex = 1;
            // 
            // log_TB1
            // 
            this.log_TB1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.log_TB1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.log_TB1.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.log_TB1.Location = new System.Drawing.Point(249, 123);
            this.log_TB1.Name = "log_TB1";
            this.log_TB1.Size = new System.Drawing.Size(210, 27);
            this.log_TB1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::registration_dbCourse.Properties.Resources._Form1_2_norm;
            this.tabPage2.Controls.Add(this.exit_BUT4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(613, 332);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "О программе";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // exit_BUT4
            // 
            this.exit_BUT4.BackColor = System.Drawing.Color.White;
            this.exit_BUT4.BackgroundImage = global::registration_dbCourse.Properties.Resources._exitBTN;
            this.exit_BUT4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exit_BUT4.Location = new System.Drawing.Point(501, 281);
            this.exit_BUT4.Name = "exit_BUT4";
            this.exit_BUT4.Size = new System.Drawing.Size(104, 45);
            this.exit_BUT4.TabIndex = 5;
            this.exit_BUT4.UseVisualStyleBackColor = false;
            this.exit_BUT4.Click += new System.EventHandler(this.exit_BUT4_Click);
            // 
            // Start_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(621, 359);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Start_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход";
            this.Load += new System.EventHandler(this.Start_Form_Load_1);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button entry_BUT1;
        private System.Windows.Forms.TextBox pass_TB2;
        private System.Windows.Forms.TextBox log_TB1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button exit_BUT3;
        private System.Windows.Forms.Button registr_BUT2;
        private System.Windows.Forms.Button exit_BUT4;
    }
}

