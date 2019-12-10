namespace Project2
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
            this.labelChoosePrez = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelInfoOption = new System.Windows.Forms.Label();
            this.listBoxInfoOptions = new System.Windows.Forms.ListBox();
            this.buttonGetInfo = new System.Windows.Forms.Button();
            this.buttonWriteInfo = new System.Windows.Forms.Button();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelVal = new System.Windows.Forms.Label();
            this.listBoxCatVal = new System.Windows.Forms.ListBox();
            this.buttonGetList = new System.Windows.Forms.Button();
            this.buttonWriteList = new System.Windows.Forms.Button();
            this.listBoxPresidents = new System.Windows.Forms.ListBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelChoosePrez
            // 
            this.labelChoosePrez.AutoSize = true;
            this.labelChoosePrez.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChoosePrez.Location = new System.Drawing.Point(60, 100);
            this.labelChoosePrez.Name = "labelChoosePrez";
            this.labelChoosePrez.Size = new System.Drawing.Size(184, 25);
            this.labelChoosePrez.TabIndex = 0;
            this.labelChoosePrez.Text = "Choose a President";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(400, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Find Information About Presidents";
            // 
            // labelInfoOption
            // 
            this.labelInfoOption.AutoSize = true;
            this.labelInfoOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfoOption.Location = new System.Drawing.Point(460, 100);
            this.labelInfoOption.Name = "labelInfoOption";
            this.labelInfoOption.Size = new System.Drawing.Size(167, 25);
            this.labelInfoOption.TabIndex = 3;
            this.labelInfoOption.Text = "Select info the get";
            // 
            // listBoxInfoOptions
            // 
            this.listBoxInfoOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxInfoOptions.FormattingEnabled = true;
            this.listBoxInfoOptions.ItemHeight = 25;
            this.listBoxInfoOptions.Location = new System.Drawing.Point(465, 128);
            this.listBoxInfoOptions.Name = "listBoxInfoOptions";
            this.listBoxInfoOptions.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxInfoOptions.Size = new System.Drawing.Size(300, 179);
            this.listBoxInfoOptions.TabIndex = 4;
            // 
            // buttonGetInfo
            // 
            this.buttonGetInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetInfo.Location = new System.Drawing.Point(860, 150);
            this.buttonGetInfo.Name = "buttonGetInfo";
            this.buttonGetInfo.Size = new System.Drawing.Size(150, 50);
            this.buttonGetInfo.TabIndex = 5;
            this.buttonGetInfo.Text = "Get Info";
            this.buttonGetInfo.UseVisualStyleBackColor = true;
            this.buttonGetInfo.Click += new System.EventHandler(this.buttonGetInfo_Click);
            // 
            // buttonWriteInfo
            // 
            this.buttonWriteInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWriteInfo.Location = new System.Drawing.Point(860, 225);
            this.buttonWriteInfo.Name = "buttonWriteInfo";
            this.buttonWriteInfo.Size = new System.Drawing.Size(150, 50);
            this.buttonWriteInfo.TabIndex = 6;
            this.buttonWriteInfo.Text = "Write Info";
            this.buttonWriteInfo.UseVisualStyleBackColor = true;
            this.buttonWriteInfo.Click += new System.EventHandler(this.buttonWriteInfo_Click);
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategory.Location = new System.Drawing.Point(60, 400);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(177, 25);
            this.labelCategory.TabIndex = 7;
            this.labelCategory.Text = "Choose a category";
            // 
            // labelVal
            // 
            this.labelVal.AutoSize = true;
            this.labelVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVal.Location = new System.Drawing.Point(460, 400);
            this.labelVal.Name = "labelVal";
            this.labelVal.Size = new System.Drawing.Size(135, 25);
            this.labelVal.TabIndex = 10;
            this.labelVal.Text = "Select a value";
            // 
            // listBoxCatVal
            // 
            this.listBoxCatVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxCatVal.FormattingEnabled = true;
            this.listBoxCatVal.ItemHeight = 25;
            this.listBoxCatVal.Location = new System.Drawing.Point(465, 428);
            this.listBoxCatVal.Name = "listBoxCatVal";
            this.listBoxCatVal.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxCatVal.Size = new System.Drawing.Size(300, 179);
            this.listBoxCatVal.TabIndex = 11;
            // 
            // buttonGetList
            // 
            this.buttonGetList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetList.Location = new System.Drawing.Point(860, 450);
            this.buttonGetList.Name = "buttonGetList";
            this.buttonGetList.Size = new System.Drawing.Size(150, 50);
            this.buttonGetList.TabIndex = 12;
            this.buttonGetList.Text = "Get List";
            this.buttonGetList.UseVisualStyleBackColor = true;
            this.buttonGetList.Click += new System.EventHandler(this.buttonGetList_Click);
            // 
            // buttonWriteList
            // 
            this.buttonWriteList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWriteList.Location = new System.Drawing.Point(860, 525);
            this.buttonWriteList.Name = "buttonWriteList";
            this.buttonWriteList.Size = new System.Drawing.Size(150, 50);
            this.buttonWriteList.TabIndex = 13;
            this.buttonWriteList.Text = "Write List";
            this.buttonWriteList.UseVisualStyleBackColor = true;
            this.buttonWriteList.Click += new System.EventHandler(this.buttonWriteList_Click);
            // 
            // listBoxPresidents
            // 
            this.listBoxPresidents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPresidents.FormattingEnabled = true;
            this.listBoxPresidents.ItemHeight = 25;
            this.listBoxPresidents.Location = new System.Drawing.Point(65, 128);
            this.listBoxPresidents.Name = "listBoxPresidents";
            this.listBoxPresidents.Size = new System.Drawing.Size(300, 179);
            this.listBoxPresidents.TabIndex = 14;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(65, 428);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(300, 33);
            this.comboBoxCategory.TabIndex = 15;
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategory_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.listBoxPresidents);
            this.Controls.Add(this.buttonWriteList);
            this.Controls.Add(this.buttonGetList);
            this.Controls.Add(this.listBoxCatVal);
            this.Controls.Add(this.labelVal);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.buttonWriteInfo);
            this.Controls.Add(this.buttonGetInfo);
            this.Controls.Add(this.listBoxInfoOptions);
            this.Controls.Add(this.labelInfoOption);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelChoosePrez);
            this.Name = "Form1";
            this.Text = "Project 2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChoosePrez;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelInfoOption;
        private System.Windows.Forms.ListBox listBoxInfoOptions;
        private System.Windows.Forms.Button buttonGetInfo;
        private System.Windows.Forms.Button buttonWriteInfo;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelVal;
        private System.Windows.Forms.ListBox listBoxCatVal;
        private System.Windows.Forms.Button buttonGetList;
        private System.Windows.Forms.Button buttonWriteList;
        private System.Windows.Forms.ListBox listBoxPresidents;
        private System.Windows.Forms.ComboBox comboBoxCategory;
    }
}

