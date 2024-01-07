namespace Biblio
{
    partial class SignUp
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
            label1 = new Label();
            button3 = new Button();
            pw = new TextBox();
            uname = new TextBox();
            label3 = new Label();
            label2 = new Label();
            em = new TextBox();
            label4 = new Label();
            cpw = new TextBox();
            label5 = new Label();
            lname = new TextBox();
            fname = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            bdate = new DateTimePicker();
            tel = new TextBox();
            label9 = new Label();
            addr = new TextBox();
            label10 = new Label();
            label11 = new Label();
            edate = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(353, 19);
            label1.Name = "label1";
            label1.Size = new Size(147, 68);
            label1.TabIndex = 1;
            label1.Text = "Sign-Up";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            button3.Location = new Point(383, 583);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 10;
            button3.Text = "Sign-Up";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // pw
            // 
            pw.Location = new Point(321, 478);
            pw.Name = "pw";
            pw.PasswordChar = '*';
            pw.Size = new Size(224, 27);
            pw.TabIndex = 9;
            // 
            // uname
            // 
            uname.Location = new Point(321, 120);
            uname.Name = "uname";
            uname.Size = new Size(224, 27);
            uname.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(227, 481);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 7;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(222, 123);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 6;
            label2.Text = "Username";
            // 
            // em
            // 
            em.Location = new Point(321, 297);
            em.Name = "em";
            em.Size = new Size(224, 27);
            em.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(240, 300);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 11;
            label4.Text = "E-mail";
            // 
            // cpw
            // 
            cpw.Location = new Point(321, 527);
            cpw.Name = "cpw";
            cpw.PasswordChar = '*';
            cpw.Size = new Size(224, 27);
            cpw.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(170, 534);
            label5.Name = "label5";
            label5.Size = new Size(127, 20);
            label5.TabIndex = 13;
            label5.Text = "Confirm Password";
            // 
            // lname
            // 
            lname.Location = new Point(321, 162);
            lname.Name = "lname";
            lname.Size = new Size(224, 27);
            lname.TabIndex = 15;
            // 
            // fname
            // 
            fname.Location = new Point(321, 205);
            fname.Name = "fname";
            fname.Size = new Size(224, 27);
            fname.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(250, 162);
            label6.Name = "label6";
            label6.Size = new Size(42, 20);
            label6.TabIndex = 19;
            label6.Text = "Nom";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(163, 254);
            label7.Name = "label7";
            label7.Size = new Size(129, 20);
            label7.TabIndex = 20;
            label7.Text = "Date de naissance";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(232, 205);
            label8.Name = "label8";
            label8.Size = new Size(60, 20);
            label8.TabIndex = 21;
            label8.Text = "Prénom";
            // 
            // bdate
            // 
            bdate.Location = new Point(321, 249);
            bdate.Name = "bdate";
            bdate.Size = new Size(224, 27);
            bdate.TabIndex = 22;
            // 
            // tel
            // 
            tel.Location = new Point(321, 390);
            tel.Name = "tel";
            tel.Size = new Size(224, 27);
            tel.TabIndex = 26;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(142, 393);
            label9.Name = "label9";
            label9.Size = new Size(155, 20);
            label9.TabIndex = 25;
            label9.Text = "Numéro de téléphone";
            // 
            // addr
            // 
            addr.Location = new Point(321, 341);
            addr.Name = "addr";
            addr.Size = new Size(224, 27);
            addr.TabIndex = 24;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(227, 344);
            label10.Name = "label10";
            label10.Size = new Size(61, 20);
            label10.TabIndex = 23;
            label10.Text = "Adresse";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(142, 437);
            label11.Name = "label11";
            label11.Size = new Size(138, 20);
            label11.TabIndex = 27;
            label11.Text = "Date d'emploiment";
            // 
            // edate
            // 
            edate.Location = new Point(321, 432);
            edate.Name = "edate";
            edate.Size = new Size(224, 27);
            edate.TabIndex = 28;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 643);
            Controls.Add(edate);
            Controls.Add(label11);
            Controls.Add(tel);
            Controls.Add(label9);
            Controls.Add(addr);
            Controls.Add(label10);
            Controls.Add(bdate);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(fname);
            Controls.Add(lname);
            Controls.Add(cpw);
            Controls.Add(label5);
            Controls.Add(em);
            Controls.Add(label4);
            Controls.Add(button3);
            Controls.Add(pw);
            Controls.Add(uname);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SignUp";
            Text = "Sign-up";
            Load += SignUp_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button3;
        private TextBox pw;
        private TextBox uname;
        private Label label3;
        private Label label2;
        private TextBox em;
        private Label label4;
        private TextBox cpw;
        private Label label5;
        private TextBox lname;
        private TextBox fname;
        private Label label6;
        private Label label7;
        private Label label8;
        private DateTimePicker bdate;
        private TextBox tel;
        private Label label9;
        private TextBox addr;
        private Label label10;
        private Label label11;
        private DateTimePicker edate;
    }
}