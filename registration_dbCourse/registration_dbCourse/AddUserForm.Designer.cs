
namespace registration_dbCourse
{
    partial class AddUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserForm));
            this.log_TB1 = new System.Windows.Forms.TextBox();
            this.pass_TB2 = new System.Windows.Forms.TextBox();
            this.registr_BUT2 = new System.Windows.Forms.Button();
            this.back_BUT1 = new System.Windows.Forms.Button();
            this.exit_BUT3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // log_TB1
            // 
            this.log_TB1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.log_TB1.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.log_TB1.Location = new System.Drawing.Point(166, 67);
            this.log_TB1.Name = "log_TB1";
            this.log_TB1.Size = new System.Drawing.Size(210, 27);
            this.log_TB1.TabIndex = 0;
            // 
            // pass_TB2
            // 
            this.pass_TB2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pass_TB2.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.pass_TB2.Location = new System.Drawing.Point(166, 117);
            this.pass_TB2.Name = "pass_TB2";
            this.pass_TB2.Size = new System.Drawing.Size(210, 27);
            this.pass_TB2.TabIndex = 1;
            // 
            // registr_BUT2
            // 
            this.registr_BUT2.BackgroundImage = global::registration_dbCourse.Properties.Resources._RegistrBTN;
            this.registr_BUT2.Location = new System.Drawing.Point(182, 150);
            this.registr_BUT2.Name = "registr_BUT2";
            this.registr_BUT2.Size = new System.Drawing.Size(150, 50);
            this.registr_BUT2.TabIndex = 2;
            this.registr_BUT2.UseVisualStyleBackColor = true;
            this.registr_BUT2.Click += new System.EventHandler(this.registr_BUT2_Click);
            // 
            // back_BUT1
            // 
            this.back_BUT1.BackgroundImage = global::registration_dbCourse.Properties.Resources._Back;
            this.back_BUT1.Location = new System.Drawing.Point(20, 207);
            this.back_BUT1.Name = "back_BUT1";
            this.back_BUT1.Size = new System.Drawing.Size(103, 44);
            this.back_BUT1.TabIndex = 3;
            this.back_BUT1.UseVisualStyleBackColor = true;
            this.back_BUT1.Click += new System.EventHandler(this.back_BUT1_Click);
            // 
            // exit_BUT3
            // 
            this.exit_BUT3.BackgroundImage = global::registration_dbCourse.Properties.Resources._exitBTN1;
            this.exit_BUT3.Location = new System.Drawing.Point(385, 207);
            this.exit_BUT3.Name = "exit_BUT3";
            this.exit_BUT3.Size = new System.Drawing.Size(103, 44);
            this.exit_BUT3.TabIndex = 4;
            this.exit_BUT3.UseVisualStyleBackColor = true;
            this.exit_BUT3.Click += new System.EventHandler(this.exit_BUT3_Click);
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::registration_dbCourse.Properties.Resources._AddUser;
            this.ClientSize = new System.Drawing.Size(504, 267);
            this.ControlBox = false;
            this.Controls.Add(this.exit_BUT3);
            this.Controls.Add(this.back_BUT1);
            this.Controls.Add(this.registr_BUT2);
            this.Controls.Add(this.pass_TB2);
            this.Controls.Add(this.log_TB1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(520, 306);
            this.MinimumSize = new System.Drawing.Size(520, 306);
            this.Name = "AddUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox log_TB1;
        private System.Windows.Forms.TextBox pass_TB2;
        private System.Windows.Forms.Button registr_BUT2;
        private System.Windows.Forms.Button back_BUT1;
        private System.Windows.Forms.Button exit_BUT3;
    }
}