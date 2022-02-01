namespace FaraBotModerator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Main = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Reaction = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.UseWaitCursor = true;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.UseWaitCursor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.UseWaitCursor = true;
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.Main);
            this.tabControl1.Controls.Add(this.Reaction);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.UseWaitCursor = true;
            // 
            // Main
            // 
            resources.ApplyResources(this.Main, "Main");
            this.Main.Controls.Add(this.textBox3);
            this.Main.Controls.Add(this.textBox2);
            this.Main.Controls.Add(this.textBox1);
            this.Main.Controls.Add(this.label3);
            this.Main.Controls.Add(this.label2);
            this.Main.Controls.Add(this.label1);
            this.Main.Name = "Main";
            this.Main.UseVisualStyleBackColor = true;
            this.Main.UseWaitCursor = true;
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.UseWaitCursor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.UseWaitCursor = true;
            // 
            // Reaction
            // 
            resources.ApplyResources(this.Reaction, "Reaction");
            this.Reaction.Name = "Reaction";
            this.Reaction.UseVisualStyleBackColor = true;
            this.Reaction.UseWaitCursor = true;
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            this.textBox3.UseWaitCursor = true;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.UseWaitCursor = true;
            this.tabControl1.ResumeLayout(false);
            this.Main.ResumeLayout(false);
            this.Main.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox textBox3;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.TextBox textBox2;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Main;
        private System.Windows.Forms.TabPage Reaction;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}