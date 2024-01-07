namespace Biblio
{
    partial class Manager
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
            tabControl1 = new TabControl();
            Employés = new TabPage();
            e_search = new TextBox();
            label29 = new Label();
            mod = new Button();
            del = new Button();
            edate = new DateTimePicker();
            label11 = new Label();
            tel = new TextBox();
            label9 = new Label();
            addr = new TextBox();
            label10 = new Label();
            bdate = new DateTimePicker();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            fname = new TextBox();
            lname = new TextBox();
            em = new TextBox();
            label4 = new Label();
            uname = new TextBox();
            label2 = new Label();
            Emp = new DataGridView();
            Adhérants = new TabPage();
            s_search = new TextBox();
            label19 = new Label();
            s_mod = new Button();
            s_del = new Button();
            s_bdate = new DateTimePicker();
            label1 = new Label();
            Sub = new DataGridView();
            s_tel = new TextBox();
            label3 = new Label();
            s_addr = new TextBox();
            label5 = new Label();
            label12 = new Label();
            label14 = new Label();
            s_fname = new TextBox();
            s_lname = new TextBox();
            s_em = new TextBox();
            label15 = new Label();
            s_uname = new TextBox();
            label16 = new Label();
            Documents = new TabPage();
            d_search = new TextBox();
            label30 = new Label();
            browse = new Button();
            label27 = new Label();
            pic = new PictureBox();
            pr = new TextBox();
            label22 = new Label();
            label21 = new Label();
            cat = new ComboBox();
            add = new Button();
            d_mod = new Button();
            d_del = new Button();
            Doc = new DataGridView();
            pdate = new DateTimePicker();
            label13 = new Label();
            desc = new TextBox();
            label17 = new Label();
            label18 = new Label();
            auth = new TextBox();
            tit = new TextBox();
            label20 = new Label();
            Réservations = new TabPage();
            doc_ = new CheckedListBox();
            adh = new ComboBox();
            r_add = new Button();
            r_search = new TextBox();
            label31 = new Label();
            ret_date = new DateTimePicker();
            r_mod = new Button();
            r_del = new Button();
            Res = new DataGridView();
            price = new TextBox();
            label23 = new Label();
            label24 = new Label();
            res_date = new DateTimePicker();
            label25 = new Label();
            label26 = new Label();
            label28 = new Label();
            Expo_Impo = new TabPage();
            button3 = new Button();
            exp_exc = new Button();
            imp_csv = new Button();
            exp_csv = new Button();
            textBox1 = new TextBox();
            label32 = new Label();
            Sub_ = new DataGridView();
            tabControl1.SuspendLayout();
            Employés.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Emp).BeginInit();
            Adhérants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Sub).BeginInit();
            Documents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Doc).BeginInit();
            Réservations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Res).BeginInit();
            Expo_Impo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Sub_).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Employés);
            tabControl1.Controls.Add(Adhérants);
            tabControl1.Controls.Add(Documents);
            tabControl1.Controls.Add(Réservations);
            tabControl1.Controls.Add(Expo_Impo);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1650, 559);
            tabControl1.TabIndex = 0;
            // 
            // Employés
            // 
            Employés.Controls.Add(e_search);
            Employés.Controls.Add(label29);
            Employés.Controls.Add(mod);
            Employés.Controls.Add(del);
            Employés.Controls.Add(edate);
            Employés.Controls.Add(label11);
            Employés.Controls.Add(tel);
            Employés.Controls.Add(label9);
            Employés.Controls.Add(addr);
            Employés.Controls.Add(label10);
            Employés.Controls.Add(bdate);
            Employés.Controls.Add(label8);
            Employés.Controls.Add(label7);
            Employés.Controls.Add(label6);
            Employés.Controls.Add(fname);
            Employés.Controls.Add(lname);
            Employés.Controls.Add(em);
            Employés.Controls.Add(label4);
            Employés.Controls.Add(uname);
            Employés.Controls.Add(label2);
            Employés.Controls.Add(Emp);
            Employés.Location = new Point(4, 29);
            Employés.Name = "Employés";
            Employés.Padding = new Padding(3);
            Employés.Size = new Size(1642, 526);
            Employés.TabIndex = 0;
            Employés.Text = "Employés";
            Employés.UseVisualStyleBackColor = true;
            // 
            // e_search
            // 
            e_search.Location = new Point(559, 22);
            e_search.Name = "e_search";
            e_search.Size = new Size(1077, 27);
            e_search.TabIndex = 52;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(460, 25);
            label29.Name = "label29";
            label29.Size = new Size(67, 20);
            label29.TabIndex = 51;
            label29.Text = "Chercher";
            // 
            // mod
            // 
            mod.Location = new Point(299, 448);
            mod.Name = "mod";
            mod.Size = new Size(94, 29);
            mod.TabIndex = 50;
            mod.Text = "Modifier";
            mod.UseVisualStyleBackColor = true;
            mod.Click += mod_Click;
            // 
            // del
            // 
            del.Location = new Point(114, 448);
            del.Name = "del";
            del.Size = new Size(94, 29);
            del.TabIndex = 49;
            del.Text = "Supprimer";
            del.UseVisualStyleBackColor = true;
            del.Click += del_Click;
            // 
            // edate
            // 
            edate.Location = new Point(200, 380);
            edate.Name = "edate";
            edate.Size = new Size(224, 27);
            edate.TabIndex = 48;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(38, 385);
            label11.Name = "label11";
            label11.Size = new Size(138, 20);
            label11.TabIndex = 47;
            label11.Text = "Date d'emploiment";
            // 
            // tel
            // 
            tel.Location = new Point(200, 338);
            tel.Name = "tel";
            tel.Size = new Size(224, 27);
            tel.TabIndex = 46;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(21, 341);
            label9.Name = "label9";
            label9.Size = new Size(155, 20);
            label9.TabIndex = 45;
            label9.Text = "Numéro de téléphone";
            // 
            // addr
            // 
            addr.Location = new Point(200, 289);
            addr.Name = "addr";
            addr.Size = new Size(224, 27);
            addr.TabIndex = 44;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(106, 292);
            label10.Name = "label10";
            label10.Size = new Size(61, 20);
            label10.TabIndex = 43;
            label10.Text = "Adresse";
            // 
            // bdate
            // 
            bdate.Location = new Point(200, 197);
            bdate.Name = "bdate";
            bdate.Size = new Size(224, 27);
            bdate.TabIndex = 42;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(111, 153);
            label8.Name = "label8";
            label8.Size = new Size(60, 20);
            label8.TabIndex = 41;
            label8.Text = "Prénom";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(42, 202);
            label7.Name = "label7";
            label7.Size = new Size(129, 20);
            label7.TabIndex = 40;
            label7.Text = "Date de naissance";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(129, 110);
            label6.Name = "label6";
            label6.Size = new Size(42, 20);
            label6.TabIndex = 39;
            label6.Text = "Nom";
            // 
            // fname
            // 
            fname.Location = new Point(200, 153);
            fname.Name = "fname";
            fname.Size = new Size(224, 27);
            fname.TabIndex = 38;
            // 
            // lname
            // 
            lname.Location = new Point(200, 110);
            lname.Name = "lname";
            lname.Size = new Size(224, 27);
            lname.TabIndex = 37;
            // 
            // em
            // 
            em.Location = new Point(200, 245);
            em.Name = "em";
            em.Size = new Size(224, 27);
            em.TabIndex = 34;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(119, 248);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 33;
            label4.Text = "E-mail";
            // 
            // uname
            // 
            uname.Location = new Point(200, 68);
            uname.Name = "uname";
            uname.Size = new Size(224, 27);
            uname.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(101, 71);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 29;
            label2.Text = "Username";
            // 
            // Emp
            // 
            Emp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Emp.Location = new Point(462, 68);
            Emp.Name = "Emp";
            Emp.RowHeadersWidth = 51;
            Emp.Size = new Size(1174, 424);
            Emp.TabIndex = 0;
            // 
            // Adhérants
            // 
            Adhérants.Controls.Add(s_search);
            Adhérants.Controls.Add(label19);
            Adhérants.Controls.Add(s_mod);
            Adhérants.Controls.Add(s_del);
            Adhérants.Controls.Add(s_bdate);
            Adhérants.Controls.Add(label1);
            Adhérants.Controls.Add(Sub);
            Adhérants.Controls.Add(s_tel);
            Adhérants.Controls.Add(label3);
            Adhérants.Controls.Add(s_addr);
            Adhérants.Controls.Add(label5);
            Adhérants.Controls.Add(label12);
            Adhérants.Controls.Add(label14);
            Adhérants.Controls.Add(s_fname);
            Adhérants.Controls.Add(s_lname);
            Adhérants.Controls.Add(s_em);
            Adhérants.Controls.Add(label15);
            Adhérants.Controls.Add(s_uname);
            Adhérants.Controls.Add(label16);
            Adhérants.Location = new Point(4, 29);
            Adhérants.Name = "Adhérants";
            Adhérants.Padding = new Padding(3);
            Adhérants.Size = new Size(1642, 526);
            Adhérants.TabIndex = 1;
            Adhérants.Text = "Adhérants";
            Adhérants.UseVisualStyleBackColor = true;
            // 
            // s_search
            // 
            s_search.Location = new Point(559, 24);
            s_search.Name = "s_search";
            s_search.Size = new Size(938, 27);
            s_search.TabIndex = 71;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(460, 27);
            label19.Name = "label19";
            label19.Size = new Size(67, 20);
            label19.TabIndex = 70;
            label19.Text = "Chercher";
            // 
            // s_mod
            // 
            s_mod.Location = new Point(286, 425);
            s_mod.Name = "s_mod";
            s_mod.Size = new Size(94, 29);
            s_mod.TabIndex = 69;
            s_mod.Text = "Modifier";
            s_mod.UseVisualStyleBackColor = true;
            s_mod.Click += s_mod_Click;
            // 
            // s_del
            // 
            s_del.Location = new Point(101, 425);
            s_del.Name = "s_del";
            s_del.Size = new Size(94, 29);
            s_del.TabIndex = 68;
            s_del.Text = "Supprimer";
            s_del.UseVisualStyleBackColor = true;
            s_del.Click += s_del_Click;
            // 
            // s_bdate
            // 
            s_bdate.Location = new Point(198, 201);
            s_bdate.Name = "s_bdate";
            s_bdate.Size = new Size(224, 27);
            s_bdate.TabIndex = 67;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 206);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 66;
            label1.Text = "Date de naissance";
            // 
            // Sub
            // 
            Sub.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Sub.Location = new Point(462, 72);
            Sub.Name = "Sub";
            Sub.RowHeadersWidth = 51;
            Sub.Size = new Size(1035, 427);
            Sub.TabIndex = 65;
            // 
            // s_tel
            // 
            s_tel.Location = new Point(198, 337);
            s_tel.Name = "s_tel";
            s_tel.Size = new Size(224, 27);
            s_tel.TabIndex = 62;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 340);
            label3.Name = "label3";
            label3.Size = new Size(155, 20);
            label3.TabIndex = 61;
            label3.Text = "Numéro de téléphone";
            // 
            // s_addr
            // 
            s_addr.Location = new Point(198, 248);
            s_addr.Name = "s_addr";
            s_addr.Size = new Size(224, 27);
            s_addr.TabIndex = 60;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(104, 251);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 59;
            label5.Text = "Adresse";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(109, 157);
            label12.Name = "label12";
            label12.Size = new Size(60, 20);
            label12.TabIndex = 57;
            label12.Text = "Prénom";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(127, 114);
            label14.Name = "label14";
            label14.Size = new Size(42, 20);
            label14.TabIndex = 55;
            label14.Text = "Nom";
            // 
            // s_fname
            // 
            s_fname.Location = new Point(198, 157);
            s_fname.Name = "s_fname";
            s_fname.Size = new Size(224, 27);
            s_fname.TabIndex = 54;
            // 
            // s_lname
            // 
            s_lname.Location = new Point(198, 114);
            s_lname.Name = "s_lname";
            s_lname.Size = new Size(224, 27);
            s_lname.TabIndex = 53;
            // 
            // s_em
            // 
            s_em.Location = new Point(198, 293);
            s_em.Name = "s_em";
            s_em.Size = new Size(224, 27);
            s_em.TabIndex = 52;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(117, 296);
            label15.Name = "label15";
            label15.Size = new Size(52, 20);
            label15.TabIndex = 51;
            label15.Text = "E-mail";
            // 
            // s_uname
            // 
            s_uname.Location = new Point(198, 72);
            s_uname.Name = "s_uname";
            s_uname.Size = new Size(224, 27);
            s_uname.TabIndex = 50;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(99, 75);
            label16.Name = "label16";
            label16.Size = new Size(75, 20);
            label16.TabIndex = 49;
            label16.Text = "Username";
            // 
            // Documents
            // 
            Documents.Controls.Add(d_search);
            Documents.Controls.Add(label30);
            Documents.Controls.Add(browse);
            Documents.Controls.Add(label27);
            Documents.Controls.Add(pic);
            Documents.Controls.Add(pr);
            Documents.Controls.Add(label22);
            Documents.Controls.Add(label21);
            Documents.Controls.Add(cat);
            Documents.Controls.Add(add);
            Documents.Controls.Add(d_mod);
            Documents.Controls.Add(d_del);
            Documents.Controls.Add(Doc);
            Documents.Controls.Add(pdate);
            Documents.Controls.Add(label13);
            Documents.Controls.Add(desc);
            Documents.Controls.Add(label17);
            Documents.Controls.Add(label18);
            Documents.Controls.Add(auth);
            Documents.Controls.Add(tit);
            Documents.Controls.Add(label20);
            Documents.Location = new Point(4, 29);
            Documents.Name = "Documents";
            Documents.Padding = new Padding(3);
            Documents.Size = new Size(1642, 526);
            Documents.TabIndex = 2;
            Documents.Text = "Documents";
            Documents.UseVisualStyleBackColor = true;
            // 
            // d_search
            // 
            d_search.Location = new Point(107, 6);
            d_search.Name = "d_search";
            d_search.Size = new Size(349, 27);
            d_search.TabIndex = 91;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(8, 9);
            label30.Name = "label30";
            label30.Size = new Size(67, 20);
            label30.TabIndex = 90;
            label30.Text = "Chercher";
            // 
            // browse
            // 
            browse.Location = new Point(1073, 379);
            browse.Name = "browse";
            browse.Size = new Size(94, 29);
            browse.TabIndex = 89;
            browse.Text = "Parcourir";
            browse.UseVisualStyleBackColor = true;
            browse.Click += browse_Click;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(650, 383);
            label27.Name = "label27";
            label27.Size = new Size(51, 20);
            label27.TabIndex = 87;
            label27.Text = "Image";
            // 
            // pic
            // 
            pic.Location = new Point(749, 314);
            pic.Name = "pic";
            pic.Size = new Size(276, 188);
            pic.TabIndex = 86;
            pic.TabStop = false;
            // 
            // pr
            // 
            pr.Location = new Point(181, 281);
            pr.Name = "pr";
            pr.Size = new Size(224, 27);
            pr.TabIndex = 85;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(139, 284);
            label22.Name = "label22";
            label22.Size = new Size(33, 20);
            label22.TabIndex = 84;
            label22.Text = "Prix";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(119, 103);
            label21.Name = "label21";
            label21.Size = new Size(53, 20);
            label21.TabIndex = 83;
            label21.Text = "Auteur";
            // 
            // cat
            // 
            cat.FormattingEnabled = true;
            cat.Location = new Point(181, 138);
            cat.Name = "cat";
            cat.Size = new Size(224, 28);
            cat.TabIndex = 82;
            // 
            // add
            // 
            add.Location = new Point(66, 383);
            add.Name = "add";
            add.Size = new Size(94, 29);
            add.TabIndex = 81;
            add.Text = "Ajouter";
            add.UseVisualStyleBackColor = true;
            add.Click += add_Click;
            // 
            // d_mod
            // 
            d_mod.Location = new Point(212, 383);
            d_mod.Name = "d_mod";
            d_mod.Size = new Size(94, 29);
            d_mod.TabIndex = 80;
            d_mod.Text = "Modifier";
            d_mod.UseVisualStyleBackColor = true;
            d_mod.Click += d_mod_Click;
            // 
            // d_del
            // 
            d_del.Location = new Point(362, 383);
            d_del.Name = "d_del";
            d_del.Size = new Size(94, 29);
            d_del.TabIndex = 79;
            d_del.Text = "Supprimer";
            d_del.UseVisualStyleBackColor = true;
            d_del.Click += d_del_Click;
            // 
            // Doc
            // 
            Doc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Doc.Location = new Point(462, 6);
            Doc.Name = "Doc";
            Doc.RowHeadersWidth = 51;
            Doc.Size = new Size(1174, 302);
            Doc.TabIndex = 78;
            // 
            // pdate
            // 
            pdate.Location = new Point(181, 187);
            pdate.Name = "pdate";
            pdate.Size = new Size(224, 27);
            pdate.TabIndex = 77;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(31, 192);
            label13.Name = "label13";
            label13.Size = new Size(141, 20);
            label13.TabIndex = 76;
            label13.Text = "Date de publication";
            // 
            // desc
            // 
            desc.Location = new Point(181, 234);
            desc.Name = "desc";
            desc.Size = new Size(224, 27);
            desc.TabIndex = 75;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(87, 237);
            label17.Name = "label17";
            label17.Size = new Size(85, 20);
            label17.TabIndex = 74;
            label17.Text = "Description";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(98, 146);
            label18.Name = "label18";
            label18.Size = new Size(74, 20);
            label18.TabIndex = 73;
            label18.Text = "Catégorie";
            // 
            // auth
            // 
            auth.Location = new Point(181, 100);
            auth.Name = "auth";
            auth.Size = new Size(224, 27);
            auth.TabIndex = 70;
            // 
            // tit
            // 
            tit.Location = new Point(181, 58);
            tit.Name = "tit";
            tit.Size = new Size(224, 27);
            tit.TabIndex = 69;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(133, 61);
            label20.Name = "label20";
            label20.Size = new Size(39, 20);
            label20.TabIndex = 68;
            label20.Text = "Titre";
            // 
            // Réservations
            // 
            Réservations.Controls.Add(doc_);
            Réservations.Controls.Add(adh);
            Réservations.Controls.Add(r_add);
            Réservations.Controls.Add(r_search);
            Réservations.Controls.Add(label31);
            Réservations.Controls.Add(ret_date);
            Réservations.Controls.Add(r_mod);
            Réservations.Controls.Add(r_del);
            Réservations.Controls.Add(Res);
            Réservations.Controls.Add(price);
            Réservations.Controls.Add(label23);
            Réservations.Controls.Add(label24);
            Réservations.Controls.Add(res_date);
            Réservations.Controls.Add(label25);
            Réservations.Controls.Add(label26);
            Réservations.Controls.Add(label28);
            Réservations.Location = new Point(4, 29);
            Réservations.Name = "Réservations";
            Réservations.Padding = new Padding(3);
            Réservations.Size = new Size(1642, 526);
            Réservations.TabIndex = 3;
            Réservations.Text = "Réservations";
            Réservations.UseVisualStyleBackColor = true;
            // 
            // doc_
            // 
            doc_.FormattingEnabled = true;
            doc_.Location = new Point(171, 140);
            doc_.Name = "doc_";
            doc_.Size = new Size(224, 114);
            doc_.TabIndex = 106;
            // 
            // adh
            // 
            adh.FormattingEnabled = true;
            adh.Location = new Point(171, 92);
            adh.Name = "adh";
            adh.Size = new Size(224, 28);
            adh.TabIndex = 105;
            // 
            // r_add
            // 
            r_add.Location = new Point(46, 448);
            r_add.Name = "r_add";
            r_add.Size = new Size(94, 29);
            r_add.TabIndex = 104;
            r_add.Text = "Ajouter";
            r_add.UseVisualStyleBackColor = true;
            r_add.Click += r_add_Click;
            // 
            // r_search
            // 
            r_search.Location = new Point(559, 30);
            r_search.Name = "r_search";
            r_search.Size = new Size(703, 27);
            r_search.TabIndex = 103;
            r_search.TextChanged += r_search_TextChanged;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(460, 33);
            label31.Name = "label31";
            label31.Size = new Size(67, 20);
            label31.TabIndex = 102;
            label31.Text = "Chercher";
            // 
            // ret_date
            // 
            ret_date.Location = new Point(171, 350);
            ret_date.Name = "ret_date";
            ret_date.Size = new Size(224, 27);
            ret_date.TabIndex = 101;
            // 
            // r_mod
            // 
            r_mod.Location = new Point(171, 448);
            r_mod.Name = "r_mod";
            r_mod.Size = new Size(94, 29);
            r_mod.TabIndex = 100;
            r_mod.Text = "Modifier";
            r_mod.UseVisualStyleBackColor = true;
            r_mod.Click += r_mod_Click;
            // 
            // r_del
            // 
            r_del.Location = new Point(301, 448);
            r_del.Name = "r_del";
            r_del.Size = new Size(94, 29);
            r_del.TabIndex = 99;
            r_del.Text = "Supprimer";
            r_del.UseVisualStyleBackColor = true;
            r_del.Click += r_del_Click;
            // 
            // Res
            // 
            Res.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Res.Location = new Point(462, 89);
            Res.Name = "Res";
            Res.RowHeadersWidth = 51;
            Res.Size = new Size(800, 388);
            Res.TabIndex = 98;
            // 
            // price
            // 
            price.Location = new Point(171, 399);
            price.Name = "price";
            price.Size = new Size(224, 27);
            price.TabIndex = 97;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(95, 402);
            label23.Name = "label23";
            label23.Size = new Size(65, 20);
            label23.TabIndex = 96;
            label23.Text = "Montant";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(84, 148);
            label24.Name = "label24";
            label24.Size = new Size(78, 20);
            label24.TabIndex = 95;
            label24.Text = "Document";
            // 
            // res_date
            // 
            res_date.Location = new Point(171, 305);
            res_date.Name = "res_date";
            res_date.Size = new Size(224, 27);
            res_date.TabIndex = 93;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(21, 310);
            label25.Name = "label25";
            label25.Size = new Size(139, 20);
            label25.TabIndex = 92;
            label25.Text = "Date de réservation";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(56, 355);
            label26.Name = "label26";
            label26.Size = new Size(106, 20);
            label26.TabIndex = 90;
            label26.Text = "Date de retour";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(92, 92);
            label28.Name = "label28";
            label28.Size = new Size(70, 20);
            label28.TabIndex = 86;
            label28.Text = "Adhérant";
            // 
            // Expo_Impo
            // 
            Expo_Impo.Controls.Add(button3);
            Expo_Impo.Controls.Add(exp_exc);
            Expo_Impo.Controls.Add(imp_csv);
            Expo_Impo.Controls.Add(exp_csv);
            Expo_Impo.Controls.Add(textBox1);
            Expo_Impo.Controls.Add(label32);
            Expo_Impo.Controls.Add(Sub_);
            Expo_Impo.Location = new Point(4, 29);
            Expo_Impo.Name = "Expo_Impo";
            Expo_Impo.Padding = new Padding(3);
            Expo_Impo.Size = new Size(1642, 526);
            Expo_Impo.TabIndex = 4;
            Expo_Impo.Text = "Expo/Impo";
            Expo_Impo.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(242, 309);
            button3.Name = "button3";
            button3.Size = new Size(135, 29);
            button3.TabIndex = 78;
            button3.Text = "Importer un Excel";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // exp_exc
            // 
            exp_exc.Location = new Point(72, 309);
            exp_exc.Name = "exp_exc";
            exp_exc.Size = new Size(135, 29);
            exp_exc.TabIndex = 77;
            exp_exc.Text = "Exporter en Excel";
            exp_exc.UseVisualStyleBackColor = true;
            exp_exc.Click += exp_exc_Click;
            // 
            // imp_csv
            // 
            imp_csv.Location = new Point(242, 152);
            imp_csv.Name = "imp_csv";
            imp_csv.Size = new Size(135, 29);
            imp_csv.TabIndex = 76;
            imp_csv.Text = "Importer un CSV";
            imp_csv.UseVisualStyleBackColor = true;
            imp_csv.Click += imp_csv_Click;
            // 
            // exp_csv
            // 
            exp_csv.Location = new Point(72, 152);
            exp_csv.Name = "exp_csv";
            exp_csv.Size = new Size(135, 29);
            exp_csv.TabIndex = 75;
            exp_csv.Text = "Exporetr en CSV";
            exp_csv.UseVisualStyleBackColor = true;
            exp_csv.Click += exp_csv_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(559, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(945, 27);
            textBox1.TabIndex = 74;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(460, 9);
            label32.Name = "label32";
            label32.Size = new Size(67, 20);
            label32.TabIndex = 73;
            label32.Text = "Chercher";
            // 
            // Sub_
            // 
            Sub_.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Sub_.Location = new Point(462, 54);
            Sub_.Name = "Sub_";
            Sub_.RowHeadersWidth = 51;
            Sub_.Size = new Size(1042, 427);
            Sub_.TabIndex = 72;
            // 
            // Manager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1667, 574);
            Controls.Add(tabControl1);
            Name = "Manager";
            Text = "Manager";
            tabControl1.ResumeLayout(false);
            Employés.ResumeLayout(false);
            Employés.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Emp).EndInit();
            Adhérants.ResumeLayout(false);
            Adhérants.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Sub).EndInit();
            Documents.ResumeLayout(false);
            Documents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic).EndInit();
            ((System.ComponentModel.ISupportInitialize)Doc).EndInit();
            Réservations.ResumeLayout(false);
            Réservations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Res).EndInit();
            Expo_Impo.ResumeLayout(false);
            Expo_Impo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Sub_).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Employés;
        private TabPage Adhérants;
        private TabPage Documents;
        private TabPage Réservations;
        private TabPage Expo_Impo;
        private DataGridView Emp;
        private DateTimePicker edate;
        private Label label11;
        private TextBox tel;
        private Label label9;
        private TextBox addr;
        private Label label10;
        private DateTimePicker bdate;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox fname;
        private TextBox lname;
        private TextBox em;
        private Label label4;
        private TextBox uname;
        private Label label2;
        private Button del;
        private Button mod;
        private DataGridView Sub;
        private TextBox s_tel;
        private Label label3;
        private TextBox s_addr;
        private Label label5;
        private Label label12;
        private Label label14;
        private TextBox s_fname;
        private TextBox s_lname;
        private TextBox s_em;
        private Label label15;
        private TextBox s_uname;
        private Label label16;
        private DateTimePicker s_bdate;
        private Label label1;
        private Button s_mod;
        private Button s_del;
        private Button add;
        private Button d_mod;
        private Button d_del;
        private DataGridView Doc;
        private DateTimePicker pdate;
        private Label label13;
        private TextBox desc;
        private Label label17;
        private Label label18;
        private Label label19;
        private TextBox textBox2;
        private TextBox auth;
        private TextBox tit;
        private Label label20;
        private ComboBox cat;
        private Label label21;
        private TextBox pr;
        private Label label22;
        private TextBox price;
        private Label label23;
        private Label label24;
        private DateTimePicker res_date;
        private Label label25;
        private Label label26;
        private Label label28;
        private Button r_mod;
        private Button r_del;
        private DataGridView Res;
        private DateTimePicker ret_date;
        private Button browse;
        private Label label27;
        private PictureBox pic;
        private TextBox e_search;
        private Label label29;
        private TextBox s_search;
        private TextBox d_search;
        private Label label30;
        private TextBox r_search;
        private Label label31;
        private Button button3;
        private Button exp_exc;
        private Button imp_csv;
        private Button exp_csv;
        private TextBox textBox1;
        private Label label32;
        private DataGridView Sub_;
        private Button r_add;
        private ComboBox adh;
        private CheckedListBox doc_;
    }
}